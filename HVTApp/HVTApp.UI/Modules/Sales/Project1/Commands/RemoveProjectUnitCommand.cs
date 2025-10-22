using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;
using HVTApp.UI.Modules.Sales.Project1.ViewModels;
using HVTApp.UI.Modules.Sales.Project1.Wrappers;

namespace HVTApp.UI.Modules.Sales.Project1.Commands
{
    public class RemoveProjectUnitCommand : RaiseCanExecuteChangedCommand
    {
        private readonly ProjectViewModel _viewModel;
        private readonly IMessageService _messageService;

        public RemoveProjectUnitCommand(
            ProjectViewModel viewModel,
            IMessageService messageService)
        {
            _viewModel = viewModel;
            _messageService = messageService;
            _viewModel.SelectedUnitChanged += RaiseCanExecuteChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _viewModel.SelectedUnit != null;
        }

        public override void Execute(object parameter)
        {
            var dr1 = _messageService.ConfirmationDialog("Вы уверены в удалении?");
            if (dr1 != true) return;
            
            var salesUnits = _viewModel.SelectedUnit is ProjectUnitGroup projectUnitGroup
                ? projectUnitGroup.Units.Select(projectUnit => projectUnit.Model).ToList()
                : new List<SalesUnit> { ((ProjectUnit)_viewModel.SelectedUnit).Model };

            if (salesUnits.Any(salesUnit => salesUnit.Order != null))
            {
                _messageService.Message("Удаление невозможно", "Оборудованию присвоен заводской заказ.");
                return;
            }

            if (salesUnits.Any(salesUnit => salesUnit.PriceEngineeringTasks.Any()))
            {
                var dr = _messageService.ConfirmationDialog("С удаляемым связана задача ТСП. Вы всё ещё уверены в удалении?");
                if (dr != true) return;
            }
            else if (salesUnits.Any(salesUnit => salesUnit.TechnicalRequirements.Any()))
            {
                var dr = _messageService.ConfirmationDialog("С удаляемым связана задача ТСЕ. Вы всё ещё уверены в удалении?");
                if (dr != true) return;
            }

            foreach (var salesUnit in salesUnits)
            {
                var projectUnit = _viewModel.ProjectWrapper.Units.Single(unit => unit.Model.Id == salesUnit.Id);
                projectUnit.IsRemoved = true;
                _viewModel.ProjectWrapper.Units.Remove(projectUnit);
            }
        }
    }
}