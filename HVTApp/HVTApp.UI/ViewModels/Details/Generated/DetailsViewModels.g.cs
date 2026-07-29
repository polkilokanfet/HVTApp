using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Events;
using Microsoft.Practices.Unity;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using HVTApp.UI.Commands;

namespace HVTApp.UI.ViewModels
{
    public partial class NotificationUnitDetailsViewModel : BaseDetailsViewModel<NotificationUnitWrapper, NotificationUnit, AfterSaveNotificationUnitEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectSenderUserCommand;
		private Func<List<User>> _getEntitiesForSelectSenderUserCommand;
		public DelegateLogCommand SelectSenderUserCommand { get; private set; }
		public DelegateLogCommand ClearSenderUserCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectRecipientUserCommand;
		private Func<List<User>> _getEntitiesForSelectRecipientUserCommand;
		public DelegateLogCommand SelectRecipientUserCommand { get; private set; }
		public DelegateLogCommand ClearRecipientUserCommand { get; private set; }

        public NotificationUnitDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectSenderUserCommand == null) _getEntitiesForSelectSenderUserCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectSenderUserCommand == null) SelectSenderUserCommand = new DelegateLogCommand(SelectSenderUserCommand_Execute_Default);
			if (ClearSenderUserCommand == null) ClearSenderUserCommand = new DelegateLogCommand(ClearSenderUserCommand_Execute_Default);

			
			if (_getEntitiesForSelectRecipientUserCommand == null) _getEntitiesForSelectRecipientUserCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectRecipientUserCommand == null) SelectRecipientUserCommand = new DelegateLogCommand(SelectRecipientUserCommand_Execute_Default);
			if (ClearRecipientUserCommand == null) ClearRecipientUserCommand = new DelegateLogCommand(ClearRecipientUserCommand_Execute_Default);

		}

		private void SelectSenderUserCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectSenderUserCommand(), nameof(Item.SenderUser), Item.SenderUser?.Id);
		}

		private void ClearSenderUserCommand_Execute_Default() 
		{
						Item.SenderUser = null;		    
		}

		private void SelectRecipientUserCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectRecipientUserCommand(), nameof(Item.RecipientUser), Item.RecipientUser?.Id);
		}

		private void ClearRecipientUserCommand_Execute_Default() 
		{
						Item.RecipientUser = null;		    
		}


    }

    public partial class CountryUnionDetailsViewModel : BaseDetailsViewModel<CountryUnionWrapper, CountryUnion, AfterSaveCountryUnionEvent>
    {
		private Func<List<Country>> _getEntitiesForAddInCountriesCommand;
		public DelegateLogCommand AddInCountriesCommand { get; }
		public DelegateLogCommand RemoveFromCountriesCommand { get; private set; }
		private CountryWrapper _selectedCountriesItem;
		public CountryWrapper SelectedCountriesItem 
		{ 
			get { return _selectedCountriesItem; }
			set 
			{ 
				if (Equals(_selectedCountriesItem, value)) return;
				_selectedCountriesItem = value;
				RaisePropertyChanged();
				RemoveFromCountriesCommand.RaiseCanExecuteChanged();
			}
		}

        public CountryUnionDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInCountriesCommand == null) _getEntitiesForAddInCountriesCommand = () => { return UnitOfWork.Repository<Country>().GetAll(); };;
			if (AddInCountriesCommand == null) AddInCountriesCommand = new DelegateLogCommand(AddInCountriesCommand_Execute_Default);
			if (RemoveFromCountriesCommand == null) RemoveFromCountriesCommand = new DelegateLogCommand(RemoveFromCountriesCommand_Execute_Default, RemoveFromCountriesCommand_CanExecute_Default);

		}

			private void AddInCountriesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Country, CountryWrapper>(_getEntitiesForAddInCountriesCommand(), Item.Countries);
			}

			private void RemoveFromCountriesCommand_Execute_Default()
			{
				Item.Countries.Remove(SelectedCountriesItem);
			}

			private bool RemoveFromCountriesCommand_CanExecute_Default()
			{
				return SelectedCountriesItem != null;
			}


    }

    public partial class BudgetDetailsViewModel : BaseDetailsViewModel<BudgetWrapper, Budget, AfterSaveBudgetEvent>
    {
		private Func<List<BudgetUnit>> _getEntitiesForAddInUnitsCommand;
		public DelegateLogCommand AddInUnitsCommand { get; }
		public DelegateLogCommand RemoveFromUnitsCommand { get; private set; }
		private BudgetUnitWrapper _selectedUnitsItem;
		public BudgetUnitWrapper SelectedUnitsItem 
		{ 
			get { return _selectedUnitsItem; }
			set 
			{ 
				if (Equals(_selectedUnitsItem, value)) return;
				_selectedUnitsItem = value;
				RaisePropertyChanged();
				RemoveFromUnitsCommand.RaiseCanExecuteChanged();
			}
		}

        public BudgetDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInUnitsCommand == null) _getEntitiesForAddInUnitsCommand = () => { return UnitOfWork.Repository<BudgetUnit>().GetAll(); };;
			if (AddInUnitsCommand == null) AddInUnitsCommand = new DelegateLogCommand(AddInUnitsCommand_Execute_Default);
			if (RemoveFromUnitsCommand == null) RemoveFromUnitsCommand = new DelegateLogCommand(RemoveFromUnitsCommand_Execute_Default, RemoveFromUnitsCommand_CanExecute_Default);

		}

			private void AddInUnitsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<BudgetUnit, BudgetUnitWrapper>(_getEntitiesForAddInUnitsCommand(), Item.Units);
			}

			private void RemoveFromUnitsCommand_Execute_Default()
			{
				Item.Units.Remove(SelectedUnitsItem);
			}

			private bool RemoveFromUnitsCommand_CanExecute_Default()
			{
				return SelectedUnitsItem != null;
			}


    }

    public partial class BudgetUnitDetailsViewModel : BaseDetailsViewModel<BudgetUnitWrapper, BudgetUnit, AfterSaveBudgetUnitEvent>
    {
		//private Func<Task<List<SalesUnit>>> _getEntitiesForSelectSalesUnitCommand;
		private Func<List<SalesUnit>> _getEntitiesForSelectSalesUnitCommand;
		public DelegateLogCommand SelectSalesUnitCommand { get; private set; }
		public DelegateLogCommand ClearSalesUnitCommand { get; private set; }

		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectPaymentConditionSetCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectPaymentConditionSetCommand;
		public DelegateLogCommand SelectPaymentConditionSetCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionSetCommand { get; private set; }

		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectPaymentConditionSetByManagerCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectPaymentConditionSetByManagerCommand;
		public DelegateLogCommand SelectPaymentConditionSetByManagerCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionSetByManagerCommand { get; private set; }

        public BudgetUnitDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectSalesUnitCommand == null) _getEntitiesForSelectSalesUnitCommand = () => { return UnitOfWork.Repository<SalesUnit>().GetAll(); };
			if (SelectSalesUnitCommand == null) SelectSalesUnitCommand = new DelegateLogCommand(SelectSalesUnitCommand_Execute_Default);
			if (ClearSalesUnitCommand == null) ClearSalesUnitCommand = new DelegateLogCommand(ClearSalesUnitCommand_Execute_Default);

			
			if (_getEntitiesForSelectPaymentConditionSetCommand == null) _getEntitiesForSelectPaymentConditionSetCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectPaymentConditionSetCommand == null) SelectPaymentConditionSetCommand = new DelegateLogCommand(SelectPaymentConditionSetCommand_Execute_Default);
			if (ClearPaymentConditionSetCommand == null) ClearPaymentConditionSetCommand = new DelegateLogCommand(ClearPaymentConditionSetCommand_Execute_Default);

			
			if (_getEntitiesForSelectPaymentConditionSetByManagerCommand == null) _getEntitiesForSelectPaymentConditionSetByManagerCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectPaymentConditionSetByManagerCommand == null) SelectPaymentConditionSetByManagerCommand = new DelegateLogCommand(SelectPaymentConditionSetByManagerCommand_Execute_Default);
			if (ClearPaymentConditionSetByManagerCommand == null) ClearPaymentConditionSetByManagerCommand = new DelegateLogCommand(ClearPaymentConditionSetByManagerCommand_Execute_Default);

		}

		private void SelectSalesUnitCommand_Execute_Default() 
		{
            SelectAndSetWrapper<SalesUnit, SalesUnitWrapper>(_getEntitiesForSelectSalesUnitCommand(), nameof(Item.SalesUnit), Item.SalesUnit?.Id);
		}

		private void ClearSalesUnitCommand_Execute_Default() 
		{
						Item.SalesUnit = null;		    
		}

		private void SelectPaymentConditionSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectPaymentConditionSetCommand(), nameof(Item.PaymentConditionSet), Item.PaymentConditionSet?.Id);
		}

		private void ClearPaymentConditionSetCommand_Execute_Default() 
		{
						Item.PaymentConditionSet = null;		    
		}

		private void SelectPaymentConditionSetByManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectPaymentConditionSetByManagerCommand(), nameof(Item.PaymentConditionSetByManager), Item.PaymentConditionSetByManager?.Id);
		}

		private void ClearPaymentConditionSetByManagerCommand_Execute_Default() 
		{
						Item.PaymentConditionSetByManager = null;		    
		}


    }

    public partial class ConstructorParametersListDetailsViewModel : BaseDetailsViewModel<ConstructorParametersListWrapper, ConstructorParametersList, AfterSaveConstructorParametersListEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public ConstructorParametersListDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class ConstructorsParametersDetailsViewModel : BaseDetailsViewModel<ConstructorsParametersWrapper, ConstructorsParameters, AfterSaveConstructorsParametersEvent>
    {
		private Func<List<User>> _getEntitiesForAddInConstructorsCommand;
		public DelegateLogCommand AddInConstructorsCommand { get; }
		public DelegateLogCommand RemoveFromConstructorsCommand { get; private set; }
		private UserWrapper _selectedConstructorsItem;
		public UserWrapper SelectedConstructorsItem 
		{ 
			get { return _selectedConstructorsItem; }
			set 
			{ 
				if (Equals(_selectedConstructorsItem, value)) return;
				_selectedConstructorsItem = value;
				RaisePropertyChanged();
				RemoveFromConstructorsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<ConstructorParametersList>> _getEntitiesForAddInPatametersListsCommand;
		public DelegateLogCommand AddInPatametersListsCommand { get; }
		public DelegateLogCommand RemoveFromPatametersListsCommand { get; private set; }
		private ConstructorParametersListWrapper _selectedPatametersListsItem;
		public ConstructorParametersListWrapper SelectedPatametersListsItem 
		{ 
			get { return _selectedPatametersListsItem; }
			set 
			{ 
				if (Equals(_selectedPatametersListsItem, value)) return;
				_selectedPatametersListsItem = value;
				RaisePropertyChanged();
				RemoveFromPatametersListsCommand.RaiseCanExecuteChanged();
			}
		}

        public ConstructorsParametersDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInConstructorsCommand == null) _getEntitiesForAddInConstructorsCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInConstructorsCommand == null) AddInConstructorsCommand = new DelegateLogCommand(AddInConstructorsCommand_Execute_Default);
			if (RemoveFromConstructorsCommand == null) RemoveFromConstructorsCommand = new DelegateLogCommand(RemoveFromConstructorsCommand_Execute_Default, RemoveFromConstructorsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPatametersListsCommand == null) _getEntitiesForAddInPatametersListsCommand = () => { return UnitOfWork.Repository<ConstructorParametersList>().GetAll(); };;
			if (AddInPatametersListsCommand == null) AddInPatametersListsCommand = new DelegateLogCommand(AddInPatametersListsCommand_Execute_Default);
			if (RemoveFromPatametersListsCommand == null) RemoveFromPatametersListsCommand = new DelegateLogCommand(RemoveFromPatametersListsCommand_Execute_Default, RemoveFromPatametersListsCommand_CanExecute_Default);

		}

			private void AddInConstructorsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInConstructorsCommand(), Item.Constructors);
			}

			private void RemoveFromConstructorsCommand_Execute_Default()
			{
				Item.Constructors.Remove(SelectedConstructorsItem);
			}

			private bool RemoveFromConstructorsCommand_CanExecute_Default()
			{
				return SelectedConstructorsItem != null;
			}

			private void AddInPatametersListsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ConstructorParametersList, ConstructorParametersListWrapper>(_getEntitiesForAddInPatametersListsCommand(), Item.PatametersLists);
			}

			private void RemoveFromPatametersListsCommand_Execute_Default()
			{
				Item.PatametersLists.Remove(SelectedPatametersListsItem);
			}

			private bool RemoveFromPatametersListsCommand_CanExecute_Default()
			{
				return SelectedPatametersListsItem != null;
			}


    }

    public partial class CostsPercentsDetailsViewModel : BaseDetailsViewModel<CostsPercentsWrapper, CostsPercents, AfterSaveCostsPercentsEvent>
    {
        public CostsPercentsDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class CreateNewProductTaskDetailsViewModel : BaseDetailsViewModel<CreateNewProductTaskWrapper, CreateNewProductTask, AfterSaveCreateNewProductTaskEvent>
    {
		//private Func<Task<List<Product>>> _getEntitiesForSelectProductCommand;
		private Func<List<Product>> _getEntitiesForSelectProductCommand;
		public DelegateLogCommand SelectProductCommand { get; private set; }
		public DelegateLogCommand ClearProductCommand { get; private set; }

        public CreateNewProductTaskDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductCommand == null) _getEntitiesForSelectProductCommand = () => { return UnitOfWork.Repository<Product>().GetAll(); };
			if (SelectProductCommand == null) SelectProductCommand = new DelegateLogCommand(SelectProductCommand_Execute_Default);
			if (ClearProductCommand == null) ClearProductCommand = new DelegateLogCommand(ClearProductCommand_Execute_Default);

		}

		private void SelectProductCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Product, ProductWrapper>(_getEntitiesForSelectProductCommand(), nameof(Item.Product), Item.Product?.Id);
		}

		private void ClearProductCommand_Execute_Default() 
		{
						Item.Product = null;		    
		}


    }

    public partial class DesignDepartmentDetailsViewModel : BaseDetailsViewModel<DesignDepartmentWrapper, DesignDepartment, AfterSaveDesignDepartmentEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectHeadCommand;
		private Func<List<User>> _getEntitiesForSelectHeadCommand;
		public DelegateLogCommand SelectHeadCommand { get; private set; }
		public DelegateLogCommand ClearHeadCommand { get; private set; }

		private Func<List<User>> _getEntitiesForAddInStaffCommand;
		public DelegateLogCommand AddInStaffCommand { get; }
		public DelegateLogCommand RemoveFromStaffCommand { get; private set; }
		private UserWrapper _selectedStaffItem;
		public UserWrapper SelectedStaffItem 
		{ 
			get { return _selectedStaffItem; }
			set 
			{ 
				if (Equals(_selectedStaffItem, value)) return;
				_selectedStaffItem = value;
				RaisePropertyChanged();
				RemoveFromStaffCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<User>> _getEntitiesForAddInObserversCommand;
		public DelegateLogCommand AddInObserversCommand { get; }
		public DelegateLogCommand RemoveFromObserversCommand { get; private set; }
		private UserWrapper _selectedObserversItem;
		public UserWrapper SelectedObserversItem 
		{ 
			get { return _selectedObserversItem; }
			set 
			{ 
				if (Equals(_selectedObserversItem, value)) return;
				_selectedObserversItem = value;
				RaisePropertyChanged();
				RemoveFromObserversCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<DesignDepartmentParameters>> _getEntitiesForAddInParameterSetsCommand;
		public DelegateLogCommand AddInParameterSetsCommand { get; }
		public DelegateLogCommand RemoveFromParameterSetsCommand { get; private set; }
		private DesignDepartmentParametersWrapper _selectedParameterSetsItem;
		public DesignDepartmentParametersWrapper SelectedParameterSetsItem 
		{ 
			get { return _selectedParameterSetsItem; }
			set 
			{ 
				if (Equals(_selectedParameterSetsItem, value)) return;
				_selectedParameterSetsItem = value;
				RaisePropertyChanged();
				RemoveFromParameterSetsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<DesignDepartmentParametersAddedBlocks>> _getEntitiesForAddInParameterSetsAddedBlocksCommand;
		public DelegateLogCommand AddInParameterSetsAddedBlocksCommand { get; }
		public DelegateLogCommand RemoveFromParameterSetsAddedBlocksCommand { get; private set; }
		private DesignDepartmentParametersAddedBlocksWrapper _selectedParameterSetsAddedBlocksItem;
		public DesignDepartmentParametersAddedBlocksWrapper SelectedParameterSetsAddedBlocksItem 
		{ 
			get { return _selectedParameterSetsAddedBlocksItem; }
			set 
			{ 
				if (Equals(_selectedParameterSetsAddedBlocksItem, value)) return;
				_selectedParameterSetsAddedBlocksItem = value;
				RaisePropertyChanged();
				RemoveFromParameterSetsAddedBlocksCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<DesignDepartmentParametersSubTask>> _getEntitiesForAddInParameterSetsSubTaskCommand;
		public DelegateLogCommand AddInParameterSetsSubTaskCommand { get; }
		public DelegateLogCommand RemoveFromParameterSetsSubTaskCommand { get; private set; }
		private DesignDepartmentParametersSubTaskWrapper _selectedParameterSetsSubTaskItem;
		public DesignDepartmentParametersSubTaskWrapper SelectedParameterSetsSubTaskItem 
		{ 
			get { return _selectedParameterSetsSubTaskItem; }
			set 
			{ 
				if (Equals(_selectedParameterSetsSubTaskItem, value)) return;
				_selectedParameterSetsSubTaskItem = value;
				RaisePropertyChanged();
				RemoveFromParameterSetsSubTaskCommand.RaiseCanExecuteChanged();
			}
		}

        public DesignDepartmentDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectHeadCommand == null) _getEntitiesForSelectHeadCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectHeadCommand == null) SelectHeadCommand = new DelegateLogCommand(SelectHeadCommand_Execute_Default);
			if (ClearHeadCommand == null) ClearHeadCommand = new DelegateLogCommand(ClearHeadCommand_Execute_Default);

			
			if (_getEntitiesForAddInStaffCommand == null) _getEntitiesForAddInStaffCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInStaffCommand == null) AddInStaffCommand = new DelegateLogCommand(AddInStaffCommand_Execute_Default);
			if (RemoveFromStaffCommand == null) RemoveFromStaffCommand = new DelegateLogCommand(RemoveFromStaffCommand_Execute_Default, RemoveFromStaffCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInObserversCommand == null) _getEntitiesForAddInObserversCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInObserversCommand == null) AddInObserversCommand = new DelegateLogCommand(AddInObserversCommand_Execute_Default);
			if (RemoveFromObserversCommand == null) RemoveFromObserversCommand = new DelegateLogCommand(RemoveFromObserversCommand_Execute_Default, RemoveFromObserversCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInParameterSetsCommand == null) _getEntitiesForAddInParameterSetsCommand = () => { return UnitOfWork.Repository<DesignDepartmentParameters>().GetAll(); };;
			if (AddInParameterSetsCommand == null) AddInParameterSetsCommand = new DelegateLogCommand(AddInParameterSetsCommand_Execute_Default);
			if (RemoveFromParameterSetsCommand == null) RemoveFromParameterSetsCommand = new DelegateLogCommand(RemoveFromParameterSetsCommand_Execute_Default, RemoveFromParameterSetsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInParameterSetsAddedBlocksCommand == null) _getEntitiesForAddInParameterSetsAddedBlocksCommand = () => { return UnitOfWork.Repository<DesignDepartmentParametersAddedBlocks>().GetAll(); };;
			if (AddInParameterSetsAddedBlocksCommand == null) AddInParameterSetsAddedBlocksCommand = new DelegateLogCommand(AddInParameterSetsAddedBlocksCommand_Execute_Default);
			if (RemoveFromParameterSetsAddedBlocksCommand == null) RemoveFromParameterSetsAddedBlocksCommand = new DelegateLogCommand(RemoveFromParameterSetsAddedBlocksCommand_Execute_Default, RemoveFromParameterSetsAddedBlocksCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInParameterSetsSubTaskCommand == null) _getEntitiesForAddInParameterSetsSubTaskCommand = () => { return UnitOfWork.Repository<DesignDepartmentParametersSubTask>().GetAll(); };;
			if (AddInParameterSetsSubTaskCommand == null) AddInParameterSetsSubTaskCommand = new DelegateLogCommand(AddInParameterSetsSubTaskCommand_Execute_Default);
			if (RemoveFromParameterSetsSubTaskCommand == null) RemoveFromParameterSetsSubTaskCommand = new DelegateLogCommand(RemoveFromParameterSetsSubTaskCommand_Execute_Default, RemoveFromParameterSetsSubTaskCommand_CanExecute_Default);

		}

		private void SelectHeadCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectHeadCommand(), nameof(Item.Head), Item.Head?.Id);
		}

		private void ClearHeadCommand_Execute_Default() 
		{
						Item.Head = null;		    
		}

			private void AddInStaffCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInStaffCommand(), Item.Staff);
			}

			private void RemoveFromStaffCommand_Execute_Default()
			{
				Item.Staff.Remove(SelectedStaffItem);
			}

			private bool RemoveFromStaffCommand_CanExecute_Default()
			{
				return SelectedStaffItem != null;
			}

			private void AddInObserversCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInObserversCommand(), Item.Observers);
			}

			private void RemoveFromObserversCommand_Execute_Default()
			{
				Item.Observers.Remove(SelectedObserversItem);
			}

			private bool RemoveFromObserversCommand_CanExecute_Default()
			{
				return SelectedObserversItem != null;
			}

			private void AddInParameterSetsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<DesignDepartmentParameters, DesignDepartmentParametersWrapper>(_getEntitiesForAddInParameterSetsCommand(), Item.ParameterSets);
			}

			private void RemoveFromParameterSetsCommand_Execute_Default()
			{
				Item.ParameterSets.Remove(SelectedParameterSetsItem);
			}

			private bool RemoveFromParameterSetsCommand_CanExecute_Default()
			{
				return SelectedParameterSetsItem != null;
			}

			private void AddInParameterSetsAddedBlocksCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<DesignDepartmentParametersAddedBlocks, DesignDepartmentParametersAddedBlocksWrapper>(_getEntitiesForAddInParameterSetsAddedBlocksCommand(), Item.ParameterSetsAddedBlocks);
			}

			private void RemoveFromParameterSetsAddedBlocksCommand_Execute_Default()
			{
				Item.ParameterSetsAddedBlocks.Remove(SelectedParameterSetsAddedBlocksItem);
			}

			private bool RemoveFromParameterSetsAddedBlocksCommand_CanExecute_Default()
			{
				return SelectedParameterSetsAddedBlocksItem != null;
			}

			private void AddInParameterSetsSubTaskCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<DesignDepartmentParametersSubTask, DesignDepartmentParametersSubTaskWrapper>(_getEntitiesForAddInParameterSetsSubTaskCommand(), Item.ParameterSetsSubTask);
			}

			private void RemoveFromParameterSetsSubTaskCommand_Execute_Default()
			{
				Item.ParameterSetsSubTask.Remove(SelectedParameterSetsSubTaskItem);
			}

			private bool RemoveFromParameterSetsSubTaskCommand_CanExecute_Default()
			{
				return SelectedParameterSetsSubTaskItem != null;
			}


    }

    public partial class DirectumTaskDetailsViewModel : BaseDetailsViewModel<DirectumTaskWrapper, DirectumTask, AfterSaveDirectumTaskEvent>
    {
		//private Func<Task<List<DirectumTaskGroup>>> _getEntitiesForSelectGroupCommand;
		private Func<List<DirectumTaskGroup>> _getEntitiesForSelectGroupCommand;
		public DelegateLogCommand SelectGroupCommand { get; private set; }
		public DelegateLogCommand ClearGroupCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectPerformerCommand;
		private Func<List<User>> _getEntitiesForSelectPerformerCommand;
		public DelegateLogCommand SelectPerformerCommand { get; private set; }
		public DelegateLogCommand ClearPerformerCommand { get; private set; }

		//private Func<Task<List<DirectumTask>>> _getEntitiesForSelectParentTaskCommand;
		private Func<List<DirectumTask>> _getEntitiesForSelectParentTaskCommand;
		public DelegateLogCommand SelectParentTaskCommand { get; private set; }
		public DelegateLogCommand ClearParentTaskCommand { get; private set; }

		//private Func<Task<List<DirectumTask>>> _getEntitiesForSelectPreviousTaskCommand;
		private Func<List<DirectumTask>> _getEntitiesForSelectPreviousTaskCommand;
		public DelegateLogCommand SelectPreviousTaskCommand { get; private set; }
		public DelegateLogCommand ClearPreviousTaskCommand { get; private set; }

		private Func<List<DirectumTaskMessage>> _getEntitiesForAddInMessagesCommand;
		public DelegateLogCommand AddInMessagesCommand { get; }
		public DelegateLogCommand RemoveFromMessagesCommand { get; private set; }
		private DirectumTaskMessageWrapper _selectedMessagesItem;
		public DirectumTaskMessageWrapper SelectedMessagesItem 
		{ 
			get { return _selectedMessagesItem; }
			set 
			{ 
				if (Equals(_selectedMessagesItem, value)) return;
				_selectedMessagesItem = value;
				RaisePropertyChanged();
				RemoveFromMessagesCommand.RaiseCanExecuteChanged();
			}
		}

        public DirectumTaskDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectGroupCommand == null) _getEntitiesForSelectGroupCommand = () => { return UnitOfWork.Repository<DirectumTaskGroup>().GetAll(); };
			if (SelectGroupCommand == null) SelectGroupCommand = new DelegateLogCommand(SelectGroupCommand_Execute_Default);
			if (ClearGroupCommand == null) ClearGroupCommand = new DelegateLogCommand(ClearGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectPerformerCommand == null) _getEntitiesForSelectPerformerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectPerformerCommand == null) SelectPerformerCommand = new DelegateLogCommand(SelectPerformerCommand_Execute_Default);
			if (ClearPerformerCommand == null) ClearPerformerCommand = new DelegateLogCommand(ClearPerformerCommand_Execute_Default);

			
			if (_getEntitiesForSelectParentTaskCommand == null) _getEntitiesForSelectParentTaskCommand = () => { return UnitOfWork.Repository<DirectumTask>().GetAll(); };
			if (SelectParentTaskCommand == null) SelectParentTaskCommand = new DelegateLogCommand(SelectParentTaskCommand_Execute_Default);
			if (ClearParentTaskCommand == null) ClearParentTaskCommand = new DelegateLogCommand(ClearParentTaskCommand_Execute_Default);

			
			if (_getEntitiesForSelectPreviousTaskCommand == null) _getEntitiesForSelectPreviousTaskCommand = () => { return UnitOfWork.Repository<DirectumTask>().GetAll(); };
			if (SelectPreviousTaskCommand == null) SelectPreviousTaskCommand = new DelegateLogCommand(SelectPreviousTaskCommand_Execute_Default);
			if (ClearPreviousTaskCommand == null) ClearPreviousTaskCommand = new DelegateLogCommand(ClearPreviousTaskCommand_Execute_Default);

			
			if (_getEntitiesForAddInMessagesCommand == null) _getEntitiesForAddInMessagesCommand = () => { return UnitOfWork.Repository<DirectumTaskMessage>().GetAll(); };;
			if (AddInMessagesCommand == null) AddInMessagesCommand = new DelegateLogCommand(AddInMessagesCommand_Execute_Default);
			if (RemoveFromMessagesCommand == null) RemoveFromMessagesCommand = new DelegateLogCommand(RemoveFromMessagesCommand_Execute_Default, RemoveFromMessagesCommand_CanExecute_Default);

		}

		private void SelectGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DirectumTaskGroup, DirectumTaskGroupWrapper>(_getEntitiesForSelectGroupCommand(), nameof(Item.Group), Item.Group?.Id);
		}

		private void ClearGroupCommand_Execute_Default() 
		{
						Item.Group = null;		    
		}

		private void SelectPerformerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectPerformerCommand(), nameof(Item.Performer), Item.Performer?.Id);
		}

		private void ClearPerformerCommand_Execute_Default() 
		{
						Item.Performer = null;		    
		}

		private void SelectParentTaskCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DirectumTask, DirectumTaskWrapper>(_getEntitiesForSelectParentTaskCommand(), nameof(Item.ParentTask), Item.ParentTask?.Id);
		}

		private void ClearParentTaskCommand_Execute_Default() 
		{
						Item.ParentTask = null;		    
		}

		private void SelectPreviousTaskCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DirectumTask, DirectumTaskWrapper>(_getEntitiesForSelectPreviousTaskCommand(), nameof(Item.PreviousTask), Item.PreviousTask?.Id);
		}

		private void ClearPreviousTaskCommand_Execute_Default() 
		{
						Item.PreviousTask = null;		    
		}

			private void AddInMessagesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<DirectumTaskMessage, DirectumTaskMessageWrapper>(_getEntitiesForAddInMessagesCommand(), Item.Messages);
			}

			private void RemoveFromMessagesCommand_Execute_Default()
			{
				Item.Messages.Remove(SelectedMessagesItem);
			}

			private bool RemoveFromMessagesCommand_CanExecute_Default()
			{
				return SelectedMessagesItem != null;
			}


    }

    public partial class DirectumTaskGroupDetailsViewModel : BaseDetailsViewModel<DirectumTaskGroupWrapper, DirectumTaskGroup, AfterSaveDirectumTaskGroupEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<User>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

		private Func<List<User>> _getEntitiesForAddInObserversCommand;
		public DelegateLogCommand AddInObserversCommand { get; }
		public DelegateLogCommand RemoveFromObserversCommand { get; private set; }
		private UserWrapper _selectedObserversItem;
		public UserWrapper SelectedObserversItem 
		{ 
			get { return _selectedObserversItem; }
			set 
			{ 
				if (Equals(_selectedObserversItem, value)) return;
				_selectedObserversItem = value;
				RaisePropertyChanged();
				RemoveFromObserversCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<DirectumTaskGroupFile>> _getEntitiesForAddInFilesCommand;
		public DelegateLogCommand AddInFilesCommand { get; }
		public DelegateLogCommand RemoveFromFilesCommand { get; private set; }
		private DirectumTaskGroupFileWrapper _selectedFilesItem;
		public DirectumTaskGroupFileWrapper SelectedFilesItem 
		{ 
			get { return _selectedFilesItem; }
			set 
			{ 
				if (Equals(_selectedFilesItem, value)) return;
				_selectedFilesItem = value;
				RaisePropertyChanged();
				RemoveFromFilesCommand.RaiseCanExecuteChanged();
			}
		}

        public DirectumTaskGroupDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

			
			if (_getEntitiesForAddInObserversCommand == null) _getEntitiesForAddInObserversCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInObserversCommand == null) AddInObserversCommand = new DelegateLogCommand(AddInObserversCommand_Execute_Default);
			if (RemoveFromObserversCommand == null) RemoveFromObserversCommand = new DelegateLogCommand(RemoveFromObserversCommand_Execute_Default, RemoveFromObserversCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInFilesCommand == null) _getEntitiesForAddInFilesCommand = () => { return UnitOfWork.Repository<DirectumTaskGroupFile>().GetAll(); };;
			if (AddInFilesCommand == null) AddInFilesCommand = new DelegateLogCommand(AddInFilesCommand_Execute_Default);
			if (RemoveFromFilesCommand == null) RemoveFromFilesCommand = new DelegateLogCommand(RemoveFromFilesCommand_Execute_Default, RemoveFromFilesCommand_CanExecute_Default);

		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}

			private void AddInObserversCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInObserversCommand(), Item.Observers);
			}

			private void RemoveFromObserversCommand_Execute_Default()
			{
				Item.Observers.Remove(SelectedObserversItem);
			}

			private bool RemoveFromObserversCommand_CanExecute_Default()
			{
				return SelectedObserversItem != null;
			}

			private void AddInFilesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<DirectumTaskGroupFile, DirectumTaskGroupFileWrapper>(_getEntitiesForAddInFilesCommand(), Item.Files);
			}

			private void RemoveFromFilesCommand_Execute_Default()
			{
				Item.Files.Remove(SelectedFilesItem);
			}

			private bool RemoveFromFilesCommand_CanExecute_Default()
			{
				return SelectedFilesItem != null;
			}


    }

    public partial class DirectumTaskGroupFileDetailsViewModel : BaseDetailsViewModel<DirectumTaskGroupFileWrapper, DirectumTaskGroupFile, AfterSaveDirectumTaskGroupFileEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<User>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

        public DirectumTaskGroupFileDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}


    }

    public partial class DirectumTaskMessageDetailsViewModel : BaseDetailsViewModel<DirectumTaskMessageWrapper, DirectumTaskMessage, AfterSaveDirectumTaskMessageEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<User>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

        public DirectumTaskMessageDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}


    }

    public partial class DocumentNumberDetailsViewModel : BaseDetailsViewModel<DocumentNumberWrapper, DocumentNumber, AfterSaveDocumentNumberEvent>
    {
        public DocumentNumberDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class IncomingRequestDetailsViewModel : BaseDetailsViewModel<IncomingRequestWrapper, IncomingRequest, AfterSaveIncomingRequestEvent>
    {
		//private Func<Task<List<Document>>> _getEntitiesForSelectDocumentCommand;
		private Func<List<Document>> _getEntitiesForSelectDocumentCommand;
		public DelegateLogCommand SelectDocumentCommand { get; private set; }
		public DelegateLogCommand ClearDocumentCommand { get; private set; }

		private Func<List<Employee>> _getEntitiesForAddInPerformersCommand;
		public DelegateLogCommand AddInPerformersCommand { get; }
		public DelegateLogCommand RemoveFromPerformersCommand { get; private set; }
		private EmployeeWrapper _selectedPerformersItem;
		public EmployeeWrapper SelectedPerformersItem 
		{ 
			get { return _selectedPerformersItem; }
			set 
			{ 
				if (Equals(_selectedPerformersItem, value)) return;
				_selectedPerformersItem = value;
				RaisePropertyChanged();
				RemoveFromPerformersCommand.RaiseCanExecuteChanged();
			}
		}

        public IncomingRequestDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectDocumentCommand == null) _getEntitiesForSelectDocumentCommand = () => { return UnitOfWork.Repository<Document>().GetAll(); };
			if (SelectDocumentCommand == null) SelectDocumentCommand = new DelegateLogCommand(SelectDocumentCommand_Execute_Default);
			if (ClearDocumentCommand == null) ClearDocumentCommand = new DelegateLogCommand(ClearDocumentCommand_Execute_Default);

			
			if (_getEntitiesForAddInPerformersCommand == null) _getEntitiesForAddInPerformersCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };;
			if (AddInPerformersCommand == null) AddInPerformersCommand = new DelegateLogCommand(AddInPerformersCommand_Execute_Default);
			if (RemoveFromPerformersCommand == null) RemoveFromPerformersCommand = new DelegateLogCommand(RemoveFromPerformersCommand_Execute_Default, RemoveFromPerformersCommand_CanExecute_Default);

		}

		private void SelectDocumentCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Document, DocumentWrapper>(_getEntitiesForSelectDocumentCommand(), nameof(Item.Document), Item.Document?.Id);
		}

		private void ClearDocumentCommand_Execute_Default() 
		{
						Item.Document = null;		    
		}

			private void AddInPerformersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Employee, EmployeeWrapper>(_getEntitiesForAddInPerformersCommand(), Item.Performers);
			}

			private void RemoveFromPerformersCommand_Execute_Default()
			{
				Item.Performers.Remove(SelectedPerformersItem);
			}

			private bool RemoveFromPerformersCommand_CanExecute_Default()
			{
				return SelectedPerformersItem != null;
			}


    }

    public partial class LaborHourCostDetailsViewModel : BaseDetailsViewModel<LaborHourCostWrapper, LaborHourCost, AfterSaveLaborHourCostEvent>
    {
        public LaborHourCostDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class LaborHoursDetailsViewModel : BaseDetailsViewModel<LaborHoursWrapper, LaborHours, AfterSaveLaborHoursEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public LaborHoursDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class LogUnitDetailsViewModel : BaseDetailsViewModel<LogUnitWrapper, LogUnit, AfterSaveLogUnitEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<User>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

        public LogUnitDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}


    }

    public partial class LosingReasonDetailsViewModel : BaseDetailsViewModel<LosingReasonWrapper, LosingReason, AfterSaveLosingReasonEvent>
    {
        public LosingReasonDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class MarketFieldDetailsViewModel : BaseDetailsViewModel<MarketFieldWrapper, MarketField, AfterSaveMarketFieldEvent>
    {
		private Func<List<ActivityField>> _getEntitiesForAddInActivityFieldsCommand;
		public DelegateLogCommand AddInActivityFieldsCommand { get; }
		public DelegateLogCommand RemoveFromActivityFieldsCommand { get; private set; }
		private ActivityFieldWrapper _selectedActivityFieldsItem;
		public ActivityFieldWrapper SelectedActivityFieldsItem 
		{ 
			get { return _selectedActivityFieldsItem; }
			set 
			{ 
				if (Equals(_selectedActivityFieldsItem, value)) return;
				_selectedActivityFieldsItem = value;
				RaisePropertyChanged();
				RemoveFromActivityFieldsCommand.RaiseCanExecuteChanged();
			}
		}

        public MarketFieldDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInActivityFieldsCommand == null) _getEntitiesForAddInActivityFieldsCommand = () => { return UnitOfWork.Repository<ActivityField>().GetAll(); };;
			if (AddInActivityFieldsCommand == null) AddInActivityFieldsCommand = new DelegateLogCommand(AddInActivityFieldsCommand_Execute_Default);
			if (RemoveFromActivityFieldsCommand == null) RemoveFromActivityFieldsCommand = new DelegateLogCommand(RemoveFromActivityFieldsCommand_Execute_Default, RemoveFromActivityFieldsCommand_CanExecute_Default);

		}

			private void AddInActivityFieldsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ActivityField, ActivityFieldWrapper>(_getEntitiesForAddInActivityFieldsCommand(), Item.ActivityFields);
			}

			private void RemoveFromActivityFieldsCommand_Execute_Default()
			{
				Item.ActivityFields.Remove(SelectedActivityFieldsItem);
			}

			private bool RemoveFromActivityFieldsCommand_CanExecute_Default()
			{
				return SelectedActivityFieldsItem != null;
			}


    }

    public partial class PaymentActualDetailsViewModel : BaseDetailsViewModel<PaymentActualWrapper, PaymentActual, AfterSavePaymentActualEvent>
    {
        public PaymentActualDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PaymentConditionPointDetailsViewModel : BaseDetailsViewModel<PaymentConditionPointWrapper, PaymentConditionPoint, AfterSavePaymentConditionPointEvent>
    {
        public PaymentConditionPointDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PaymentPlannedDetailsViewModel : BaseDetailsViewModel<PaymentPlannedWrapper, PaymentPlanned, AfterSavePaymentPlannedEvent>
    {
		//private Func<Task<List<PaymentCondition>>> _getEntitiesForSelectConditionCommand;
		private Func<List<PaymentCondition>> _getEntitiesForSelectConditionCommand;
		public DelegateLogCommand SelectConditionCommand { get; private set; }
		public DelegateLogCommand ClearConditionCommand { get; private set; }

        public PaymentPlannedDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectConditionCommand == null) _getEntitiesForSelectConditionCommand = () => { return UnitOfWork.Repository<PaymentCondition>().GetAll(); };
			if (SelectConditionCommand == null) SelectConditionCommand = new DelegateLogCommand(SelectConditionCommand_Execute_Default);
			if (ClearConditionCommand == null) ClearConditionCommand = new DelegateLogCommand(ClearConditionCommand_Execute_Default);

		}

		private void SelectConditionCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentCondition, PaymentConditionWrapper>(_getEntitiesForSelectConditionCommand(), nameof(Item.Condition), Item.Condition?.Id);
		}

		private void ClearConditionCommand_Execute_Default() 
		{
						Item.Condition = null;		    
		}


    }

    public partial class PenaltyDetailsViewModel : BaseDetailsViewModel<PenaltyWrapper, Penalty, AfterSavePenaltyEvent>
    {
        public PenaltyDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PriceCalculationDetailsViewModel : BaseDetailsViewModel<PriceCalculationWrapper, PriceCalculation, AfterSavePriceCalculationEvent>
    {
		//private Func<Task<List<PriceCalculationHistoryItem>>> _getEntitiesForSelectLastHistoryItemCommand;
		private Func<List<PriceCalculationHistoryItem>> _getEntitiesForSelectLastHistoryItemCommand;
		public DelegateLogCommand SelectLastHistoryItemCommand { get; private set; }
		public DelegateLogCommand ClearLastHistoryItemCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectInitiatorCommand;
		private Func<List<User>> _getEntitiesForSelectInitiatorCommand;
		public DelegateLogCommand SelectInitiatorCommand { get; private set; }
		public DelegateLogCommand ClearInitiatorCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectFrontManagerCommand;
		private Func<List<User>> _getEntitiesForSelectFrontManagerCommand;
		public DelegateLogCommand SelectFrontManagerCommand { get; private set; }
		public DelegateLogCommand ClearFrontManagerCommand { get; private set; }

		private Func<List<PriceCalculationItem>> _getEntitiesForAddInPriceCalculationItemsCommand;
		public DelegateLogCommand AddInPriceCalculationItemsCommand { get; }
		public DelegateLogCommand RemoveFromPriceCalculationItemsCommand { get; private set; }
		private PriceCalculationItemWrapper _selectedPriceCalculationItemsItem;
		public PriceCalculationItemWrapper SelectedPriceCalculationItemsItem 
		{ 
			get { return _selectedPriceCalculationItemsItem; }
			set 
			{ 
				if (Equals(_selectedPriceCalculationItemsItem, value)) return;
				_selectedPriceCalculationItemsItem = value;
				RaisePropertyChanged();
				RemoveFromPriceCalculationItemsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceCalculationHistoryItem>> _getEntitiesForAddInHistoryCommand;
		public DelegateLogCommand AddInHistoryCommand { get; }
		public DelegateLogCommand RemoveFromHistoryCommand { get; private set; }
		private PriceCalculationHistoryItemWrapper _selectedHistoryItem;
		public PriceCalculationHistoryItemWrapper SelectedHistoryItem 
		{ 
			get { return _selectedHistoryItem; }
			set 
			{ 
				if (Equals(_selectedHistoryItem, value)) return;
				_selectedHistoryItem = value;
				RaisePropertyChanged();
				RemoveFromHistoryCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceCalculationFile>> _getEntitiesForAddInFilesCommand;
		public DelegateLogCommand AddInFilesCommand { get; }
		public DelegateLogCommand RemoveFromFilesCommand { get; private set; }
		private PriceCalculationFileWrapper _selectedFilesItem;
		public PriceCalculationFileWrapper SelectedFilesItem 
		{ 
			get { return _selectedFilesItem; }
			set 
			{ 
				if (Equals(_selectedFilesItem, value)) return;
				_selectedFilesItem = value;
				RaisePropertyChanged();
				RemoveFromFilesCommand.RaiseCanExecuteChanged();
			}
		}

        public PriceCalculationDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectLastHistoryItemCommand == null) _getEntitiesForSelectLastHistoryItemCommand = () => { return UnitOfWork.Repository<PriceCalculationHistoryItem>().GetAll(); };
			if (SelectLastHistoryItemCommand == null) SelectLastHistoryItemCommand = new DelegateLogCommand(SelectLastHistoryItemCommand_Execute_Default);
			if (ClearLastHistoryItemCommand == null) ClearLastHistoryItemCommand = new DelegateLogCommand(ClearLastHistoryItemCommand_Execute_Default);

			
			if (_getEntitiesForSelectInitiatorCommand == null) _getEntitiesForSelectInitiatorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectInitiatorCommand == null) SelectInitiatorCommand = new DelegateLogCommand(SelectInitiatorCommand_Execute_Default);
			if (ClearInitiatorCommand == null) ClearInitiatorCommand = new DelegateLogCommand(ClearInitiatorCommand_Execute_Default);

			
			if (_getEntitiesForSelectFrontManagerCommand == null) _getEntitiesForSelectFrontManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectFrontManagerCommand == null) SelectFrontManagerCommand = new DelegateLogCommand(SelectFrontManagerCommand_Execute_Default);
			if (ClearFrontManagerCommand == null) ClearFrontManagerCommand = new DelegateLogCommand(ClearFrontManagerCommand_Execute_Default);

			
			if (_getEntitiesForAddInPriceCalculationItemsCommand == null) _getEntitiesForAddInPriceCalculationItemsCommand = () => { return UnitOfWork.Repository<PriceCalculationItem>().GetAll(); };;
			if (AddInPriceCalculationItemsCommand == null) AddInPriceCalculationItemsCommand = new DelegateLogCommand(AddInPriceCalculationItemsCommand_Execute_Default);
			if (RemoveFromPriceCalculationItemsCommand == null) RemoveFromPriceCalculationItemsCommand = new DelegateLogCommand(RemoveFromPriceCalculationItemsCommand_Execute_Default, RemoveFromPriceCalculationItemsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInHistoryCommand == null) _getEntitiesForAddInHistoryCommand = () => { return UnitOfWork.Repository<PriceCalculationHistoryItem>().GetAll(); };;
			if (AddInHistoryCommand == null) AddInHistoryCommand = new DelegateLogCommand(AddInHistoryCommand_Execute_Default);
			if (RemoveFromHistoryCommand == null) RemoveFromHistoryCommand = new DelegateLogCommand(RemoveFromHistoryCommand_Execute_Default, RemoveFromHistoryCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInFilesCommand == null) _getEntitiesForAddInFilesCommand = () => { return UnitOfWork.Repository<PriceCalculationFile>().GetAll(); };;
			if (AddInFilesCommand == null) AddInFilesCommand = new DelegateLogCommand(AddInFilesCommand_Execute_Default);
			if (RemoveFromFilesCommand == null) RemoveFromFilesCommand = new DelegateLogCommand(RemoveFromFilesCommand_Execute_Default, RemoveFromFilesCommand_CanExecute_Default);

		}

		private void SelectLastHistoryItemCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PriceCalculationHistoryItem, PriceCalculationHistoryItemWrapper>(_getEntitiesForSelectLastHistoryItemCommand(), nameof(Item.LastHistoryItem), Item.LastHistoryItem?.Id);
		}

		private void ClearLastHistoryItemCommand_Execute_Default() 
		{
				    
		}

		private void SelectInitiatorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectInitiatorCommand(), nameof(Item.Initiator), Item.Initiator?.Id);
		}

		private void ClearInitiatorCommand_Execute_Default() 
		{
						Item.Initiator = null;		    
		}

		private void SelectFrontManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectFrontManagerCommand(), nameof(Item.FrontManager), Item.FrontManager?.Id);
		}

		private void ClearFrontManagerCommand_Execute_Default() 
		{
				    
		}

			private void AddInPriceCalculationItemsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceCalculationItem, PriceCalculationItemWrapper>(_getEntitiesForAddInPriceCalculationItemsCommand(), Item.PriceCalculationItems);
			}

			private void RemoveFromPriceCalculationItemsCommand_Execute_Default()
			{
				Item.PriceCalculationItems.Remove(SelectedPriceCalculationItemsItem);
			}

			private bool RemoveFromPriceCalculationItemsCommand_CanExecute_Default()
			{
				return SelectedPriceCalculationItemsItem != null;
			}

			private void AddInHistoryCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceCalculationHistoryItem, PriceCalculationHistoryItemWrapper>(_getEntitiesForAddInHistoryCommand(), Item.History);
			}

			private void RemoveFromHistoryCommand_Execute_Default()
			{
				Item.History.Remove(SelectedHistoryItem);
			}

			private bool RemoveFromHistoryCommand_CanExecute_Default()
			{
				return SelectedHistoryItem != null;
			}

			private void AddInFilesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceCalculationFile, PriceCalculationFileWrapper>(_getEntitiesForAddInFilesCommand(), Item.Files);
			}

			private void RemoveFromFilesCommand_Execute_Default()
			{
				Item.Files.Remove(SelectedFilesItem);
			}

			private bool RemoveFromFilesCommand_CanExecute_Default()
			{
				return SelectedFilesItem != null;
			}


    }

    public partial class PriceCalculationFileDetailsViewModel : BaseDetailsViewModel<PriceCalculationFileWrapper, PriceCalculationFile, AfterSavePriceCalculationFileEvent>
    {
        public PriceCalculationFileDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PriceCalculationHistoryItemDetailsViewModel : BaseDetailsViewModel<PriceCalculationHistoryItemWrapper, PriceCalculationHistoryItem, AfterSavePriceCalculationHistoryItemEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectUserCommand;
		private Func<List<User>> _getEntitiesForSelectUserCommand;
		public DelegateLogCommand SelectUserCommand { get; private set; }
		public DelegateLogCommand ClearUserCommand { get; private set; }

        public PriceCalculationHistoryItemDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectUserCommand == null) _getEntitiesForSelectUserCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserCommand == null) SelectUserCommand = new DelegateLogCommand(SelectUserCommand_Execute_Default);
			if (ClearUserCommand == null) ClearUserCommand = new DelegateLogCommand(ClearUserCommand_Execute_Default);

		}

		private void SelectUserCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserCommand(), nameof(Item.User), Item.User?.Id);
		}

		private void ClearUserCommand_Execute_Default() 
		{
						Item.User = null;		    
		}


    }

    public partial class PriceCalculationItemDetailsViewModel : BaseDetailsViewModel<PriceCalculationItemWrapper, PriceCalculationItem, AfterSavePriceCalculationItemEvent>
    {
		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectPaymentConditionSetCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectPaymentConditionSetCommand;
		public DelegateLogCommand SelectPaymentConditionSetCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionSetCommand { get; private set; }

		private Func<List<SalesUnit>> _getEntitiesForAddInSalesUnitsCommand;
		public DelegateLogCommand AddInSalesUnitsCommand { get; }
		public DelegateLogCommand RemoveFromSalesUnitsCommand { get; private set; }
		private SalesUnitWrapper _selectedSalesUnitsItem;
		public SalesUnitWrapper SelectedSalesUnitsItem 
		{ 
			get { return _selectedSalesUnitsItem; }
			set 
			{ 
				if (Equals(_selectedSalesUnitsItem, value)) return;
				_selectedSalesUnitsItem = value;
				RaisePropertyChanged();
				RemoveFromSalesUnitsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<StructureCost>> _getEntitiesForAddInStructureCostsCommand;
		public DelegateLogCommand AddInStructureCostsCommand { get; }
		public DelegateLogCommand RemoveFromStructureCostsCommand { get; private set; }
		private StructureCostWrapper _selectedStructureCostsItem;
		public StructureCostWrapper SelectedStructureCostsItem 
		{ 
			get { return _selectedStructureCostsItem; }
			set 
			{ 
				if (Equals(_selectedStructureCostsItem, value)) return;
				_selectedStructureCostsItem = value;
				RaisePropertyChanged();
				RemoveFromStructureCostsCommand.RaiseCanExecuteChanged();
			}
		}

        public PriceCalculationItemDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectPaymentConditionSetCommand == null) _getEntitiesForSelectPaymentConditionSetCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectPaymentConditionSetCommand == null) SelectPaymentConditionSetCommand = new DelegateLogCommand(SelectPaymentConditionSetCommand_Execute_Default);
			if (ClearPaymentConditionSetCommand == null) ClearPaymentConditionSetCommand = new DelegateLogCommand(ClearPaymentConditionSetCommand_Execute_Default);

			
			if (_getEntitiesForAddInSalesUnitsCommand == null) _getEntitiesForAddInSalesUnitsCommand = () => { return UnitOfWork.Repository<SalesUnit>().GetAll(); };;
			if (AddInSalesUnitsCommand == null) AddInSalesUnitsCommand = new DelegateLogCommand(AddInSalesUnitsCommand_Execute_Default);
			if (RemoveFromSalesUnitsCommand == null) RemoveFromSalesUnitsCommand = new DelegateLogCommand(RemoveFromSalesUnitsCommand_Execute_Default, RemoveFromSalesUnitsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInStructureCostsCommand == null) _getEntitiesForAddInStructureCostsCommand = () => { return UnitOfWork.Repository<StructureCost>().GetAll(); };;
			if (AddInStructureCostsCommand == null) AddInStructureCostsCommand = new DelegateLogCommand(AddInStructureCostsCommand_Execute_Default);
			if (RemoveFromStructureCostsCommand == null) RemoveFromStructureCostsCommand = new DelegateLogCommand(RemoveFromStructureCostsCommand_Execute_Default, RemoveFromStructureCostsCommand_CanExecute_Default);

		}

		private void SelectPaymentConditionSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectPaymentConditionSetCommand(), nameof(Item.PaymentConditionSet), Item.PaymentConditionSet?.Id);
		}

		private void ClearPaymentConditionSetCommand_Execute_Default() 
		{
						Item.PaymentConditionSet = null;		    
		}

			private void AddInSalesUnitsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<SalesUnit, SalesUnitWrapper>(_getEntitiesForAddInSalesUnitsCommand(), Item.SalesUnits);
			}

			private void RemoveFromSalesUnitsCommand_Execute_Default()
			{
				Item.SalesUnits.Remove(SelectedSalesUnitsItem);
			}

			private bool RemoveFromSalesUnitsCommand_CanExecute_Default()
			{
				return SelectedSalesUnitsItem != null;
			}

			private void AddInStructureCostsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<StructureCost, StructureCostWrapper>(_getEntitiesForAddInStructureCostsCommand(), Item.StructureCosts);
			}

			private void RemoveFromStructureCostsCommand_Execute_Default()
			{
				Item.StructureCosts.Remove(SelectedStructureCostsItem);
			}

			private bool RemoveFromStructureCostsCommand_CanExecute_Default()
			{
				return SelectedStructureCostsItem != null;
			}


    }

    public partial class DesignDepartmentParametersDetailsViewModel : BaseDetailsViewModel<DesignDepartmentParametersWrapper, DesignDepartmentParameters, AfterSaveDesignDepartmentParametersEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public DesignDepartmentParametersDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class DesignDepartmentParametersAddedBlocksDetailsViewModel : BaseDetailsViewModel<DesignDepartmentParametersAddedBlocksWrapper, DesignDepartmentParametersAddedBlocks, AfterSaveDesignDepartmentParametersAddedBlocksEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public DesignDepartmentParametersAddedBlocksDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class DesignDepartmentParametersSubTaskDetailsViewModel : BaseDetailsViewModel<DesignDepartmentParametersSubTaskWrapper, DesignDepartmentParametersSubTask, AfterSaveDesignDepartmentParametersSubTaskEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public DesignDepartmentParametersSubTaskDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class NotificationsReportsSettingsDetailsViewModel : BaseDetailsViewModel<NotificationsReportsSettingsWrapper, NotificationsReportsSettings, AfterSaveNotificationsReportsSettingsEvent>
    {
		private Func<List<User>> _getEntitiesForAddInChiefEngineerReportDistributionListCommand;
		public DelegateLogCommand AddInChiefEngineerReportDistributionListCommand { get; }
		public DelegateLogCommand RemoveFromChiefEngineerReportDistributionListCommand { get; private set; }
		private UserWrapper _selectedChiefEngineerReportDistributionListItem;
		public UserWrapper SelectedChiefEngineerReportDistributionListItem 
		{ 
			get { return _selectedChiefEngineerReportDistributionListItem; }
			set 
			{ 
				if (Equals(_selectedChiefEngineerReportDistributionListItem, value)) return;
				_selectedChiefEngineerReportDistributionListItem = value;
				RaisePropertyChanged();
				RemoveFromChiefEngineerReportDistributionListCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<User>> _getEntitiesForAddInSavePaymentDocumentDistributionListCommand;
		public DelegateLogCommand AddInSavePaymentDocumentDistributionListCommand { get; }
		public DelegateLogCommand RemoveFromSavePaymentDocumentDistributionListCommand { get; private set; }
		private UserWrapper _selectedSavePaymentDocumentDistributionListItem;
		public UserWrapper SelectedSavePaymentDocumentDistributionListItem 
		{ 
			get { return _selectedSavePaymentDocumentDistributionListItem; }
			set 
			{ 
				if (Equals(_selectedSavePaymentDocumentDistributionListItem, value)) return;
				_selectedSavePaymentDocumentDistributionListItem = value;
				RaisePropertyChanged();
				RemoveFromSavePaymentDocumentDistributionListCommand.RaiseCanExecuteChanged();
			}
		}

        public NotificationsReportsSettingsDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInChiefEngineerReportDistributionListCommand == null) _getEntitiesForAddInChiefEngineerReportDistributionListCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInChiefEngineerReportDistributionListCommand == null) AddInChiefEngineerReportDistributionListCommand = new DelegateLogCommand(AddInChiefEngineerReportDistributionListCommand_Execute_Default);
			if (RemoveFromChiefEngineerReportDistributionListCommand == null) RemoveFromChiefEngineerReportDistributionListCommand = new DelegateLogCommand(RemoveFromChiefEngineerReportDistributionListCommand_Execute_Default, RemoveFromChiefEngineerReportDistributionListCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInSavePaymentDocumentDistributionListCommand == null) _getEntitiesForAddInSavePaymentDocumentDistributionListCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInSavePaymentDocumentDistributionListCommand == null) AddInSavePaymentDocumentDistributionListCommand = new DelegateLogCommand(AddInSavePaymentDocumentDistributionListCommand_Execute_Default);
			if (RemoveFromSavePaymentDocumentDistributionListCommand == null) RemoveFromSavePaymentDocumentDistributionListCommand = new DelegateLogCommand(RemoveFromSavePaymentDocumentDistributionListCommand_Execute_Default, RemoveFromSavePaymentDocumentDistributionListCommand_CanExecute_Default);

		}

			private void AddInChiefEngineerReportDistributionListCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInChiefEngineerReportDistributionListCommand(), Item.ChiefEngineerReportDistributionList);
			}

			private void RemoveFromChiefEngineerReportDistributionListCommand_Execute_Default()
			{
				Item.ChiefEngineerReportDistributionList.Remove(SelectedChiefEngineerReportDistributionListItem);
			}

			private bool RemoveFromChiefEngineerReportDistributionListCommand_CanExecute_Default()
			{
				return SelectedChiefEngineerReportDistributionListItem != null;
			}

			private void AddInSavePaymentDocumentDistributionListCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInSavePaymentDocumentDistributionListCommand(), Item.SavePaymentDocumentDistributionList);
			}

			private void RemoveFromSavePaymentDocumentDistributionListCommand_Execute_Default()
			{
				Item.SavePaymentDocumentDistributionList.Remove(SelectedSavePaymentDocumentDistributionListItem);
			}

			private bool RemoveFromSavePaymentDocumentDistributionListCommand_CanExecute_Default()
			{
				return SelectedSavePaymentDocumentDistributionListItem != null;
			}


    }

    public partial class PriceEngineeringTaskDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTaskWrapper, PriceEngineeringTask, AfterSavePriceEngineeringTaskEvent>
    {
		//private Func<Task<List<DesignDepartment>>> _getEntitiesForSelectDesignDepartmentCommand;
		private Func<List<DesignDepartment>> _getEntitiesForSelectDesignDepartmentCommand;
		public DelegateLogCommand SelectDesignDepartmentCommand { get; private set; }
		public DelegateLogCommand ClearDesignDepartmentCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectUserConstructorCommand;
		private Func<List<User>> _getEntitiesForSelectUserConstructorCommand;
		public DelegateLogCommand SelectUserConstructorCommand { get; private set; }
		public DelegateLogCommand ClearUserConstructorCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectUserPlanMakerCommand;
		private Func<List<User>> _getEntitiesForSelectUserPlanMakerCommand;
		public DelegateLogCommand SelectUserPlanMakerCommand { get; private set; }
		public DelegateLogCommand ClearUserPlanMakerCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectUserConstructorInspectorCommand;
		private Func<List<User>> _getEntitiesForSelectUserConstructorInspectorCommand;
		public DelegateLogCommand SelectUserConstructorInspectorCommand { get; private set; }
		public DelegateLogCommand ClearUserConstructorInspectorCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectUserConstructorInitiatorCommand;
		private Func<List<User>> _getEntitiesForSelectUserConstructorInitiatorCommand;
		public DelegateLogCommand SelectUserConstructorInitiatorCommand { get; private set; }
		public DelegateLogCommand ClearUserConstructorInitiatorCommand { get; private set; }

		//private Func<Task<List<ProductBlock>>> _getEntitiesForSelectProductBlockManagerCommand;
		private Func<List<ProductBlock>> _getEntitiesForSelectProductBlockManagerCommand;
		public DelegateLogCommand SelectProductBlockManagerCommand { get; private set; }
		public DelegateLogCommand ClearProductBlockManagerCommand { get; private set; }

		//private Func<Task<List<ProductBlock>>> _getEntitiesForSelectProductBlockEngineerCommand;
		private Func<List<ProductBlock>> _getEntitiesForSelectProductBlockEngineerCommand;
		public DelegateLogCommand SelectProductBlockEngineerCommand { get; private set; }
		public DelegateLogCommand ClearProductBlockEngineerCommand { get; private set; }

		//private Func<Task<List<Specification>>> _getEntitiesForSelectSpecificationCommand;
		private Func<List<Specification>> _getEntitiesForSelectSpecificationCommand;
		public DelegateLogCommand SelectSpecificationCommand { get; private set; }
		public DelegateLogCommand ClearSpecificationCommand { get; private set; }

		private Func<List<PriceEngineeringTaskProductBlockAdded>> _getEntitiesForAddInProductBlocksAddedCommand;
		public DelegateLogCommand AddInProductBlocksAddedCommand { get; }
		public DelegateLogCommand RemoveFromProductBlocksAddedCommand { get; private set; }
		private PriceEngineeringTaskProductBlockAddedWrapper _selectedProductBlocksAddedItem;
		public PriceEngineeringTaskProductBlockAddedWrapper SelectedProductBlocksAddedItem 
		{ 
			get { return _selectedProductBlocksAddedItem; }
			set 
			{ 
				if (Equals(_selectedProductBlocksAddedItem, value)) return;
				_selectedProductBlocksAddedItem = value;
				RaisePropertyChanged();
				RemoveFromProductBlocksAddedCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTaskProductBlockAdded>> _getEntitiesForAddInProductBlocksAddedActualCommand;
		public DelegateLogCommand AddInProductBlocksAddedActualCommand { get; }
		public DelegateLogCommand RemoveFromProductBlocksAddedActualCommand { get; private set; }
		private PriceEngineeringTaskProductBlockAddedWrapper _selectedProductBlocksAddedActualItem;
		public PriceEngineeringTaskProductBlockAddedWrapper SelectedProductBlocksAddedActualItem 
		{ 
			get { return _selectedProductBlocksAddedActualItem; }
			set 
			{ 
				if (Equals(_selectedProductBlocksAddedActualItem, value)) return;
				_selectedProductBlocksAddedActualItem = value;
				RaisePropertyChanged();
				RemoveFromProductBlocksAddedActualCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTaskFileTechnicalRequirements>> _getEntitiesForAddInFilesTechnicalRequirementsCommand;
		public DelegateLogCommand AddInFilesTechnicalRequirementsCommand { get; }
		public DelegateLogCommand RemoveFromFilesTechnicalRequirementsCommand { get; private set; }
		private PriceEngineeringTaskFileTechnicalRequirementsWrapper _selectedFilesTechnicalRequirementsItem;
		public PriceEngineeringTaskFileTechnicalRequirementsWrapper SelectedFilesTechnicalRequirementsItem 
		{ 
			get { return _selectedFilesTechnicalRequirementsItem; }
			set 
			{ 
				if (Equals(_selectedFilesTechnicalRequirementsItem, value)) return;
				_selectedFilesTechnicalRequirementsItem = value;
				RaisePropertyChanged();
				RemoveFromFilesTechnicalRequirementsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTaskFileAnswer>> _getEntitiesForAddInFilesAnswersCommand;
		public DelegateLogCommand AddInFilesAnswersCommand { get; }
		public DelegateLogCommand RemoveFromFilesAnswersCommand { get; private set; }
		private PriceEngineeringTaskFileAnswerWrapper _selectedFilesAnswersItem;
		public PriceEngineeringTaskFileAnswerWrapper SelectedFilesAnswersItem 
		{ 
			get { return _selectedFilesAnswersItem; }
			set 
			{ 
				if (Equals(_selectedFilesAnswersItem, value)) return;
				_selectedFilesAnswersItem = value;
				RaisePropertyChanged();
				RemoveFromFilesAnswersCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTaskMessage>> _getEntitiesForAddInMessagesCommand;
		public DelegateLogCommand AddInMessagesCommand { get; }
		public DelegateLogCommand RemoveFromMessagesCommand { get; private set; }
		private PriceEngineeringTaskMessageWrapper _selectedMessagesItem;
		public PriceEngineeringTaskMessageWrapper SelectedMessagesItem 
		{ 
			get { return _selectedMessagesItem; }
			set 
			{ 
				if (Equals(_selectedMessagesItem, value)) return;
				_selectedMessagesItem = value;
				RaisePropertyChanged();
				RemoveFromMessagesCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTask>> _getEntitiesForAddInChildPriceEngineeringTasksCommand;
		public DelegateLogCommand AddInChildPriceEngineeringTasksCommand { get; }
		public DelegateLogCommand RemoveFromChildPriceEngineeringTasksCommand { get; private set; }
		private PriceEngineeringTaskWrapper _selectedChildPriceEngineeringTasksItem;
		public PriceEngineeringTaskWrapper SelectedChildPriceEngineeringTasksItem 
		{ 
			get { return _selectedChildPriceEngineeringTasksItem; }
			set 
			{ 
				if (Equals(_selectedChildPriceEngineeringTasksItem, value)) return;
				_selectedChildPriceEngineeringTasksItem = value;
				RaisePropertyChanged();
				RemoveFromChildPriceEngineeringTasksCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<StructureCostVersion>> _getEntitiesForAddInStructureCostVersionsCommand;
		public DelegateLogCommand AddInStructureCostVersionsCommand { get; }
		public DelegateLogCommand RemoveFromStructureCostVersionsCommand { get; private set; }
		private StructureCostVersionWrapper _selectedStructureCostVersionsItem;
		public StructureCostVersionWrapper SelectedStructureCostVersionsItem 
		{ 
			get { return _selectedStructureCostVersionsItem; }
			set 
			{ 
				if (Equals(_selectedStructureCostVersionsItem, value)) return;
				_selectedStructureCostVersionsItem = value;
				RaisePropertyChanged();
				RemoveFromStructureCostVersionsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceCalculationItem>> _getEntitiesForAddInPriceCalculationItemsCommand;
		public DelegateLogCommand AddInPriceCalculationItemsCommand { get; }
		public DelegateLogCommand RemoveFromPriceCalculationItemsCommand { get; private set; }
		private PriceCalculationItemWrapper _selectedPriceCalculationItemsItem;
		public PriceCalculationItemWrapper SelectedPriceCalculationItemsItem 
		{ 
			get { return _selectedPriceCalculationItemsItem; }
			set 
			{ 
				if (Equals(_selectedPriceCalculationItemsItem, value)) return;
				_selectedPriceCalculationItemsItem = value;
				RaisePropertyChanged();
				RemoveFromPriceCalculationItemsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTaskStatus>> _getEntitiesForAddInStatusesCommand;
		public DelegateLogCommand AddInStatusesCommand { get; }
		public DelegateLogCommand RemoveFromStatusesCommand { get; private set; }
		private PriceEngineeringTaskStatusWrapper _selectedStatusesItem;
		public PriceEngineeringTaskStatusWrapper SelectedStatusesItem 
		{ 
			get { return _selectedStatusesItem; }
			set 
			{ 
				if (Equals(_selectedStatusesItem, value)) return;
				_selectedStatusesItem = value;
				RaisePropertyChanged();
				RemoveFromStatusesCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<SalesUnit>> _getEntitiesForAddInSalesUnitsCommand;
		public DelegateLogCommand AddInSalesUnitsCommand { get; }
		public DelegateLogCommand RemoveFromSalesUnitsCommand { get; private set; }
		private SalesUnitWrapper _selectedSalesUnitsItem;
		public SalesUnitWrapper SelectedSalesUnitsItem 
		{ 
			get { return _selectedSalesUnitsItem; }
			set 
			{ 
				if (Equals(_selectedSalesUnitsItem, value)) return;
				_selectedSalesUnitsItem = value;
				RaisePropertyChanged();
				RemoveFromSalesUnitsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<UpdateStructureCostNumberTask>> _getEntitiesForAddInUpdateStructureCostNumberTasksCommand;
		public DelegateLogCommand AddInUpdateStructureCostNumberTasksCommand { get; }
		public DelegateLogCommand RemoveFromUpdateStructureCostNumberTasksCommand { get; private set; }
		private UpdateStructureCostNumberTaskWrapper _selectedUpdateStructureCostNumberTasksItem;
		public UpdateStructureCostNumberTaskWrapper SelectedUpdateStructureCostNumberTasksItem 
		{ 
			get { return _selectedUpdateStructureCostNumberTasksItem; }
			set 
			{ 
				if (Equals(_selectedUpdateStructureCostNumberTasksItem, value)) return;
				_selectedUpdateStructureCostNumberTasksItem = value;
				RaisePropertyChanged();
				RemoveFromUpdateStructureCostNumberTasksCommand.RaiseCanExecuteChanged();
			}
		}

        public PriceEngineeringTaskDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectDesignDepartmentCommand == null) _getEntitiesForSelectDesignDepartmentCommand = () => { return UnitOfWork.Repository<DesignDepartment>().GetAll(); };
			if (SelectDesignDepartmentCommand == null) SelectDesignDepartmentCommand = new DelegateLogCommand(SelectDesignDepartmentCommand_Execute_Default);
			if (ClearDesignDepartmentCommand == null) ClearDesignDepartmentCommand = new DelegateLogCommand(ClearDesignDepartmentCommand_Execute_Default);

			
			if (_getEntitiesForSelectUserConstructorCommand == null) _getEntitiesForSelectUserConstructorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserConstructorCommand == null) SelectUserConstructorCommand = new DelegateLogCommand(SelectUserConstructorCommand_Execute_Default);
			if (ClearUserConstructorCommand == null) ClearUserConstructorCommand = new DelegateLogCommand(ClearUserConstructorCommand_Execute_Default);

			
			if (_getEntitiesForSelectUserPlanMakerCommand == null) _getEntitiesForSelectUserPlanMakerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserPlanMakerCommand == null) SelectUserPlanMakerCommand = new DelegateLogCommand(SelectUserPlanMakerCommand_Execute_Default);
			if (ClearUserPlanMakerCommand == null) ClearUserPlanMakerCommand = new DelegateLogCommand(ClearUserPlanMakerCommand_Execute_Default);

			
			if (_getEntitiesForSelectUserConstructorInspectorCommand == null) _getEntitiesForSelectUserConstructorInspectorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserConstructorInspectorCommand == null) SelectUserConstructorInspectorCommand = new DelegateLogCommand(SelectUserConstructorInspectorCommand_Execute_Default);
			if (ClearUserConstructorInspectorCommand == null) ClearUserConstructorInspectorCommand = new DelegateLogCommand(ClearUserConstructorInspectorCommand_Execute_Default);

			
			if (_getEntitiesForSelectUserConstructorInitiatorCommand == null) _getEntitiesForSelectUserConstructorInitiatorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserConstructorInitiatorCommand == null) SelectUserConstructorInitiatorCommand = new DelegateLogCommand(SelectUserConstructorInitiatorCommand_Execute_Default);
			if (ClearUserConstructorInitiatorCommand == null) ClearUserConstructorInitiatorCommand = new DelegateLogCommand(ClearUserConstructorInitiatorCommand_Execute_Default);

			
			if (_getEntitiesForSelectProductBlockManagerCommand == null) _getEntitiesForSelectProductBlockManagerCommand = () => { return UnitOfWork.Repository<ProductBlock>().GetAll(); };
			if (SelectProductBlockManagerCommand == null) SelectProductBlockManagerCommand = new DelegateLogCommand(SelectProductBlockManagerCommand_Execute_Default);
			if (ClearProductBlockManagerCommand == null) ClearProductBlockManagerCommand = new DelegateLogCommand(ClearProductBlockManagerCommand_Execute_Default);

			
			if (_getEntitiesForSelectProductBlockEngineerCommand == null) _getEntitiesForSelectProductBlockEngineerCommand = () => { return UnitOfWork.Repository<ProductBlock>().GetAll(); };
			if (SelectProductBlockEngineerCommand == null) SelectProductBlockEngineerCommand = new DelegateLogCommand(SelectProductBlockEngineerCommand_Execute_Default);
			if (ClearProductBlockEngineerCommand == null) ClearProductBlockEngineerCommand = new DelegateLogCommand(ClearProductBlockEngineerCommand_Execute_Default);

			
			if (_getEntitiesForSelectSpecificationCommand == null) _getEntitiesForSelectSpecificationCommand = () => { return UnitOfWork.Repository<Specification>().GetAll(); };
			if (SelectSpecificationCommand == null) SelectSpecificationCommand = new DelegateLogCommand(SelectSpecificationCommand_Execute_Default);
			if (ClearSpecificationCommand == null) ClearSpecificationCommand = new DelegateLogCommand(ClearSpecificationCommand_Execute_Default);

			
			if (_getEntitiesForAddInProductBlocksAddedCommand == null) _getEntitiesForAddInProductBlocksAddedCommand = () => { return UnitOfWork.Repository<PriceEngineeringTaskProductBlockAdded>().GetAll(); };;
			if (AddInProductBlocksAddedCommand == null) AddInProductBlocksAddedCommand = new DelegateLogCommand(AddInProductBlocksAddedCommand_Execute_Default);
			if (RemoveFromProductBlocksAddedCommand == null) RemoveFromProductBlocksAddedCommand = new DelegateLogCommand(RemoveFromProductBlocksAddedCommand_Execute_Default, RemoveFromProductBlocksAddedCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInProductBlocksAddedActualCommand == null) _getEntitiesForAddInProductBlocksAddedActualCommand = () => { return UnitOfWork.Repository<PriceEngineeringTaskProductBlockAdded>().GetAll(); };;
			if (AddInProductBlocksAddedActualCommand == null) AddInProductBlocksAddedActualCommand = new DelegateLogCommand(AddInProductBlocksAddedActualCommand_Execute_Default);
			if (RemoveFromProductBlocksAddedActualCommand == null) RemoveFromProductBlocksAddedActualCommand = new DelegateLogCommand(RemoveFromProductBlocksAddedActualCommand_Execute_Default, RemoveFromProductBlocksAddedActualCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInFilesTechnicalRequirementsCommand == null) _getEntitiesForAddInFilesTechnicalRequirementsCommand = () => { return UnitOfWork.Repository<PriceEngineeringTaskFileTechnicalRequirements>().GetAll(); };;
			if (AddInFilesTechnicalRequirementsCommand == null) AddInFilesTechnicalRequirementsCommand = new DelegateLogCommand(AddInFilesTechnicalRequirementsCommand_Execute_Default);
			if (RemoveFromFilesTechnicalRequirementsCommand == null) RemoveFromFilesTechnicalRequirementsCommand = new DelegateLogCommand(RemoveFromFilesTechnicalRequirementsCommand_Execute_Default, RemoveFromFilesTechnicalRequirementsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInFilesAnswersCommand == null) _getEntitiesForAddInFilesAnswersCommand = () => { return UnitOfWork.Repository<PriceEngineeringTaskFileAnswer>().GetAll(); };;
			if (AddInFilesAnswersCommand == null) AddInFilesAnswersCommand = new DelegateLogCommand(AddInFilesAnswersCommand_Execute_Default);
			if (RemoveFromFilesAnswersCommand == null) RemoveFromFilesAnswersCommand = new DelegateLogCommand(RemoveFromFilesAnswersCommand_Execute_Default, RemoveFromFilesAnswersCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInMessagesCommand == null) _getEntitiesForAddInMessagesCommand = () => { return UnitOfWork.Repository<PriceEngineeringTaskMessage>().GetAll(); };;
			if (AddInMessagesCommand == null) AddInMessagesCommand = new DelegateLogCommand(AddInMessagesCommand_Execute_Default);
			if (RemoveFromMessagesCommand == null) RemoveFromMessagesCommand = new DelegateLogCommand(RemoveFromMessagesCommand_Execute_Default, RemoveFromMessagesCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInChildPriceEngineeringTasksCommand == null) _getEntitiesForAddInChildPriceEngineeringTasksCommand = () => { return UnitOfWork.Repository<PriceEngineeringTask>().GetAll(); };;
			if (AddInChildPriceEngineeringTasksCommand == null) AddInChildPriceEngineeringTasksCommand = new DelegateLogCommand(AddInChildPriceEngineeringTasksCommand_Execute_Default);
			if (RemoveFromChildPriceEngineeringTasksCommand == null) RemoveFromChildPriceEngineeringTasksCommand = new DelegateLogCommand(RemoveFromChildPriceEngineeringTasksCommand_Execute_Default, RemoveFromChildPriceEngineeringTasksCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInStructureCostVersionsCommand == null) _getEntitiesForAddInStructureCostVersionsCommand = () => { return UnitOfWork.Repository<StructureCostVersion>().GetAll(); };;
			if (AddInStructureCostVersionsCommand == null) AddInStructureCostVersionsCommand = new DelegateLogCommand(AddInStructureCostVersionsCommand_Execute_Default);
			if (RemoveFromStructureCostVersionsCommand == null) RemoveFromStructureCostVersionsCommand = new DelegateLogCommand(RemoveFromStructureCostVersionsCommand_Execute_Default, RemoveFromStructureCostVersionsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPriceCalculationItemsCommand == null) _getEntitiesForAddInPriceCalculationItemsCommand = () => { return UnitOfWork.Repository<PriceCalculationItem>().GetAll(); };;
			if (AddInPriceCalculationItemsCommand == null) AddInPriceCalculationItemsCommand = new DelegateLogCommand(AddInPriceCalculationItemsCommand_Execute_Default);
			if (RemoveFromPriceCalculationItemsCommand == null) RemoveFromPriceCalculationItemsCommand = new DelegateLogCommand(RemoveFromPriceCalculationItemsCommand_Execute_Default, RemoveFromPriceCalculationItemsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInStatusesCommand == null) _getEntitiesForAddInStatusesCommand = () => { return UnitOfWork.Repository<PriceEngineeringTaskStatus>().GetAll(); };;
			if (AddInStatusesCommand == null) AddInStatusesCommand = new DelegateLogCommand(AddInStatusesCommand_Execute_Default);
			if (RemoveFromStatusesCommand == null) RemoveFromStatusesCommand = new DelegateLogCommand(RemoveFromStatusesCommand_Execute_Default, RemoveFromStatusesCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInSalesUnitsCommand == null) _getEntitiesForAddInSalesUnitsCommand = () => { return UnitOfWork.Repository<SalesUnit>().GetAll(); };;
			if (AddInSalesUnitsCommand == null) AddInSalesUnitsCommand = new DelegateLogCommand(AddInSalesUnitsCommand_Execute_Default);
			if (RemoveFromSalesUnitsCommand == null) RemoveFromSalesUnitsCommand = new DelegateLogCommand(RemoveFromSalesUnitsCommand_Execute_Default, RemoveFromSalesUnitsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInUpdateStructureCostNumberTasksCommand == null) _getEntitiesForAddInUpdateStructureCostNumberTasksCommand = () => { return UnitOfWork.Repository<UpdateStructureCostNumberTask>().GetAll(); };;
			if (AddInUpdateStructureCostNumberTasksCommand == null) AddInUpdateStructureCostNumberTasksCommand = new DelegateLogCommand(AddInUpdateStructureCostNumberTasksCommand_Execute_Default);
			if (RemoveFromUpdateStructureCostNumberTasksCommand == null) RemoveFromUpdateStructureCostNumberTasksCommand = new DelegateLogCommand(RemoveFromUpdateStructureCostNumberTasksCommand_Execute_Default, RemoveFromUpdateStructureCostNumberTasksCommand_CanExecute_Default);

		}

		private void SelectDesignDepartmentCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DesignDepartment, DesignDepartmentWrapper>(_getEntitiesForSelectDesignDepartmentCommand(), nameof(Item.DesignDepartment), Item.DesignDepartment?.Id);
		}

		private void ClearDesignDepartmentCommand_Execute_Default() 
		{
						Item.DesignDepartment = null;		    
		}

		private void SelectUserConstructorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserConstructorCommand(), nameof(Item.UserConstructor), Item.UserConstructor?.Id);
		}

		private void ClearUserConstructorCommand_Execute_Default() 
		{
						Item.UserConstructor = null;		    
		}

		private void SelectUserPlanMakerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserPlanMakerCommand(), nameof(Item.UserPlanMaker), Item.UserPlanMaker?.Id);
		}

		private void ClearUserPlanMakerCommand_Execute_Default() 
		{
						Item.UserPlanMaker = null;		    
		}

		private void SelectUserConstructorInspectorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserConstructorInspectorCommand(), nameof(Item.UserConstructorInspector), Item.UserConstructorInspector?.Id);
		}

		private void ClearUserConstructorInspectorCommand_Execute_Default() 
		{
						Item.UserConstructorInspector = null;		    
		}

		private void SelectUserConstructorInitiatorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserConstructorInitiatorCommand(), nameof(Item.UserConstructorInitiator), Item.UserConstructorInitiator?.Id);
		}

		private void ClearUserConstructorInitiatorCommand_Execute_Default() 
		{
						Item.UserConstructorInitiator = null;		    
		}

		private void SelectProductBlockManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductBlock, ProductBlockWrapper>(_getEntitiesForSelectProductBlockManagerCommand(), nameof(Item.ProductBlockManager), Item.ProductBlockManager?.Id);
		}

		private void ClearProductBlockManagerCommand_Execute_Default() 
		{
						Item.ProductBlockManager = null;		    
		}

		private void SelectProductBlockEngineerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductBlock, ProductBlockWrapper>(_getEntitiesForSelectProductBlockEngineerCommand(), nameof(Item.ProductBlockEngineer), Item.ProductBlockEngineer?.Id);
		}

		private void ClearProductBlockEngineerCommand_Execute_Default() 
		{
						Item.ProductBlockEngineer = null;		    
		}

		private void SelectSpecificationCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Specification, SpecificationWrapper>(_getEntitiesForSelectSpecificationCommand(), nameof(Item.Specification), Item.Specification?.Id);
		}

		private void ClearSpecificationCommand_Execute_Default() 
		{
						Item.Specification = null;		    
		}

			private void AddInProductBlocksAddedCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTaskProductBlockAdded, PriceEngineeringTaskProductBlockAddedWrapper>(_getEntitiesForAddInProductBlocksAddedCommand(), Item.ProductBlocksAdded);
			}

			private void RemoveFromProductBlocksAddedCommand_Execute_Default()
			{
				Item.ProductBlocksAdded.Remove(SelectedProductBlocksAddedItem);
			}

			private bool RemoveFromProductBlocksAddedCommand_CanExecute_Default()
			{
				return SelectedProductBlocksAddedItem != null;
			}

			private void AddInProductBlocksAddedActualCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTaskProductBlockAdded, PriceEngineeringTaskProductBlockAddedWrapper>(_getEntitiesForAddInProductBlocksAddedActualCommand(), Item.ProductBlocksAddedActual);
			}

			private void RemoveFromProductBlocksAddedActualCommand_Execute_Default()
			{
				Item.ProductBlocksAddedActual.Remove(SelectedProductBlocksAddedActualItem);
			}

			private bool RemoveFromProductBlocksAddedActualCommand_CanExecute_Default()
			{
				return SelectedProductBlocksAddedActualItem != null;
			}

			private void AddInFilesTechnicalRequirementsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTaskFileTechnicalRequirements, PriceEngineeringTaskFileTechnicalRequirementsWrapper>(_getEntitiesForAddInFilesTechnicalRequirementsCommand(), Item.FilesTechnicalRequirements);
			}

			private void RemoveFromFilesTechnicalRequirementsCommand_Execute_Default()
			{
				Item.FilesTechnicalRequirements.Remove(SelectedFilesTechnicalRequirementsItem);
			}

			private bool RemoveFromFilesTechnicalRequirementsCommand_CanExecute_Default()
			{
				return SelectedFilesTechnicalRequirementsItem != null;
			}

			private void AddInFilesAnswersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTaskFileAnswer, PriceEngineeringTaskFileAnswerWrapper>(_getEntitiesForAddInFilesAnswersCommand(), Item.FilesAnswers);
			}

			private void RemoveFromFilesAnswersCommand_Execute_Default()
			{
				Item.FilesAnswers.Remove(SelectedFilesAnswersItem);
			}

			private bool RemoveFromFilesAnswersCommand_CanExecute_Default()
			{
				return SelectedFilesAnswersItem != null;
			}

			private void AddInMessagesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTaskMessage, PriceEngineeringTaskMessageWrapper>(_getEntitiesForAddInMessagesCommand(), Item.Messages);
			}

			private void RemoveFromMessagesCommand_Execute_Default()
			{
				Item.Messages.Remove(SelectedMessagesItem);
			}

			private bool RemoveFromMessagesCommand_CanExecute_Default()
			{
				return SelectedMessagesItem != null;
			}

			private void AddInChildPriceEngineeringTasksCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTask, PriceEngineeringTaskWrapper>(_getEntitiesForAddInChildPriceEngineeringTasksCommand(), Item.ChildPriceEngineeringTasks);
			}

			private void RemoveFromChildPriceEngineeringTasksCommand_Execute_Default()
			{
				Item.ChildPriceEngineeringTasks.Remove(SelectedChildPriceEngineeringTasksItem);
			}

			private bool RemoveFromChildPriceEngineeringTasksCommand_CanExecute_Default()
			{
				return SelectedChildPriceEngineeringTasksItem != null;
			}

			private void AddInStructureCostVersionsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<StructureCostVersion, StructureCostVersionWrapper>(_getEntitiesForAddInStructureCostVersionsCommand(), Item.StructureCostVersions);
			}

			private void RemoveFromStructureCostVersionsCommand_Execute_Default()
			{
				Item.StructureCostVersions.Remove(SelectedStructureCostVersionsItem);
			}

			private bool RemoveFromStructureCostVersionsCommand_CanExecute_Default()
			{
				return SelectedStructureCostVersionsItem != null;
			}

			private void AddInPriceCalculationItemsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceCalculationItem, PriceCalculationItemWrapper>(_getEntitiesForAddInPriceCalculationItemsCommand(), Item.PriceCalculationItems);
			}

			private void RemoveFromPriceCalculationItemsCommand_Execute_Default()
			{
				Item.PriceCalculationItems.Remove(SelectedPriceCalculationItemsItem);
			}

			private bool RemoveFromPriceCalculationItemsCommand_CanExecute_Default()
			{
				return SelectedPriceCalculationItemsItem != null;
			}

			private void AddInStatusesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTaskStatus, PriceEngineeringTaskStatusWrapper>(_getEntitiesForAddInStatusesCommand(), Item.Statuses);
			}

			private void RemoveFromStatusesCommand_Execute_Default()
			{
				Item.Statuses.Remove(SelectedStatusesItem);
			}

			private bool RemoveFromStatusesCommand_CanExecute_Default()
			{
				return SelectedStatusesItem != null;
			}

			private void AddInSalesUnitsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<SalesUnit, SalesUnitWrapper>(_getEntitiesForAddInSalesUnitsCommand(), Item.SalesUnits);
			}

			private void RemoveFromSalesUnitsCommand_Execute_Default()
			{
				Item.SalesUnits.Remove(SelectedSalesUnitsItem);
			}

			private bool RemoveFromSalesUnitsCommand_CanExecute_Default()
			{
				return SelectedSalesUnitsItem != null;
			}

			private void AddInUpdateStructureCostNumberTasksCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<UpdateStructureCostNumberTask, UpdateStructureCostNumberTaskWrapper>(_getEntitiesForAddInUpdateStructureCostNumberTasksCommand(), Item.UpdateStructureCostNumberTasks);
			}

			private void RemoveFromUpdateStructureCostNumberTasksCommand_Execute_Default()
			{
				Item.UpdateStructureCostNumberTasks.Remove(SelectedUpdateStructureCostNumberTasksItem);
			}

			private bool RemoveFromUpdateStructureCostNumberTasksCommand_CanExecute_Default()
			{
				return SelectedUpdateStructureCostNumberTasksItem != null;
			}


    }

    public partial class PriceEngineeringTaskFileAnswerDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTaskFileAnswerWrapper, PriceEngineeringTaskFileAnswer, AfterSavePriceEngineeringTaskFileAnswerEvent>
    {
        public PriceEngineeringTaskFileAnswerDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PriceEngineeringTaskFileTechnicalRequirementsDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTaskFileTechnicalRequirementsWrapper, PriceEngineeringTaskFileTechnicalRequirements, AfterSavePriceEngineeringTaskFileTechnicalRequirementsEvent>
    {
        public PriceEngineeringTaskFileTechnicalRequirementsDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PriceEngineeringTaskMessageDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTaskMessageWrapper, PriceEngineeringTaskMessage, AfterSavePriceEngineeringTaskMessageEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<User>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

        public PriceEngineeringTaskMessageDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}


    }

    public partial class PriceEngineeringTaskProductBlockAddedDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTaskProductBlockAddedWrapper, PriceEngineeringTaskProductBlockAdded, AfterSavePriceEngineeringTaskProductBlockAddedEvent>
    {
		//private Func<Task<List<ProductBlock>>> _getEntitiesForSelectProductBlockCommand;
		private Func<List<ProductBlock>> _getEntitiesForSelectProductBlockCommand;
		public DelegateLogCommand SelectProductBlockCommand { get; private set; }
		public DelegateLogCommand ClearProductBlockCommand { get; private set; }

		private Func<List<StructureCostVersion>> _getEntitiesForAddInStructureCostVersionsCommand;
		public DelegateLogCommand AddInStructureCostVersionsCommand { get; }
		public DelegateLogCommand RemoveFromStructureCostVersionsCommand { get; private set; }
		private StructureCostVersionWrapper _selectedStructureCostVersionsItem;
		public StructureCostVersionWrapper SelectedStructureCostVersionsItem 
		{ 
			get { return _selectedStructureCostVersionsItem; }
			set 
			{ 
				if (Equals(_selectedStructureCostVersionsItem, value)) return;
				_selectedStructureCostVersionsItem = value;
				RaisePropertyChanged();
				RemoveFromStructureCostVersionsCommand.RaiseCanExecuteChanged();
			}
		}

        public PriceEngineeringTaskProductBlockAddedDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductBlockCommand == null) _getEntitiesForSelectProductBlockCommand = () => { return UnitOfWork.Repository<ProductBlock>().GetAll(); };
			if (SelectProductBlockCommand == null) SelectProductBlockCommand = new DelegateLogCommand(SelectProductBlockCommand_Execute_Default);
			if (ClearProductBlockCommand == null) ClearProductBlockCommand = new DelegateLogCommand(ClearProductBlockCommand_Execute_Default);

			
			if (_getEntitiesForAddInStructureCostVersionsCommand == null) _getEntitiesForAddInStructureCostVersionsCommand = () => { return UnitOfWork.Repository<StructureCostVersion>().GetAll(); };;
			if (AddInStructureCostVersionsCommand == null) AddInStructureCostVersionsCommand = new DelegateLogCommand(AddInStructureCostVersionsCommand_Execute_Default);
			if (RemoveFromStructureCostVersionsCommand == null) RemoveFromStructureCostVersionsCommand = new DelegateLogCommand(RemoveFromStructureCostVersionsCommand_Execute_Default, RemoveFromStructureCostVersionsCommand_CanExecute_Default);

		}

		private void SelectProductBlockCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductBlock, ProductBlockWrapper>(_getEntitiesForSelectProductBlockCommand(), nameof(Item.ProductBlock), Item.ProductBlock?.Id);
		}

		private void ClearProductBlockCommand_Execute_Default() 
		{
						Item.ProductBlock = null;		    
		}

			private void AddInStructureCostVersionsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<StructureCostVersion, StructureCostVersionWrapper>(_getEntitiesForAddInStructureCostVersionsCommand(), Item.StructureCostVersions);
			}

			private void RemoveFromStructureCostVersionsCommand_Execute_Default()
			{
				Item.StructureCostVersions.Remove(SelectedStructureCostVersionsItem);
			}

			private bool RemoveFromStructureCostVersionsCommand_CanExecute_Default()
			{
				return SelectedStructureCostVersionsItem != null;
			}


    }

    public partial class PriceEngineeringTasksDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTasksWrapper, PriceEngineeringTasks, AfterSavePriceEngineeringTasksEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectUserManagerCommand;
		private Func<List<User>> _getEntitiesForSelectUserManagerCommand;
		public DelegateLogCommand SelectUserManagerCommand { get; private set; }
		public DelegateLogCommand ClearUserManagerCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectBackManagerCommand;
		private Func<List<User>> _getEntitiesForSelectBackManagerCommand;
		public DelegateLogCommand SelectBackManagerCommand { get; private set; }
		public DelegateLogCommand ClearBackManagerCommand { get; private set; }

		private Func<List<PriceEngineeringTasksFileTechnicalRequirements>> _getEntitiesForAddInFilesTechnicalRequirementsCommand;
		public DelegateLogCommand AddInFilesTechnicalRequirementsCommand { get; }
		public DelegateLogCommand RemoveFromFilesTechnicalRequirementsCommand { get; private set; }
		private PriceEngineeringTasksFileTechnicalRequirementsWrapper _selectedFilesTechnicalRequirementsItem;
		public PriceEngineeringTasksFileTechnicalRequirementsWrapper SelectedFilesTechnicalRequirementsItem 
		{ 
			get { return _selectedFilesTechnicalRequirementsItem; }
			set 
			{ 
				if (Equals(_selectedFilesTechnicalRequirementsItem, value)) return;
				_selectedFilesTechnicalRequirementsItem = value;
				RaisePropertyChanged();
				RemoveFromFilesTechnicalRequirementsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceEngineeringTask>> _getEntitiesForAddInChildPriceEngineeringTasksCommand;
		public DelegateLogCommand AddInChildPriceEngineeringTasksCommand { get; }
		public DelegateLogCommand RemoveFromChildPriceEngineeringTasksCommand { get; private set; }
		private PriceEngineeringTaskWrapper _selectedChildPriceEngineeringTasksItem;
		public PriceEngineeringTaskWrapper SelectedChildPriceEngineeringTasksItem 
		{ 
			get { return _selectedChildPriceEngineeringTasksItem; }
			set 
			{ 
				if (Equals(_selectedChildPriceEngineeringTasksItem, value)) return;
				_selectedChildPriceEngineeringTasksItem = value;
				RaisePropertyChanged();
				RemoveFromChildPriceEngineeringTasksCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceCalculation>> _getEntitiesForAddInPriceCalculationsCommand;
		public DelegateLogCommand AddInPriceCalculationsCommand { get; }
		public DelegateLogCommand RemoveFromPriceCalculationsCommand { get; private set; }
		private PriceCalculationWrapper _selectedPriceCalculationsItem;
		public PriceCalculationWrapper SelectedPriceCalculationsItem 
		{ 
			get { return _selectedPriceCalculationsItem; }
			set 
			{ 
				if (Equals(_selectedPriceCalculationsItem, value)) return;
				_selectedPriceCalculationsItem = value;
				RaisePropertyChanged();
				RemoveFromPriceCalculationsCommand.RaiseCanExecuteChanged();
			}
		}

        public PriceEngineeringTasksDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectUserManagerCommand == null) _getEntitiesForSelectUserManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserManagerCommand == null) SelectUserManagerCommand = new DelegateLogCommand(SelectUserManagerCommand_Execute_Default);
			if (ClearUserManagerCommand == null) ClearUserManagerCommand = new DelegateLogCommand(ClearUserManagerCommand_Execute_Default);

			
			if (_getEntitiesForSelectBackManagerCommand == null) _getEntitiesForSelectBackManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectBackManagerCommand == null) SelectBackManagerCommand = new DelegateLogCommand(SelectBackManagerCommand_Execute_Default);
			if (ClearBackManagerCommand == null) ClearBackManagerCommand = new DelegateLogCommand(ClearBackManagerCommand_Execute_Default);

			
			if (_getEntitiesForAddInFilesTechnicalRequirementsCommand == null) _getEntitiesForAddInFilesTechnicalRequirementsCommand = () => { return UnitOfWork.Repository<PriceEngineeringTasksFileTechnicalRequirements>().GetAll(); };;
			if (AddInFilesTechnicalRequirementsCommand == null) AddInFilesTechnicalRequirementsCommand = new DelegateLogCommand(AddInFilesTechnicalRequirementsCommand_Execute_Default);
			if (RemoveFromFilesTechnicalRequirementsCommand == null) RemoveFromFilesTechnicalRequirementsCommand = new DelegateLogCommand(RemoveFromFilesTechnicalRequirementsCommand_Execute_Default, RemoveFromFilesTechnicalRequirementsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInChildPriceEngineeringTasksCommand == null) _getEntitiesForAddInChildPriceEngineeringTasksCommand = () => { return UnitOfWork.Repository<PriceEngineeringTask>().GetAll(); };;
			if (AddInChildPriceEngineeringTasksCommand == null) AddInChildPriceEngineeringTasksCommand = new DelegateLogCommand(AddInChildPriceEngineeringTasksCommand_Execute_Default);
			if (RemoveFromChildPriceEngineeringTasksCommand == null) RemoveFromChildPriceEngineeringTasksCommand = new DelegateLogCommand(RemoveFromChildPriceEngineeringTasksCommand_Execute_Default, RemoveFromChildPriceEngineeringTasksCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPriceCalculationsCommand == null) _getEntitiesForAddInPriceCalculationsCommand = () => { return UnitOfWork.Repository<PriceCalculation>().GetAll(); };;
			if (AddInPriceCalculationsCommand == null) AddInPriceCalculationsCommand = new DelegateLogCommand(AddInPriceCalculationsCommand_Execute_Default);
			if (RemoveFromPriceCalculationsCommand == null) RemoveFromPriceCalculationsCommand = new DelegateLogCommand(RemoveFromPriceCalculationsCommand_Execute_Default, RemoveFromPriceCalculationsCommand_CanExecute_Default);

		}

		private void SelectUserManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserManagerCommand(), nameof(Item.UserManager), Item.UserManager?.Id);
		}

		private void ClearUserManagerCommand_Execute_Default() 
		{
						Item.UserManager = null;		    
		}

		private void SelectBackManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectBackManagerCommand(), nameof(Item.BackManager), Item.BackManager?.Id);
		}

		private void ClearBackManagerCommand_Execute_Default() 
		{
						Item.BackManager = null;		    
		}

			private void AddInFilesTechnicalRequirementsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTasksFileTechnicalRequirements, PriceEngineeringTasksFileTechnicalRequirementsWrapper>(_getEntitiesForAddInFilesTechnicalRequirementsCommand(), Item.FilesTechnicalRequirements);
			}

			private void RemoveFromFilesTechnicalRequirementsCommand_Execute_Default()
			{
				Item.FilesTechnicalRequirements.Remove(SelectedFilesTechnicalRequirementsItem);
			}

			private bool RemoveFromFilesTechnicalRequirementsCommand_CanExecute_Default()
			{
				return SelectedFilesTechnicalRequirementsItem != null;
			}

			private void AddInChildPriceEngineeringTasksCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceEngineeringTask, PriceEngineeringTaskWrapper>(_getEntitiesForAddInChildPriceEngineeringTasksCommand(), Item.ChildPriceEngineeringTasks);
			}

			private void RemoveFromChildPriceEngineeringTasksCommand_Execute_Default()
			{
				Item.ChildPriceEngineeringTasks.Remove(SelectedChildPriceEngineeringTasksItem);
			}

			private bool RemoveFromChildPriceEngineeringTasksCommand_CanExecute_Default()
			{
				return SelectedChildPriceEngineeringTasksItem != null;
			}

			private void AddInPriceCalculationsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceCalculation, PriceCalculationWrapper>(_getEntitiesForAddInPriceCalculationsCommand(), Item.PriceCalculations);
			}

			private void RemoveFromPriceCalculationsCommand_Execute_Default()
			{
				Item.PriceCalculations.Remove(SelectedPriceCalculationsItem);
			}

			private bool RemoveFromPriceCalculationsCommand_CanExecute_Default()
			{
				return SelectedPriceCalculationsItem != null;
			}


    }

    public partial class PriceEngineeringTasksFileTechnicalRequirementsDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTasksFileTechnicalRequirementsWrapper, PriceEngineeringTasksFileTechnicalRequirements, AfterSavePriceEngineeringTasksFileTechnicalRequirementsEvent>
    {
        public PriceEngineeringTasksFileTechnicalRequirementsDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PriceEngineeringTaskStatusDetailsViewModel : BaseDetailsViewModel<PriceEngineeringTaskStatusWrapper, PriceEngineeringTaskStatus, AfterSavePriceEngineeringTaskStatusEvent>
    {
        public PriceEngineeringTaskStatusDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class StructureCostVersionDetailsViewModel : BaseDetailsViewModel<StructureCostVersionWrapper, StructureCostVersion, AfterSaveStructureCostVersionEvent>
    {
        public StructureCostVersionDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class UpdateStructureCostNumberTaskDetailsViewModel : BaseDetailsViewModel<UpdateStructureCostNumberTaskWrapper, UpdateStructureCostNumberTask, AfterSaveUpdateStructureCostNumberTaskEvent>
    {
		//private Func<Task<List<ProductBlock>>> _getEntitiesForSelectProductBlockCommand;
		private Func<List<ProductBlock>> _getEntitiesForSelectProductBlockCommand;
		public DelegateLogCommand SelectProductBlockCommand { get; private set; }
		public DelegateLogCommand ClearProductBlockCommand { get; private set; }

        public UpdateStructureCostNumberTaskDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductBlockCommand == null) _getEntitiesForSelectProductBlockCommand = () => { return UnitOfWork.Repository<ProductBlock>().GetAll(); };
			if (SelectProductBlockCommand == null) SelectProductBlockCommand = new DelegateLogCommand(SelectProductBlockCommand_Execute_Default);
			if (ClearProductBlockCommand == null) ClearProductBlockCommand = new DelegateLogCommand(ClearProductBlockCommand_Execute_Default);

		}

		private void SelectProductBlockCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductBlock, ProductBlockWrapper>(_getEntitiesForSelectProductBlockCommand(), nameof(Item.ProductBlock), Item.ProductBlock?.Id);
		}

		private void ClearProductBlockCommand_Execute_Default() 
		{
						Item.ProductBlock = null;		    
		}


    }

    public partial class ProductCategoryDetailsViewModel : BaseDetailsViewModel<ProductCategoryWrapper, ProductCategory, AfterSaveProductCategoryEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public ProductCategoryDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class ProductCategoryPriceAndCostDetailsViewModel : BaseDetailsViewModel<ProductCategoryPriceAndCostWrapper, ProductCategoryPriceAndCost, AfterSaveProductCategoryPriceAndCostEvent>
    {
		//private Func<Task<List<ProductCategory>>> _getEntitiesForSelectCategoryCommand;
		private Func<List<ProductCategory>> _getEntitiesForSelectCategoryCommand;
		public DelegateLogCommand SelectCategoryCommand { get; private set; }
		public DelegateLogCommand ClearCategoryCommand { get; private set; }

        public ProductCategoryPriceAndCostDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectCategoryCommand == null) _getEntitiesForSelectCategoryCommand = () => { return UnitOfWork.Repository<ProductCategory>().GetAll(); };
			if (SelectCategoryCommand == null) SelectCategoryCommand = new DelegateLogCommand(SelectCategoryCommand_Execute_Default);
			if (ClearCategoryCommand == null) ClearCategoryCommand = new DelegateLogCommand(ClearCategoryCommand_Execute_Default);

		}

		private void SelectCategoryCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductCategory, ProductCategoryWrapper>(_getEntitiesForSelectCategoryCommand(), nameof(Item.Category), Item.Category?.Id);
		}

		private void ClearCategoryCommand_Execute_Default() 
		{
						Item.Category = null;		    
		}


    }

    public partial class ProductIncludedDetailsViewModel : BaseDetailsViewModel<ProductIncludedWrapper, ProductIncluded, AfterSaveProductIncludedEvent>
    {
		//private Func<Task<List<Product>>> _getEntitiesForSelectProductCommand;
		private Func<List<Product>> _getEntitiesForSelectProductCommand;
		public DelegateLogCommand SelectProductCommand { get; private set; }
		public DelegateLogCommand ClearProductCommand { get; private set; }

        public ProductIncludedDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductCommand == null) _getEntitiesForSelectProductCommand = () => { return UnitOfWork.Repository<Product>().GetAll(); };
			if (SelectProductCommand == null) SelectProductCommand = new DelegateLogCommand(SelectProductCommand_Execute_Default);
			if (ClearProductCommand == null) ClearProductCommand = new DelegateLogCommand(ClearProductCommand_Execute_Default);

		}

		private void SelectProductCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Product, ProductWrapper>(_getEntitiesForSelectProductCommand(), nameof(Item.Product), Item.Product?.Id);
		}

		private void ClearProductCommand_Execute_Default() 
		{
						Item.Product = null;		    
		}


    }

    public partial class ProductDesignationDetailsViewModel : BaseDetailsViewModel<ProductDesignationWrapper, ProductDesignation, AfterSaveProductDesignationEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

		private Func<List<ProductDesignation>> _getEntitiesForAddInParentsCommand;
		public DelegateLogCommand AddInParentsCommand { get; }
		public DelegateLogCommand RemoveFromParentsCommand { get; private set; }
		private ProductDesignationWrapper _selectedParentsItem;
		public ProductDesignationWrapper SelectedParentsItem 
		{ 
			get { return _selectedParentsItem; }
			set 
			{ 
				if (Equals(_selectedParentsItem, value)) return;
				_selectedParentsItem = value;
				RaisePropertyChanged();
				RemoveFromParentsCommand.RaiseCanExecuteChanged();
			}
		}

        public ProductDesignationDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInParentsCommand == null) _getEntitiesForAddInParentsCommand = () => { return UnitOfWork.Repository<ProductDesignation>().GetAll(); };;
			if (AddInParentsCommand == null) AddInParentsCommand = new DelegateLogCommand(AddInParentsCommand_Execute_Default);
			if (RemoveFromParentsCommand == null) RemoveFromParentsCommand = new DelegateLogCommand(RemoveFromParentsCommand_Execute_Default, RemoveFromParentsCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}

			private void AddInParentsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ProductDesignation, ProductDesignationWrapper>(_getEntitiesForAddInParentsCommand(), Item.Parents);
			}

			private void RemoveFromParentsCommand_Execute_Default()
			{
				Item.Parents.Remove(SelectedParentsItem);
			}

			private bool RemoveFromParentsCommand_CanExecute_Default()
			{
				return SelectedParentsItem != null;
			}


    }

    public partial class ProductTypeDetailsViewModel : BaseDetailsViewModel<ProductTypeWrapper, ProductType, AfterSaveProductTypeEvent>
    {
        public ProductTypeDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ProductTypeDesignationDetailsViewModel : BaseDetailsViewModel<ProductTypeDesignationWrapper, ProductTypeDesignation, AfterSaveProductTypeDesignationEvent>
    {
		//private Func<Task<List<ProductType>>> _getEntitiesForSelectProductTypeCommand;
		private Func<List<ProductType>> _getEntitiesForSelectProductTypeCommand;
		public DelegateLogCommand SelectProductTypeCommand { get; private set; }
		public DelegateLogCommand ClearProductTypeCommand { get; private set; }

		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public ProductTypeDesignationDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductTypeCommand == null) _getEntitiesForSelectProductTypeCommand = () => { return UnitOfWork.Repository<ProductType>().GetAll(); };
			if (SelectProductTypeCommand == null) SelectProductTypeCommand = new DelegateLogCommand(SelectProductTypeCommand_Execute_Default);
			if (ClearProductTypeCommand == null) ClearProductTypeCommand = new DelegateLogCommand(ClearProductTypeCommand_Execute_Default);

			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

		private void SelectProductTypeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductType, ProductTypeWrapper>(_getEntitiesForSelectProductTypeCommand(), nameof(Item.ProductType), Item.ProductType?.Id);
		}

		private void ClearProductTypeCommand_Execute_Default() 
		{
						Item.ProductType = null;		    
		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class ProjectTypeDetailsViewModel : BaseDetailsViewModel<ProjectTypeWrapper, ProjectType, AfterSaveProjectTypeEvent>
    {
        public ProjectTypeDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class StandartMarginalIncomeDetailsViewModel : BaseDetailsViewModel<StandartMarginalIncomeWrapper, StandartMarginalIncome, AfterSaveStandartMarginalIncomeEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public StandartMarginalIncomeDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class StandartProductionTermDetailsViewModel : BaseDetailsViewModel<StandartProductionTermWrapper, StandartProductionTerm, AfterSaveStandartProductionTermEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParametersCommand;
		public DelegateLogCommand AddInParametersCommand { get; }
		public DelegateLogCommand RemoveFromParametersCommand { get; private set; }
		private ParameterWrapper _selectedParametersItem;
		public ParameterWrapper SelectedParametersItem 
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

        public StandartProductionTermDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParametersCommand == null) _getEntitiesForAddInParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParametersCommand == null) AddInParametersCommand = new DelegateLogCommand(AddInParametersCommand_Execute_Default);
			if (RemoveFromParametersCommand == null) RemoveFromParametersCommand = new DelegateLogCommand(RemoveFromParametersCommand_Execute_Default, RemoveFromParametersCommand_CanExecute_Default);

		}

			private void AddInParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParametersCommand(), Item.Parameters);
			}

			private void RemoveFromParametersCommand_Execute_Default()
			{
				Item.Parameters.Remove(SelectedParametersItem);
			}

			private bool RemoveFromParametersCommand_CanExecute_Default()
			{
				return SelectedParametersItem != null;
			}


    }

    public partial class StructureCostDetailsViewModel : BaseDetailsViewModel<StructureCostWrapper, StructureCost, AfterSaveStructureCostEvent>
    {
		//private Func<Task<List<ProductBlock>>> _getEntitiesForSelectOriginalStructureCostProductBlockCommand;
		private Func<List<ProductBlock>> _getEntitiesForSelectOriginalStructureCostProductBlockCommand;
		public DelegateLogCommand SelectOriginalStructureCostProductBlockCommand { get; private set; }
		public DelegateLogCommand ClearOriginalStructureCostProductBlockCommand { get; private set; }

        public StructureCostDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectOriginalStructureCostProductBlockCommand == null) _getEntitiesForSelectOriginalStructureCostProductBlockCommand = () => { return UnitOfWork.Repository<ProductBlock>().GetAll(); };
			if (SelectOriginalStructureCostProductBlockCommand == null) SelectOriginalStructureCostProductBlockCommand = new DelegateLogCommand(SelectOriginalStructureCostProductBlockCommand_Execute_Default);
			if (ClearOriginalStructureCostProductBlockCommand == null) ClearOriginalStructureCostProductBlockCommand = new DelegateLogCommand(ClearOriginalStructureCostProductBlockCommand_Execute_Default);

		}

		private void SelectOriginalStructureCostProductBlockCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductBlock, ProductBlockWrapper>(_getEntitiesForSelectOriginalStructureCostProductBlockCommand(), nameof(Item.OriginalStructureCostProductBlock), Item.OriginalStructureCostProductBlock?.Id);
		}

		private void ClearOriginalStructureCostProductBlockCommand_Execute_Default() 
		{
						Item.OriginalStructureCostProductBlock = null;		    
		}


    }

    public partial class SupervisionDetailsViewModel : BaseDetailsViewModel<SupervisionWrapper, Supervision, AfterSaveSupervisionEvent>
    {
		//private Func<Task<List<SalesUnit>>> _getEntitiesForSelectSalesUnitCommand;
		private Func<List<SalesUnit>> _getEntitiesForSelectSalesUnitCommand;
		public DelegateLogCommand SelectSalesUnitCommand { get; private set; }
		public DelegateLogCommand ClearSalesUnitCommand { get; private set; }

		//private Func<Task<List<SalesUnit>>> _getEntitiesForSelectSupervisionUnitCommand;
		private Func<List<SalesUnit>> _getEntitiesForSelectSupervisionUnitCommand;
		public DelegateLogCommand SelectSupervisionUnitCommand { get; private set; }
		public DelegateLogCommand ClearSupervisionUnitCommand { get; private set; }

        public SupervisionDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectSalesUnitCommand == null) _getEntitiesForSelectSalesUnitCommand = () => { return UnitOfWork.Repository<SalesUnit>().GetAll(); };
			if (SelectSalesUnitCommand == null) SelectSalesUnitCommand = new DelegateLogCommand(SelectSalesUnitCommand_Execute_Default);
			if (ClearSalesUnitCommand == null) ClearSalesUnitCommand = new DelegateLogCommand(ClearSalesUnitCommand_Execute_Default);

			
			if (_getEntitiesForSelectSupervisionUnitCommand == null) _getEntitiesForSelectSupervisionUnitCommand = () => { return UnitOfWork.Repository<SalesUnit>().GetAll(); };
			if (SelectSupervisionUnitCommand == null) SelectSupervisionUnitCommand = new DelegateLogCommand(SelectSupervisionUnitCommand_Execute_Default);
			if (ClearSupervisionUnitCommand == null) ClearSupervisionUnitCommand = new DelegateLogCommand(ClearSupervisionUnitCommand_Execute_Default);

		}

		private void SelectSalesUnitCommand_Execute_Default() 
		{
            SelectAndSetWrapper<SalesUnit, SalesUnitWrapper>(_getEntitiesForSelectSalesUnitCommand(), nameof(Item.SalesUnit), Item.SalesUnit?.Id);
		}

		private void ClearSalesUnitCommand_Execute_Default() 
		{
						Item.SalesUnit = null;		    
		}

		private void SelectSupervisionUnitCommand_Execute_Default() 
		{
            SelectAndSetWrapper<SalesUnit, SalesUnitWrapper>(_getEntitiesForSelectSupervisionUnitCommand(), nameof(Item.SupervisionUnit), Item.SupervisionUnit?.Id);
		}

		private void ClearSupervisionUnitCommand_Execute_Default() 
		{
						Item.SupervisionUnit = null;		    
		}


    }

    public partial class TaskInvoiceForPaymentDetailsViewModel : BaseDetailsViewModel<TaskInvoiceForPaymentWrapper, TaskInvoiceForPayment, AfterSaveTaskInvoiceForPaymentEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectBackManagerCommand;
		private Func<List<User>> _getEntitiesForSelectBackManagerCommand;
		public DelegateLogCommand SelectBackManagerCommand { get; private set; }
		public DelegateLogCommand ClearBackManagerCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectPlanMakerCommand;
		private Func<List<User>> _getEntitiesForSelectPlanMakerCommand;
		public DelegateLogCommand SelectPlanMakerCommand { get; private set; }
		public DelegateLogCommand ClearPlanMakerCommand { get; private set; }

		private Func<List<TaskInvoiceForPaymentItem>> _getEntitiesForAddInItemsCommand;
		public DelegateLogCommand AddInItemsCommand { get; }
		public DelegateLogCommand RemoveFromItemsCommand { get; private set; }
		private TaskInvoiceForPaymentItemWrapper _selectedItemsItem;
		public TaskInvoiceForPaymentItemWrapper SelectedItemsItem 
		{ 
			get { return _selectedItemsItem; }
			set 
			{ 
				if (Equals(_selectedItemsItem, value)) return;
				_selectedItemsItem = value;
				RaisePropertyChanged();
				RemoveFromItemsCommand.RaiseCanExecuteChanged();
			}
		}

        public TaskInvoiceForPaymentDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectBackManagerCommand == null) _getEntitiesForSelectBackManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectBackManagerCommand == null) SelectBackManagerCommand = new DelegateLogCommand(SelectBackManagerCommand_Execute_Default);
			if (ClearBackManagerCommand == null) ClearBackManagerCommand = new DelegateLogCommand(ClearBackManagerCommand_Execute_Default);

			
			if (_getEntitiesForSelectPlanMakerCommand == null) _getEntitiesForSelectPlanMakerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectPlanMakerCommand == null) SelectPlanMakerCommand = new DelegateLogCommand(SelectPlanMakerCommand_Execute_Default);
			if (ClearPlanMakerCommand == null) ClearPlanMakerCommand = new DelegateLogCommand(ClearPlanMakerCommand_Execute_Default);

			
			if (_getEntitiesForAddInItemsCommand == null) _getEntitiesForAddInItemsCommand = () => { return UnitOfWork.Repository<TaskInvoiceForPaymentItem>().GetAll(); };;
			if (AddInItemsCommand == null) AddInItemsCommand = new DelegateLogCommand(AddInItemsCommand_Execute_Default);
			if (RemoveFromItemsCommand == null) RemoveFromItemsCommand = new DelegateLogCommand(RemoveFromItemsCommand_Execute_Default, RemoveFromItemsCommand_CanExecute_Default);

		}

		private void SelectBackManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectBackManagerCommand(), nameof(Item.BackManager), Item.BackManager?.Id);
		}

		private void ClearBackManagerCommand_Execute_Default() 
		{
						Item.BackManager = null;		    
		}

		private void SelectPlanMakerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectPlanMakerCommand(), nameof(Item.PlanMaker), Item.PlanMaker?.Id);
		}

		private void ClearPlanMakerCommand_Execute_Default() 
		{
						Item.PlanMaker = null;		    
		}

			private void AddInItemsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<TaskInvoiceForPaymentItem, TaskInvoiceForPaymentItemWrapper>(_getEntitiesForAddInItemsCommand(), Item.Items);
			}

			private void RemoveFromItemsCommand_Execute_Default()
			{
				Item.Items.Remove(SelectedItemsItem);
			}

			private bool RemoveFromItemsCommand_CanExecute_Default()
			{
				return SelectedItemsItem != null;
			}


    }

    public partial class TaskInvoiceForPaymentItemDetailsViewModel : BaseDetailsViewModel<TaskInvoiceForPaymentItemWrapper, TaskInvoiceForPaymentItem, AfterSaveTaskInvoiceForPaymentItemEvent>
    {
		//private Func<Task<List<PriceEngineeringTask>>> _getEntitiesForSelectPriceEngineeringTaskCommand;
		private Func<List<PriceEngineeringTask>> _getEntitiesForSelectPriceEngineeringTaskCommand;
		public DelegateLogCommand SelectPriceEngineeringTaskCommand { get; private set; }
		public DelegateLogCommand ClearPriceEngineeringTaskCommand { get; private set; }

		//private Func<Task<List<TechnicalRequrements>>> _getEntitiesForSelectTechnicalRequrementsCommand;
		private Func<List<TechnicalRequrements>> _getEntitiesForSelectTechnicalRequrementsCommand;
		public DelegateLogCommand SelectTechnicalRequrementsCommand { get; private set; }
		public DelegateLogCommand ClearTechnicalRequrementsCommand { get; private set; }

		//private Func<Task<List<PaymentCondition>>> _getEntitiesForSelectPaymentConditionCommand;
		private Func<List<PaymentCondition>> _getEntitiesForSelectPaymentConditionCommand;
		public DelegateLogCommand SelectPaymentConditionCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionCommand { get; private set; }

        public TaskInvoiceForPaymentItemDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectPriceEngineeringTaskCommand == null) _getEntitiesForSelectPriceEngineeringTaskCommand = () => { return UnitOfWork.Repository<PriceEngineeringTask>().GetAll(); };
			if (SelectPriceEngineeringTaskCommand == null) SelectPriceEngineeringTaskCommand = new DelegateLogCommand(SelectPriceEngineeringTaskCommand_Execute_Default);
			if (ClearPriceEngineeringTaskCommand == null) ClearPriceEngineeringTaskCommand = new DelegateLogCommand(ClearPriceEngineeringTaskCommand_Execute_Default);

			
			if (_getEntitiesForSelectTechnicalRequrementsCommand == null) _getEntitiesForSelectTechnicalRequrementsCommand = () => { return UnitOfWork.Repository<TechnicalRequrements>().GetAll(); };
			if (SelectTechnicalRequrementsCommand == null) SelectTechnicalRequrementsCommand = new DelegateLogCommand(SelectTechnicalRequrementsCommand_Execute_Default);
			if (ClearTechnicalRequrementsCommand == null) ClearTechnicalRequrementsCommand = new DelegateLogCommand(ClearTechnicalRequrementsCommand_Execute_Default);

			
			if (_getEntitiesForSelectPaymentConditionCommand == null) _getEntitiesForSelectPaymentConditionCommand = () => { return UnitOfWork.Repository<PaymentCondition>().GetAll(); };
			if (SelectPaymentConditionCommand == null) SelectPaymentConditionCommand = new DelegateLogCommand(SelectPaymentConditionCommand_Execute_Default);
			if (ClearPaymentConditionCommand == null) ClearPaymentConditionCommand = new DelegateLogCommand(ClearPaymentConditionCommand_Execute_Default);

		}

		private void SelectPriceEngineeringTaskCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PriceEngineeringTask, PriceEngineeringTaskWrapper>(_getEntitiesForSelectPriceEngineeringTaskCommand(), nameof(Item.PriceEngineeringTask), Item.PriceEngineeringTask?.Id);
		}

		private void ClearPriceEngineeringTaskCommand_Execute_Default() 
		{
						Item.PriceEngineeringTask = null;		    
		}

		private void SelectTechnicalRequrementsCommand_Execute_Default() 
		{
            SelectAndSetWrapper<TechnicalRequrements, TechnicalRequrementsWrapper>(_getEntitiesForSelectTechnicalRequrementsCommand(), nameof(Item.TechnicalRequrements), Item.TechnicalRequrements?.Id);
		}

		private void ClearTechnicalRequrementsCommand_Execute_Default() 
		{
						Item.TechnicalRequrements = null;		    
		}

		private void SelectPaymentConditionCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentCondition, PaymentConditionWrapper>(_getEntitiesForSelectPaymentConditionCommand(), nameof(Item.PaymentCondition), Item.PaymentCondition?.Id);
		}

		private void ClearPaymentConditionCommand_Execute_Default() 
		{
						Item.PaymentCondition = null;		    
		}


    }

    public partial class AnswerFileTceDetailsViewModel : BaseDetailsViewModel<AnswerFileTceWrapper, AnswerFileTce, AfterSaveAnswerFileTceEvent>
    {
        public AnswerFileTceDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ShippingCostFileDetailsViewModel : BaseDetailsViewModel<ShippingCostFileWrapper, ShippingCostFile, AfterSaveShippingCostFileEvent>
    {
        public ShippingCostFileDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class TechnicalRequrementsDetailsViewModel : BaseDetailsViewModel<TechnicalRequrementsWrapper, TechnicalRequrements, AfterSaveTechnicalRequrementsEvent>
    {
		//private Func<Task<List<Specification>>> _getEntitiesForSelectSpecificationCommand;
		private Func<List<Specification>> _getEntitiesForSelectSpecificationCommand;
		public DelegateLogCommand SelectSpecificationCommand { get; private set; }
		public DelegateLogCommand ClearSpecificationCommand { get; private set; }

		private Func<List<SalesUnit>> _getEntitiesForAddInSalesUnitsCommand;
		public DelegateLogCommand AddInSalesUnitsCommand { get; }
		public DelegateLogCommand RemoveFromSalesUnitsCommand { get; private set; }
		private SalesUnitWrapper _selectedSalesUnitsItem;
		public SalesUnitWrapper SelectedSalesUnitsItem 
		{ 
			get { return _selectedSalesUnitsItem; }
			set 
			{ 
				if (Equals(_selectedSalesUnitsItem, value)) return;
				_selectedSalesUnitsItem = value;
				RaisePropertyChanged();
				RemoveFromSalesUnitsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<TechnicalRequrementsFile>> _getEntitiesForAddInFilesCommand;
		public DelegateLogCommand AddInFilesCommand { get; }
		public DelegateLogCommand RemoveFromFilesCommand { get; private set; }
		private TechnicalRequrementsFileWrapper _selectedFilesItem;
		public TechnicalRequrementsFileWrapper SelectedFilesItem 
		{ 
			get { return _selectedFilesItem; }
			set 
			{ 
				if (Equals(_selectedFilesItem, value)) return;
				_selectedFilesItem = value;
				RaisePropertyChanged();
				RemoveFromFilesCommand.RaiseCanExecuteChanged();
			}
		}

        public TechnicalRequrementsDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectSpecificationCommand == null) _getEntitiesForSelectSpecificationCommand = () => { return UnitOfWork.Repository<Specification>().GetAll(); };
			if (SelectSpecificationCommand == null) SelectSpecificationCommand = new DelegateLogCommand(SelectSpecificationCommand_Execute_Default);
			if (ClearSpecificationCommand == null) ClearSpecificationCommand = new DelegateLogCommand(ClearSpecificationCommand_Execute_Default);

			
			if (_getEntitiesForAddInSalesUnitsCommand == null) _getEntitiesForAddInSalesUnitsCommand = () => { return UnitOfWork.Repository<SalesUnit>().GetAll(); };;
			if (AddInSalesUnitsCommand == null) AddInSalesUnitsCommand = new DelegateLogCommand(AddInSalesUnitsCommand_Execute_Default);
			if (RemoveFromSalesUnitsCommand == null) RemoveFromSalesUnitsCommand = new DelegateLogCommand(RemoveFromSalesUnitsCommand_Execute_Default, RemoveFromSalesUnitsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInFilesCommand == null) _getEntitiesForAddInFilesCommand = () => { return UnitOfWork.Repository<TechnicalRequrementsFile>().GetAll(); };;
			if (AddInFilesCommand == null) AddInFilesCommand = new DelegateLogCommand(AddInFilesCommand_Execute_Default);
			if (RemoveFromFilesCommand == null) RemoveFromFilesCommand = new DelegateLogCommand(RemoveFromFilesCommand_Execute_Default, RemoveFromFilesCommand_CanExecute_Default);

		}

		private void SelectSpecificationCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Specification, SpecificationWrapper>(_getEntitiesForSelectSpecificationCommand(), nameof(Item.Specification), Item.Specification?.Id);
		}

		private void ClearSpecificationCommand_Execute_Default() 
		{
						Item.Specification = null;		    
		}

			private void AddInSalesUnitsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<SalesUnit, SalesUnitWrapper>(_getEntitiesForAddInSalesUnitsCommand(), Item.SalesUnits);
			}

			private void RemoveFromSalesUnitsCommand_Execute_Default()
			{
				Item.SalesUnits.Remove(SelectedSalesUnitsItem);
			}

			private bool RemoveFromSalesUnitsCommand_CanExecute_Default()
			{
				return SelectedSalesUnitsItem != null;
			}

			private void AddInFilesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<TechnicalRequrementsFile, TechnicalRequrementsFileWrapper>(_getEntitiesForAddInFilesCommand(), Item.Files);
			}

			private void RemoveFromFilesCommand_Execute_Default()
			{
				Item.Files.Remove(SelectedFilesItem);
			}

			private bool RemoveFromFilesCommand_CanExecute_Default()
			{
				return SelectedFilesItem != null;
			}


    }

    public partial class TechnicalRequrementsFileDetailsViewModel : BaseDetailsViewModel<TechnicalRequrementsFileWrapper, TechnicalRequrementsFile, AfterSaveTechnicalRequrementsFileEvent>
    {
        public TechnicalRequrementsFileDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class TechnicalRequrementsTaskDetailsViewModel : BaseDetailsViewModel<TechnicalRequrementsTaskWrapper, TechnicalRequrementsTask, AfterSaveTechnicalRequrementsTaskEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectBackManagerCommand;
		private Func<List<User>> _getEntitiesForSelectBackManagerCommand;
		public DelegateLogCommand SelectBackManagerCommand { get; private set; }
		public DelegateLogCommand ClearBackManagerCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectFrontManagerCommand;
		private Func<List<User>> _getEntitiesForSelectFrontManagerCommand;
		public DelegateLogCommand SelectFrontManagerCommand { get; private set; }
		public DelegateLogCommand ClearFrontManagerCommand { get; private set; }

		//private Func<Task<List<TechnicalRequrementsTaskHistoryElement>>> _getEntitiesForSelectLastHistoryElementCommand;
		private Func<List<TechnicalRequrementsTaskHistoryElement>> _getEntitiesForSelectLastHistoryElementCommand;
		public DelegateLogCommand SelectLastHistoryElementCommand { get; private set; }
		public DelegateLogCommand ClearLastHistoryElementCommand { get; private set; }

		private Func<List<TechnicalRequrements>> _getEntitiesForAddInRequrementsCommand;
		public DelegateLogCommand AddInRequrementsCommand { get; }
		public DelegateLogCommand RemoveFromRequrementsCommand { get; private set; }
		private TechnicalRequrementsWrapper _selectedRequrementsItem;
		public TechnicalRequrementsWrapper SelectedRequrementsItem 
		{ 
			get { return _selectedRequrementsItem; }
			set 
			{ 
				if (Equals(_selectedRequrementsItem, value)) return;
				_selectedRequrementsItem = value;
				RaisePropertyChanged();
				RemoveFromRequrementsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PriceCalculation>> _getEntitiesForAddInPriceCalculationsCommand;
		public DelegateLogCommand AddInPriceCalculationsCommand { get; }
		public DelegateLogCommand RemoveFromPriceCalculationsCommand { get; private set; }
		private PriceCalculationWrapper _selectedPriceCalculationsItem;
		public PriceCalculationWrapper SelectedPriceCalculationsItem 
		{ 
			get { return _selectedPriceCalculationsItem; }
			set 
			{ 
				if (Equals(_selectedPriceCalculationsItem, value)) return;
				_selectedPriceCalculationsItem = value;
				RaisePropertyChanged();
				RemoveFromPriceCalculationsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<AnswerFileTce>> _getEntitiesForAddInAnswerFilesCommand;
		public DelegateLogCommand AddInAnswerFilesCommand { get; }
		public DelegateLogCommand RemoveFromAnswerFilesCommand { get; private set; }
		private AnswerFileTceWrapper _selectedAnswerFilesItem;
		public AnswerFileTceWrapper SelectedAnswerFilesItem 
		{ 
			get { return _selectedAnswerFilesItem; }
			set 
			{ 
				if (Equals(_selectedAnswerFilesItem, value)) return;
				_selectedAnswerFilesItem = value;
				RaisePropertyChanged();
				RemoveFromAnswerFilesCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<ShippingCostFile>> _getEntitiesForAddInShippingCostFilesCommand;
		public DelegateLogCommand AddInShippingCostFilesCommand { get; }
		public DelegateLogCommand RemoveFromShippingCostFilesCommand { get; private set; }
		private ShippingCostFileWrapper _selectedShippingCostFilesItem;
		public ShippingCostFileWrapper SelectedShippingCostFilesItem 
		{ 
			get { return _selectedShippingCostFilesItem; }
			set 
			{ 
				if (Equals(_selectedShippingCostFilesItem, value)) return;
				_selectedShippingCostFilesItem = value;
				RaisePropertyChanged();
				RemoveFromShippingCostFilesCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<TechnicalRequrementsTaskHistoryElement>> _getEntitiesForAddInHistoryElementsCommand;
		public DelegateLogCommand AddInHistoryElementsCommand { get; }
		public DelegateLogCommand RemoveFromHistoryElementsCommand { get; private set; }
		private TechnicalRequrementsTaskHistoryElementWrapper _selectedHistoryElementsItem;
		public TechnicalRequrementsTaskHistoryElementWrapper SelectedHistoryElementsItem 
		{ 
			get { return _selectedHistoryElementsItem; }
			set 
			{ 
				if (Equals(_selectedHistoryElementsItem, value)) return;
				_selectedHistoryElementsItem = value;
				RaisePropertyChanged();
				RemoveFromHistoryElementsCommand.RaiseCanExecuteChanged();
			}
		}

        public TechnicalRequrementsTaskDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectBackManagerCommand == null) _getEntitiesForSelectBackManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectBackManagerCommand == null) SelectBackManagerCommand = new DelegateLogCommand(SelectBackManagerCommand_Execute_Default);
			if (ClearBackManagerCommand == null) ClearBackManagerCommand = new DelegateLogCommand(ClearBackManagerCommand_Execute_Default);

			
			if (_getEntitiesForSelectFrontManagerCommand == null) _getEntitiesForSelectFrontManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectFrontManagerCommand == null) SelectFrontManagerCommand = new DelegateLogCommand(SelectFrontManagerCommand_Execute_Default);
			if (ClearFrontManagerCommand == null) ClearFrontManagerCommand = new DelegateLogCommand(ClearFrontManagerCommand_Execute_Default);

			
			if (_getEntitiesForSelectLastHistoryElementCommand == null) _getEntitiesForSelectLastHistoryElementCommand = () => { return UnitOfWork.Repository<TechnicalRequrementsTaskHistoryElement>().GetAll(); };
			if (SelectLastHistoryElementCommand == null) SelectLastHistoryElementCommand = new DelegateLogCommand(SelectLastHistoryElementCommand_Execute_Default);
			if (ClearLastHistoryElementCommand == null) ClearLastHistoryElementCommand = new DelegateLogCommand(ClearLastHistoryElementCommand_Execute_Default);

			
			if (_getEntitiesForAddInRequrementsCommand == null) _getEntitiesForAddInRequrementsCommand = () => { return UnitOfWork.Repository<TechnicalRequrements>().GetAll(); };;
			if (AddInRequrementsCommand == null) AddInRequrementsCommand = new DelegateLogCommand(AddInRequrementsCommand_Execute_Default);
			if (RemoveFromRequrementsCommand == null) RemoveFromRequrementsCommand = new DelegateLogCommand(RemoveFromRequrementsCommand_Execute_Default, RemoveFromRequrementsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPriceCalculationsCommand == null) _getEntitiesForAddInPriceCalculationsCommand = () => { return UnitOfWork.Repository<PriceCalculation>().GetAll(); };;
			if (AddInPriceCalculationsCommand == null) AddInPriceCalculationsCommand = new DelegateLogCommand(AddInPriceCalculationsCommand_Execute_Default);
			if (RemoveFromPriceCalculationsCommand == null) RemoveFromPriceCalculationsCommand = new DelegateLogCommand(RemoveFromPriceCalculationsCommand_Execute_Default, RemoveFromPriceCalculationsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInAnswerFilesCommand == null) _getEntitiesForAddInAnswerFilesCommand = () => { return UnitOfWork.Repository<AnswerFileTce>().GetAll(); };;
			if (AddInAnswerFilesCommand == null) AddInAnswerFilesCommand = new DelegateLogCommand(AddInAnswerFilesCommand_Execute_Default);
			if (RemoveFromAnswerFilesCommand == null) RemoveFromAnswerFilesCommand = new DelegateLogCommand(RemoveFromAnswerFilesCommand_Execute_Default, RemoveFromAnswerFilesCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInShippingCostFilesCommand == null) _getEntitiesForAddInShippingCostFilesCommand = () => { return UnitOfWork.Repository<ShippingCostFile>().GetAll(); };;
			if (AddInShippingCostFilesCommand == null) AddInShippingCostFilesCommand = new DelegateLogCommand(AddInShippingCostFilesCommand_Execute_Default);
			if (RemoveFromShippingCostFilesCommand == null) RemoveFromShippingCostFilesCommand = new DelegateLogCommand(RemoveFromShippingCostFilesCommand_Execute_Default, RemoveFromShippingCostFilesCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInHistoryElementsCommand == null) _getEntitiesForAddInHistoryElementsCommand = () => { return UnitOfWork.Repository<TechnicalRequrementsTaskHistoryElement>().GetAll(); };;
			if (AddInHistoryElementsCommand == null) AddInHistoryElementsCommand = new DelegateLogCommand(AddInHistoryElementsCommand_Execute_Default);
			if (RemoveFromHistoryElementsCommand == null) RemoveFromHistoryElementsCommand = new DelegateLogCommand(RemoveFromHistoryElementsCommand_Execute_Default, RemoveFromHistoryElementsCommand_CanExecute_Default);

		}

		private void SelectBackManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectBackManagerCommand(), nameof(Item.BackManager), Item.BackManager?.Id);
		}

		private void ClearBackManagerCommand_Execute_Default() 
		{
						Item.BackManager = null;		    
		}

		private void SelectFrontManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectFrontManagerCommand(), nameof(Item.FrontManager), Item.FrontManager?.Id);
		}

		private void ClearFrontManagerCommand_Execute_Default() 
		{
				    
		}

		private void SelectLastHistoryElementCommand_Execute_Default() 
		{
            SelectAndSetWrapper<TechnicalRequrementsTaskHistoryElement, TechnicalRequrementsTaskHistoryElementWrapper>(_getEntitiesForSelectLastHistoryElementCommand(), nameof(Item.LastHistoryElement), Item.LastHistoryElement?.Id);
		}

		private void ClearLastHistoryElementCommand_Execute_Default() 
		{
				    
		}

			private void AddInRequrementsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<TechnicalRequrements, TechnicalRequrementsWrapper>(_getEntitiesForAddInRequrementsCommand(), Item.Requrements);
			}

			private void RemoveFromRequrementsCommand_Execute_Default()
			{
				Item.Requrements.Remove(SelectedRequrementsItem);
			}

			private bool RemoveFromRequrementsCommand_CanExecute_Default()
			{
				return SelectedRequrementsItem != null;
			}

			private void AddInPriceCalculationsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PriceCalculation, PriceCalculationWrapper>(_getEntitiesForAddInPriceCalculationsCommand(), Item.PriceCalculations);
			}

			private void RemoveFromPriceCalculationsCommand_Execute_Default()
			{
				Item.PriceCalculations.Remove(SelectedPriceCalculationsItem);
			}

			private bool RemoveFromPriceCalculationsCommand_CanExecute_Default()
			{
				return SelectedPriceCalculationsItem != null;
			}

			private void AddInAnswerFilesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<AnswerFileTce, AnswerFileTceWrapper>(_getEntitiesForAddInAnswerFilesCommand(), Item.AnswerFiles);
			}

			private void RemoveFromAnswerFilesCommand_Execute_Default()
			{
				Item.AnswerFiles.Remove(SelectedAnswerFilesItem);
			}

			private bool RemoveFromAnswerFilesCommand_CanExecute_Default()
			{
				return SelectedAnswerFilesItem != null;
			}

			private void AddInShippingCostFilesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ShippingCostFile, ShippingCostFileWrapper>(_getEntitiesForAddInShippingCostFilesCommand(), Item.ShippingCostFiles);
			}

			private void RemoveFromShippingCostFilesCommand_Execute_Default()
			{
				Item.ShippingCostFiles.Remove(SelectedShippingCostFilesItem);
			}

			private bool RemoveFromShippingCostFilesCommand_CanExecute_Default()
			{
				return SelectedShippingCostFilesItem != null;
			}

			private void AddInHistoryElementsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<TechnicalRequrementsTaskHistoryElement, TechnicalRequrementsTaskHistoryElementWrapper>(_getEntitiesForAddInHistoryElementsCommand(), Item.HistoryElements);
			}

			private void RemoveFromHistoryElementsCommand_Execute_Default()
			{
				Item.HistoryElements.Remove(SelectedHistoryElementsItem);
			}

			private bool RemoveFromHistoryElementsCommand_CanExecute_Default()
			{
				return SelectedHistoryElementsItem != null;
			}


    }

    public partial class TechnicalRequrementsTaskHistoryElementDetailsViewModel : BaseDetailsViewModel<TechnicalRequrementsTaskHistoryElementWrapper, TechnicalRequrementsTaskHistoryElement, AfterSaveTechnicalRequrementsTaskHistoryElementEvent>
    {
		//private Func<Task<List<User>>> _getEntitiesForSelectUserCommand;
		private Func<List<User>> _getEntitiesForSelectUserCommand;
		public DelegateLogCommand SelectUserCommand { get; private set; }
		public DelegateLogCommand ClearUserCommand { get; private set; }

        public TechnicalRequrementsTaskHistoryElementDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectUserCommand == null) _getEntitiesForSelectUserCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectUserCommand == null) SelectUserCommand = new DelegateLogCommand(SelectUserCommand_Execute_Default);
			if (ClearUserCommand == null) ClearUserCommand = new DelegateLogCommand(ClearUserCommand_Execute_Default);

		}

		private void SelectUserCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectUserCommand(), nameof(Item.User), Item.User?.Id);
		}

		private void ClearUserCommand_Execute_Default() 
		{
						Item.User = null;		    
		}


    }

    public partial class UserGroupDetailsViewModel : BaseDetailsViewModel<UserGroupWrapper, UserGroup, AfterSaveUserGroupEvent>
    {
		private Func<List<User>> _getEntitiesForAddInUsersCommand;
		public DelegateLogCommand AddInUsersCommand { get; }
		public DelegateLogCommand RemoveFromUsersCommand { get; private set; }
		private UserWrapper _selectedUsersItem;
		public UserWrapper SelectedUsersItem 
		{ 
			get { return _selectedUsersItem; }
			set 
			{ 
				if (Equals(_selectedUsersItem, value)) return;
				_selectedUsersItem = value;
				RaisePropertyChanged();
				RemoveFromUsersCommand.RaiseCanExecuteChanged();
			}
		}

        public UserGroupDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInUsersCommand == null) _getEntitiesForAddInUsersCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };;
			if (AddInUsersCommand == null) AddInUsersCommand = new DelegateLogCommand(AddInUsersCommand_Execute_Default);
			if (RemoveFromUsersCommand == null) RemoveFromUsersCommand = new DelegateLogCommand(RemoveFromUsersCommand_Execute_Default, RemoveFromUsersCommand_CanExecute_Default);

		}

			private void AddInUsersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<User, UserWrapper>(_getEntitiesForAddInUsersCommand(), Item.Users);
			}

			private void RemoveFromUsersCommand_Execute_Default()
			{
				Item.Users.Remove(SelectedUsersItem);
			}

			private bool RemoveFromUsersCommand_CanExecute_Default()
			{
				return SelectedUsersItem != null;
			}


    }

    public partial class GlobalPropertiesDetailsViewModel : BaseDetailsViewModel<GlobalPropertiesWrapper, GlobalProperties, AfterSaveGlobalPropertiesEvent>
    {
		//private Func<Task<List<Company>>> _getEntitiesForSelectOurCompanyCommand;
		private Func<List<Company>> _getEntitiesForSelectOurCompanyCommand;
		public DelegateLogCommand SelectOurCompanyCommand { get; private set; }
		public DelegateLogCommand ClearOurCompanyCommand { get; private set; }

		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectStandartPaymentsConditionSetCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectStandartPaymentsConditionSetCommand;
		public DelegateLogCommand SelectStandartPaymentsConditionSetCommand { get; private set; }
		public DelegateLogCommand ClearStandartPaymentsConditionSetCommand { get; private set; }

		//private Func<Task<List<Parameter>>> _getEntitiesForSelectNewProductParameterCommand;
		private Func<List<Parameter>> _getEntitiesForSelectNewProductParameterCommand;
		public DelegateLogCommand SelectNewProductParameterCommand { get; private set; }
		public DelegateLogCommand ClearNewProductParameterCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectNewProductParameterGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectNewProductParameterGroupCommand;
		public DelegateLogCommand SelectNewProductParameterGroupCommand { get; private set; }
		public DelegateLogCommand ClearNewProductParameterGroupCommand { get; private set; }

		//private Func<Task<List<Parameter>>> _getEntitiesForSelectServiceParameterCommand;
		private Func<List<Parameter>> _getEntitiesForSelectServiceParameterCommand;
		public DelegateLogCommand SelectServiceParameterCommand { get; private set; }
		public DelegateLogCommand ClearServiceParameterCommand { get; private set; }

		//private Func<Task<List<Parameter>>> _getEntitiesForSelectSupervisionParameterCommand;
		private Func<List<Parameter>> _getEntitiesForSelectSupervisionParameterCommand;
		public DelegateLogCommand SelectSupervisionParameterCommand { get; private set; }
		public DelegateLogCommand ClearSupervisionParameterCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectVoltageGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectVoltageGroupCommand;
		public DelegateLogCommand SelectVoltageGroupCommand { get; private set; }
		public DelegateLogCommand ClearVoltageGroupCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectIsolationMaterialGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectIsolationMaterialGroupCommand;
		public DelegateLogCommand SelectIsolationMaterialGroupCommand { get; private set; }
		public DelegateLogCommand ClearIsolationMaterialGroupCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectIsolationColorGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectIsolationColorGroupCommand;
		public DelegateLogCommand SelectIsolationColorGroupCommand { get; private set; }
		public DelegateLogCommand ClearIsolationColorGroupCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectIsolationDpuGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectIsolationDpuGroupCommand;
		public DelegateLogCommand SelectIsolationDpuGroupCommand { get; private set; }
		public DelegateLogCommand ClearIsolationDpuGroupCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectComplectDesignationGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectComplectDesignationGroupCommand;
		public DelegateLogCommand SelectComplectDesignationGroupCommand { get; private set; }
		public DelegateLogCommand ClearComplectDesignationGroupCommand { get; private set; }

		//private Func<Task<List<Parameter>>> _getEntitiesForSelectComplectsParameterCommand;
		private Func<List<Parameter>> _getEntitiesForSelectComplectsParameterCommand;
		public DelegateLogCommand SelectComplectsParameterCommand { get; private set; }
		public DelegateLogCommand ClearComplectsParameterCommand { get; private set; }

		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectComplectsGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectComplectsGroupCommand;
		public DelegateLogCommand SelectComplectsGroupCommand { get; private set; }
		public DelegateLogCommand ClearComplectsGroupCommand { get; private set; }

		//private Func<Task<List<ProjectType>>> _getEntitiesForSelectDefaultProjectTypeCommand;
		private Func<List<ProjectType>> _getEntitiesForSelectDefaultProjectTypeCommand;
		public DelegateLogCommand SelectDefaultProjectTypeCommand { get; private set; }
		public DelegateLogCommand ClearDefaultProjectTypeCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectRecipientSupervisionLetterEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectRecipientSupervisionLetterEmployeeCommand;
		public DelegateLogCommand SelectRecipientSupervisionLetterEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearRecipientSupervisionLetterEmployeeCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectSenderOfferEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectSenderOfferEmployeeCommand;
		public DelegateLogCommand SelectSenderOfferEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearSenderOfferEmployeeCommand { get; private set; }

		//private Func<Task<List<ActivityField>>> _getEntitiesForSelectHvtProducersActivityFieldCommand;
		private Func<List<ActivityField>> _getEntitiesForSelectHvtProducersActivityFieldCommand;
		public DelegateLogCommand SelectHvtProducersActivityFieldCommand { get; private set; }
		public DelegateLogCommand ClearHvtProducersActivityFieldCommand { get; private set; }

		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectPaymentConditionSetCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectPaymentConditionSetCommand;
		public DelegateLogCommand SelectPaymentConditionSetCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionSetCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectDeveloperCommand;
		private Func<List<User>> _getEntitiesForSelectDeveloperCommand;
		public DelegateLogCommand SelectDeveloperCommand { get; private set; }
		public DelegateLogCommand ClearDeveloperCommand { get; private set; }

		//private Func<Task<List<Product>>> _getEntitiesForSelectProductIncludedDefaultCommand;
		private Func<List<Product>> _getEntitiesForSelectProductIncludedDefaultCommand;
		public DelegateLogCommand SelectProductIncludedDefaultCommand { get; private set; }
		public DelegateLogCommand ClearProductIncludedDefaultCommand { get; private set; }

		//private Func<Task<List<Parameter>>> _getEntitiesForSelectEmptyParameterCurrentTransformersSetCommand;
		private Func<List<Parameter>> _getEntitiesForSelectEmptyParameterCurrentTransformersSetCommand;
		public DelegateLogCommand SelectEmptyParameterCurrentTransformersSetCommand { get; private set; }
		public DelegateLogCommand ClearEmptyParameterCurrentTransformersSetCommand { get; private set; }

		//private Func<Task<List<Parameter>>> _getEntitiesForSelectParameterCurrentTransformersSetCustomCommand;
		private Func<List<Parameter>> _getEntitiesForSelectParameterCurrentTransformersSetCustomCommand;
		public DelegateLogCommand SelectParameterCurrentTransformersSetCustomCommand { get; private set; }
		public DelegateLogCommand ClearParameterCurrentTransformersSetCustomCommand { get; private set; }

        public GlobalPropertiesDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectOurCompanyCommand == null) _getEntitiesForSelectOurCompanyCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectOurCompanyCommand == null) SelectOurCompanyCommand = new DelegateLogCommand(SelectOurCompanyCommand_Execute_Default);
			if (ClearOurCompanyCommand == null) ClearOurCompanyCommand = new DelegateLogCommand(ClearOurCompanyCommand_Execute_Default);

			
			if (_getEntitiesForSelectStandartPaymentsConditionSetCommand == null) _getEntitiesForSelectStandartPaymentsConditionSetCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectStandartPaymentsConditionSetCommand == null) SelectStandartPaymentsConditionSetCommand = new DelegateLogCommand(SelectStandartPaymentsConditionSetCommand_Execute_Default);
			if (ClearStandartPaymentsConditionSetCommand == null) ClearStandartPaymentsConditionSetCommand = new DelegateLogCommand(ClearStandartPaymentsConditionSetCommand_Execute_Default);

			
			if (_getEntitiesForSelectNewProductParameterCommand == null) _getEntitiesForSelectNewProductParameterCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };
			if (SelectNewProductParameterCommand == null) SelectNewProductParameterCommand = new DelegateLogCommand(SelectNewProductParameterCommand_Execute_Default);
			if (ClearNewProductParameterCommand == null) ClearNewProductParameterCommand = new DelegateLogCommand(ClearNewProductParameterCommand_Execute_Default);

			
			if (_getEntitiesForSelectNewProductParameterGroupCommand == null) _getEntitiesForSelectNewProductParameterGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectNewProductParameterGroupCommand == null) SelectNewProductParameterGroupCommand = new DelegateLogCommand(SelectNewProductParameterGroupCommand_Execute_Default);
			if (ClearNewProductParameterGroupCommand == null) ClearNewProductParameterGroupCommand = new DelegateLogCommand(ClearNewProductParameterGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectServiceParameterCommand == null) _getEntitiesForSelectServiceParameterCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };
			if (SelectServiceParameterCommand == null) SelectServiceParameterCommand = new DelegateLogCommand(SelectServiceParameterCommand_Execute_Default);
			if (ClearServiceParameterCommand == null) ClearServiceParameterCommand = new DelegateLogCommand(ClearServiceParameterCommand_Execute_Default);

			
			if (_getEntitiesForSelectSupervisionParameterCommand == null) _getEntitiesForSelectSupervisionParameterCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };
			if (SelectSupervisionParameterCommand == null) SelectSupervisionParameterCommand = new DelegateLogCommand(SelectSupervisionParameterCommand_Execute_Default);
			if (ClearSupervisionParameterCommand == null) ClearSupervisionParameterCommand = new DelegateLogCommand(ClearSupervisionParameterCommand_Execute_Default);

			
			if (_getEntitiesForSelectVoltageGroupCommand == null) _getEntitiesForSelectVoltageGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectVoltageGroupCommand == null) SelectVoltageGroupCommand = new DelegateLogCommand(SelectVoltageGroupCommand_Execute_Default);
			if (ClearVoltageGroupCommand == null) ClearVoltageGroupCommand = new DelegateLogCommand(ClearVoltageGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectIsolationMaterialGroupCommand == null) _getEntitiesForSelectIsolationMaterialGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectIsolationMaterialGroupCommand == null) SelectIsolationMaterialGroupCommand = new DelegateLogCommand(SelectIsolationMaterialGroupCommand_Execute_Default);
			if (ClearIsolationMaterialGroupCommand == null) ClearIsolationMaterialGroupCommand = new DelegateLogCommand(ClearIsolationMaterialGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectIsolationColorGroupCommand == null) _getEntitiesForSelectIsolationColorGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectIsolationColorGroupCommand == null) SelectIsolationColorGroupCommand = new DelegateLogCommand(SelectIsolationColorGroupCommand_Execute_Default);
			if (ClearIsolationColorGroupCommand == null) ClearIsolationColorGroupCommand = new DelegateLogCommand(ClearIsolationColorGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectIsolationDpuGroupCommand == null) _getEntitiesForSelectIsolationDpuGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectIsolationDpuGroupCommand == null) SelectIsolationDpuGroupCommand = new DelegateLogCommand(SelectIsolationDpuGroupCommand_Execute_Default);
			if (ClearIsolationDpuGroupCommand == null) ClearIsolationDpuGroupCommand = new DelegateLogCommand(ClearIsolationDpuGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectComplectDesignationGroupCommand == null) _getEntitiesForSelectComplectDesignationGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectComplectDesignationGroupCommand == null) SelectComplectDesignationGroupCommand = new DelegateLogCommand(SelectComplectDesignationGroupCommand_Execute_Default);
			if (ClearComplectDesignationGroupCommand == null) ClearComplectDesignationGroupCommand = new DelegateLogCommand(ClearComplectDesignationGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectComplectsParameterCommand == null) _getEntitiesForSelectComplectsParameterCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };
			if (SelectComplectsParameterCommand == null) SelectComplectsParameterCommand = new DelegateLogCommand(SelectComplectsParameterCommand_Execute_Default);
			if (ClearComplectsParameterCommand == null) ClearComplectsParameterCommand = new DelegateLogCommand(ClearComplectsParameterCommand_Execute_Default);

			
			if (_getEntitiesForSelectComplectsGroupCommand == null) _getEntitiesForSelectComplectsGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectComplectsGroupCommand == null) SelectComplectsGroupCommand = new DelegateLogCommand(SelectComplectsGroupCommand_Execute_Default);
			if (ClearComplectsGroupCommand == null) ClearComplectsGroupCommand = new DelegateLogCommand(ClearComplectsGroupCommand_Execute_Default);

			
			if (_getEntitiesForSelectDefaultProjectTypeCommand == null) _getEntitiesForSelectDefaultProjectTypeCommand = () => { return UnitOfWork.Repository<ProjectType>().GetAll(); };
			if (SelectDefaultProjectTypeCommand == null) SelectDefaultProjectTypeCommand = new DelegateLogCommand(SelectDefaultProjectTypeCommand_Execute_Default);
			if (ClearDefaultProjectTypeCommand == null) ClearDefaultProjectTypeCommand = new DelegateLogCommand(ClearDefaultProjectTypeCommand_Execute_Default);

			
			if (_getEntitiesForSelectRecipientSupervisionLetterEmployeeCommand == null) _getEntitiesForSelectRecipientSupervisionLetterEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectRecipientSupervisionLetterEmployeeCommand == null) SelectRecipientSupervisionLetterEmployeeCommand = new DelegateLogCommand(SelectRecipientSupervisionLetterEmployeeCommand_Execute_Default);
			if (ClearRecipientSupervisionLetterEmployeeCommand == null) ClearRecipientSupervisionLetterEmployeeCommand = new DelegateLogCommand(ClearRecipientSupervisionLetterEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForSelectSenderOfferEmployeeCommand == null) _getEntitiesForSelectSenderOfferEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectSenderOfferEmployeeCommand == null) SelectSenderOfferEmployeeCommand = new DelegateLogCommand(SelectSenderOfferEmployeeCommand_Execute_Default);
			if (ClearSenderOfferEmployeeCommand == null) ClearSenderOfferEmployeeCommand = new DelegateLogCommand(ClearSenderOfferEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForSelectHvtProducersActivityFieldCommand == null) _getEntitiesForSelectHvtProducersActivityFieldCommand = () => { return UnitOfWork.Repository<ActivityField>().GetAll(); };
			if (SelectHvtProducersActivityFieldCommand == null) SelectHvtProducersActivityFieldCommand = new DelegateLogCommand(SelectHvtProducersActivityFieldCommand_Execute_Default);
			if (ClearHvtProducersActivityFieldCommand == null) ClearHvtProducersActivityFieldCommand = new DelegateLogCommand(ClearHvtProducersActivityFieldCommand_Execute_Default);

			
			if (_getEntitiesForSelectPaymentConditionSetCommand == null) _getEntitiesForSelectPaymentConditionSetCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectPaymentConditionSetCommand == null) SelectPaymentConditionSetCommand = new DelegateLogCommand(SelectPaymentConditionSetCommand_Execute_Default);
			if (ClearPaymentConditionSetCommand == null) ClearPaymentConditionSetCommand = new DelegateLogCommand(ClearPaymentConditionSetCommand_Execute_Default);

			
			if (_getEntitiesForSelectDeveloperCommand == null) _getEntitiesForSelectDeveloperCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectDeveloperCommand == null) SelectDeveloperCommand = new DelegateLogCommand(SelectDeveloperCommand_Execute_Default);
			if (ClearDeveloperCommand == null) ClearDeveloperCommand = new DelegateLogCommand(ClearDeveloperCommand_Execute_Default);

			
			if (_getEntitiesForSelectProductIncludedDefaultCommand == null) _getEntitiesForSelectProductIncludedDefaultCommand = () => { return UnitOfWork.Repository<Product>().GetAll(); };
			if (SelectProductIncludedDefaultCommand == null) SelectProductIncludedDefaultCommand = new DelegateLogCommand(SelectProductIncludedDefaultCommand_Execute_Default);
			if (ClearProductIncludedDefaultCommand == null) ClearProductIncludedDefaultCommand = new DelegateLogCommand(ClearProductIncludedDefaultCommand_Execute_Default);

			
			if (_getEntitiesForSelectEmptyParameterCurrentTransformersSetCommand == null) _getEntitiesForSelectEmptyParameterCurrentTransformersSetCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };
			if (SelectEmptyParameterCurrentTransformersSetCommand == null) SelectEmptyParameterCurrentTransformersSetCommand = new DelegateLogCommand(SelectEmptyParameterCurrentTransformersSetCommand_Execute_Default);
			if (ClearEmptyParameterCurrentTransformersSetCommand == null) ClearEmptyParameterCurrentTransformersSetCommand = new DelegateLogCommand(ClearEmptyParameterCurrentTransformersSetCommand_Execute_Default);

			
			if (_getEntitiesForSelectParameterCurrentTransformersSetCustomCommand == null) _getEntitiesForSelectParameterCurrentTransformersSetCustomCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };
			if (SelectParameterCurrentTransformersSetCustomCommand == null) SelectParameterCurrentTransformersSetCustomCommand = new DelegateLogCommand(SelectParameterCurrentTransformersSetCustomCommand_Execute_Default);
			if (ClearParameterCurrentTransformersSetCustomCommand == null) ClearParameterCurrentTransformersSetCustomCommand = new DelegateLogCommand(ClearParameterCurrentTransformersSetCustomCommand_Execute_Default);

		}

		private void SelectOurCompanyCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectOurCompanyCommand(), nameof(Item.OurCompany), Item.OurCompany?.Id);
		}

		private void ClearOurCompanyCommand_Execute_Default() 
		{
						Item.OurCompany = null;		    
		}

		private void SelectStandartPaymentsConditionSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectStandartPaymentsConditionSetCommand(), nameof(Item.StandartPaymentsConditionSet), Item.StandartPaymentsConditionSet?.Id);
		}

		private void ClearStandartPaymentsConditionSetCommand_Execute_Default() 
		{
						Item.StandartPaymentsConditionSet = null;		    
		}

		private void SelectNewProductParameterCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Parameter, ParameterWrapper>(_getEntitiesForSelectNewProductParameterCommand(), nameof(Item.NewProductParameter), Item.NewProductParameter?.Id);
		}

		private void ClearNewProductParameterCommand_Execute_Default() 
		{
						Item.NewProductParameter = null;		    
		}

		private void SelectNewProductParameterGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectNewProductParameterGroupCommand(), nameof(Item.NewProductParameterGroup), Item.NewProductParameterGroup?.Id);
		}

		private void ClearNewProductParameterGroupCommand_Execute_Default() 
		{
						Item.NewProductParameterGroup = null;		    
		}

		private void SelectServiceParameterCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Parameter, ParameterWrapper>(_getEntitiesForSelectServiceParameterCommand(), nameof(Item.ServiceParameter), Item.ServiceParameter?.Id);
		}

		private void ClearServiceParameterCommand_Execute_Default() 
		{
						Item.ServiceParameter = null;		    
		}

		private void SelectSupervisionParameterCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Parameter, ParameterWrapper>(_getEntitiesForSelectSupervisionParameterCommand(), nameof(Item.SupervisionParameter), Item.SupervisionParameter?.Id);
		}

		private void ClearSupervisionParameterCommand_Execute_Default() 
		{
						Item.SupervisionParameter = null;		    
		}

		private void SelectVoltageGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectVoltageGroupCommand(), nameof(Item.VoltageGroup), Item.VoltageGroup?.Id);
		}

		private void ClearVoltageGroupCommand_Execute_Default() 
		{
						Item.VoltageGroup = null;		    
		}

		private void SelectIsolationMaterialGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectIsolationMaterialGroupCommand(), nameof(Item.IsolationMaterialGroup), Item.IsolationMaterialGroup?.Id);
		}

		private void ClearIsolationMaterialGroupCommand_Execute_Default() 
		{
						Item.IsolationMaterialGroup = null;		    
		}

		private void SelectIsolationColorGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectIsolationColorGroupCommand(), nameof(Item.IsolationColorGroup), Item.IsolationColorGroup?.Id);
		}

		private void ClearIsolationColorGroupCommand_Execute_Default() 
		{
						Item.IsolationColorGroup = null;		    
		}

		private void SelectIsolationDpuGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectIsolationDpuGroupCommand(), nameof(Item.IsolationDpuGroup), Item.IsolationDpuGroup?.Id);
		}

		private void ClearIsolationDpuGroupCommand_Execute_Default() 
		{
						Item.IsolationDpuGroup = null;		    
		}

		private void SelectComplectDesignationGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectComplectDesignationGroupCommand(), nameof(Item.ComplectDesignationGroup), Item.ComplectDesignationGroup?.Id);
		}

		private void ClearComplectDesignationGroupCommand_Execute_Default() 
		{
						Item.ComplectDesignationGroup = null;		    
		}

		private void SelectComplectsParameterCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Parameter, ParameterWrapper>(_getEntitiesForSelectComplectsParameterCommand(), nameof(Item.ComplectsParameter), Item.ComplectsParameter?.Id);
		}

		private void ClearComplectsParameterCommand_Execute_Default() 
		{
						Item.ComplectsParameter = null;		    
		}

		private void SelectComplectsGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectComplectsGroupCommand(), nameof(Item.ComplectsGroup), Item.ComplectsGroup?.Id);
		}

		private void ClearComplectsGroupCommand_Execute_Default() 
		{
						Item.ComplectsGroup = null;		    
		}

		private void SelectDefaultProjectTypeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProjectType, ProjectTypeWrapper>(_getEntitiesForSelectDefaultProjectTypeCommand(), nameof(Item.DefaultProjectType), Item.DefaultProjectType?.Id);
		}

		private void ClearDefaultProjectTypeCommand_Execute_Default() 
		{
						Item.DefaultProjectType = null;		    
		}

		private void SelectRecipientSupervisionLetterEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectRecipientSupervisionLetterEmployeeCommand(), nameof(Item.RecipientSupervisionLetterEmployee), Item.RecipientSupervisionLetterEmployee?.Id);
		}

		private void ClearRecipientSupervisionLetterEmployeeCommand_Execute_Default() 
		{
						Item.RecipientSupervisionLetterEmployee = null;		    
		}

		private void SelectSenderOfferEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectSenderOfferEmployeeCommand(), nameof(Item.SenderOfferEmployee), Item.SenderOfferEmployee?.Id);
		}

		private void ClearSenderOfferEmployeeCommand_Execute_Default() 
		{
						Item.SenderOfferEmployee = null;		    
		}

		private void SelectHvtProducersActivityFieldCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ActivityField, ActivityFieldWrapper>(_getEntitiesForSelectHvtProducersActivityFieldCommand(), nameof(Item.HvtProducersActivityField), Item.HvtProducersActivityField?.Id);
		}

		private void ClearHvtProducersActivityFieldCommand_Execute_Default() 
		{
						Item.HvtProducersActivityField = null;		    
		}

		private void SelectPaymentConditionSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectPaymentConditionSetCommand(), nameof(Item.PaymentConditionSet), Item.PaymentConditionSet?.Id);
		}

		private void ClearPaymentConditionSetCommand_Execute_Default() 
		{
						Item.PaymentConditionSet = null;		    
		}

		private void SelectDeveloperCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectDeveloperCommand(), nameof(Item.Developer), Item.Developer?.Id);
		}

		private void ClearDeveloperCommand_Execute_Default() 
		{
						Item.Developer = null;		    
		}

		private void SelectProductIncludedDefaultCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Product, ProductWrapper>(_getEntitiesForSelectProductIncludedDefaultCommand(), nameof(Item.ProductIncludedDefault), Item.ProductIncludedDefault?.Id);
		}

		private void ClearProductIncludedDefaultCommand_Execute_Default() 
		{
						Item.ProductIncludedDefault = null;		    
		}

		private void SelectEmptyParameterCurrentTransformersSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Parameter, ParameterWrapper>(_getEntitiesForSelectEmptyParameterCurrentTransformersSetCommand(), nameof(Item.EmptyParameterCurrentTransformersSet), Item.EmptyParameterCurrentTransformersSet?.Id);
		}

		private void ClearEmptyParameterCurrentTransformersSetCommand_Execute_Default() 
		{
						Item.EmptyParameterCurrentTransformersSet = null;		    
		}

		private void SelectParameterCurrentTransformersSetCustomCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Parameter, ParameterWrapper>(_getEntitiesForSelectParameterCurrentTransformersSetCustomCommand(), nameof(Item.ParameterCurrentTransformersSetCustom), Item.ParameterCurrentTransformersSetCustom?.Id);
		}

		private void ClearParameterCurrentTransformersSetCustomCommand_Execute_Default() 
		{
						Item.ParameterCurrentTransformersSetCustom = null;		    
		}


    }

    public partial class AddressDetailsViewModel : BaseDetailsViewModel<AddressWrapper, Address, AfterSaveAddressEvent>
    {
		//private Func<Task<List<Locality>>> _getEntitiesForSelectLocalityCommand;
		private Func<List<Locality>> _getEntitiesForSelectLocalityCommand;
		public DelegateLogCommand SelectLocalityCommand { get; private set; }
		public DelegateLogCommand ClearLocalityCommand { get; private set; }

        public AddressDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectLocalityCommand == null) _getEntitiesForSelectLocalityCommand = () => { return UnitOfWork.Repository<Locality>().GetAll(); };
			if (SelectLocalityCommand == null) SelectLocalityCommand = new DelegateLogCommand(SelectLocalityCommand_Execute_Default);
			if (ClearLocalityCommand == null) ClearLocalityCommand = new DelegateLogCommand(ClearLocalityCommand_Execute_Default);

		}

		private void SelectLocalityCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Locality, LocalityWrapper>(_getEntitiesForSelectLocalityCommand(), nameof(Item.Locality), Item.Locality?.Id);
		}

		private void ClearLocalityCommand_Execute_Default() 
		{
						Item.Locality = null;		    
		}


    }

    public partial class CountryDetailsViewModel : BaseDetailsViewModel<CountryWrapper, Country, AfterSaveCountryEvent>
    {
        public CountryDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class DistrictDetailsViewModel : BaseDetailsViewModel<DistrictWrapper, District, AfterSaveDistrictEvent>
    {
		//private Func<Task<List<Country>>> _getEntitiesForSelectCountryCommand;
		private Func<List<Country>> _getEntitiesForSelectCountryCommand;
		public DelegateLogCommand SelectCountryCommand { get; private set; }
		public DelegateLogCommand ClearCountryCommand { get; private set; }

        public DistrictDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectCountryCommand == null) _getEntitiesForSelectCountryCommand = () => { return UnitOfWork.Repository<Country>().GetAll(); };
			if (SelectCountryCommand == null) SelectCountryCommand = new DelegateLogCommand(SelectCountryCommand_Execute_Default);
			if (ClearCountryCommand == null) ClearCountryCommand = new DelegateLogCommand(ClearCountryCommand_Execute_Default);

		}

		private void SelectCountryCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Country, CountryWrapper>(_getEntitiesForSelectCountryCommand(), nameof(Item.Country), Item.Country?.Id);
		}

		private void ClearCountryCommand_Execute_Default() 
		{
						Item.Country = null;		    
		}


    }

    public partial class LocalityDetailsViewModel : BaseDetailsViewModel<LocalityWrapper, Locality, AfterSaveLocalityEvent>
    {
		//private Func<Task<List<LocalityType>>> _getEntitiesForSelectLocalityTypeCommand;
		private Func<List<LocalityType>> _getEntitiesForSelectLocalityTypeCommand;
		public DelegateLogCommand SelectLocalityTypeCommand { get; private set; }
		public DelegateLogCommand ClearLocalityTypeCommand { get; private set; }

		//private Func<Task<List<Region>>> _getEntitiesForSelectRegionCommand;
		private Func<List<Region>> _getEntitiesForSelectRegionCommand;
		public DelegateLogCommand SelectRegionCommand { get; private set; }
		public DelegateLogCommand ClearRegionCommand { get; private set; }

        public LocalityDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectLocalityTypeCommand == null) _getEntitiesForSelectLocalityTypeCommand = () => { return UnitOfWork.Repository<LocalityType>().GetAll(); };
			if (SelectLocalityTypeCommand == null) SelectLocalityTypeCommand = new DelegateLogCommand(SelectLocalityTypeCommand_Execute_Default);
			if (ClearLocalityTypeCommand == null) ClearLocalityTypeCommand = new DelegateLogCommand(ClearLocalityTypeCommand_Execute_Default);

			
			if (_getEntitiesForSelectRegionCommand == null) _getEntitiesForSelectRegionCommand = () => { return UnitOfWork.Repository<Region>().GetAll(); };
			if (SelectRegionCommand == null) SelectRegionCommand = new DelegateLogCommand(SelectRegionCommand_Execute_Default);
			if (ClearRegionCommand == null) ClearRegionCommand = new DelegateLogCommand(ClearRegionCommand_Execute_Default);

		}

		private void SelectLocalityTypeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<LocalityType, LocalityTypeWrapper>(_getEntitiesForSelectLocalityTypeCommand(), nameof(Item.LocalityType), Item.LocalityType?.Id);
		}

		private void ClearLocalityTypeCommand_Execute_Default() 
		{
						Item.LocalityType = null;		    
		}

		private void SelectRegionCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Region, RegionWrapper>(_getEntitiesForSelectRegionCommand(), nameof(Item.Region), Item.Region?.Id);
		}

		private void ClearRegionCommand_Execute_Default() 
		{
						Item.Region = null;		    
		}


    }

    public partial class LocalityTypeDetailsViewModel : BaseDetailsViewModel<LocalityTypeWrapper, LocalityType, AfterSaveLocalityTypeEvent>
    {
        public LocalityTypeDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class RegionDetailsViewModel : BaseDetailsViewModel<RegionWrapper, Region, AfterSaveRegionEvent>
    {
		//private Func<Task<List<District>>> _getEntitiesForSelectDistrictCommand;
		private Func<List<District>> _getEntitiesForSelectDistrictCommand;
		public DelegateLogCommand SelectDistrictCommand { get; private set; }
		public DelegateLogCommand ClearDistrictCommand { get; private set; }

        public RegionDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectDistrictCommand == null) _getEntitiesForSelectDistrictCommand = () => { return UnitOfWork.Repository<District>().GetAll(); };
			if (SelectDistrictCommand == null) SelectDistrictCommand = new DelegateLogCommand(SelectDistrictCommand_Execute_Default);
			if (ClearDistrictCommand == null) ClearDistrictCommand = new DelegateLogCommand(ClearDistrictCommand_Execute_Default);

		}

		private void SelectDistrictCommand_Execute_Default() 
		{
            SelectAndSetWrapper<District, DistrictWrapper>(_getEntitiesForSelectDistrictCommand(), nameof(Item.District), Item.District?.Id);
		}

		private void ClearDistrictCommand_Execute_Default() 
		{
						Item.District = null;		    
		}


    }

    public partial class SumDetailsViewModel : BaseDetailsViewModel<SumWrapper, Sum, AfterSaveSumEvent>
    {
        public SumDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class CurrencyExchangeRateDetailsViewModel : BaseDetailsViewModel<CurrencyExchangeRateWrapper, CurrencyExchangeRate, AfterSaveCurrencyExchangeRateEvent>
    {
        public CurrencyExchangeRateDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class NoteDetailsViewModel : BaseDetailsViewModel<NoteWrapper, Note, AfterSaveNoteEvent>
    {
        public NoteDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class OfferUnitDetailsViewModel : BaseDetailsViewModel<OfferUnitWrapper, OfferUnit, AfterSaveOfferUnitEvent>
    {
		//private Func<Task<List<Offer>>> _getEntitiesForSelectOfferCommand;
		private Func<List<Offer>> _getEntitiesForSelectOfferCommand;
		public DelegateLogCommand SelectOfferCommand { get; private set; }
		public DelegateLogCommand ClearOfferCommand { get; private set; }

		//private Func<Task<List<Facility>>> _getEntitiesForSelectFacilityCommand;
		private Func<List<Facility>> _getEntitiesForSelectFacilityCommand;
		public DelegateLogCommand SelectFacilityCommand { get; private set; }
		public DelegateLogCommand ClearFacilityCommand { get; private set; }

		//private Func<Task<List<Product>>> _getEntitiesForSelectProductCommand;
		private Func<List<Product>> _getEntitiesForSelectProductCommand;
		public DelegateLogCommand SelectProductCommand { get; private set; }
		public DelegateLogCommand ClearProductCommand { get; private set; }

		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectPaymentConditionSetCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectPaymentConditionSetCommand;
		public DelegateLogCommand SelectPaymentConditionSetCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionSetCommand { get; private set; }

		private Func<List<ProductIncluded>> _getEntitiesForAddInProductsIncludedCommand;
		public DelegateLogCommand AddInProductsIncludedCommand { get; }
		public DelegateLogCommand RemoveFromProductsIncludedCommand { get; private set; }
		private ProductIncludedWrapper _selectedProductsIncludedItem;
		public ProductIncludedWrapper SelectedProductsIncludedItem 
		{ 
			get { return _selectedProductsIncludedItem; }
			set 
			{ 
				if (Equals(_selectedProductsIncludedItem, value)) return;
				_selectedProductsIncludedItem = value;
				RaisePropertyChanged();
				RemoveFromProductsIncludedCommand.RaiseCanExecuteChanged();
			}
		}

        public OfferUnitDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectOfferCommand == null) _getEntitiesForSelectOfferCommand = () => { return UnitOfWork.Repository<Offer>().GetAll(); };
			if (SelectOfferCommand == null) SelectOfferCommand = new DelegateLogCommand(SelectOfferCommand_Execute_Default);
			if (ClearOfferCommand == null) ClearOfferCommand = new DelegateLogCommand(ClearOfferCommand_Execute_Default);

			
			if (_getEntitiesForSelectFacilityCommand == null) _getEntitiesForSelectFacilityCommand = () => { return UnitOfWork.Repository<Facility>().GetAll(); };
			if (SelectFacilityCommand == null) SelectFacilityCommand = new DelegateLogCommand(SelectFacilityCommand_Execute_Default);
			if (ClearFacilityCommand == null) ClearFacilityCommand = new DelegateLogCommand(ClearFacilityCommand_Execute_Default);

			
			if (_getEntitiesForSelectProductCommand == null) _getEntitiesForSelectProductCommand = () => { return UnitOfWork.Repository<Product>().GetAll(); };
			if (SelectProductCommand == null) SelectProductCommand = new DelegateLogCommand(SelectProductCommand_Execute_Default);
			if (ClearProductCommand == null) ClearProductCommand = new DelegateLogCommand(ClearProductCommand_Execute_Default);

			
			if (_getEntitiesForSelectPaymentConditionSetCommand == null) _getEntitiesForSelectPaymentConditionSetCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectPaymentConditionSetCommand == null) SelectPaymentConditionSetCommand = new DelegateLogCommand(SelectPaymentConditionSetCommand_Execute_Default);
			if (ClearPaymentConditionSetCommand == null) ClearPaymentConditionSetCommand = new DelegateLogCommand(ClearPaymentConditionSetCommand_Execute_Default);

			
			if (_getEntitiesForAddInProductsIncludedCommand == null) _getEntitiesForAddInProductsIncludedCommand = () => { return UnitOfWork.Repository<ProductIncluded>().GetAll(); };;
			if (AddInProductsIncludedCommand == null) AddInProductsIncludedCommand = new DelegateLogCommand(AddInProductsIncludedCommand_Execute_Default);
			if (RemoveFromProductsIncludedCommand == null) RemoveFromProductsIncludedCommand = new DelegateLogCommand(RemoveFromProductsIncludedCommand_Execute_Default, RemoveFromProductsIncludedCommand_CanExecute_Default);

		}

		private void SelectOfferCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Offer, OfferWrapper>(_getEntitiesForSelectOfferCommand(), nameof(Item.Offer), Item.Offer?.Id);
		}

		private void ClearOfferCommand_Execute_Default() 
		{
						Item.Offer = null;		    
		}

		private void SelectFacilityCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Facility, FacilityWrapper>(_getEntitiesForSelectFacilityCommand(), nameof(Item.Facility), Item.Facility?.Id);
		}

		private void ClearFacilityCommand_Execute_Default() 
		{
						Item.Facility = null;		    
		}

		private void SelectProductCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Product, ProductWrapper>(_getEntitiesForSelectProductCommand(), nameof(Item.Product), Item.Product?.Id);
		}

		private void ClearProductCommand_Execute_Default() 
		{
						Item.Product = null;		    
		}

		private void SelectPaymentConditionSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectPaymentConditionSetCommand(), nameof(Item.PaymentConditionSet), Item.PaymentConditionSet?.Id);
		}

		private void ClearPaymentConditionSetCommand_Execute_Default() 
		{
						Item.PaymentConditionSet = null;		    
		}

			private void AddInProductsIncludedCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ProductIncluded, ProductIncludedWrapper>(_getEntitiesForAddInProductsIncludedCommand(), Item.ProductsIncluded);
			}

			private void RemoveFromProductsIncludedCommand_Execute_Default()
			{
				Item.ProductsIncluded.Remove(SelectedProductsIncludedItem);
			}

			private bool RemoveFromProductsIncludedCommand_CanExecute_Default()
			{
				return SelectedProductsIncludedItem != null;
			}


    }

    public partial class PaymentConditionSetDetailsViewModel : BaseDetailsViewModel<PaymentConditionSetWrapper, PaymentConditionSet, AfterSavePaymentConditionSetEvent>
    {
		private Func<List<PaymentCondition>> _getEntitiesForAddInPaymentConditionsCommand;
		public DelegateLogCommand AddInPaymentConditionsCommand { get; }
		public DelegateLogCommand RemoveFromPaymentConditionsCommand { get; private set; }
		private PaymentConditionWrapper _selectedPaymentConditionsItem;
		public PaymentConditionWrapper SelectedPaymentConditionsItem 
		{ 
			get { return _selectedPaymentConditionsItem; }
			set 
			{ 
				if (Equals(_selectedPaymentConditionsItem, value)) return;
				_selectedPaymentConditionsItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentConditionsCommand.RaiseCanExecuteChanged();
			}
		}

        public PaymentConditionSetDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInPaymentConditionsCommand == null) _getEntitiesForAddInPaymentConditionsCommand = () => { return UnitOfWork.Repository<PaymentCondition>().GetAll(); };;
			if (AddInPaymentConditionsCommand == null) AddInPaymentConditionsCommand = new DelegateLogCommand(AddInPaymentConditionsCommand_Execute_Default);
			if (RemoveFromPaymentConditionsCommand == null) RemoveFromPaymentConditionsCommand = new DelegateLogCommand(RemoveFromPaymentConditionsCommand_Execute_Default, RemoveFromPaymentConditionsCommand_CanExecute_Default);

		}

			private void AddInPaymentConditionsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentCondition, PaymentConditionWrapper>(_getEntitiesForAddInPaymentConditionsCommand(), Item.PaymentConditions);
			}

			private void RemoveFromPaymentConditionsCommand_Execute_Default()
			{
				Item.PaymentConditions.Remove(SelectedPaymentConditionsItem);
			}

			private bool RemoveFromPaymentConditionsCommand_CanExecute_Default()
			{
				return SelectedPaymentConditionsItem != null;
			}


    }

    public partial class ProductDependentDetailsViewModel : BaseDetailsViewModel<ProductDependentWrapper, ProductDependent, AfterSaveProductDependentEvent>
    {
		//private Func<Task<List<Product>>> _getEntitiesForSelectProductCommand;
		private Func<List<Product>> _getEntitiesForSelectProductCommand;
		public DelegateLogCommand SelectProductCommand { get; private set; }
		public DelegateLogCommand ClearProductCommand { get; private set; }

        public ProductDependentDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductCommand == null) _getEntitiesForSelectProductCommand = () => { return UnitOfWork.Repository<Product>().GetAll(); };
			if (SelectProductCommand == null) SelectProductCommand = new DelegateLogCommand(SelectProductCommand_Execute_Default);
			if (ClearProductCommand == null) ClearProductCommand = new DelegateLogCommand(ClearProductCommand_Execute_Default);

		}

		private void SelectProductCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Product, ProductWrapper>(_getEntitiesForSelectProductCommand(), nameof(Item.Product), Item.Product?.Id);
		}

		private void ClearProductCommand_Execute_Default() 
		{
						Item.Product = null;		    
		}


    }

    public partial class BankDetailsDetailsViewModel : BaseDetailsViewModel<BankDetailsWrapper, BankDetails, AfterSaveBankDetailsEvent>
    {
        public BankDetailsDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class CompanyDetailsViewModel : BaseDetailsViewModel<CompanyWrapper, Company, AfterSaveCompanyEvent>
    {
		//private Func<Task<List<CompanyForm>>> _getEntitiesForSelectFormCommand;
		private Func<List<CompanyForm>> _getEntitiesForSelectFormCommand;
		public DelegateLogCommand SelectFormCommand { get; private set; }
		public DelegateLogCommand ClearFormCommand { get; private set; }

		//private Func<Task<List<Company>>> _getEntitiesForSelectParentCompanyCommand;
		private Func<List<Company>> _getEntitiesForSelectParentCompanyCommand;
		public DelegateLogCommand SelectParentCompanyCommand { get; private set; }
		public DelegateLogCommand ClearParentCompanyCommand { get; private set; }

		//private Func<Task<List<Address>>> _getEntitiesForSelectAddressLegalCommand;
		private Func<List<Address>> _getEntitiesForSelectAddressLegalCommand;
		public DelegateLogCommand SelectAddressLegalCommand { get; private set; }
		public DelegateLogCommand ClearAddressLegalCommand { get; private set; }

		//private Func<Task<List<Address>>> _getEntitiesForSelectAddressPostCommand;
		private Func<List<Address>> _getEntitiesForSelectAddressPostCommand;
		public DelegateLogCommand SelectAddressPostCommand { get; private set; }
		public DelegateLogCommand ClearAddressPostCommand { get; private set; }

		private Func<List<BankDetails>> _getEntitiesForAddInBankDetailsListCommand;
		public DelegateLogCommand AddInBankDetailsListCommand { get; }
		public DelegateLogCommand RemoveFromBankDetailsListCommand { get; private set; }
		private BankDetailsWrapper _selectedBankDetailsListItem;
		public BankDetailsWrapper SelectedBankDetailsListItem 
		{ 
			get { return _selectedBankDetailsListItem; }
			set 
			{ 
				if (Equals(_selectedBankDetailsListItem, value)) return;
				_selectedBankDetailsListItem = value;
				RaisePropertyChanged();
				RemoveFromBankDetailsListCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<ActivityField>> _getEntitiesForAddInActivityFildsCommand;
		public DelegateLogCommand AddInActivityFildsCommand { get; }
		public DelegateLogCommand RemoveFromActivityFildsCommand { get; private set; }
		private ActivityFieldWrapper _selectedActivityFildsItem;
		public ActivityFieldWrapper SelectedActivityFildsItem 
		{ 
			get { return _selectedActivityFildsItem; }
			set 
			{ 
				if (Equals(_selectedActivityFildsItem, value)) return;
				_selectedActivityFildsItem = value;
				RaisePropertyChanged();
				RemoveFromActivityFildsCommand.RaiseCanExecuteChanged();
			}
		}

        public CompanyDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectFormCommand == null) _getEntitiesForSelectFormCommand = () => { return UnitOfWork.Repository<CompanyForm>().GetAll(); };
			if (SelectFormCommand == null) SelectFormCommand = new DelegateLogCommand(SelectFormCommand_Execute_Default);
			if (ClearFormCommand == null) ClearFormCommand = new DelegateLogCommand(ClearFormCommand_Execute_Default);

			
			if (_getEntitiesForSelectParentCompanyCommand == null) _getEntitiesForSelectParentCompanyCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectParentCompanyCommand == null) SelectParentCompanyCommand = new DelegateLogCommand(SelectParentCompanyCommand_Execute_Default);
			if (ClearParentCompanyCommand == null) ClearParentCompanyCommand = new DelegateLogCommand(ClearParentCompanyCommand_Execute_Default);

			
			if (_getEntitiesForSelectAddressLegalCommand == null) _getEntitiesForSelectAddressLegalCommand = () => { return UnitOfWork.Repository<Address>().GetAll(); };
			if (SelectAddressLegalCommand == null) SelectAddressLegalCommand = new DelegateLogCommand(SelectAddressLegalCommand_Execute_Default);
			if (ClearAddressLegalCommand == null) ClearAddressLegalCommand = new DelegateLogCommand(ClearAddressLegalCommand_Execute_Default);

			
			if (_getEntitiesForSelectAddressPostCommand == null) _getEntitiesForSelectAddressPostCommand = () => { return UnitOfWork.Repository<Address>().GetAll(); };
			if (SelectAddressPostCommand == null) SelectAddressPostCommand = new DelegateLogCommand(SelectAddressPostCommand_Execute_Default);
			if (ClearAddressPostCommand == null) ClearAddressPostCommand = new DelegateLogCommand(ClearAddressPostCommand_Execute_Default);

			
			if (_getEntitiesForAddInBankDetailsListCommand == null) _getEntitiesForAddInBankDetailsListCommand = () => { return UnitOfWork.Repository<BankDetails>().GetAll(); };;
			if (AddInBankDetailsListCommand == null) AddInBankDetailsListCommand = new DelegateLogCommand(AddInBankDetailsListCommand_Execute_Default);
			if (RemoveFromBankDetailsListCommand == null) RemoveFromBankDetailsListCommand = new DelegateLogCommand(RemoveFromBankDetailsListCommand_Execute_Default, RemoveFromBankDetailsListCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInActivityFildsCommand == null) _getEntitiesForAddInActivityFildsCommand = () => { return UnitOfWork.Repository<ActivityField>().GetAll(); };;
			if (AddInActivityFildsCommand == null) AddInActivityFildsCommand = new DelegateLogCommand(AddInActivityFildsCommand_Execute_Default);
			if (RemoveFromActivityFildsCommand == null) RemoveFromActivityFildsCommand = new DelegateLogCommand(RemoveFromActivityFildsCommand_Execute_Default, RemoveFromActivityFildsCommand_CanExecute_Default);

		}

		private void SelectFormCommand_Execute_Default() 
		{
            SelectAndSetWrapper<CompanyForm, CompanyFormWrapper>(_getEntitiesForSelectFormCommand(), nameof(Item.Form), Item.Form?.Id);
		}

		private void ClearFormCommand_Execute_Default() 
		{
						Item.Form = null;		    
		}

		private void SelectParentCompanyCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectParentCompanyCommand(), nameof(Item.ParentCompany), Item.ParentCompany?.Id);
		}

		private void ClearParentCompanyCommand_Execute_Default() 
		{
						Item.ParentCompany = null;		    
		}

		private void SelectAddressLegalCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Address, AddressWrapper>(_getEntitiesForSelectAddressLegalCommand(), nameof(Item.AddressLegal), Item.AddressLegal?.Id);
		}

		private void ClearAddressLegalCommand_Execute_Default() 
		{
						Item.AddressLegal = null;		    
		}

		private void SelectAddressPostCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Address, AddressWrapper>(_getEntitiesForSelectAddressPostCommand(), nameof(Item.AddressPost), Item.AddressPost?.Id);
		}

		private void ClearAddressPostCommand_Execute_Default() 
		{
						Item.AddressPost = null;		    
		}

			private void AddInBankDetailsListCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<BankDetails, BankDetailsWrapper>(_getEntitiesForAddInBankDetailsListCommand(), Item.BankDetailsList);
			}

			private void RemoveFromBankDetailsListCommand_Execute_Default()
			{
				Item.BankDetailsList.Remove(SelectedBankDetailsListItem);
			}

			private bool RemoveFromBankDetailsListCommand_CanExecute_Default()
			{
				return SelectedBankDetailsListItem != null;
			}

			private void AddInActivityFildsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ActivityField, ActivityFieldWrapper>(_getEntitiesForAddInActivityFildsCommand(), Item.ActivityFilds);
			}

			private void RemoveFromActivityFildsCommand_Execute_Default()
			{
				Item.ActivityFilds.Remove(SelectedActivityFildsItem);
			}

			private bool RemoveFromActivityFildsCommand_CanExecute_Default()
			{
				return SelectedActivityFildsItem != null;
			}


    }

    public partial class CompanyFormDetailsViewModel : BaseDetailsViewModel<CompanyFormWrapper, CompanyForm, AfterSaveCompanyFormEvent>
    {
        public CompanyFormDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class DocumentsRegistrationDetailsDetailsViewModel : BaseDetailsViewModel<DocumentsRegistrationDetailsWrapper, DocumentsRegistrationDetails, AfterSaveDocumentsRegistrationDetailsEvent>
    {
        public DocumentsRegistrationDetailsDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class EmployeesPositionDetailsViewModel : BaseDetailsViewModel<EmployeesPositionWrapper, EmployeesPosition, AfterSaveEmployeesPositionEvent>
    {
        public EmployeesPositionDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class FacilityTypeDetailsViewModel : BaseDetailsViewModel<FacilityTypeWrapper, FacilityType, AfterSaveFacilityTypeEvent>
    {
        public FacilityTypeDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ActivityFieldDetailsViewModel : BaseDetailsViewModel<ActivityFieldWrapper, ActivityField, AfterSaveActivityFieldEvent>
    {
        public ActivityFieldDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ContractDetailsViewModel : BaseDetailsViewModel<ContractWrapper, Contract, AfterSaveContractEvent>
    {
		//private Func<Task<List<Company>>> _getEntitiesForSelectContragentCommand;
		private Func<List<Company>> _getEntitiesForSelectContragentCommand;
		public DelegateLogCommand SelectContragentCommand { get; private set; }
		public DelegateLogCommand ClearContragentCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectContragentEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectContragentEmployeeCommand;
		public DelegateLogCommand SelectContragentEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearContragentEmployeeCommand { get; private set; }

        public ContractDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectContragentCommand == null) _getEntitiesForSelectContragentCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectContragentCommand == null) SelectContragentCommand = new DelegateLogCommand(SelectContragentCommand_Execute_Default);
			if (ClearContragentCommand == null) ClearContragentCommand = new DelegateLogCommand(ClearContragentCommand_Execute_Default);

			
			if (_getEntitiesForSelectContragentEmployeeCommand == null) _getEntitiesForSelectContragentEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectContragentEmployeeCommand == null) SelectContragentEmployeeCommand = new DelegateLogCommand(SelectContragentEmployeeCommand_Execute_Default);
			if (ClearContragentEmployeeCommand == null) ClearContragentEmployeeCommand = new DelegateLogCommand(ClearContragentEmployeeCommand_Execute_Default);

		}

		private void SelectContragentCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectContragentCommand(), nameof(Item.Contragent), Item.Contragent?.Id);
		}

		private void ClearContragentCommand_Execute_Default() 
		{
						Item.Contragent = null;		    
		}

		private void SelectContragentEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectContragentEmployeeCommand(), nameof(Item.ContragentEmployee), Item.ContragentEmployee?.Id);
		}

		private void ClearContragentEmployeeCommand_Execute_Default() 
		{
						Item.ContragentEmployee = null;		    
		}


    }

    public partial class MeasureDetailsViewModel : BaseDetailsViewModel<MeasureWrapper, Measure, AfterSaveMeasureEvent>
    {
        public MeasureDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ParameterDetailsViewModel : BaseDetailsViewModel<ParameterWrapper, Parameter, AfterSaveParameterEvent>
    {
		//private Func<Task<List<ParameterGroup>>> _getEntitiesForSelectParameterGroupCommand;
		private Func<List<ParameterGroup>> _getEntitiesForSelectParameterGroupCommand;
		public DelegateLogCommand SelectParameterGroupCommand { get; private set; }
		public DelegateLogCommand ClearParameterGroupCommand { get; private set; }

		private Func<List<ParameterRelation>> _getEntitiesForAddInParameterRelationsCommand;
		public DelegateLogCommand AddInParameterRelationsCommand { get; }
		public DelegateLogCommand RemoveFromParameterRelationsCommand { get; private set; }
		private ParameterRelationWrapper _selectedParameterRelationsItem;
		public ParameterRelationWrapper SelectedParameterRelationsItem 
		{ 
			get { return _selectedParameterRelationsItem; }
			set 
			{ 
				if (Equals(_selectedParameterRelationsItem, value)) return;
				_selectedParameterRelationsItem = value;
				RaisePropertyChanged();
				RemoveFromParameterRelationsCommand.RaiseCanExecuteChanged();
			}
		}

        public ParameterDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectParameterGroupCommand == null) _getEntitiesForSelectParameterGroupCommand = () => { return UnitOfWork.Repository<ParameterGroup>().GetAll(); };
			if (SelectParameterGroupCommand == null) SelectParameterGroupCommand = new DelegateLogCommand(SelectParameterGroupCommand_Execute_Default);
			if (ClearParameterGroupCommand == null) ClearParameterGroupCommand = new DelegateLogCommand(ClearParameterGroupCommand_Execute_Default);

			
			if (_getEntitiesForAddInParameterRelationsCommand == null) _getEntitiesForAddInParameterRelationsCommand = () => { return UnitOfWork.Repository<ParameterRelation>().GetAll(); };;
			if (AddInParameterRelationsCommand == null) AddInParameterRelationsCommand = new DelegateLogCommand(AddInParameterRelationsCommand_Execute_Default);
			if (RemoveFromParameterRelationsCommand == null) RemoveFromParameterRelationsCommand = new DelegateLogCommand(RemoveFromParameterRelationsCommand_Execute_Default, RemoveFromParameterRelationsCommand_CanExecute_Default);

		}

		private void SelectParameterGroupCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ParameterGroup, ParameterGroupWrapper>(_getEntitiesForSelectParameterGroupCommand(), nameof(Item.ParameterGroup), Item.ParameterGroup?.Id);
		}

		private void ClearParameterGroupCommand_Execute_Default() 
		{
						Item.ParameterGroup = null;		    
		}

			private void AddInParameterRelationsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ParameterRelation, ParameterRelationWrapper>(_getEntitiesForAddInParameterRelationsCommand(), Item.ParameterRelations);
			}

			private void RemoveFromParameterRelationsCommand_Execute_Default()
			{
				Item.ParameterRelations.Remove(SelectedParameterRelationsItem);
			}

			private bool RemoveFromParameterRelationsCommand_CanExecute_Default()
			{
				return SelectedParameterRelationsItem != null;
			}


    }

    public partial class ParameterGroupDetailsViewModel : BaseDetailsViewModel<ParameterGroupWrapper, ParameterGroup, AfterSaveParameterGroupEvent>
    {
		//private Func<Task<List<Measure>>> _getEntitiesForSelectMeasureCommand;
		private Func<List<Measure>> _getEntitiesForSelectMeasureCommand;
		public DelegateLogCommand SelectMeasureCommand { get; private set; }
		public DelegateLogCommand ClearMeasureCommand { get; private set; }

        public ParameterGroupDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectMeasureCommand == null) _getEntitiesForSelectMeasureCommand = () => { return UnitOfWork.Repository<Measure>().GetAll(); };
			if (SelectMeasureCommand == null) SelectMeasureCommand = new DelegateLogCommand(SelectMeasureCommand_Execute_Default);
			if (ClearMeasureCommand == null) ClearMeasureCommand = new DelegateLogCommand(ClearMeasureCommand_Execute_Default);

		}

		private void SelectMeasureCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Measure, MeasureWrapper>(_getEntitiesForSelectMeasureCommand(), nameof(Item.Measure), Item.Measure?.Id);
		}

		private void ClearMeasureCommand_Execute_Default() 
		{
						Item.Measure = null;		    
		}


    }

    public partial class ProductRelationDetailsViewModel : BaseDetailsViewModel<ProductRelationWrapper, ProductRelation, AfterSaveProductRelationEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInParentProductParametersCommand;
		public DelegateLogCommand AddInParentProductParametersCommand { get; }
		public DelegateLogCommand RemoveFromParentProductParametersCommand { get; private set; }
		private ParameterWrapper _selectedParentProductParametersItem;
		public ParameterWrapper SelectedParentProductParametersItem 
		{ 
			get { return _selectedParentProductParametersItem; }
			set 
			{ 
				if (Equals(_selectedParentProductParametersItem, value)) return;
				_selectedParentProductParametersItem = value;
				RaisePropertyChanged();
				RemoveFromParentProductParametersCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<Parameter>> _getEntitiesForAddInChildProductParametersCommand;
		public DelegateLogCommand AddInChildProductParametersCommand { get; }
		public DelegateLogCommand RemoveFromChildProductParametersCommand { get; private set; }
		private ParameterWrapper _selectedChildProductParametersItem;
		public ParameterWrapper SelectedChildProductParametersItem 
		{ 
			get { return _selectedChildProductParametersItem; }
			set 
			{ 
				if (Equals(_selectedChildProductParametersItem, value)) return;
				_selectedChildProductParametersItem = value;
				RaisePropertyChanged();
				RemoveFromChildProductParametersCommand.RaiseCanExecuteChanged();
			}
		}

        public ProductRelationDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInParentProductParametersCommand == null) _getEntitiesForAddInParentProductParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInParentProductParametersCommand == null) AddInParentProductParametersCommand = new DelegateLogCommand(AddInParentProductParametersCommand_Execute_Default);
			if (RemoveFromParentProductParametersCommand == null) RemoveFromParentProductParametersCommand = new DelegateLogCommand(RemoveFromParentProductParametersCommand_Execute_Default, RemoveFromParentProductParametersCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInChildProductParametersCommand == null) _getEntitiesForAddInChildProductParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInChildProductParametersCommand == null) AddInChildProductParametersCommand = new DelegateLogCommand(AddInChildProductParametersCommand_Execute_Default);
			if (RemoveFromChildProductParametersCommand == null) RemoveFromChildProductParametersCommand = new DelegateLogCommand(RemoveFromChildProductParametersCommand_Execute_Default, RemoveFromChildProductParametersCommand_CanExecute_Default);

		}

			private void AddInParentProductParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInParentProductParametersCommand(), Item.ParentProductParameters);
			}

			private void RemoveFromParentProductParametersCommand_Execute_Default()
			{
				Item.ParentProductParameters.Remove(SelectedParentProductParametersItem);
			}

			private bool RemoveFromParentProductParametersCommand_CanExecute_Default()
			{
				return SelectedParentProductParametersItem != null;
			}

			private void AddInChildProductParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInChildProductParametersCommand(), Item.ChildProductParameters);
			}

			private void RemoveFromChildProductParametersCommand_Execute_Default()
			{
				Item.ChildProductParameters.Remove(SelectedChildProductParametersItem);
			}

			private bool RemoveFromChildProductParametersCommand_CanExecute_Default()
			{
				return SelectedChildProductParametersItem != null;
			}


    }

    public partial class PersonDetailsViewModel : BaseDetailsViewModel<PersonWrapper, Person, AfterSavePersonEvent>
    {
        public PersonDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ParameterRelationDetailsViewModel : BaseDetailsViewModel<ParameterRelationWrapper, ParameterRelation, AfterSaveParameterRelationEvent>
    {
		private Func<List<Parameter>> _getEntitiesForAddInRequiredParametersCommand;
		public DelegateLogCommand AddInRequiredParametersCommand { get; }
		public DelegateLogCommand RemoveFromRequiredParametersCommand { get; private set; }
		private ParameterWrapper _selectedRequiredParametersItem;
		public ParameterWrapper SelectedRequiredParametersItem 
		{ 
			get { return _selectedRequiredParametersItem; }
			set 
			{ 
				if (Equals(_selectedRequiredParametersItem, value)) return;
				_selectedRequiredParametersItem = value;
				RaisePropertyChanged();
				RemoveFromRequiredParametersCommand.RaiseCanExecuteChanged();
			}
		}

        public ParameterRelationDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInRequiredParametersCommand == null) _getEntitiesForAddInRequiredParametersCommand = () => { return UnitOfWork.Repository<Parameter>().GetAll(); };;
			if (AddInRequiredParametersCommand == null) AddInRequiredParametersCommand = new DelegateLogCommand(AddInRequiredParametersCommand_Execute_Default);
			if (RemoveFromRequiredParametersCommand == null) RemoveFromRequiredParametersCommand = new DelegateLogCommand(RemoveFromRequiredParametersCommand_Execute_Default, RemoveFromRequiredParametersCommand_CanExecute_Default);

		}

			private void AddInRequiredParametersCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Parameter, ParameterWrapper>(_getEntitiesForAddInRequiredParametersCommand(), Item.RequiredParameters);
			}

			private void RemoveFromRequiredParametersCommand_Execute_Default()
			{
				Item.RequiredParameters.Remove(SelectedRequiredParametersItem);
			}

			private bool RemoveFromRequiredParametersCommand_CanExecute_Default()
			{
				return SelectedRequiredParametersItem != null;
			}


    }

    public partial class SalesUnitDetailsViewModel : BaseDetailsViewModel<SalesUnitWrapper, SalesUnit, AfterSaveSalesUnitEvent>
    {
		//private Func<Task<List<Facility>>> _getEntitiesForSelectFacilityCommand;
		private Func<List<Facility>> _getEntitiesForSelectFacilityCommand;
		public DelegateLogCommand SelectFacilityCommand { get; private set; }
		public DelegateLogCommand ClearFacilityCommand { get; private set; }

		//private Func<Task<List<Product>>> _getEntitiesForSelectProductCommand;
		private Func<List<Product>> _getEntitiesForSelectProductCommand;
		public DelegateLogCommand SelectProductCommand { get; private set; }
		public DelegateLogCommand ClearProductCommand { get; private set; }

		//private Func<Task<List<PaymentConditionSet>>> _getEntitiesForSelectPaymentConditionSetCommand;
		private Func<List<PaymentConditionSet>> _getEntitiesForSelectPaymentConditionSetCommand;
		public DelegateLogCommand SelectPaymentConditionSetCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionSetCommand { get; private set; }

		//private Func<Task<List<Project>>> _getEntitiesForSelectProjectCommand;
		private Func<List<Project>> _getEntitiesForSelectProjectCommand;
		public DelegateLogCommand SelectProjectCommand { get; private set; }
		public DelegateLogCommand ClearProjectCommand { get; private set; }

		//private Func<Task<List<Company>>> _getEntitiesForSelectProducerCommand;
		private Func<List<Company>> _getEntitiesForSelectProducerCommand;
		public DelegateLogCommand SelectProducerCommand { get; private set; }
		public DelegateLogCommand ClearProducerCommand { get; private set; }

		//private Func<Task<List<Order>>> _getEntitiesForSelectOrderCommand;
		private Func<List<Order>> _getEntitiesForSelectOrderCommand;
		public DelegateLogCommand SelectOrderCommand { get; private set; }
		public DelegateLogCommand ClearOrderCommand { get; private set; }

		//private Func<Task<List<Specification>>> _getEntitiesForSelectSpecificationCommand;
		private Func<List<Specification>> _getEntitiesForSelectSpecificationCommand;
		public DelegateLogCommand SelectSpecificationCommand { get; private set; }
		public DelegateLogCommand ClearSpecificationCommand { get; private set; }

		//private Func<Task<List<Penalty>>> _getEntitiesForSelectPenaltyCommand;
		private Func<List<Penalty>> _getEntitiesForSelectPenaltyCommand;
		public DelegateLogCommand SelectPenaltyCommand { get; private set; }
		public DelegateLogCommand ClearPenaltyCommand { get; private set; }

		//private Func<Task<List<Address>>> _getEntitiesForSelectAddressDeliveryCommand;
		private Func<List<Address>> _getEntitiesForSelectAddressDeliveryCommand;
		public DelegateLogCommand SelectAddressDeliveryCommand { get; private set; }
		public DelegateLogCommand ClearAddressDeliveryCommand { get; private set; }

		//private Func<Task<List<Address>>> _getEntitiesForSelectAddressDeliveryCalculatedCommand;
		private Func<List<Address>> _getEntitiesForSelectAddressDeliveryCalculatedCommand;
		public DelegateLogCommand SelectAddressDeliveryCalculatedCommand { get; private set; }
		public DelegateLogCommand ClearAddressDeliveryCalculatedCommand { get; private set; }

		private Func<List<ProductIncluded>> _getEntitiesForAddInProductsIncludedCommand;
		public DelegateLogCommand AddInProductsIncludedCommand { get; }
		public DelegateLogCommand RemoveFromProductsIncludedCommand { get; private set; }
		private ProductIncludedWrapper _selectedProductsIncludedItem;
		public ProductIncludedWrapper SelectedProductsIncludedItem 
		{ 
			get { return _selectedProductsIncludedItem; }
			set 
			{ 
				if (Equals(_selectedProductsIncludedItem, value)) return;
				_selectedProductsIncludedItem = value;
				RaisePropertyChanged();
				RemoveFromProductsIncludedCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<LosingReason>> _getEntitiesForAddInLosingReasonsCommand;
		public DelegateLogCommand AddInLosingReasonsCommand { get; }
		public DelegateLogCommand RemoveFromLosingReasonsCommand { get; private set; }
		private LosingReasonWrapper _selectedLosingReasonsItem;
		public LosingReasonWrapper SelectedLosingReasonsItem 
		{ 
			get { return _selectedLosingReasonsItem; }
			set 
			{ 
				if (Equals(_selectedLosingReasonsItem, value)) return;
				_selectedLosingReasonsItem = value;
				RaisePropertyChanged();
				RemoveFromLosingReasonsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PaymentActual>> _getEntitiesForAddInPaymentsActualCommand;
		public DelegateLogCommand AddInPaymentsActualCommand { get; }
		public DelegateLogCommand RemoveFromPaymentsActualCommand { get; private set; }
		private PaymentActualWrapper _selectedPaymentsActualItem;
		public PaymentActualWrapper SelectedPaymentsActualItem 
		{ 
			get { return _selectedPaymentsActualItem; }
			set 
			{ 
				if (Equals(_selectedPaymentsActualItem, value)) return;
				_selectedPaymentsActualItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentsActualCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PaymentPlanned>> _getEntitiesForAddInPaymentsPlannedCommand;
		public DelegateLogCommand AddInPaymentsPlannedCommand { get; }
		public DelegateLogCommand RemoveFromPaymentsPlannedCommand { get; private set; }
		private PaymentPlannedWrapper _selectedPaymentsPlannedItem;
		public PaymentPlannedWrapper SelectedPaymentsPlannedItem 
		{ 
			get { return _selectedPaymentsPlannedItem; }
			set 
			{ 
				if (Equals(_selectedPaymentsPlannedItem, value)) return;
				_selectedPaymentsPlannedItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentsPlannedCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PaymentPlanned>> _getEntitiesForAddInPaymentsPlannedActualCommand;
		public DelegateLogCommand AddInPaymentsPlannedActualCommand { get; }
		public DelegateLogCommand RemoveFromPaymentsPlannedActualCommand { get; private set; }
		private PaymentPlannedWrapper _selectedPaymentsPlannedActualItem;
		public PaymentPlannedWrapper SelectedPaymentsPlannedActualItem 
		{ 
			get { return _selectedPaymentsPlannedActualItem; }
			set 
			{ 
				if (Equals(_selectedPaymentsPlannedActualItem, value)) return;
				_selectedPaymentsPlannedActualItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentsPlannedActualCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PaymentPlanned>> _getEntitiesForAddInPaymentsPlannedGeneratedCommand;
		public DelegateLogCommand AddInPaymentsPlannedGeneratedCommand { get; }
		public DelegateLogCommand RemoveFromPaymentsPlannedGeneratedCommand { get; private set; }
		private PaymentPlannedWrapper _selectedPaymentsPlannedGeneratedItem;
		public PaymentPlannedWrapper SelectedPaymentsPlannedGeneratedItem 
		{ 
			get { return _selectedPaymentsPlannedGeneratedItem; }
			set 
			{ 
				if (Equals(_selectedPaymentsPlannedGeneratedItem, value)) return;
				_selectedPaymentsPlannedGeneratedItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentsPlannedGeneratedCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<PaymentPlanned>> _getEntitiesForAddInPaymentsPlannedCalculatedCommand;
		public DelegateLogCommand AddInPaymentsPlannedCalculatedCommand { get; }
		public DelegateLogCommand RemoveFromPaymentsPlannedCalculatedCommand { get; private set; }
		private PaymentPlannedWrapper _selectedPaymentsPlannedCalculatedItem;
		public PaymentPlannedWrapper SelectedPaymentsPlannedCalculatedItem 
		{ 
			get { return _selectedPaymentsPlannedCalculatedItem; }
			set 
			{ 
				if (Equals(_selectedPaymentsPlannedCalculatedItem, value)) return;
				_selectedPaymentsPlannedCalculatedItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentsPlannedCalculatedCommand.RaiseCanExecuteChanged();
			}
		}

        public SalesUnitDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectFacilityCommand == null) _getEntitiesForSelectFacilityCommand = () => { return UnitOfWork.Repository<Facility>().GetAll(); };
			if (SelectFacilityCommand == null) SelectFacilityCommand = new DelegateLogCommand(SelectFacilityCommand_Execute_Default);
			if (ClearFacilityCommand == null) ClearFacilityCommand = new DelegateLogCommand(ClearFacilityCommand_Execute_Default);

			
			if (_getEntitiesForSelectProductCommand == null) _getEntitiesForSelectProductCommand = () => { return UnitOfWork.Repository<Product>().GetAll(); };
			if (SelectProductCommand == null) SelectProductCommand = new DelegateLogCommand(SelectProductCommand_Execute_Default);
			if (ClearProductCommand == null) ClearProductCommand = new DelegateLogCommand(ClearProductCommand_Execute_Default);

			
			if (_getEntitiesForSelectPaymentConditionSetCommand == null) _getEntitiesForSelectPaymentConditionSetCommand = () => { return UnitOfWork.Repository<PaymentConditionSet>().GetAll(); };
			if (SelectPaymentConditionSetCommand == null) SelectPaymentConditionSetCommand = new DelegateLogCommand(SelectPaymentConditionSetCommand_Execute_Default);
			if (ClearPaymentConditionSetCommand == null) ClearPaymentConditionSetCommand = new DelegateLogCommand(ClearPaymentConditionSetCommand_Execute_Default);

			
			if (_getEntitiesForSelectProjectCommand == null) _getEntitiesForSelectProjectCommand = () => { return UnitOfWork.Repository<Project>().GetAll(); };
			if (SelectProjectCommand == null) SelectProjectCommand = new DelegateLogCommand(SelectProjectCommand_Execute_Default);
			if (ClearProjectCommand == null) ClearProjectCommand = new DelegateLogCommand(ClearProjectCommand_Execute_Default);

			
			if (_getEntitiesForSelectProducerCommand == null) _getEntitiesForSelectProducerCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectProducerCommand == null) SelectProducerCommand = new DelegateLogCommand(SelectProducerCommand_Execute_Default);
			if (ClearProducerCommand == null) ClearProducerCommand = new DelegateLogCommand(ClearProducerCommand_Execute_Default);

			
			if (_getEntitiesForSelectOrderCommand == null) _getEntitiesForSelectOrderCommand = () => { return UnitOfWork.Repository<Order>().GetAll(); };
			if (SelectOrderCommand == null) SelectOrderCommand = new DelegateLogCommand(SelectOrderCommand_Execute_Default);
			if (ClearOrderCommand == null) ClearOrderCommand = new DelegateLogCommand(ClearOrderCommand_Execute_Default);

			
			if (_getEntitiesForSelectSpecificationCommand == null) _getEntitiesForSelectSpecificationCommand = () => { return UnitOfWork.Repository<Specification>().GetAll(); };
			if (SelectSpecificationCommand == null) SelectSpecificationCommand = new DelegateLogCommand(SelectSpecificationCommand_Execute_Default);
			if (ClearSpecificationCommand == null) ClearSpecificationCommand = new DelegateLogCommand(ClearSpecificationCommand_Execute_Default);

			
			if (_getEntitiesForSelectPenaltyCommand == null) _getEntitiesForSelectPenaltyCommand = () => { return UnitOfWork.Repository<Penalty>().GetAll(); };
			if (SelectPenaltyCommand == null) SelectPenaltyCommand = new DelegateLogCommand(SelectPenaltyCommand_Execute_Default);
			if (ClearPenaltyCommand == null) ClearPenaltyCommand = new DelegateLogCommand(ClearPenaltyCommand_Execute_Default);

			
			if (_getEntitiesForSelectAddressDeliveryCommand == null) _getEntitiesForSelectAddressDeliveryCommand = () => { return UnitOfWork.Repository<Address>().GetAll(); };
			if (SelectAddressDeliveryCommand == null) SelectAddressDeliveryCommand = new DelegateLogCommand(SelectAddressDeliveryCommand_Execute_Default);
			if (ClearAddressDeliveryCommand == null) ClearAddressDeliveryCommand = new DelegateLogCommand(ClearAddressDeliveryCommand_Execute_Default);

			
			if (_getEntitiesForSelectAddressDeliveryCalculatedCommand == null) _getEntitiesForSelectAddressDeliveryCalculatedCommand = () => { return UnitOfWork.Repository<Address>().GetAll(); };
			if (SelectAddressDeliveryCalculatedCommand == null) SelectAddressDeliveryCalculatedCommand = new DelegateLogCommand(SelectAddressDeliveryCalculatedCommand_Execute_Default);
			if (ClearAddressDeliveryCalculatedCommand == null) ClearAddressDeliveryCalculatedCommand = new DelegateLogCommand(ClearAddressDeliveryCalculatedCommand_Execute_Default);

			
			if (_getEntitiesForAddInProductsIncludedCommand == null) _getEntitiesForAddInProductsIncludedCommand = () => { return UnitOfWork.Repository<ProductIncluded>().GetAll(); };;
			if (AddInProductsIncludedCommand == null) AddInProductsIncludedCommand = new DelegateLogCommand(AddInProductsIncludedCommand_Execute_Default);
			if (RemoveFromProductsIncludedCommand == null) RemoveFromProductsIncludedCommand = new DelegateLogCommand(RemoveFromProductsIncludedCommand_Execute_Default, RemoveFromProductsIncludedCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInLosingReasonsCommand == null) _getEntitiesForAddInLosingReasonsCommand = () => { return UnitOfWork.Repository<LosingReason>().GetAll(); };;
			if (AddInLosingReasonsCommand == null) AddInLosingReasonsCommand = new DelegateLogCommand(AddInLosingReasonsCommand_Execute_Default);
			if (RemoveFromLosingReasonsCommand == null) RemoveFromLosingReasonsCommand = new DelegateLogCommand(RemoveFromLosingReasonsCommand_Execute_Default, RemoveFromLosingReasonsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPaymentsActualCommand == null) _getEntitiesForAddInPaymentsActualCommand = () => { return UnitOfWork.Repository<PaymentActual>().GetAll(); };;
			if (AddInPaymentsActualCommand == null) AddInPaymentsActualCommand = new DelegateLogCommand(AddInPaymentsActualCommand_Execute_Default);
			if (RemoveFromPaymentsActualCommand == null) RemoveFromPaymentsActualCommand = new DelegateLogCommand(RemoveFromPaymentsActualCommand_Execute_Default, RemoveFromPaymentsActualCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPaymentsPlannedCommand == null) _getEntitiesForAddInPaymentsPlannedCommand = () => { return UnitOfWork.Repository<PaymentPlanned>().GetAll(); };;
			if (AddInPaymentsPlannedCommand == null) AddInPaymentsPlannedCommand = new DelegateLogCommand(AddInPaymentsPlannedCommand_Execute_Default);
			if (RemoveFromPaymentsPlannedCommand == null) RemoveFromPaymentsPlannedCommand = new DelegateLogCommand(RemoveFromPaymentsPlannedCommand_Execute_Default, RemoveFromPaymentsPlannedCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPaymentsPlannedActualCommand == null) _getEntitiesForAddInPaymentsPlannedActualCommand = () => { return UnitOfWork.Repository<PaymentPlanned>().GetAll(); };;
			if (AddInPaymentsPlannedActualCommand == null) AddInPaymentsPlannedActualCommand = new DelegateLogCommand(AddInPaymentsPlannedActualCommand_Execute_Default);
			if (RemoveFromPaymentsPlannedActualCommand == null) RemoveFromPaymentsPlannedActualCommand = new DelegateLogCommand(RemoveFromPaymentsPlannedActualCommand_Execute_Default, RemoveFromPaymentsPlannedActualCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPaymentsPlannedGeneratedCommand == null) _getEntitiesForAddInPaymentsPlannedGeneratedCommand = () => { return UnitOfWork.Repository<PaymentPlanned>().GetAll(); };;
			if (AddInPaymentsPlannedGeneratedCommand == null) AddInPaymentsPlannedGeneratedCommand = new DelegateLogCommand(AddInPaymentsPlannedGeneratedCommand_Execute_Default);
			if (RemoveFromPaymentsPlannedGeneratedCommand == null) RemoveFromPaymentsPlannedGeneratedCommand = new DelegateLogCommand(RemoveFromPaymentsPlannedGeneratedCommand_Execute_Default, RemoveFromPaymentsPlannedGeneratedCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInPaymentsPlannedCalculatedCommand == null) _getEntitiesForAddInPaymentsPlannedCalculatedCommand = () => { return UnitOfWork.Repository<PaymentPlanned>().GetAll(); };;
			if (AddInPaymentsPlannedCalculatedCommand == null) AddInPaymentsPlannedCalculatedCommand = new DelegateLogCommand(AddInPaymentsPlannedCalculatedCommand_Execute_Default);
			if (RemoveFromPaymentsPlannedCalculatedCommand == null) RemoveFromPaymentsPlannedCalculatedCommand = new DelegateLogCommand(RemoveFromPaymentsPlannedCalculatedCommand_Execute_Default, RemoveFromPaymentsPlannedCalculatedCommand_CanExecute_Default);

		}

		private void SelectFacilityCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Facility, FacilityWrapper>(_getEntitiesForSelectFacilityCommand(), nameof(Item.Facility), Item.Facility?.Id);
		}

		private void ClearFacilityCommand_Execute_Default() 
		{
						Item.Facility = null;		    
		}

		private void SelectProductCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Product, ProductWrapper>(_getEntitiesForSelectProductCommand(), nameof(Item.Product), Item.Product?.Id);
		}

		private void ClearProductCommand_Execute_Default() 
		{
						Item.Product = null;		    
		}

		private void SelectPaymentConditionSetCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionSet, PaymentConditionSetWrapper>(_getEntitiesForSelectPaymentConditionSetCommand(), nameof(Item.PaymentConditionSet), Item.PaymentConditionSet?.Id);
		}

		private void ClearPaymentConditionSetCommand_Execute_Default() 
		{
						Item.PaymentConditionSet = null;		    
		}

		private void SelectProjectCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Project, ProjectWrapper>(_getEntitiesForSelectProjectCommand(), nameof(Item.Project), Item.Project?.Id);
		}

		private void ClearProjectCommand_Execute_Default() 
		{
						Item.Project = null;		    
		}

		private void SelectProducerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectProducerCommand(), nameof(Item.Producer), Item.Producer?.Id);
		}

		private void ClearProducerCommand_Execute_Default() 
		{
						Item.Producer = null;		    
		}

		private void SelectOrderCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Order, OrderWrapper>(_getEntitiesForSelectOrderCommand(), nameof(Item.Order), Item.Order?.Id);
		}

		private void ClearOrderCommand_Execute_Default() 
		{
						Item.Order = null;		    
		}

		private void SelectSpecificationCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Specification, SpecificationWrapper>(_getEntitiesForSelectSpecificationCommand(), nameof(Item.Specification), Item.Specification?.Id);
		}

		private void ClearSpecificationCommand_Execute_Default() 
		{
						Item.Specification = null;		    
		}

		private void SelectPenaltyCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Penalty, PenaltyWrapper>(_getEntitiesForSelectPenaltyCommand(), nameof(Item.Penalty), Item.Penalty?.Id);
		}

		private void ClearPenaltyCommand_Execute_Default() 
		{
						Item.Penalty = null;		    
		}

		private void SelectAddressDeliveryCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Address, AddressWrapper>(_getEntitiesForSelectAddressDeliveryCommand(), nameof(Item.AddressDelivery), Item.AddressDelivery?.Id);
		}

		private void ClearAddressDeliveryCommand_Execute_Default() 
		{
						Item.AddressDelivery = null;		    
		}

		private void SelectAddressDeliveryCalculatedCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Address, AddressWrapper>(_getEntitiesForSelectAddressDeliveryCalculatedCommand(), nameof(Item.AddressDeliveryCalculated), Item.AddressDeliveryCalculated?.Id);
		}

		private void ClearAddressDeliveryCalculatedCommand_Execute_Default() 
		{
				    
		}

			private void AddInProductsIncludedCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ProductIncluded, ProductIncludedWrapper>(_getEntitiesForAddInProductsIncludedCommand(), Item.ProductsIncluded);
			}

			private void RemoveFromProductsIncludedCommand_Execute_Default()
			{
				Item.ProductsIncluded.Remove(SelectedProductsIncludedItem);
			}

			private bool RemoveFromProductsIncludedCommand_CanExecute_Default()
			{
				return SelectedProductsIncludedItem != null;
			}

			private void AddInLosingReasonsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<LosingReason, LosingReasonWrapper>(_getEntitiesForAddInLosingReasonsCommand(), Item.LosingReasons);
			}

			private void RemoveFromLosingReasonsCommand_Execute_Default()
			{
				Item.LosingReasons.Remove(SelectedLosingReasonsItem);
			}

			private bool RemoveFromLosingReasonsCommand_CanExecute_Default()
			{
				return SelectedLosingReasonsItem != null;
			}

			private void AddInPaymentsActualCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentActual, PaymentActualWrapper>(_getEntitiesForAddInPaymentsActualCommand(), Item.PaymentsActual);
			}

			private void RemoveFromPaymentsActualCommand_Execute_Default()
			{
				Item.PaymentsActual.Remove(SelectedPaymentsActualItem);
			}

			private bool RemoveFromPaymentsActualCommand_CanExecute_Default()
			{
				return SelectedPaymentsActualItem != null;
			}

			private void AddInPaymentsPlannedCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentPlanned, PaymentPlannedWrapper>(_getEntitiesForAddInPaymentsPlannedCommand(), Item.PaymentsPlanned);
			}

			private void RemoveFromPaymentsPlannedCommand_Execute_Default()
			{
				Item.PaymentsPlanned.Remove(SelectedPaymentsPlannedItem);
			}

			private bool RemoveFromPaymentsPlannedCommand_CanExecute_Default()
			{
				return SelectedPaymentsPlannedItem != null;
			}

			private void AddInPaymentsPlannedActualCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentPlanned, PaymentPlannedWrapper>(_getEntitiesForAddInPaymentsPlannedActualCommand(), Item.PaymentsPlannedActual);
			}

			private void RemoveFromPaymentsPlannedActualCommand_Execute_Default()
			{
				Item.PaymentsPlannedActual.Remove(SelectedPaymentsPlannedActualItem);
			}

			private bool RemoveFromPaymentsPlannedActualCommand_CanExecute_Default()
			{
				return SelectedPaymentsPlannedActualItem != null;
			}

			private void AddInPaymentsPlannedGeneratedCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentPlanned, PaymentPlannedWrapper>(_getEntitiesForAddInPaymentsPlannedGeneratedCommand(), Item.PaymentsPlannedGenerated);
			}

			private void RemoveFromPaymentsPlannedGeneratedCommand_Execute_Default()
			{
				Item.PaymentsPlannedGenerated.Remove(SelectedPaymentsPlannedGeneratedItem);
			}

			private bool RemoveFromPaymentsPlannedGeneratedCommand_CanExecute_Default()
			{
				return SelectedPaymentsPlannedGeneratedItem != null;
			}

			private void AddInPaymentsPlannedCalculatedCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentPlanned, PaymentPlannedWrapper>(_getEntitiesForAddInPaymentsPlannedCalculatedCommand(), Item.PaymentsPlannedCalculated);
			}

			private void RemoveFromPaymentsPlannedCalculatedCommand_Execute_Default()
			{
				Item.PaymentsPlannedCalculated.Remove(SelectedPaymentsPlannedCalculatedItem);
			}

			private bool RemoveFromPaymentsPlannedCalculatedCommand_CanExecute_Default()
			{
				return SelectedPaymentsPlannedCalculatedItem != null;
			}


    }

    public partial class DocumentDetailsViewModel : BaseDetailsViewModel<DocumentWrapper, Document, AfterSaveDocumentEvent>
    {
		//private Func<Task<List<DocumentNumber>>> _getEntitiesForSelectNumberCommand;
		private Func<List<DocumentNumber>> _getEntitiesForSelectNumberCommand;
		public DelegateLogCommand SelectNumberCommand { get; private set; }
		public DelegateLogCommand ClearNumberCommand { get; private set; }

		//private Func<Task<List<Document>>> _getEntitiesForSelectRequestDocumentCommand;
		private Func<List<Document>> _getEntitiesForSelectRequestDocumentCommand;
		public DelegateLogCommand SelectRequestDocumentCommand { get; private set; }
		public DelegateLogCommand ClearRequestDocumentCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<Employee>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectSenderEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectSenderEmployeeCommand;
		public DelegateLogCommand SelectSenderEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearSenderEmployeeCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectRecipientEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectRecipientEmployeeCommand;
		public DelegateLogCommand SelectRecipientEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearRecipientEmployeeCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectWhoRegisteredUserCommand;
		private Func<List<User>> _getEntitiesForSelectWhoRegisteredUserCommand;
		public DelegateLogCommand SelectWhoRegisteredUserCommand { get; private set; }
		public DelegateLogCommand ClearWhoRegisteredUserCommand { get; private set; }

		//private Func<Task<List<DocumentsRegistrationDetails>>> _getEntitiesForSelectRegistrationDetailsOfRecipientCommand;
		private Func<List<DocumentsRegistrationDetails>> _getEntitiesForSelectRegistrationDetailsOfRecipientCommand;
		public DelegateLogCommand SelectRegistrationDetailsOfRecipientCommand { get; private set; }
		public DelegateLogCommand ClearRegistrationDetailsOfRecipientCommand { get; private set; }

		private Func<List<Employee>> _getEntitiesForAddInCopyToRecipientsCommand;
		public DelegateLogCommand AddInCopyToRecipientsCommand { get; }
		public DelegateLogCommand RemoveFromCopyToRecipientsCommand { get; private set; }
		private EmployeeWrapper _selectedCopyToRecipientsItem;
		public EmployeeWrapper SelectedCopyToRecipientsItem 
		{ 
			get { return _selectedCopyToRecipientsItem; }
			set 
			{ 
				if (Equals(_selectedCopyToRecipientsItem, value)) return;
				_selectedCopyToRecipientsItem = value;
				RaisePropertyChanged();
				RemoveFromCopyToRecipientsCommand.RaiseCanExecuteChanged();
			}
		}

        public DocumentDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectNumberCommand == null) _getEntitiesForSelectNumberCommand = () => { return UnitOfWork.Repository<DocumentNumber>().GetAll(); };
			if (SelectNumberCommand == null) SelectNumberCommand = new DelegateLogCommand(SelectNumberCommand_Execute_Default);
			if (ClearNumberCommand == null) ClearNumberCommand = new DelegateLogCommand(ClearNumberCommand_Execute_Default);

			
			if (_getEntitiesForSelectRequestDocumentCommand == null) _getEntitiesForSelectRequestDocumentCommand = () => { return UnitOfWork.Repository<Document>().GetAll(); };
			if (SelectRequestDocumentCommand == null) SelectRequestDocumentCommand = new DelegateLogCommand(SelectRequestDocumentCommand_Execute_Default);
			if (ClearRequestDocumentCommand == null) ClearRequestDocumentCommand = new DelegateLogCommand(ClearRequestDocumentCommand_Execute_Default);

			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

			
			if (_getEntitiesForSelectSenderEmployeeCommand == null) _getEntitiesForSelectSenderEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectSenderEmployeeCommand == null) SelectSenderEmployeeCommand = new DelegateLogCommand(SelectSenderEmployeeCommand_Execute_Default);
			if (ClearSenderEmployeeCommand == null) ClearSenderEmployeeCommand = new DelegateLogCommand(ClearSenderEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForSelectRecipientEmployeeCommand == null) _getEntitiesForSelectRecipientEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectRecipientEmployeeCommand == null) SelectRecipientEmployeeCommand = new DelegateLogCommand(SelectRecipientEmployeeCommand_Execute_Default);
			if (ClearRecipientEmployeeCommand == null) ClearRecipientEmployeeCommand = new DelegateLogCommand(ClearRecipientEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForSelectWhoRegisteredUserCommand == null) _getEntitiesForSelectWhoRegisteredUserCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectWhoRegisteredUserCommand == null) SelectWhoRegisteredUserCommand = new DelegateLogCommand(SelectWhoRegisteredUserCommand_Execute_Default);
			if (ClearWhoRegisteredUserCommand == null) ClearWhoRegisteredUserCommand = new DelegateLogCommand(ClearWhoRegisteredUserCommand_Execute_Default);

			
			if (_getEntitiesForSelectRegistrationDetailsOfRecipientCommand == null) _getEntitiesForSelectRegistrationDetailsOfRecipientCommand = () => { return UnitOfWork.Repository<DocumentsRegistrationDetails>().GetAll(); };
			if (SelectRegistrationDetailsOfRecipientCommand == null) SelectRegistrationDetailsOfRecipientCommand = new DelegateLogCommand(SelectRegistrationDetailsOfRecipientCommand_Execute_Default);
			if (ClearRegistrationDetailsOfRecipientCommand == null) ClearRegistrationDetailsOfRecipientCommand = new DelegateLogCommand(ClearRegistrationDetailsOfRecipientCommand_Execute_Default);

			
			if (_getEntitiesForAddInCopyToRecipientsCommand == null) _getEntitiesForAddInCopyToRecipientsCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };;
			if (AddInCopyToRecipientsCommand == null) AddInCopyToRecipientsCommand = new DelegateLogCommand(AddInCopyToRecipientsCommand_Execute_Default);
			if (RemoveFromCopyToRecipientsCommand == null) RemoveFromCopyToRecipientsCommand = new DelegateLogCommand(RemoveFromCopyToRecipientsCommand_Execute_Default, RemoveFromCopyToRecipientsCommand_CanExecute_Default);

		}

		private void SelectNumberCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DocumentNumber, DocumentNumberWrapper>(_getEntitiesForSelectNumberCommand(), nameof(Item.Number), Item.Number?.Id);
		}

		private void ClearNumberCommand_Execute_Default() 
		{
						Item.Number = null;		    
		}

		private void SelectRequestDocumentCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Document, DocumentWrapper>(_getEntitiesForSelectRequestDocumentCommand(), nameof(Item.RequestDocument), Item.RequestDocument?.Id);
		}

		private void ClearRequestDocumentCommand_Execute_Default() 
		{
						Item.RequestDocument = null;		    
		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}

		private void SelectSenderEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectSenderEmployeeCommand(), nameof(Item.SenderEmployee), Item.SenderEmployee?.Id);
		}

		private void ClearSenderEmployeeCommand_Execute_Default() 
		{
						Item.SenderEmployee = null;		    
		}

		private void SelectRecipientEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectRecipientEmployeeCommand(), nameof(Item.RecipientEmployee), Item.RecipientEmployee?.Id);
		}

		private void ClearRecipientEmployeeCommand_Execute_Default() 
		{
						Item.RecipientEmployee = null;		    
		}

		private void SelectWhoRegisteredUserCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectWhoRegisteredUserCommand(), nameof(Item.WhoRegisteredUser), Item.WhoRegisteredUser?.Id);
		}

		private void ClearWhoRegisteredUserCommand_Execute_Default() 
		{
						Item.WhoRegisteredUser = null;		    
		}

		private void SelectRegistrationDetailsOfRecipientCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DocumentsRegistrationDetails, DocumentsRegistrationDetailsWrapper>(_getEntitiesForSelectRegistrationDetailsOfRecipientCommand(), nameof(Item.RegistrationDetailsOfRecipient), Item.RegistrationDetailsOfRecipient?.Id);
		}

		private void ClearRegistrationDetailsOfRecipientCommand_Execute_Default() 
		{
						Item.RegistrationDetailsOfRecipient = null;		    
		}

			private void AddInCopyToRecipientsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Employee, EmployeeWrapper>(_getEntitiesForAddInCopyToRecipientsCommand(), Item.CopyToRecipients);
			}

			private void RemoveFromCopyToRecipientsCommand_Execute_Default()
			{
				Item.CopyToRecipients.Remove(SelectedCopyToRecipientsItem);
			}

			private bool RemoveFromCopyToRecipientsCommand_CanExecute_Default()
			{
				return SelectedCopyToRecipientsItem != null;
			}


    }

    public partial class SumOnDateDetailsViewModel : BaseDetailsViewModel<SumOnDateWrapper, SumOnDate, AfterSaveSumOnDateEvent>
    {
        public SumOnDateDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class ProductDetailsViewModel : BaseDetailsViewModel<ProductWrapper, Product, AfterSaveProductEvent>
    {
		//private Func<Task<List<ProductType>>> _getEntitiesForSelectProductTypeCommand;
		private Func<List<ProductType>> _getEntitiesForSelectProductTypeCommand;
		public DelegateLogCommand SelectProductTypeCommand { get; private set; }
		public DelegateLogCommand ClearProductTypeCommand { get; private set; }

		//private Func<Task<List<ProductCategory>>> _getEntitiesForSelectCategoryCommand;
		private Func<List<ProductCategory>> _getEntitiesForSelectCategoryCommand;
		public DelegateLogCommand SelectCategoryCommand { get; private set; }
		public DelegateLogCommand ClearCategoryCommand { get; private set; }

		//private Func<Task<List<ProductBlock>>> _getEntitiesForSelectProductBlockCommand;
		private Func<List<ProductBlock>> _getEntitiesForSelectProductBlockCommand;
		public DelegateLogCommand SelectProductBlockCommand { get; private set; }
		public DelegateLogCommand ClearProductBlockCommand { get; private set; }

		private Func<List<ProductDependent>> _getEntitiesForAddInDependentProductsCommand;
		public DelegateLogCommand AddInDependentProductsCommand { get; }
		public DelegateLogCommand RemoveFromDependentProductsCommand { get; private set; }
		private ProductDependentWrapper _selectedDependentProductsItem;
		public ProductDependentWrapper SelectedDependentProductsItem 
		{ 
			get { return _selectedDependentProductsItem; }
			set 
			{ 
				if (Equals(_selectedDependentProductsItem, value)) return;
				_selectedDependentProductsItem = value;
				RaisePropertyChanged();
				RemoveFromDependentProductsCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<DesignDepartment>> _getEntitiesForAddInDesignDepartmentsKitsCommand;
		public DelegateLogCommand AddInDesignDepartmentsKitsCommand { get; }
		public DelegateLogCommand RemoveFromDesignDepartmentsKitsCommand { get; private set; }
		private DesignDepartmentWrapper _selectedDesignDepartmentsKitsItem;
		public DesignDepartmentWrapper SelectedDesignDepartmentsKitsItem 
		{ 
			get { return _selectedDesignDepartmentsKitsItem; }
			set 
			{ 
				if (Equals(_selectedDesignDepartmentsKitsItem, value)) return;
				_selectedDesignDepartmentsKitsItem = value;
				RaisePropertyChanged();
				RemoveFromDesignDepartmentsKitsCommand.RaiseCanExecuteChanged();
			}
		}

        public ProductDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProductTypeCommand == null) _getEntitiesForSelectProductTypeCommand = () => { return UnitOfWork.Repository<ProductType>().GetAll(); };
			if (SelectProductTypeCommand == null) SelectProductTypeCommand = new DelegateLogCommand(SelectProductTypeCommand_Execute_Default);
			if (ClearProductTypeCommand == null) ClearProductTypeCommand = new DelegateLogCommand(ClearProductTypeCommand_Execute_Default);

			
			if (_getEntitiesForSelectCategoryCommand == null) _getEntitiesForSelectCategoryCommand = () => { return UnitOfWork.Repository<ProductCategory>().GetAll(); };
			if (SelectCategoryCommand == null) SelectCategoryCommand = new DelegateLogCommand(SelectCategoryCommand_Execute_Default);
			if (ClearCategoryCommand == null) ClearCategoryCommand = new DelegateLogCommand(ClearCategoryCommand_Execute_Default);

			
			if (_getEntitiesForSelectProductBlockCommand == null) _getEntitiesForSelectProductBlockCommand = () => { return UnitOfWork.Repository<ProductBlock>().GetAll(); };
			if (SelectProductBlockCommand == null) SelectProductBlockCommand = new DelegateLogCommand(SelectProductBlockCommand_Execute_Default);
			if (ClearProductBlockCommand == null) ClearProductBlockCommand = new DelegateLogCommand(ClearProductBlockCommand_Execute_Default);

			
			if (_getEntitiesForAddInDependentProductsCommand == null) _getEntitiesForAddInDependentProductsCommand = () => { return UnitOfWork.Repository<ProductDependent>().GetAll(); };;
			if (AddInDependentProductsCommand == null) AddInDependentProductsCommand = new DelegateLogCommand(AddInDependentProductsCommand_Execute_Default);
			if (RemoveFromDependentProductsCommand == null) RemoveFromDependentProductsCommand = new DelegateLogCommand(RemoveFromDependentProductsCommand_Execute_Default, RemoveFromDependentProductsCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInDesignDepartmentsKitsCommand == null) _getEntitiesForAddInDesignDepartmentsKitsCommand = () => { return UnitOfWork.Repository<DesignDepartment>().GetAll(); };;
			if (AddInDesignDepartmentsKitsCommand == null) AddInDesignDepartmentsKitsCommand = new DelegateLogCommand(AddInDesignDepartmentsKitsCommand_Execute_Default);
			if (RemoveFromDesignDepartmentsKitsCommand == null) RemoveFromDesignDepartmentsKitsCommand = new DelegateLogCommand(RemoveFromDesignDepartmentsKitsCommand_Execute_Default, RemoveFromDesignDepartmentsKitsCommand_CanExecute_Default);

		}

		private void SelectProductTypeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductType, ProductTypeWrapper>(_getEntitiesForSelectProductTypeCommand(), nameof(Item.ProductType), Item.ProductType?.Id);
		}

		private void ClearProductTypeCommand_Execute_Default() 
		{
				    
		}

		private void SelectCategoryCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductCategory, ProductCategoryWrapper>(_getEntitiesForSelectCategoryCommand(), nameof(Item.Category), Item.Category?.Id);
		}

		private void ClearCategoryCommand_Execute_Default() 
		{
				    
		}

		private void SelectProductBlockCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProductBlock, ProductBlockWrapper>(_getEntitiesForSelectProductBlockCommand(), nameof(Item.ProductBlock), Item.ProductBlock?.Id);
		}

		private void ClearProductBlockCommand_Execute_Default() 
		{
						Item.ProductBlock = null;		    
		}

			private void AddInDependentProductsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<ProductDependent, ProductDependentWrapper>(_getEntitiesForAddInDependentProductsCommand(), Item.DependentProducts);
			}

			private void RemoveFromDependentProductsCommand_Execute_Default()
			{
				Item.DependentProducts.Remove(SelectedDependentProductsItem);
			}

			private bool RemoveFromDependentProductsCommand_CanExecute_Default()
			{
				return SelectedDependentProductsItem != null;
			}

			private void AddInDesignDepartmentsKitsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<DesignDepartment, DesignDepartmentWrapper>(_getEntitiesForAddInDesignDepartmentsKitsCommand(), Item.DesignDepartmentsKits);
			}

			private void RemoveFromDesignDepartmentsKitsCommand_Execute_Default()
			{
				Item.DesignDepartmentsKits.Remove(SelectedDesignDepartmentsKitsItem);
			}

			private bool RemoveFromDesignDepartmentsKitsCommand_CanExecute_Default()
			{
				return SelectedDesignDepartmentsKitsItem != null;
			}


    }

    public partial class OfferDetailsViewModel : BaseDetailsViewModel<OfferWrapper, Offer, AfterSaveOfferEvent>
    {
		//private Func<Task<List<Project>>> _getEntitiesForSelectProjectCommand;
		private Func<List<Project>> _getEntitiesForSelectProjectCommand;
		public DelegateLogCommand SelectProjectCommand { get; private set; }
		public DelegateLogCommand ClearProjectCommand { get; private set; }

		//private Func<Task<List<DocumentNumber>>> _getEntitiesForSelectNumberCommand;
		private Func<List<DocumentNumber>> _getEntitiesForSelectNumberCommand;
		public DelegateLogCommand SelectNumberCommand { get; private set; }
		public DelegateLogCommand ClearNumberCommand { get; private set; }

		//private Func<Task<List<Document>>> _getEntitiesForSelectRequestDocumentCommand;
		private Func<List<Document>> _getEntitiesForSelectRequestDocumentCommand;
		public DelegateLogCommand SelectRequestDocumentCommand { get; private set; }
		public DelegateLogCommand ClearRequestDocumentCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectAuthorCommand;
		private Func<List<Employee>> _getEntitiesForSelectAuthorCommand;
		public DelegateLogCommand SelectAuthorCommand { get; private set; }
		public DelegateLogCommand ClearAuthorCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectSenderEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectSenderEmployeeCommand;
		public DelegateLogCommand SelectSenderEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearSenderEmployeeCommand { get; private set; }

		//private Func<Task<List<Employee>>> _getEntitiesForSelectRecipientEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectRecipientEmployeeCommand;
		public DelegateLogCommand SelectRecipientEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearRecipientEmployeeCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectWhoRegisteredUserCommand;
		private Func<List<User>> _getEntitiesForSelectWhoRegisteredUserCommand;
		public DelegateLogCommand SelectWhoRegisteredUserCommand { get; private set; }
		public DelegateLogCommand ClearWhoRegisteredUserCommand { get; private set; }

		//private Func<Task<List<DocumentsRegistrationDetails>>> _getEntitiesForSelectRegistrationDetailsOfRecipientCommand;
		private Func<List<DocumentsRegistrationDetails>> _getEntitiesForSelectRegistrationDetailsOfRecipientCommand;
		public DelegateLogCommand SelectRegistrationDetailsOfRecipientCommand { get; private set; }
		public DelegateLogCommand ClearRegistrationDetailsOfRecipientCommand { get; private set; }

		private Func<List<Employee>> _getEntitiesForAddInCopyToRecipientsCommand;
		public DelegateLogCommand AddInCopyToRecipientsCommand { get; }
		public DelegateLogCommand RemoveFromCopyToRecipientsCommand { get; private set; }
		private EmployeeWrapper _selectedCopyToRecipientsItem;
		public EmployeeWrapper SelectedCopyToRecipientsItem 
		{ 
			get { return _selectedCopyToRecipientsItem; }
			set 
			{ 
				if (Equals(_selectedCopyToRecipientsItem, value)) return;
				_selectedCopyToRecipientsItem = value;
				RaisePropertyChanged();
				RemoveFromCopyToRecipientsCommand.RaiseCanExecuteChanged();
			}
		}

        public OfferDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProjectCommand == null) _getEntitiesForSelectProjectCommand = () => { return UnitOfWork.Repository<Project>().GetAll(); };
			if (SelectProjectCommand == null) SelectProjectCommand = new DelegateLogCommand(SelectProjectCommand_Execute_Default);
			if (ClearProjectCommand == null) ClearProjectCommand = new DelegateLogCommand(ClearProjectCommand_Execute_Default);

			
			if (_getEntitiesForSelectNumberCommand == null) _getEntitiesForSelectNumberCommand = () => { return UnitOfWork.Repository<DocumentNumber>().GetAll(); };
			if (SelectNumberCommand == null) SelectNumberCommand = new DelegateLogCommand(SelectNumberCommand_Execute_Default);
			if (ClearNumberCommand == null) ClearNumberCommand = new DelegateLogCommand(ClearNumberCommand_Execute_Default);

			
			if (_getEntitiesForSelectRequestDocumentCommand == null) _getEntitiesForSelectRequestDocumentCommand = () => { return UnitOfWork.Repository<Document>().GetAll(); };
			if (SelectRequestDocumentCommand == null) SelectRequestDocumentCommand = new DelegateLogCommand(SelectRequestDocumentCommand_Execute_Default);
			if (ClearRequestDocumentCommand == null) ClearRequestDocumentCommand = new DelegateLogCommand(ClearRequestDocumentCommand_Execute_Default);

			
			if (_getEntitiesForSelectAuthorCommand == null) _getEntitiesForSelectAuthorCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectAuthorCommand == null) SelectAuthorCommand = new DelegateLogCommand(SelectAuthorCommand_Execute_Default);
			if (ClearAuthorCommand == null) ClearAuthorCommand = new DelegateLogCommand(ClearAuthorCommand_Execute_Default);

			
			if (_getEntitiesForSelectSenderEmployeeCommand == null) _getEntitiesForSelectSenderEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectSenderEmployeeCommand == null) SelectSenderEmployeeCommand = new DelegateLogCommand(SelectSenderEmployeeCommand_Execute_Default);
			if (ClearSenderEmployeeCommand == null) ClearSenderEmployeeCommand = new DelegateLogCommand(ClearSenderEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForSelectRecipientEmployeeCommand == null) _getEntitiesForSelectRecipientEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectRecipientEmployeeCommand == null) SelectRecipientEmployeeCommand = new DelegateLogCommand(SelectRecipientEmployeeCommand_Execute_Default);
			if (ClearRecipientEmployeeCommand == null) ClearRecipientEmployeeCommand = new DelegateLogCommand(ClearRecipientEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForSelectWhoRegisteredUserCommand == null) _getEntitiesForSelectWhoRegisteredUserCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectWhoRegisteredUserCommand == null) SelectWhoRegisteredUserCommand = new DelegateLogCommand(SelectWhoRegisteredUserCommand_Execute_Default);
			if (ClearWhoRegisteredUserCommand == null) ClearWhoRegisteredUserCommand = new DelegateLogCommand(ClearWhoRegisteredUserCommand_Execute_Default);

			
			if (_getEntitiesForSelectRegistrationDetailsOfRecipientCommand == null) _getEntitiesForSelectRegistrationDetailsOfRecipientCommand = () => { return UnitOfWork.Repository<DocumentsRegistrationDetails>().GetAll(); };
			if (SelectRegistrationDetailsOfRecipientCommand == null) SelectRegistrationDetailsOfRecipientCommand = new DelegateLogCommand(SelectRegistrationDetailsOfRecipientCommand_Execute_Default);
			if (ClearRegistrationDetailsOfRecipientCommand == null) ClearRegistrationDetailsOfRecipientCommand = new DelegateLogCommand(ClearRegistrationDetailsOfRecipientCommand_Execute_Default);

			
			if (_getEntitiesForAddInCopyToRecipientsCommand == null) _getEntitiesForAddInCopyToRecipientsCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };;
			if (AddInCopyToRecipientsCommand == null) AddInCopyToRecipientsCommand = new DelegateLogCommand(AddInCopyToRecipientsCommand_Execute_Default);
			if (RemoveFromCopyToRecipientsCommand == null) RemoveFromCopyToRecipientsCommand = new DelegateLogCommand(RemoveFromCopyToRecipientsCommand_Execute_Default, RemoveFromCopyToRecipientsCommand_CanExecute_Default);

		}

		private void SelectProjectCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Project, ProjectWrapper>(_getEntitiesForSelectProjectCommand(), nameof(Item.Project), Item.Project?.Id);
		}

		private void ClearProjectCommand_Execute_Default() 
		{
						Item.Project = null;		    
		}

		private void SelectNumberCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DocumentNumber, DocumentNumberWrapper>(_getEntitiesForSelectNumberCommand(), nameof(Item.Number), Item.Number?.Id);
		}

		private void ClearNumberCommand_Execute_Default() 
		{
						Item.Number = null;		    
		}

		private void SelectRequestDocumentCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Document, DocumentWrapper>(_getEntitiesForSelectRequestDocumentCommand(), nameof(Item.RequestDocument), Item.RequestDocument?.Id);
		}

		private void ClearRequestDocumentCommand_Execute_Default() 
		{
						Item.RequestDocument = null;		    
		}

		private void SelectAuthorCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectAuthorCommand(), nameof(Item.Author), Item.Author?.Id);
		}

		private void ClearAuthorCommand_Execute_Default() 
		{
						Item.Author = null;		    
		}

		private void SelectSenderEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectSenderEmployeeCommand(), nameof(Item.SenderEmployee), Item.SenderEmployee?.Id);
		}

		private void ClearSenderEmployeeCommand_Execute_Default() 
		{
						Item.SenderEmployee = null;		    
		}

		private void SelectRecipientEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectRecipientEmployeeCommand(), nameof(Item.RecipientEmployee), Item.RecipientEmployee?.Id);
		}

		private void ClearRecipientEmployeeCommand_Execute_Default() 
		{
						Item.RecipientEmployee = null;		    
		}

		private void SelectWhoRegisteredUserCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectWhoRegisteredUserCommand(), nameof(Item.WhoRegisteredUser), Item.WhoRegisteredUser?.Id);
		}

		private void ClearWhoRegisteredUserCommand_Execute_Default() 
		{
						Item.WhoRegisteredUser = null;		    
		}

		private void SelectRegistrationDetailsOfRecipientCommand_Execute_Default() 
		{
            SelectAndSetWrapper<DocumentsRegistrationDetails, DocumentsRegistrationDetailsWrapper>(_getEntitiesForSelectRegistrationDetailsOfRecipientCommand(), nameof(Item.RegistrationDetailsOfRecipient), Item.RegistrationDetailsOfRecipient?.Id);
		}

		private void ClearRegistrationDetailsOfRecipientCommand_Execute_Default() 
		{
						Item.RegistrationDetailsOfRecipient = null;		    
		}

			private void AddInCopyToRecipientsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Employee, EmployeeWrapper>(_getEntitiesForAddInCopyToRecipientsCommand(), Item.CopyToRecipients);
			}

			private void RemoveFromCopyToRecipientsCommand_Execute_Default()
			{
				Item.CopyToRecipients.Remove(SelectedCopyToRecipientsItem);
			}

			private bool RemoveFromCopyToRecipientsCommand_CanExecute_Default()
			{
				return SelectedCopyToRecipientsItem != null;
			}


    }

    public partial class EmployeeDetailsViewModel : BaseDetailsViewModel<EmployeeWrapper, Employee, AfterSaveEmployeeEvent>
    {
		//private Func<Task<List<Person>>> _getEntitiesForSelectPersonCommand;
		private Func<List<Person>> _getEntitiesForSelectPersonCommand;
		public DelegateLogCommand SelectPersonCommand { get; private set; }
		public DelegateLogCommand ClearPersonCommand { get; private set; }

		//private Func<Task<List<Company>>> _getEntitiesForSelectCompanyCommand;
		private Func<List<Company>> _getEntitiesForSelectCompanyCommand;
		public DelegateLogCommand SelectCompanyCommand { get; private set; }
		public DelegateLogCommand ClearCompanyCommand { get; private set; }

		//private Func<Task<List<EmployeesPosition>>> _getEntitiesForSelectPositionCommand;
		private Func<List<EmployeesPosition>> _getEntitiesForSelectPositionCommand;
		public DelegateLogCommand SelectPositionCommand { get; private set; }
		public DelegateLogCommand ClearPositionCommand { get; private set; }

        public EmployeeDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectPersonCommand == null) _getEntitiesForSelectPersonCommand = () => { return UnitOfWork.Repository<Person>().GetAll(); };
			if (SelectPersonCommand == null) SelectPersonCommand = new DelegateLogCommand(SelectPersonCommand_Execute_Default);
			if (ClearPersonCommand == null) ClearPersonCommand = new DelegateLogCommand(ClearPersonCommand_Execute_Default);

			
			if (_getEntitiesForSelectCompanyCommand == null) _getEntitiesForSelectCompanyCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectCompanyCommand == null) SelectCompanyCommand = new DelegateLogCommand(SelectCompanyCommand_Execute_Default);
			if (ClearCompanyCommand == null) ClearCompanyCommand = new DelegateLogCommand(ClearCompanyCommand_Execute_Default);

			
			if (_getEntitiesForSelectPositionCommand == null) _getEntitiesForSelectPositionCommand = () => { return UnitOfWork.Repository<EmployeesPosition>().GetAll(); };
			if (SelectPositionCommand == null) SelectPositionCommand = new DelegateLogCommand(SelectPositionCommand_Execute_Default);
			if (ClearPositionCommand == null) ClearPositionCommand = new DelegateLogCommand(ClearPositionCommand_Execute_Default);

		}

		private void SelectPersonCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Person, PersonWrapper>(_getEntitiesForSelectPersonCommand(), nameof(Item.Person), Item.Person?.Id);
		}

		private void ClearPersonCommand_Execute_Default() 
		{
						Item.Person = null;		    
		}

		private void SelectCompanyCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectCompanyCommand(), nameof(Item.Company), Item.Company?.Id);
		}

		private void ClearCompanyCommand_Execute_Default() 
		{
						Item.Company = null;		    
		}

		private void SelectPositionCommand_Execute_Default() 
		{
            SelectAndSetWrapper<EmployeesPosition, EmployeesPositionWrapper>(_getEntitiesForSelectPositionCommand(), nameof(Item.Position), Item.Position?.Id);
		}

		private void ClearPositionCommand_Execute_Default() 
		{
						Item.Position = null;		    
		}


    }

    public partial class OrderDetailsViewModel : BaseDetailsViewModel<OrderWrapper, Order, AfterSaveOrderEvent>
    {
        public OrderDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class PaymentConditionDetailsViewModel : BaseDetailsViewModel<PaymentConditionWrapper, PaymentCondition, AfterSavePaymentConditionEvent>
    {
		//private Func<Task<List<PaymentConditionPoint>>> _getEntitiesForSelectPaymentConditionPointCommand;
		private Func<List<PaymentConditionPoint>> _getEntitiesForSelectPaymentConditionPointCommand;
		public DelegateLogCommand SelectPaymentConditionPointCommand { get; private set; }
		public DelegateLogCommand ClearPaymentConditionPointCommand { get; private set; }

        public PaymentConditionDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectPaymentConditionPointCommand == null) _getEntitiesForSelectPaymentConditionPointCommand = () => { return UnitOfWork.Repository<PaymentConditionPoint>().GetAll(); };
			if (SelectPaymentConditionPointCommand == null) SelectPaymentConditionPointCommand = new DelegateLogCommand(SelectPaymentConditionPointCommand_Execute_Default);
			if (ClearPaymentConditionPointCommand == null) ClearPaymentConditionPointCommand = new DelegateLogCommand(ClearPaymentConditionPointCommand_Execute_Default);

		}

		private void SelectPaymentConditionPointCommand_Execute_Default() 
		{
            SelectAndSetWrapper<PaymentConditionPoint, PaymentConditionPointWrapper>(_getEntitiesForSelectPaymentConditionPointCommand(), nameof(Item.PaymentConditionPoint), Item.PaymentConditionPoint?.Id);
		}

		private void ClearPaymentConditionPointCommand_Execute_Default() 
		{
						Item.PaymentConditionPoint = null;		    
		}


    }

    public partial class PaymentDocumentDetailsViewModel : BaseDetailsViewModel<PaymentDocumentWrapper, PaymentDocument, AfterSavePaymentDocumentEvent>
    {
		private Func<List<PaymentActual>> _getEntitiesForAddInPaymentsCommand;
		public DelegateLogCommand AddInPaymentsCommand { get; }
		public DelegateLogCommand RemoveFromPaymentsCommand { get; private set; }
		private PaymentActualWrapper _selectedPaymentsItem;
		public PaymentActualWrapper SelectedPaymentsItem 
		{ 
			get { return _selectedPaymentsItem; }
			set 
			{ 
				if (Equals(_selectedPaymentsItem, value)) return;
				_selectedPaymentsItem = value;
				RaisePropertyChanged();
				RemoveFromPaymentsCommand.RaiseCanExecuteChanged();
			}
		}

        public PaymentDocumentDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForAddInPaymentsCommand == null) _getEntitiesForAddInPaymentsCommand = () => { return UnitOfWork.Repository<PaymentActual>().GetAll(); };;
			if (AddInPaymentsCommand == null) AddInPaymentsCommand = new DelegateLogCommand(AddInPaymentsCommand_Execute_Default);
			if (RemoveFromPaymentsCommand == null) RemoveFromPaymentsCommand = new DelegateLogCommand(RemoveFromPaymentsCommand_Execute_Default, RemoveFromPaymentsCommand_CanExecute_Default);

		}

			private void AddInPaymentsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<PaymentActual, PaymentActualWrapper>(_getEntitiesForAddInPaymentsCommand(), Item.Payments);
			}

			private void RemoveFromPaymentsCommand_Execute_Default()
			{
				Item.Payments.Remove(SelectedPaymentsItem);
			}

			private bool RemoveFromPaymentsCommand_CanExecute_Default()
			{
				return SelectedPaymentsItem != null;
			}


    }

    public partial class FacilityDetailsViewModel : BaseDetailsViewModel<FacilityWrapper, Facility, AfterSaveFacilityEvent>
    {
		//private Func<Task<List<FacilityType>>> _getEntitiesForSelectTypeCommand;
		private Func<List<FacilityType>> _getEntitiesForSelectTypeCommand;
		public DelegateLogCommand SelectTypeCommand { get; private set; }
		public DelegateLogCommand ClearTypeCommand { get; private set; }

		//private Func<Task<List<Company>>> _getEntitiesForSelectOwnerCompanyCommand;
		private Func<List<Company>> _getEntitiesForSelectOwnerCompanyCommand;
		public DelegateLogCommand SelectOwnerCompanyCommand { get; private set; }
		public DelegateLogCommand ClearOwnerCompanyCommand { get; private set; }

		//private Func<Task<List<Address>>> _getEntitiesForSelectAddressCommand;
		private Func<List<Address>> _getEntitiesForSelectAddressCommand;
		public DelegateLogCommand SelectAddressCommand { get; private set; }
		public DelegateLogCommand ClearAddressCommand { get; private set; }

        public FacilityDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectTypeCommand == null) _getEntitiesForSelectTypeCommand = () => { return UnitOfWork.Repository<FacilityType>().GetAll(); };
			if (SelectTypeCommand == null) SelectTypeCommand = new DelegateLogCommand(SelectTypeCommand_Execute_Default);
			if (ClearTypeCommand == null) ClearTypeCommand = new DelegateLogCommand(ClearTypeCommand_Execute_Default);

			
			if (_getEntitiesForSelectOwnerCompanyCommand == null) _getEntitiesForSelectOwnerCompanyCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectOwnerCompanyCommand == null) SelectOwnerCompanyCommand = new DelegateLogCommand(SelectOwnerCompanyCommand_Execute_Default);
			if (ClearOwnerCompanyCommand == null) ClearOwnerCompanyCommand = new DelegateLogCommand(ClearOwnerCompanyCommand_Execute_Default);

			
			if (_getEntitiesForSelectAddressCommand == null) _getEntitiesForSelectAddressCommand = () => { return UnitOfWork.Repository<Address>().GetAll(); };
			if (SelectAddressCommand == null) SelectAddressCommand = new DelegateLogCommand(SelectAddressCommand_Execute_Default);
			if (ClearAddressCommand == null) ClearAddressCommand = new DelegateLogCommand(ClearAddressCommand_Execute_Default);

		}

		private void SelectTypeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<FacilityType, FacilityTypeWrapper>(_getEntitiesForSelectTypeCommand(), nameof(Item.Type), Item.Type?.Id);
		}

		private void ClearTypeCommand_Execute_Default() 
		{
						Item.Type = null;		    
		}

		private void SelectOwnerCompanyCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectOwnerCompanyCommand(), nameof(Item.OwnerCompany), Item.OwnerCompany?.Id);
		}

		private void ClearOwnerCompanyCommand_Execute_Default() 
		{
						Item.OwnerCompany = null;		    
		}

		private void SelectAddressCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Address, AddressWrapper>(_getEntitiesForSelectAddressCommand(), nameof(Item.Address), Item.Address?.Id);
		}

		private void ClearAddressCommand_Execute_Default() 
		{
						Item.Address = null;		    
		}


    }

    public partial class ProjectDetailsViewModel : BaseDetailsViewModel<ProjectWrapper, Project, AfterSaveProjectEvent>
    {
		//private Func<Task<List<ProjectType>>> _getEntitiesForSelectProjectTypeCommand;
		private Func<List<ProjectType>> _getEntitiesForSelectProjectTypeCommand;
		public DelegateLogCommand SelectProjectTypeCommand { get; private set; }
		public DelegateLogCommand ClearProjectTypeCommand { get; private set; }

		//private Func<Task<List<User>>> _getEntitiesForSelectManagerCommand;
		private Func<List<User>> _getEntitiesForSelectManagerCommand;
		public DelegateLogCommand SelectManagerCommand { get; private set; }
		public DelegateLogCommand ClearManagerCommand { get; private set; }

		private Func<List<Note>> _getEntitiesForAddInNotesCommand;
		public DelegateLogCommand AddInNotesCommand { get; }
		public DelegateLogCommand RemoveFromNotesCommand { get; private set; }
		private NoteWrapper _selectedNotesItem;
		public NoteWrapper SelectedNotesItem 
		{ 
			get { return _selectedNotesItem; }
			set 
			{ 
				if (Equals(_selectedNotesItem, value)) return;
				_selectedNotesItem = value;
				RaisePropertyChanged();
				RemoveFromNotesCommand.RaiseCanExecuteChanged();
			}
		}

        public ProjectDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProjectTypeCommand == null) _getEntitiesForSelectProjectTypeCommand = () => { return UnitOfWork.Repository<ProjectType>().GetAll(); };
			if (SelectProjectTypeCommand == null) SelectProjectTypeCommand = new DelegateLogCommand(SelectProjectTypeCommand_Execute_Default);
			if (ClearProjectTypeCommand == null) ClearProjectTypeCommand = new DelegateLogCommand(ClearProjectTypeCommand_Execute_Default);

			
			if (_getEntitiesForSelectManagerCommand == null) _getEntitiesForSelectManagerCommand = () => { return UnitOfWork.Repository<User>().GetAll(); };
			if (SelectManagerCommand == null) SelectManagerCommand = new DelegateLogCommand(SelectManagerCommand_Execute_Default);
			if (ClearManagerCommand == null) ClearManagerCommand = new DelegateLogCommand(ClearManagerCommand_Execute_Default);

			
			if (_getEntitiesForAddInNotesCommand == null) _getEntitiesForAddInNotesCommand = () => { return UnitOfWork.Repository<Note>().GetAll(); };;
			if (AddInNotesCommand == null) AddInNotesCommand = new DelegateLogCommand(AddInNotesCommand_Execute_Default);
			if (RemoveFromNotesCommand == null) RemoveFromNotesCommand = new DelegateLogCommand(RemoveFromNotesCommand_Execute_Default, RemoveFromNotesCommand_CanExecute_Default);

		}

		private void SelectProjectTypeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<ProjectType, ProjectTypeWrapper>(_getEntitiesForSelectProjectTypeCommand(), nameof(Item.ProjectType), Item.ProjectType?.Id);
		}

		private void ClearProjectTypeCommand_Execute_Default() 
		{
						Item.ProjectType = null;		    
		}

		private void SelectManagerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<User, UserWrapper>(_getEntitiesForSelectManagerCommand(), nameof(Item.Manager), Item.Manager?.Id);
		}

		private void ClearManagerCommand_Execute_Default() 
		{
						Item.Manager = null;		    
		}

			private void AddInNotesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Note, NoteWrapper>(_getEntitiesForAddInNotesCommand(), Item.Notes);
			}

			private void RemoveFromNotesCommand_Execute_Default()
			{
				Item.Notes.Remove(SelectedNotesItem);
			}

			private bool RemoveFromNotesCommand_CanExecute_Default()
			{
				return SelectedNotesItem != null;
			}


    }

    public partial class UserRoleDetailsViewModel : BaseDetailsViewModel<UserRoleWrapper, UserRole, AfterSaveUserRoleEvent>
    {
        public UserRoleDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class SpecificationDetailsViewModel : BaseDetailsViewModel<SpecificationWrapper, Specification, AfterSaveSpecificationEvent>
    {
		//private Func<Task<List<Contract>>> _getEntitiesForSelectContractCommand;
		private Func<List<Contract>> _getEntitiesForSelectContractCommand;
		public DelegateLogCommand SelectContractCommand { get; private set; }
		public DelegateLogCommand ClearContractCommand { get; private set; }

        public SpecificationDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectContractCommand == null) _getEntitiesForSelectContractCommand = () => { return UnitOfWork.Repository<Contract>().GetAll(); };
			if (SelectContractCommand == null) SelectContractCommand = new DelegateLogCommand(SelectContractCommand_Execute_Default);
			if (ClearContractCommand == null) ClearContractCommand = new DelegateLogCommand(ClearContractCommand_Execute_Default);

		}

		private void SelectContractCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Contract, ContractWrapper>(_getEntitiesForSelectContractCommand(), nameof(Item.Contract), Item.Contract?.Id);
		}

		private void ClearContractCommand_Execute_Default() 
		{
						Item.Contract = null;		    
		}


    }

    public partial class TenderDetailsViewModel : BaseDetailsViewModel<TenderWrapper, Tender, AfterSaveTenderEvent>
    {
		//private Func<Task<List<Project>>> _getEntitiesForSelectProjectCommand;
		private Func<List<Project>> _getEntitiesForSelectProjectCommand;
		public DelegateLogCommand SelectProjectCommand { get; private set; }
		public DelegateLogCommand ClearProjectCommand { get; private set; }

		//private Func<Task<List<Company>>> _getEntitiesForSelectWinnerCommand;
		private Func<List<Company>> _getEntitiesForSelectWinnerCommand;
		public DelegateLogCommand SelectWinnerCommand { get; private set; }
		public DelegateLogCommand ClearWinnerCommand { get; private set; }

		private Func<List<TenderType>> _getEntitiesForAddInTypesCommand;
		public DelegateLogCommand AddInTypesCommand { get; }
		public DelegateLogCommand RemoveFromTypesCommand { get; private set; }
		private TenderTypeWrapper _selectedTypesItem;
		public TenderTypeWrapper SelectedTypesItem 
		{ 
			get { return _selectedTypesItem; }
			set 
			{ 
				if (Equals(_selectedTypesItem, value)) return;
				_selectedTypesItem = value;
				RaisePropertyChanged();
				RemoveFromTypesCommand.RaiseCanExecuteChanged();
			}
		}

		private Func<List<Company>> _getEntitiesForAddInParticipantsCommand;
		public DelegateLogCommand AddInParticipantsCommand { get; }
		public DelegateLogCommand RemoveFromParticipantsCommand { get; private set; }
		private CompanyWrapper _selectedParticipantsItem;
		public CompanyWrapper SelectedParticipantsItem 
		{ 
			get { return _selectedParticipantsItem; }
			set 
			{ 
				if (Equals(_selectedParticipantsItem, value)) return;
				_selectedParticipantsItem = value;
				RaisePropertyChanged();
				RemoveFromParticipantsCommand.RaiseCanExecuteChanged();
			}
		}

        public TenderDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectProjectCommand == null) _getEntitiesForSelectProjectCommand = () => { return UnitOfWork.Repository<Project>().GetAll(); };
			if (SelectProjectCommand == null) SelectProjectCommand = new DelegateLogCommand(SelectProjectCommand_Execute_Default);
			if (ClearProjectCommand == null) ClearProjectCommand = new DelegateLogCommand(ClearProjectCommand_Execute_Default);

			
			if (_getEntitiesForSelectWinnerCommand == null) _getEntitiesForSelectWinnerCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };
			if (SelectWinnerCommand == null) SelectWinnerCommand = new DelegateLogCommand(SelectWinnerCommand_Execute_Default);
			if (ClearWinnerCommand == null) ClearWinnerCommand = new DelegateLogCommand(ClearWinnerCommand_Execute_Default);

			
			if (_getEntitiesForAddInTypesCommand == null) _getEntitiesForAddInTypesCommand = () => { return UnitOfWork.Repository<TenderType>().GetAll(); };;
			if (AddInTypesCommand == null) AddInTypesCommand = new DelegateLogCommand(AddInTypesCommand_Execute_Default);
			if (RemoveFromTypesCommand == null) RemoveFromTypesCommand = new DelegateLogCommand(RemoveFromTypesCommand_Execute_Default, RemoveFromTypesCommand_CanExecute_Default);

			
			if (_getEntitiesForAddInParticipantsCommand == null) _getEntitiesForAddInParticipantsCommand = () => { return UnitOfWork.Repository<Company>().GetAll(); };;
			if (AddInParticipantsCommand == null) AddInParticipantsCommand = new DelegateLogCommand(AddInParticipantsCommand_Execute_Default);
			if (RemoveFromParticipantsCommand == null) RemoveFromParticipantsCommand = new DelegateLogCommand(RemoveFromParticipantsCommand_Execute_Default, RemoveFromParticipantsCommand_CanExecute_Default);

		}

		private void SelectProjectCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Project, ProjectWrapper>(_getEntitiesForSelectProjectCommand(), nameof(Item.Project), Item.Project?.Id);
		}

		private void ClearProjectCommand_Execute_Default() 
		{
						Item.Project = null;		    
		}

		private void SelectWinnerCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Company, CompanyWrapper>(_getEntitiesForSelectWinnerCommand(), nameof(Item.Winner), Item.Winner?.Id);
		}

		private void ClearWinnerCommand_Execute_Default() 
		{
						Item.Winner = null;		    
		}

			private void AddInTypesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<TenderType, TenderTypeWrapper>(_getEntitiesForAddInTypesCommand(), Item.Types);
			}

			private void RemoveFromTypesCommand_Execute_Default()
			{
				Item.Types.Remove(SelectedTypesItem);
			}

			private bool RemoveFromTypesCommand_CanExecute_Default()
			{
				return SelectedTypesItem != null;
			}

			private void AddInParticipantsCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<Company, CompanyWrapper>(_getEntitiesForAddInParticipantsCommand(), Item.Participants);
			}

			private void RemoveFromParticipantsCommand_Execute_Default()
			{
				Item.Participants.Remove(SelectedParticipantsItem);
			}

			private bool RemoveFromParticipantsCommand_CanExecute_Default()
			{
				return SelectedParticipantsItem != null;
			}


    }

    public partial class TenderTypeDetailsViewModel : BaseDetailsViewModel<TenderTypeWrapper, TenderType, AfterSaveTenderTypeEvent>
    {
        public TenderTypeDetailsViewModel(IUnityContainer container) : base(container) 
		{
		}


    }

    public partial class UserDetailsViewModel : BaseDetailsViewModel<UserWrapper, User, AfterSaveUserEvent>
    {
		//private Func<Task<List<Employee>>> _getEntitiesForSelectEmployeeCommand;
		private Func<List<Employee>> _getEntitiesForSelectEmployeeCommand;
		public DelegateLogCommand SelectEmployeeCommand { get; private set; }
		public DelegateLogCommand ClearEmployeeCommand { get; private set; }

		private Func<List<UserRole>> _getEntitiesForAddInRolesCommand;
		public DelegateLogCommand AddInRolesCommand { get; }
		public DelegateLogCommand RemoveFromRolesCommand { get; private set; }
		private UserRoleWrapper _selectedRolesItem;
		public UserRoleWrapper SelectedRolesItem 
		{ 
			get { return _selectedRolesItem; }
			set 
			{ 
				if (Equals(_selectedRolesItem, value)) return;
				_selectedRolesItem = value;
				RaisePropertyChanged();
				RemoveFromRolesCommand.RaiseCanExecuteChanged();
			}
		}

        public UserDetailsViewModel(IUnityContainer container) : base(container) 
		{
			
			if (_getEntitiesForSelectEmployeeCommand == null) _getEntitiesForSelectEmployeeCommand = () => { return UnitOfWork.Repository<Employee>().GetAll(); };
			if (SelectEmployeeCommand == null) SelectEmployeeCommand = new DelegateLogCommand(SelectEmployeeCommand_Execute_Default);
			if (ClearEmployeeCommand == null) ClearEmployeeCommand = new DelegateLogCommand(ClearEmployeeCommand_Execute_Default);

			
			if (_getEntitiesForAddInRolesCommand == null) _getEntitiesForAddInRolesCommand = () => { return UnitOfWork.Repository<UserRole>().GetAll(); };;
			if (AddInRolesCommand == null) AddInRolesCommand = new DelegateLogCommand(AddInRolesCommand_Execute_Default);
			if (RemoveFromRolesCommand == null) RemoveFromRolesCommand = new DelegateLogCommand(RemoveFromRolesCommand_Execute_Default, RemoveFromRolesCommand_CanExecute_Default);

		}

		private void SelectEmployeeCommand_Execute_Default() 
		{
            SelectAndSetWrapper<Employee, EmployeeWrapper>(_getEntitiesForSelectEmployeeCommand(), nameof(Item.Employee), Item.Employee?.Id);
		}

		private void ClearEmployeeCommand_Execute_Default() 
		{
						Item.Employee = null;		    
		}

			private void AddInRolesCommand_Execute_Default()
			{
				SelectAndAddInListWrapper<UserRole, UserRoleWrapper>(_getEntitiesForAddInRolesCommand(), Item.Roles);
			}

			private void RemoveFromRolesCommand_Execute_Default()
			{
				Item.Roles.Remove(SelectedRolesItem);
			}

			private bool RemoveFromRolesCommand_CanExecute_Default()
			{
				return SelectedRolesItem != null;
			}


    }

}
