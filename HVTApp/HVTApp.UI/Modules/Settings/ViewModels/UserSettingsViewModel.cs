using HVTApp.Infrastructure;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.UI.Commands;
using Prism.Mvvm;

namespace HVTApp.UI.Modules.Settings.ViewModels
{
    public class UserSettingsViewModel : BindableBase
    {
        public PasswordViewModel PasswordViewModel { get; }
        public UserSettingsWrapper User { get; }

        public DelegateLogCommand SaveCommand { get; set; }

        public UserSettingsViewModel(IUnitOfWork unitOfWork, PasswordViewModel passwordViewModel)
        {
            PasswordViewModel = passwordViewModel;

            var user = unitOfWork.Repository<User>().GetById(GlobalAppProperties.User.Id);
            User = new UserSettingsWrapper(user);

            SaveCommand = new DelegateLogCommand(
                () =>
                {
                    User.AcceptChanges();
                    unitOfWork.SaveChanges();
                },
                () => 
                    User.IsValid && 
                    User.IsChanged);

            User.PropertyChanged += (sender, args) => SaveCommand.RaiseCanExecuteChanged();
        }
    }
}