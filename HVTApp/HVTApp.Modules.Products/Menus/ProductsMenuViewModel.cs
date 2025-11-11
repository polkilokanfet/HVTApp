using HVTApp.Infrastructure;
using HVTApp.Model;
using HVTApp.UI.EngineeringDepartmentTasksQueue.Views;
using HVTApp.UI.Modules.Products.LaborHours;
using HVTApp.UI.Modules.Products.Parameters;
using HVTApp.UI.Modules.Products.StructureCostsNumbers;
using HVTApp.UI.Modules.Products.Views;
using HVTApp.UI.Modules.Reports.Reference;
using HVTApp.UI.PriceEngineering;
using HVTApp.UI.PriceEngineering.Statistics;
using HVTApp.UI.PriceEngineering.View;
using HVTApp.UI.Views;

namespace HVTApp.Modules.Products.Menus
{
    public class ProductsMenuViewModel : BaseMenuViewModel
    {
        protected override void GenerateMenu()
        {
            if (GlobalAppProperties.User.RoleCurrent == Role.Admin)
            {
                Items.Add(new NavigationItem("Параметры", typeof(ParametersView)));
                Items.Add(new NavigationItem("Обозначение продукта", typeof(ProductDesignationLookupListView)));
                Items.Add(new NavigationItem("Обозначение типа продукта", typeof(ProductTypeDesignationLookupListView)));
                Items.Add(new NavigationItem("Связи продуктов", typeof(ProductRelationsView)));
                Items.Add(new NavigationItem("Задания", typeof(CreateNewProductTasksView)));
                Items.Add(new NavigationItem("Замена", typeof(ProductReplacementView)));
                Items.Add(new NavigationItem("Нормо-часы", typeof(LaborHoursView)));
                Items.Add(new NavigationItem("Технико-стоимостные проработки", typeof(PriceEngineeringTasksListViewAdmin)));
            }

            if (GlobalAppProperties.UserIsDesignDepartmentHead)
            {
                //Items.Add(new NavigationItem("Приоритетность задач", typeof(EngineeringDepartmentTasksQueueViewDepartmentHead)));
                Items.Add(new NavigationItem("Технико-стоимостные проработки", typeof(PriceEngineeringTasksListViewDesignDepartmentHead)));
                Items.Add(new NavigationItem("Мониторинг ТСП", typeof(PriceEngineeringTasksListViewObserver)));
                Items.Add(new NavigationItem("StructureCosts", typeof(StructureCostsNumbersView)));
                //Items.Add(new NavigationItem("Статистика работы в ТСП", typeof(PriceEngineeringStatisticsView)));
            }
            else
            {
                //Items.Add(new NavigationItem("Приоритетность задач", typeof(EngineeringDepartmentTasksQueueViewConstructor)));
                if (GlobalAppProperties.User.RoleCurrent != Role.Admin)
                    Items.Add(new NavigationItem("Технико-стоимостные проработки", typeof(PriceEngineeringTasksListView)));
            }


            //if (GlobalAppProperties.UserIsConstructor)
            //    Items.Add(new NavigationItem("Стракчакосты", typeof(StructureCostsView)));

            //if (GlobalAppProperties.UserIsConstructor == false)
                Items.Add(new NavigationItem("Референс", typeof(ReferenceView)));
        }
    }
}
