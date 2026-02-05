using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace HVTApp.UI.Modules.Settings.ViewModels
{
    public class PasswordViewModel : BindableBase
    {
        private string _passOld;
        private string _passNew;
        private string _passAgain;

        public DelegateLogCommand OkCommand { get; set; }

        public string PassOld
        {
            get => _passOld;
            set
            {
                _passOld = value;
                (OkCommand).RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string PassNew
        {
            get => _passNew;
            set
            {
                _passNew = value;
                (OkCommand).RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string PassAgain
        {
            get => _passAgain;
            set
            {
                _passAgain = value;
                (OkCommand).RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public PasswordViewModel(IUnityContainer container)
        {
            var unitOfWork = container.Resolve<IUnitOfWork>();
            var user = unitOfWork.Repository<User>().Find(x => x.IsAppCurrentUser()).First();

            OkCommand = new DelegateLogCommand(
                () =>
                {
                    user.Password = StringToGuid.GetHashString(PassNew);
                    unitOfWork.SaveChanges();
                    container.Resolve<IMessageService>().Message("Пароль изменен", "Пароль успешно изменен.");

                    PassOld = string.Empty;
                    PassNew = string.Empty;
                    PassAgain = string.Empty;
                },

                () => !string.IsNullOrEmpty(PassOld) &&
                      !string.IsNullOrEmpty(PassNew) &&
                      !string.IsNullOrEmpty(PassAgain) &&
                      StringToGuid.GetHashString(PassOld) == user.Password 
                      && PassNew == PassAgain);
        }
    }
}
