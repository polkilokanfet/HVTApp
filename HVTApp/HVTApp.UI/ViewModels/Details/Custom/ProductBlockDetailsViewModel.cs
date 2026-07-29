using System;
using System.Collections.Generic;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.ViewModels
{
    public partial class ProductBlockDetailsViewModel : BaseDetailsViewModel<ProductBlockWrapper1, ProductBlock, AfterSaveProductBlockEvent>
    {
        protected override void InitSpecialCommands()
        {
            RemoveFromPricesCommand = new DelegateLogConfirmationCommand(
                this.Container.Resolve<IMessageService>(),
                () =>
                {
                    using (var unitOfWork = Container.Resolve<IUnitOfWork>())
                    {
                        var block = unitOfWork.Repository<ProductBlock>().GetById(this.Entity.Id);
                        var sumOnDate = unitOfWork.Repository<SumOnDate>().GetById(SelectedPricesItem.Model.Id);

                        block.Prices.Remove(sumOnDate);
                        unitOfWork.Repository<SumOnDate>().Delete(sumOnDate);

                        unitOfWork.SaveChanges();
                    }
                },
                () => this.SelectedPricesItem != null);
        }

        private Func<List<ProductType>> _getEntitiesForSelectProductTypeCommand;
        public DelegateLogCommand SelectProductTypeCommand { get; private set; }
        public DelegateLogCommand ClearProductTypeCommand { get; private set; }

        private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
        public DelegateLogCommand AddInParametersCommand { get; }
        public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
        private ParameterEmptyWrapper _selectedParametersItem;
        public ParameterEmptyWrapper SelectedParametersItem 
        { 
            get { return _selectedParametersItem; }
            set 
            { 
                if (Equals(_selectedParametersItem, value)) return;
                _selectedParametersItem = value;
                RaisePropertyChanged();
                RemoveFromParametersCommand.RaiseCanExecuteChanged();
            }
        }

        private Func<List<SumOnDate>> _getEntitiesForAddInPricesCommand;
        public DelegateLogCommand AddInPricesCommand { get; }
        public DelegateLogCommand RemoveFromPricesCommand { get; private set; }
        private SumOnDateEmptyWrapper _selectedPricesItem;
        public SumOnDateEmptyWrapper SelectedPricesItem 
        { 
            get { return _selectedPricesItem; }
            set 
            { 
                if (Equals(_selectedPricesItem, value)) return;
                _selectedPricesItem = value;
                RaisePropertyChanged();
                RemoveFromPricesCommand.RaiseCanExecuteChanged();
            }
        }

        private Func<List<SumOnDate>> _getEntitiesForAddInFixedCostsCommand;
        public DelegateLogCommand AddInFixedCostsCommand { get; }
        public DelegateLogCommand RemoveFromFixedCostsCommand { get; private set; }
        private SumOnDateEmptyWrapper _selectedFixedCostsItem;
        public SumOnDateEmptyWrapper SelectedFixedCostsItem 
        { 
            get { return _selectedFixedCostsItem; }
            set 
            { 
                if (Equals(_selectedFixedCostsItem, value)) return;
                _selectedFixedCostsItem = value;
                RaisePropertyChanged();
                RemoveFromFixedCostsCommand.RaiseCanExecuteChanged();
            }
        }

        private Func<List<Parameter>> _getEntitiesForAddInParametersOrderedCommand;
        public DelegateLogCommand AddInParametersOrderedCommand { get; }
        public DelegateLogCommand RemoveFromParametersOrderedCommand { get; private set; }
        private ParameterEmptyWrapper _selectedParametersOrderedItem;
        public ParameterEmptyWrapper SelectedParametersOrderedItem 
        { 
            get { return _selectedParametersOrderedItem; }
            set 
            { 
                if (Equals(_selectedParametersOrderedItem, value)) return;
                _selectedParametersOrderedItem = value;
                RaisePropertyChanged();
                RemoveFromParametersOrderedCommand.RaiseCanExecuteChanged();
            }
        }

        public ProductBlockDetailsViewModel(IUnityContainer container) : base(container) 
        {
			
            if (_getEntitiesForSelectProductTypeCommand == null) _getEntitiesForSelectProductTypeCommand = () => { return UnitOfWork.Repository<ProductType>().GetAll(); };
            if (SelectProductTypeCommand == null) SelectProductTypeCommand = new DelegateLogCommand(SelectProductTypeCommand_Execute_Default);
            if (ClearProductTypeCommand == null) ClearProductTypeCommand = new DelegateLogCommand(ClearProductTypeCommand_Execute_Default);

			
            if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
            if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
            if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

			
            if (_getEntitiesForAddInPricesCommand == null) _getEntitiesForAddInPricesCommand = () => { return UnitOfWork.Repository<SumOnDate>().GetAll(); };;
            if (AddInPricesCommand == null) AddInPricesCommand = new DelegateLogCommand(AddInPricesCommand_Execute_Default);
            if (RemoveFromPricesCommand == null) RemoveFromPricesCommand = new DelegateLogCommand(RemoveFromPricesCommand_Execute_Default, RemoveFromPricesCommand_CanExecute_Default);

			
            if (_getEntitiesForAddInFixedCostsCommand == null) _getEntitiesForAddInFixedCostsCommand = () => { return UnitOfWork.Repository<SumOnDate>().GetAll(); };;
            if (AddInFixedCostsCommand == null) AddInFixedCostsCommand = new DelegateLogCommand(AddInFixedCostsCommand_Execute_Default);
            if (RemoveFromFixedCostsCommand == null) RemoveFromFixedCostsCommand = new DelegateLogCommand(RemoveFromFixedCostsCommand_Execute_Default, RemoveFromFixedCostsCommand_CanExecute_Default);

			
            if (_getEntitiesForAddInParametersOrderedCommand == null) _getEntitiesForAddInParametersOrderedCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
        }

        private void SelectProductTypeCommand_Execute_Default() 
        {
            SelectAndSetWrapper<ProductType, ProductTypeWrapper>(_getEntitiesForSelectProductTypeCommand(), nameof(Item.ProductType), Item.ProductType?.Id);
        }

        private void ClearProductTypeCommand_Execute_Default() 
        {
				    
        }

        private void AddInParametersCommand_Execute_Default()
        {
            SelectAndAddInListWrapper<Parameter, ParameterEmptyWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
        }

        private void RemoveFromParametersCommand_Execute_Default()
        {
            Item.Parameters.Remove(SelectedParametersItem);
        }

        private bool RemoveFromParametersCommand_CanExecute_Default()
        {
            return SelectedParametersItem != null;
        }

        private void AddInPricesCommand_Execute_Default()
        {
            SelectAndAddInListWrapper<SumOnDate, SumOnDateEmptyWrapper>(_getEntitiesForAddInPricesCommand(), Item.Prices);
        }

        private void RemoveFromPricesCommand_Execute_Default()
        {
            Item.Prices.Remove(SelectedPricesItem);
        }

        private bool RemoveFromPricesCommand_CanExecute_Default()
        {
            return SelectedPricesItem != null;
        }

        private void AddInFixedCostsCommand_Execute_Default()
        {
            SelectAndAddInListWrapper<SumOnDate, SumOnDateEmptyWrapper>(_getEntitiesForAddInFixedCostsCommand(), Item.FixedCosts);
        }

        private void RemoveFromFixedCostsCommand_Execute_Default()
        {
            Item.FixedCosts.Remove(SelectedFixedCostsItem);
        }

        private bool RemoveFromFixedCostsCommand_CanExecute_Default()
        {
            return SelectedFixedCostsItem != null;
        }

        private bool RemoveFromParametersOrderedCommand_CanExecute_Default()
        {
            return SelectedParametersOrderedItem != null;
        }


    }
}