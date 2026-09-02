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
using Prism.Mvvm;

namespace HVTApp.UI.Modules.Settings.ViewModels
{
    public class AdminViewModel : BindableBase
    {
        private string _result;
        public DelegateLogCommand Command1 { get; }
        public DelegateLogCommand Command2 { get; }
        public DelegateLogCommand Command3 { get; }
        public DelegateLogCommand Command4 { get; }
        public DelegateLogCommand Command5 { get; }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

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

                    ////var sb = new StringBuilder();

                    ////using (var unitOfWork = container.Resolve<IUnitOfWork>())
                    ////{
                    ////    var tasks = unitOfWork.Repository<PriceEngineeringTask>().Find(task => task.Amount == 0);
                    ////    tasks.ForEach(task => task.Amount = 1);
                    ////    unitOfWork.SaveChanges();
                    ////}

                    ////Result = sb.ToString();
                    ////container.Resolve<IMessageService>().Message(sb.ToString());

                    //Clipboard.SetText(sb.ToString());

                    container.Resolve<INotificationServiceClient>().SendNotificationToHub("ttt").Await();
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