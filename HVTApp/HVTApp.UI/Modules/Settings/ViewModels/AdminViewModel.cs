using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Serialization;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces.Services;
using HVTApp.Infrastructure.Interfaces.Services.SelectService;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;
using HVTApp.Model;
using HVTApp.Model.Services;
using HVTApp.UI.Commands;
using HVTApp.UI.PriceEngineering;
using HVTApp.UI.PriceEngineering.PriceEngineeringTasksContainer;
using HVTApp.UI.PriceEngineering.Tce.Second;
using HVTApp.UI.TechnicalRequrementsTasksModule.Wrapper;
using Microsoft.Practices.ObjectBuilder2;

namespace HVTApp.UI.Modules.Settings.ViewModels
{
    public class AdminViewModel
    {
        public DelegateLogCommand Command1 { get; }
        public DelegateLogCommand Command2 { get; }
        public DelegateLogCommand Command3 { get; }
        public DelegateLogCommand Command4 { get; }
        public DelegateLogCommand Command5 { get; }

        public AdminViewModel(IUnityContainer container)
        {
            Command1 = new DelegateLogCommand(
                () =>
                {
                    //try
                    //{
                    //    _container.Resolve<IEmailService>().SendMail("kosolapov.ag@gmail.com", "SubjTest", "BodyTest");
                    //    _container.Resolve<IEmailService>().SendMail("kosolapov.ep@mail.ru", "SubjTest", "BodyTest");
                    //    _container.Resolve<IMessageService>().Message("Send letter", "Success!");
                    //}
                    //catch (Exception e)
                    //{
                    //    _container.Resolve<IHvtAppLogger>().LogError(e.PrintAllExceptions(), e);
                    //    _container.Resolve<IMessageService>().Message(e.GetType().ToString(), e.PrintAllExceptions());
                    //}

                    var sb = new StringBuilder();

                    using (var unitOfWork = container.Resolve<IUnitOfWork>())
                    {
                        //var productsAll = unitOfWork.Repository<Product>().GetAll();

                        //var productGroups = productsAll
                        //    .GroupBy(x => x)
                        //    .Where(x => x.Count() > 1)
                        //    .ToList();

                        //sb.AppendLine("   Products");
                        //foreach (var productsGroup in productGroups)
                        //{
                        //    var productOk = productsGroup.Single(x => x.ProductBlock.StructureCostNumber != null);
                        //    var productRemove = productsGroup.Single(x => x.ProductBlock.StructureCostNumber is null);
                            
                        //    sb.AppendLine(productRemove.ToString());

                        //    foreach (var productDependent in unitOfWork.Repository<ProductDependent>().Find(x => x.Product.Equals(productRemove)))
                        //        productDependent.Product = productOk;

                        //    unitOfWork.Repository<Product>().Delete(productRemove);
                        //}
                        //unitOfWork.SaveChanges();
                        //container.Resolve<IMessageService>().Message(sb.ToString());


                        //sb.AppendLine("   Blocks");
                        var blocks = unitOfWork.Repository<ProductBlock>().GetAll();

                        var blocksGroups = blocks
                            .GroupBy(x => x)
                            .Where(x => x.Count() > 1)
                            .ToList();

                        foreach (var blockGroup in blocksGroups)
                        {
                            var productBlock = blockGroup.Single(x => x.StructureCostNumber is null);
                            sb.AppendLine($"- block {productBlock}");

                            foreach (var product in unitOfWork.Repository<Product>().Find(x => x.ProductBlock != null && x.ProductBlock.Id == productBlock.Id))
                            {
                                sb.AppendLine($"- product {product}");
                                unitOfWork.Repository<Product>().Delete(product);
                            }

                            unitOfWork.Repository<ProductBlock>().Delete(productBlock);
                        }

                        unitOfWork.SaveChanges();
                    }

                    container.Resolve<IMessageService>().Message(sb.ToString());

                    //Clipboard.SetText(sb.ToString());
                });

            Command2 = new DelegateLogCommand(() =>
            {
                var folderPath = container.Resolve<IGetFilePaths>().GetFolderPath();
                var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
                var gr = files.GroupBy(Path.GetFileName).Where(x => x.Count() > 1);
                StringBuilder sb = new StringBuilder();
                foreach (var g in gr)
                {
                    sb.AppendLine($"file name: {g.Key}");
                    foreach (var s in g)
                    {
                        sb.AppendLine($"    {s}");
                    }

                    sb.AppendLine("");
                }
                container.Resolve<IMessageService>().Message("", sb.ToString());
            });

            Command3 = new DelegateLogCommand(() =>
            {
                var getProductService = container.Resolve<IGetProductService>();

                Product product = null;

                while (true)
                {
                    product = getProductService.GetProduct(product);
                }
            });

            Command4 = new DelegateLogCommand(() =>
            {
                var designDepartments = container.Resolve<IUnitOfWork>().Repository<DesignDepartment>()
                    .GetAll();
                var department = container.Resolve<ISelectService>().SelectItem(designDepartments);

                var getProductService = container.Resolve<IGetProductService>();

                ProductBlock productBlock = null;
                do
                {
                    productBlock = getProductService.GetProductBlock(productBlock, department.ParameterSets.First().Parameters);
                } while (productBlock != null);
            });

            Command5 = new DelegateLogCommand(() =>
            {
                var designDepartments = container.Resolve<IUnitOfWork>().Repository<DesignDepartment>()
                    .GetAll();
                var department = container.Resolve<ISelectService>().SelectItem(designDepartments);

                var getProductService = container.Resolve<IGetProductService>();

                ProductBlock productBlock = null;
                do
                {
                    productBlock = getProductService.GetProductBlock(department.ParameterSetsAddedBlocks, productBlock);
                } while (productBlock != null);
            });
        }
    }
}