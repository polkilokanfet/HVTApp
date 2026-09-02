using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using HVTApp.Views;
using System.Windows;
using EventServiceClient2;
using HVTApp.DataAccess;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces.Services;
using HVTApp.Infrastructure.Interfaces.Services.DialogService;
using HVTApp.Infrastructure.Interfaces.Services.EventService;
using HVTApp.Infrastructure.Interfaces.Services.SelectService;
using HVTApp.Infrastructure.Prism;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.Events.EventServiceEvents;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Modules.BaseEntities;
using HVTApp.Modules.BookRegistration;
using HVTApp.Modules.Director;
using HVTApp.Modules.DirectumLite;
using HVTApp.Modules.Messenger;
using HVTApp.Modules.PlanAndEconomy;
using HVTApp.Modules.PriceMaking;
using HVTApp.Modules.Products;
using HVTApp.Modules.Reports;
using HVTApp.Modules.Settings;
using HVTApp.Modules.Sales;
using HVTApp.Modules.SupplyModule;
using HVTApp.RegionAdapters;
using HVTApp.Services.AllowStartService;
using HVTApp.Services.GetProductService;
using HVTApp.Services.WpfAuthenticationService;
using HVTApp.Services.DialogService;
using HVTApp.Services.EmailService;
using HVTApp.Services.FileManagerService;
using HVTApp.Services.GetCostsFromExcelFileService;
using HVTApp.Services.GetFilePathsService;
using HVTApp.Services.JsonService;
using HVTApp.Services.MessageService;
using HVTApp.Services.MessagesOutlookService;
using HVTApp.Services.NewProductService;
using HVTApp.Services.PrintService;
using HVTApp.Services.ProductDesignationService;
using HVTApp.Services.SelectService;
using HVTApp.Services.ShippingService;
using HVTApp.Services.UpdateDetailsService;
using HVTApp.UI;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Unity;
using NotificationsFromDataBaseService;
using NotificationsMainService;
using NotificationsReportsService;
using NotificationsService;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using PriceService = HVTApp.Services.PriceService1.PriceService;

namespace HVTApp
{
    internal class Bootstrapper : UnityBootstrapper
    {
        private List<ModuleInfo> _modules;
        private readonly SplashScreenWindow _splashScreenWindow = new SplashScreenWindow();

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    var catalog = new ModuleCatalog();

        //    catalog.AddModule(typeof(UiModule));

        //    //AddModuleByRole(catalog, typeof(DirectorModule));
        //    //AddModuleByRole(catalog, typeof(SalesModule));
        //    //AddModuleByRole(catalog, typeof(PlanAndEconomyModule));
        //    //AddModuleByRole(catalog, typeof(PriceMakingModule));
        //    //AddModuleByRole(catalog, typeof(SupplyModule));
        //    //AddModuleByRole(catalog, typeof(ProductsModule));
        //    //AddModuleByRole(catalog, typeof(BookRegistrationModule));
        //    //AddModuleByRole(catalog, typeof(ReportsModule));

        //    ////catalog.AddModule(typeof(MessengerModule));
        //    //catalog.AddModule(typeof(BaseEntitiesModule));
        //    //catalog.AddModule(typeof(SettingsModule));
        //    //AddModuleByRole(catalog, typeof(DirectumLiteModule));

        //    //_modules = catalog.Modules.ToList();

        //    return catalog;
        //}

        protected void CreateModuleCatalog2(IModuleCatalog catalog1)
        {
            var catalog = (ModuleCatalog)catalog1;
            catalog.AddModule(typeof(UiModule));

            AddModuleByRole(catalog, typeof(DirectorModule));
            AddModuleByRole(catalog, typeof(SalesModule));
            AddModuleByRole(catalog, typeof(PlanAndEconomyModule));
            AddModuleByRole(catalog, typeof(PriceMakingModule));
            AddModuleByRole(catalog, typeof(SupplyModule));
            AddModuleByRole(catalog, typeof(ProductsModule));
            AddModuleByRole(catalog, typeof(BookRegistrationModule));
            AddModuleByRole(catalog, typeof(ReportsModule));

            //catalog.AddModule(typeof(MessengerModule));
            catalog.AddModule(typeof(BaseEntitiesModule));
            catalog.AddModule(typeof(SettingsModule));
            AddModuleByRole(catalog, typeof(DirectumLiteModule));

            _modules = catalog.Modules.ToList();
        }


        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IHvtAppLogger, HvtAppLogger2>(new ContainerControlledLifetimeManager());
            
            Container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            Container.RegisterType<DbContext, HvtAppContext>();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IAuthenticationService, AuthenticationService>();
            Container.RegisterType<ISelectService, SelectServiceWpf>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IMessageService, MessageServiceWpf>();
            Container.RegisterType<IEmailService, MailKitService>();
            Container.RegisterType<IAllowStartService, AllowStartAppService>();
            Container.RegisterType<IMessagesOutlookService, MessagesOutlookService1>();
            Container.RegisterType<IPopupNotificationsService, HVTApp.Services.PopupNotificationsService1.PopupNotificationsService>();

            Container.RegisterType<IUpdateDetailsService, UpdateDetailsServiceWpf>(new ContainerControlledLifetimeManager());

            Container.RegisterInstance(typeof(IDialogService), new DialogService((Window)Shell));
            Container.RegisterType<IGetProductService, GetProductServiceWpf>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INewProductService, NewProductServiceWpf>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IPrintOfferService, PrintOfferService>();
            Container.RegisterType<IPrintContract, PrintContractService>();
            Container.RegisterType<IPrintProductService, PrintProductService>();
            Container.RegisterType<IPrintSupervisionLetterService, PrintSupervisionLetterService>();
            Container.RegisterType<IPrintBlankLetterService, PrintBlankLetterService>();
            Container.RegisterType<IPrintNoticeOfCompletionOfProductionService, PrintNoticeOfCompletionOfProductionService>();
            Container.RegisterType<IPrintPriceEngineering, PrintPriceEngineeringService>();
            Container.RegisterType<IPrintPriceCalculationInformationCardService, PrintPriceCalculationInformationCardService>();
            Container.RegisterType<IProductDesignationService, ProductDesignator>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IPriceService, PriceService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IShippingService, ShippService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IFileManagerService, FileManagerService1>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IFilesStorageService, FilesStorageService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IJsonService, ServiceJson>();
            Container.RegisterType<IGetInformationFromExcelFileService, GetInformationFromExcelFileService1>();
            Container.RegisterType<IGetFilePaths, GetFilePathsService1>();

            Container.RegisterType<IEventServiceClient, EventServiceClient>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISendNotificationThroughApp, EventServiceClient>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INotificationsReportService, NotificationsReportService>();
            Container.RegisterType<INotificationServiceClient, HVTApp.NotificationService1.NotificationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INotificationMainService, NotificationMainService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INotificationFromDataBaseService, NotificationFromDataBaseService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INotificationGeneratorService, NotificationGeneratorService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INotificationTextService, NotificationTextService>(new ContainerControlledLifetimeManager());

            Container.RegisterType<INotificationUnitWatcher, NotificationUnitWatcher>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IMessenger, Messenger>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IModelsStore, ModelsStore>(new ContainerControlledLifetimeManager());
            //Container.RegisterInstance(typeof(IModelsStore), new ModelsStore(Container));

            Container.RegisterType<ILastUpdateMomentService, LastUpdateMomentService>(new ContainerControlledLifetimeManager());

            //костыли
            var user = this.Container.Resolve<IAuthenticationService>().GetAuthenticationUser();
            GlobalAppProperties.User = user ?? throw new NoUserException();

            _splashScreenWindow.Show();

            this.CreateModuleCatalog2(this.ModuleCatalog);
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(XamOutlookBar), Container.Resolve<XamOutlookBarRegionAdapter>());
            mappings.RegisterMapping(typeof(XamRibbon), Container.Resolve<XamRibbonRegionAdapter>());
            return mappings;
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(XamRibbonRegionBehavior.BehaviorKey, typeof(XamRibbonRegionBehavior));
            //behaviors.AddIfMissing(typeof(DisposeClosedViewsBehavior).FullName, typeof(DisposeClosedViewsBehavior));
            return behaviors;
        }

        protected override DependencyObject CreateShell()
        {
            var mainWindow = Container.Resolve<MainWindow>();
            Application.Current.MainWindow = mainWindow;
            //Завершить приложение при закрытии главного окна.
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            return mainWindow;
        }

        private readonly List<Type> _initializedModules = new List<Type>();
        public event Action AllModulesAreInitialized;
        public event Action<double> ModuleIsInitialized;

        protected override void InitializeShell()
        {
            SetGlobalAppProperties();

            if (Container.Resolve<IAllowStartService>().AllowStart() == false)
            {
                Application.Current.Shutdown();
            }

            //#region IEventServiceClient

            ////старт клиентской части сервиса синхронизации
            //#if DEBUG
            //if (false)
            //#endif
            //{ }
            //#endregion

            Container.Resolve<INotificationServiceClient>().StartAsync().Await();
            Container.Resolve<INotificationMainService>().Start();

            Container.Resolve<IEventAggregator>().GetEvent<ModuleIsInitializedEvent>().Subscribe(moduleType =>
            {
                _initializedModules.Add(moduleType);

                ModuleIsInitialized?.Invoke((double)_initializedModules.Count / _modules.Count);

                if (_modules.Select(moduleInfo => moduleInfo.ModuleName).AllContainsIn(_initializedModules.Select(type => type.Name)))
                {
                    AllModulesAreInitialized?.Invoke();
                    Application.Current.MainWindow.Show();
                    _splashScreenWindow.Close();
                }
            });
        }

        /// <summary>
        /// Установка общих опций для всех (наша компания, стандартный срок изготовления и т.д.)
        /// </summary>
        /// <returns></returns>
        private void SetGlobalAppProperties()
        {
            //репозиторий с опциями
            var repository = Container.Resolve<IUnitOfWork>().Repository<GlobalProperties>();
            //назначение актуальных опций (последние по дате)
            GlobalAppProperties.Actual = repository.GetAll().OrderBy(globalProperties => globalProperties.Date).Last();
            
            GlobalAppProperties.ProductDesignationService = Container.Resolve<IProductDesignationService>();
            GlobalAppProperties.ShippingService = Container.Resolve<IShippingService>();
            GlobalAppProperties.PriceService = Container.Resolve<IPriceService>();
            GlobalAppProperties.HvtAppLogger = Container.Resolve<IHvtAppLogger>();
            GlobalAppProperties.MessageService = Container.Resolve<IMessageService>();
        }

        /// <summary>
        /// Добавление модулей на основе ролей.
        /// </summary>
        /// <param name="catalog">Каталог</param>
        /// <param name="moduleType">Тип модуля</param>
        private void AddModuleByRole(ModuleCatalog catalog, Type moduleType)
        {
            var attr = moduleType.GetCustomAttribute<ModuleAccessAttribute>();
            if (attr != null && attr.Roles.Contains(GlobalAppProperties.User.RoleCurrent))
            {
                catalog.AddModule(moduleType);
            }
        }
    }

    //internal static class PrH
    //{
    //    public static void AddModule(this IModuleCatalog catalog, Type moduleType)
    //    {
    //        catalog.AddModule(new ModuleInfo(moduleType.ToString(), moduleType.ToString()));
    //    }
    //}
}
