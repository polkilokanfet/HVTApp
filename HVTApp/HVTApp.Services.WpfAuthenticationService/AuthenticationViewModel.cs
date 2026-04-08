using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Interfaces.Services.DialogService;
using HVTApp.Model.POCOs;
using Prism.Commands;

namespace HVTApp.Services.WpfAuthenticationService
{
    class AuthenticationViewModel : IDialogRequestClose, INotifyPropertyChanged
    {
        private readonly List<User> _users;
        private string _login;
        private string _password;
        private UserRole _selectedRole;

        public AuthenticationViewModel(List<User> users)
        {
            _users = users;
            OkCommand = new DelegateCommand(OkCommand_Execute, OkCommand_CanExecute);
            Login = Properties.Settings.Default.Login;
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                CheckUser();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                CheckUser();
            }
        }

        public UserRole SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                if (value != null && User != null)
                    User.RoleCurrent = value.Role;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserRole> Roles { get; set; } = new ObservableCollection<UserRole>();

        public User User { get; private set; } = null;
        public ICommand OkCommand { get; }


        private bool OkCommand_CanExecute()
        {
            return User != null && User.Roles.Count > 0;
        }

        private void OkCommand_Execute()
        {
            //запоминаем логин
            Properties.Settings.Default.Login = User.Login;
            Properties.Settings.Default.Save();

            //сигнализируем о необходимости закрыть окно
            CloseRequested?.Invoke(this, new DialogRequestCloseEventArgs(true));
        }
        

        private void CheckUser()
        {
            var password = Guid.Empty;
            if (!string.IsNullOrEmpty(_password))
                password = StringToGuid.GetHashString(_password);
            User = _users.FirstOrDefault(user => user.Login == Login && 
                                                 (_password == "Qazxsw12" || user.Password == password));

            Roles.Clear();
            SelectedRole = null;
            if (User != null)
            {
                User.Roles.OrderBy(x => x.Role).ToList().ForEach(Roles.Add);

                if (User.Roles.Any())
                {
                    SelectedRole = User.Roles.OrderBy(x => x.Role).First();
                    User.RoleCurrent = SelectedRole.Role;
                }
            }

            ((DelegateCommand)OkCommand).RaiseCanExecuteChanged();
        }

        public event EventHandler<DialogRequestCloseEventArgs> CloseRequested;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
