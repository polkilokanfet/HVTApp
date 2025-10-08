using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Services.GetProductService.Kits;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace HVTApp.Services.GetProductService
{
    public class GetProductServiceWpf : IGetProductService
    {
        private IUnityContainer Container { get; }
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly GetService _getService;

        private List<Product> _products = new List<Product>();

        public GetProductServiceWpf(IUnityContainer container)
        {
            Container = container;
            _unitOfWork = container.Resolve<IUnitOfWork>();
            _getService = new GetService(_unitOfWork, container.Resolve<ILastUpdateMomentService>(), container.Resolve<IEventAggregator>());
        }

        #region GetProduct

        public Product GetProduct(Product originProduct = null)
        {
            var selector = new ProductSelector(_getService, selectedProduct: originProduct);
            return this.GetProduct(selector, originProduct);
        }

        public Product GetProduct(IEnumerable<Parameter> requiredParameters)
        {
            var selector = new ProductSelector(_getService, requiredParameters);
            return this.GetProduct(selector);
        }

        private Product GetProduct(ProductSelector productSelector, Product originProduct = null)
        {
            try
            {
                //предварительно выбранный продукт
                var selectedProduct = originProduct?.ChangeUnitOfWork(_unitOfWork);

                var owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                var window = new SelectProductWindow { DataContext = productSelector, Owner = owner };
                window.ShowDialog();

                //если необходимо выбрать комплект
                if (window.ShouldSelectComplect)
                    return Container.Resolve<IGetProductService>().GetKit(originProduct);

                //выходим, если пользователь отменил выбор продукта.
                if (window.DialogResult.HasValue == false || 
                    window.DialogResult.Value == false) 
                    return originProduct;

                var result = productSelector.SelectedProduct;
                productSelector.Dispose();

                return this.GetSavedOrSaveProduct(result);
            }
            catch (DependencyParameterException e)
            {
                Container.Resolve<IMessageService>().Message("Exception", e.Message);
                return this.GetProduct(originProduct: null);
            }
            catch (Exception e)
            {
                Container.Resolve<IMessageService>().Message("Exception", e.Message);
                return this.GetProduct(originProduct: null);
            }
        }

        public Product GetSavedOrSaveProduct(Product product)
        {
            var result = this.CheckReloadCheckAgain(product);
            if (result != null)
                return result;

            this.SubstitutionBlocksAndProducts(
                product, 
                _unitOfWork.Repository<Product>().GetAll(),
                _unitOfWork.Repository<ProductBlock>().GetAll());

            //если выбранного продукта нет в базе
            return this.SaveProduct(product);
        }

        private Product CheckReloadCheckAgain(Product product)
        {
            var existsProduct = _products.SingleOrDefault(p => p.Equals(product));
            if (existsProduct != null)
                return existsProduct;

            //загрузка актуальных продуктов
            this._products = _unitOfWork.Repository<Product>().GetAll();

            return _products.SingleOrDefault(p => p.Equals(product));
        }

        #endregion

        //private Product GetOrSaveProduct(Product product)
        //{
        //    var result = this.CheckReloadCheckAgain(product);
        //    if (result != null)
        //        return result;

        //    //если выбранного продукта нет в базе
        //    return this.SaveProduct(product);
        //}

        private Product SaveProduct(Product product)
        {
            //если выбранного продукта нет в базе
            var operationResult = _unitOfWork.SaveEntity(product);

            if (operationResult.OperationCompletedSuccessfully == false)
                throw new Exception("ќшибка при сохранении нового продукта в базу данных.", operationResult.Exception);

            Container.Resolve<IEventAggregator>().GetEvent<AfterSaveProductEvent>().Publish(product);

            _products.Add(product);

            return product;
        }


        #region GetKit

        public Product GetKit(Product originProduct = null)
        {
            var kitsViewModel = Container.Resolve<KitsViewModel>();
            kitsViewModel.Load();
            return GetKitBase(kitsViewModel, originProduct);
        }

        public Product GetKit(DesignDepartment designDepartment, Product originProduct = null)
        {
            var kitsViewModel = Container.Resolve<KitsViewModel>();
            kitsViewModel.Load(designDepartment);
            return GetKitBase(kitsViewModel, originProduct);
        }

        private Product GetKitBase(KitsViewModel kitsViewModel, Product originProduct = null)
        {
            kitsViewModel.ShowDialog();

            return kitsViewModel.IsSelected
                ? kitsViewModel.SelectedItem.Product
                : originProduct;
        }

        #endregion

        /// <summary>
        /// «амена новых блоков и продуктов на сохранЄнные
        /// </summary>
        /// <param name="product"></param>
        /// <param name="savedProducts">—охраненные продукты</param>
        /// <param name="savedBlocks"></param>
        private void SubstitutionBlocksAndProducts(
            Product product, 
            ICollection<Product> savedProducts, 
            ICollection<ProductBlock> savedBlocks)
        {
            //замена блоков на сохранЄнные
            var block = savedBlocks.SingleOrDefault(productBlock => product.ProductBlock.Equals(productBlock));
            if (block != null)
                product.ProductBlock = block;
            else
                savedBlocks.Add(product.ProductBlock);

            //дл€ каждого зависиммого продукта
            foreach (var dependentProduct in product.DependentProducts)
            {
                var savedProduct = savedProducts.SingleOrDefault(product1 => product1.Equals(dependentProduct.Product));
                //если продукт есть в сохраненных, мен€ем его
                if (savedProduct != null)
                    dependentProduct.Product = savedProduct;
                else
                    savedProducts.Add(dependentProduct.Product);

                SubstitutionBlocksAndProducts(dependentProduct.Product, savedProducts, savedBlocks);
            }
        }

        #region GetProductBlock

        private ProductBlock GetProductBlockBase(ProductBlockSelector selector, ProductBlock originProductBlock)
        {
            var owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            var window = new SelectProductBlockWindow { DataContext = selector, Owner = owner };
            window.ShowDialog();

            //выходим, если пользователь отменил выбор блока продукта.
            if (window.DialogResult.HasValue == false ||
                window.DialogResult.Value == false)
                return originProductBlock;

            return _getService.SaveProductBlock(selector.SelectedBlock);
        }

        public ProductBlock GetProductBlock(
            ProductBlock originProductBlock = null, 
            IEnumerable<Parameter> requiredParameters = null)
        {
            var selector = this._getService.GetProductBlockSelector(true, originProductBlock, requiredParameters);
            return this.GetProductBlockBase(selector, originProductBlock);
        }

        public ProductBlock GetProductBlock(
            IEnumerable<IParametersContainer> parametersContainers, 
            ProductBlock originProductBlock = null)
        {
            var selector = this._getService.GetProductBlockSelector(true, originProductBlock, containers: parametersContainers);
            return this.GetProductBlockBase(selector, originProductBlock);
        }

        #endregion


        public IEnumerable<ProductBlock> GenerateBlocks()
        {
            var parameters = this.Container.Resolve<IUnitOfWork>().Repository<Parameter>().GetAll();
            var nodes = PathNodesGenerator.GetPathNodes(parameters);
            return PathNodesGenerator.GetAllBlocks(nodes).Distinct();
        }

        public bool ReplaceProduct(Product productToReplace, Product product)
        {
            using (var unitOfWork = Container.Resolve<IUnitOfWork>())
            {
                productToReplace = unitOfWork.Repository<Product>().GetById(productToReplace.Id);
                product = unitOfWork.Repository<Product>().GetById(product.Id);


                unitOfWork.Repository<SalesUnit>()
                    .Find(salesUnit => salesUnit.Product.Id == productToReplace.Id)
                    .ForEach(salesUnit => salesUnit.ProductId = product.Id);

                unitOfWork.Repository<OfferUnit>()
                    .Find(offerUnit => offerUnit.Product.Id == productToReplace.Id)
                    .ForEach(offerUnit => offerUnit.ProductId = product.Id);

                unitOfWork.Repository<ProductIncluded>()
                    .Find(productIncluded => productIncluded.Product.Id == productToReplace.Id)
                    .ForEach(productIncluded => productIncluded.ProductId = product.Id);

                productToReplace.DesignDepartmentsKits.ForEach(department => department.Kits.ReAddById(product));


                unitOfWork.SaveChanges();
            }
            return true;
        }
    }
}