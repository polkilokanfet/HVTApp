using System.Collections.Generic;
using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;

namespace HVTApp.Model.Services
{
    public interface IGetProductService
    {
        //Task<Product> GetProductAsync(Product originProduct = null);

        /// <summary>
        /// Выбор продукта
        /// </summary>
        /// <param name="originProduct"></param>
        /// <returns></returns>
        Product GetProduct(Product originProduct = null);

        Product GetProduct(IEnumerable<Parameter> requiredParameters);

        /// <summary>
        /// Вернуть сохраненный продукт или сохранить новый
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Product GetSavedOrSaveProduct(Product product);

        /// <summary>
        /// Выбор ремонтного комплекта
        /// </summary>
        /// <param name="originProduct"></param>
        /// <returns></returns>
        Product GetKit(Product originProduct = null);

        /// <summary>
        /// Выбор ремонтного комплекта
        /// </summary>
        /// <param name="designDepartment">КБ, которому пренадлежат эти комплекты</param>
        /// <param name="originProduct"></param>
        /// <returns></returns>
        Product GetKit(DesignDepartment designDepartment, Product originProduct = null);

        /// <summary>
        /// Выбор блока продукта
        /// </summary>
        /// <param name="originProductBlock">Предварительно выбранный блок продукта</param>
        /// <param name="requiredParameters">Обязательные параметры выбираемого блока продукта</param>
        /// <returns></returns>
        ProductBlock GetProductBlock(ProductBlock originProductBlock = null, IEnumerable<Parameter> requiredParameters = null);

        /// <summary>
        /// Выбор блока продукта
        /// </summary>
        /// <param name="parametersContainers"></param>
        /// <param name="originProductBlock"></param>
        /// <returns></returns>
        ProductBlock GetProductBlock(IEnumerable<IParametersContainer> parametersContainers, ProductBlock originProductBlock = null);

        IEnumerable<ProductBlock> GenerateBlocks();

        /// <summary>
        /// Замена одного продукта другим
        /// </summary>
        /// <param name="productToReplace">Заменяемый продукт</param>
        /// <param name="product"></param>
        /// <returns></returns>
        bool ReplaceProduct(Product productToReplace, Product product);
    }
}
