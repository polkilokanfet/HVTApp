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
        private Bank Bank { get; }

        public ProductBlockSelector BlockSelector { get; }

        /// <summary>
        /// Селекторы дочерних продуктов
        /// </summary>
        public ObservableCollection<ProductSelector> ProductSelectors { get; } = new ObservableCollection<ProductSelector>();

        public int Amount { get; }
        public bool HasDependentProducts => ProductSelectors.Any();

        private IEnumerable<ProductDependent> ProductDependents
        {
            get
            {
                //берем продукты, выбранные в селекторе
                var dps = ProductSelectors.Select(x => x.SelectedProduct);
                //находим повторяющиеся (группируем).
                var gdps = dps.GroupBy(product => product, new ProductComparer());
                //генерируем зависимые продукты
                foreach (var gdp in gdps)
                {
                    yield return new ProductDependent {Product = gdp.Key, Amount = gdp.Count()};
                }
            } 
        }

        public Product SelectedProduct =>
            new Product
            {
                ProductBlock = BlockSelector.SelectedBlock,
                DependentProducts = this.ProductDependents.ToList(),
            };

        public ProductSelector(Bank bank, IEnumerable<Parameter> parameters, Product selectedProduct = null, int amount = 1)
        {
            throw new NotImplementedException();
            //if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            //Bank = bank;
            //Amount = amount;

            ////создаем селектор блока
            //BlockSelector = new ProductBlockSelector(parameters, Bank, selectedProduct?.ProductBlock);
            ////подписываемся на событие его изменения
            //BlockSelector.SelectedBlockChanged += selector =>
            //{
            //    RefreshProductSelectors();
            //    SelectedProductChanged?.Invoke();
            //    RaisePropertyChanged(nameof(SelectedProduct));
            //};

            ////удаление/добавление селекторов дочерних продуктов
            //ProductSelectors.CollectionChanged += (sender, args) =>
            //{
            //    args.NewItems?.Cast<ProductSelector>().ForEach(x => x.SelectedProductChanged += OnChildProductChanged);
            //    args.OldItems?.Cast<ProductSelector>().ForEach(x => x.SelectedProductChanged -= OnChildProductChanged);
            //};

            //if (selectedProduct == null)
            //{
            //    //поиск селектора, содержащего базовые параметры
            //    var parameterSelector = BlockSelector.ParameterSelectors.Single(x => x.ParametersFlaged.All(p => p.Parameter.IsOrigin));
            //    //выбор параметра
            //    parameterSelector.SelectedParameterFlaged = parameterSelector.ParametersFlaged.First();
            //}
            //else
            //{
            //    foreach (var kvp in GetDictionaryOfMatching(selectedProduct))
            //    {
            //        if (Equals(kvp.Value, default(IEnumerable<Product>))) continue;

            //        foreach (var product in kvp.Value)
            //        {
            //            //редактируем список параметров
            //            var usefullParameters = bank.Parameters.GetUsefull(kvp.Key);
            //            var productSelector = new ProductSelector(bank, usefullParameters, product);
            //            ProductSelectors.Add(productSelector);
            //        }
            //    }
            //}
        }

        private void RefreshProductSelectors()
        {
            //упорядочиваем селектры продуктов по уменьшению количества параметров в блоке
            var productSelectors = ProductSelectors.OrderByDescending(x => x.SelectedProduct.ProductBlock.Parameters.Count).ToList();

            //загружаем связи к дочерним продуктам, упорядоченные по количеству параметров, зависимого продукта
            var childProductsRelations = Bank
                .GetActualRelationsToChildProducts(SelectedProduct)
                .OrderBy(x => x.ChildProductParameters.Count)
                .ToList();

            var relationsDictionary = new Dictionary<ProductRelation, int>();
            foreach (var actualProductRelation in childProductsRelations)
            {
                relationsDictionary.Add(actualProductRelation, actualProductRelation.ChildProductsAmount);
            }

            //удаление неактуальных селекторов и чистка связей
            foreach (var productSelector in productSelectors.ToList())
            {
                //ищем связь, которая соответствует селектору
                var relation = childProductsRelations.FirstOrDefault(x => x.ChildProductParameters.AllContainsIn(productSelector.BlockSelector.SelectedBlock.Parameters));

                //если не находим - сносим ее
                if (relation == null)
                {
                    ProductSelectors.Remove(productSelector);
                    productSelector.Dispose();
                }
                //если находим - корректируем связь и удаляем этот селектор из поиска
                else
                {
                    productSelectors.Remove(productSelector);

                    relationsDictionary[relation] -= productSelector.Amount;
                    if (relationsDictionary[relation] == 0)
                    {
                        childProductsRelations.Remove(relation);
                    }
                }
            }

            //добавление новых актуальных селекторов
            foreach (var productRelation in childProductsRelations)
            {
                for (int i = 0; i < relationsDictionary[productRelation]; i++)
                {
                    //новый селектор с усеченными под связь параметрами
                    var productSelector = new ProductSelector(Bank, Bank.Parameters.GetUsefull(productRelation));
                    ProductSelectors.Add(productSelector);
                }
            }

            RaisePropertyChanged(nameof(HasDependentProducts));
        }

        /// <summary>
        /// Реакция на изменение дочернего продукта
        /// </summary>
        private void OnChildProductChanged()
        {
            RaisePropertyChanged(nameof(SelectedProduct));
        }

        /// <summary>
        /// Поиск соответствий между дочерними продуктами и связями.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private Dictionary<ProductRelation, IEnumerable<Product>> GetDictionaryOfMatching(Product product)
        {
            var result = new Dictionary<ProductRelation, IEnumerable<Product>>();
            //получаем актуальные для выбранных параметров связи
            var actualProductRelations = Bank.GetActualRelationsToChildProducts(product);
            actualProductRelations.ForEach(x => result.Add(x, default(IEnumerable<Product>)));

            //составляем список дочерних продуктов
            var dependentProducts = new List<Product>();
            foreach (var dependentProduct in product.DependentProducts)
            {
                for (int i = 0; i < dependentProduct.Amount; i++)
                {
                    dependentProducts.Add(dependentProduct.Product);
                }
            }

            //составляем словарь соответствий
            while (dependentProducts.Any())
            {
                var dependentProduct = dependentProducts.First();
                //возможно такой зависимый продукт уже добавлен
                //ищем ключ, список дочерних параметров которого полностью содержится в списке параметров дочернего блока и он еще не полный (количество дочерних продуктов)
                var node = result.FirstOrDefault(x => x.Key.ChildProductParameters.AllContainsIn(dependentProduct.ProductBlock.Parameters) && 
                                                     (x.Value == null || x.Value.Count() < x.Key.ChildProductsAmount));
                if (!Equals(node, default(KeyValuePair<ProductRelation, IEnumerable<Product>>)))
                {
                    //добавляем дочерний продукт в словарь
                    if(result[node.Key] == null)
                        result[node.Key] = new List<Product>();
                    ((List<Product>)result[node.Key]).Add(dependentProduct);
                    
                    //исключаем его из дальнейшего поиска соответствий
                    dependentProducts.Remove(dependentProduct);
                    continue;
                }


                node = result.FirstOrDefault(x => x.Key.ChildProductParameters.AllContainsIn(dependentProduct.ProductBlock.Parameters));

                if (!Equals(node, default(KeyValuePair<ProductRelation, IEnumerable<Product>>)))
                {
                    dependentProducts.Add(result[node.Key].Last());
                    ((List<Product>)result[node.Key]).Add(dependentProduct);
                    dependentProducts.Remove(dependentProduct);
                    continue;
                }

                throw new DependencyParameterException("Не найдена подходящая зависимость для продукта");
            }

            return result;
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

    public class DependencyParameterException : Exception
    {
        public DependencyParameterException(string s) : base(s)
        {
        }
    }
}