using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ProductSelector : BindableBase, IDisposable
    {
        private readonly GetService _getService;

        public ProductBlockSelector BlockSelector { get; }

        public IReadOnlyCollection<Parameter> RequiredParameters { get; }

        /// <summary>
        /// —електоры дочерних продуктов
        /// </summary>
        public ObservableCollection<ProductSelector> ProductSelectors { get; } = new ObservableCollection<ProductSelector>();

        public int Amount { get; }
        public bool HasDependentProducts => ProductSelectors.Any();

        private IEnumerable<ProductDependent> ProductDependents => 
            ProductSelectors.Select(x => new ProductDependent { Amount = x.Amount, Product = x.SelectedProduct });

        public Product SelectedProduct =>
            new Product
            {
                ProductBlock = BlockSelector.SelectedBlock,
                DependentProducts = this.ProductDependents.ToList()
            };

        public ProductSelector(
            GetService getService,
            IEnumerable<Parameter> requiredParameters = null,
            Product selectedProduct = null, 
            int amount = 1)
        {
            _getService = getService;
            RequiredParameters = requiredParameters?.ToReadOnlyCollection();
            Amount = amount;

            //создаем селектор блока
            BlockSelector = RequiredParameters is null
                ? ProductBlockSelector.GetSelector(_getService, selectedProduct?.ProductBlock)
                : ProductBlockSelector.GetSelector(_getService, RequiredParameters, selectedProduct?.ProductBlock);

            //подписываемс€ на событие его изменени€
            BlockSelector.SelectedBlockChanged += selector =>
            {
                RefreshProductSelectors();
                SelectedProductChanged?.Invoke();
                RaisePropertyChanged(nameof(SelectedProduct));
            };

            //удаление/добавление селекторов дочерних продуктов
            ProductSelectors.CollectionChanged += (sender, args) =>
            {
                args.NewItems?.Cast<ProductSelector>().ForEach(selector => selector.SelectedProductChanged += OnChildProductChanged);
                args.OldItems?.Cast<ProductSelector>().ForEach(selector =>
                {
                    selector.SelectedProductChanged -= OnChildProductChanged;
                    selector.Dispose();
                });
            };

            if (selectedProduct == null)
            {
                RefreshProductSelectors();
            }
            else
            {
                //получаем актуальные дл€ выбранных параметров св€зи
                var relations = getService.GetActualRelationsToChildProducts(selectedProduct).ToList();

                foreach (var dependentProduct in selectedProduct.DependentProducts)
                {
                    var relation = relations
                        .FirstOrDefault(productRelation =>
                            productRelation.ChildProductsAmount == dependentProduct.Amount &&
                            productRelation.ChildProductParameters.AllContainsInById(dependentProduct.Product.ProductBlock.Parameters));
                    if (relation == null)
                        throw new Exception($"Ќе найдено соответствующей св€зи дл€ зависимого продукта <{dependentProduct}>");
                    relations.Remove(relation);
                    var productSelector = new ProductSelector(_getService, relation.ChildProductParameters, dependentProduct.Product, dependentProduct.Amount);
                    ProductSelectors.Add(productSelector);
                }

                if (relations.Any())
                    throw new Exception($"Ќе найдено зависимого продукт под св€зи <{relations.Select(x => x.Name).ToStringEnum()}>");
            }
        }

        private void RefreshProductSelectors()
        {
            //получаем актуальные дл€ выбранных параметров св€зи
            var relations = _getService.GetActualRelationsToChildProducts(this.SelectedProduct).ToList();

            //удаление неактуальных селекторов и чистка св€зей
            foreach (var productSelector in this.ProductSelectors.ToList())
            {
                var relation = relations.FirstOrDefault(productRelation => 
                    productRelation.ChildProductsAmount == productSelector.Amount && 
                    productRelation.ChildProductParameters.MembersAreSameById(productSelector.RequiredParameters));
                if (relation == null)
                {
                    this.ProductSelectors.Remove(productSelector);
                    continue;
                }

                relations.Remove(relation);
            }

            //добавление новых актуальных селекторов
            foreach (var relation in relations)
            {
                var productSelector = new ProductSelector(_getService, relation.ChildProductParameters, amount:relation.ChildProductsAmount);
                this.ProductSelectors.Add(productSelector);
            }

            RaisePropertyChanged(nameof(HasDependentProducts));
        }

        /// <summary>
        /// –еакци€ на изменение дочернего продукта
        /// </summary>
        private void OnChildProductChanged()
        {
            RaisePropertyChanged(nameof(SelectedProduct));
        }

        #region events

        public event Action SelectedProductChanged;

        #endregion

        public void Dispose()
        {
            BlockSelector?.Dispose();
            ProductSelectors.ForEach(productSelector => productSelector.Dispose());
        }
    }
}