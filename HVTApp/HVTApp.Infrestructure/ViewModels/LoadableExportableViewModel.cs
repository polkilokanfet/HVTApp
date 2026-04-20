using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;

namespace HVTApp.Infrastructure.ViewModels
{
    public abstract class LoadableExportableViewModel : ViewModelBaseCanExportToExcelSaveCustomization
    {
        private bool _isLoaded = false;
        private bool _loadingInProcess;

        public bool IsLoaded
        {
            get => _isLoaded;
            protected set
            {
                _isLoaded = value;
                RaisePropertyChanged();

                if (_isLoaded)
                {
                    LoadComplited?.Invoke();
                }
            }
        }

        /// <summary>
        /// флаг протекания в данный момент загрузки данных
        /// </summary>
        public bool LoadingInProcess
        {
            get => _loadingInProcess;
            private set => SetProperty(ref _loadingInProcess, value, () =>
            {
                ((DelegateCommand)ReloadCommand).RaiseCanExecuteChanged();
            });
        }

        /// <summary>
        /// Загрузка завершена
        /// </summary>
        public event Action LoadComplited;

        public ICommand ReloadCommand { get; }

        protected LoadableExportableViewModel(IUnityContainer container, bool loadDataInCtor = true) 
            : base(container)
        {
            ReloadCommand = new DelegateCommand(ReloadCommand_Execute, ReloadCommand_CanExecute);

            if (loadDataInCtor)
            {
                Load();
            }
        }

        private bool ReloadCommand_CanExecute()
        {
            return LoadingInProcess == false;
        }

        protected virtual void ReloadCommand_Execute()
        {
            Load();
        }

        private void Load()
        {
            BeforeGetData();
            LoadingInProcess = true;
            IsLoaded = false;
            Task.Run(() =>
                {
                    GetData();
                })
                .Await(
                    () =>
                    {
                        AfterGetData();
                        IsLoaded = true;
                        LoadingInProcess = false;
                        ((DelegateCommand)ReloadCommand).RaiseCanExecuteChanged();
                    }, 
                    ErrorCallback);
        }

        protected virtual void ErrorCallback(Exception exception)
        {
            Container.Resolve<IMessageService>().Message("Exception", exception.PrintAllExceptions());
        }

        /// <summary>
        /// Получение всех необходимых данных.
        /// </summary>
        protected abstract void GetData();

        /// <summary>
        /// Действия до получения всех необходимых данных.
        /// </summary>
        protected virtual void BeforeGetData()
        {
        }

        /// <summary>
        /// Действия после получения всех необходимых данных.
        /// </summary>
        protected abstract void AfterGetData();
    }
}