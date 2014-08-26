using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Security;



namespace Lunchtime
{
    public interface IViewModel { }

    public class LoginViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly DelegateCommand _loginCommand;
        private readonly DelegateCommand _cancelCommand;
        
        private string _username;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new DelegateCommand(Login, CanLogin);
            _cancelCommand = new DelegateCommand(Cancel, CanCancel);
        }

        #region Properties

        public Action CloseAction { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }
 
        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                {
                    return string.Format("Signed in as: {0}", Thread.CurrentPrincipal.Identity.Name);
                }
                else
                    return "Not authenticated!";
            }
        }

        #endregion

        #region Commands

        public DelegateCommand LoginCommand
        {
            get { return _loginCommand; }
        }


        public DelegateCommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        #endregion

        private void Login(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;

            try
            {
                // Validate user through validation service (db)
                clearTextPassword = clearTextPassword.Trim();
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);

                //Get current principal object
                CustomPrincipal customPrinciplal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrinciplal == null)
                    throw new ArgumentException("Set the default CustomPrincipal at start-up!");

                // Authenticate user
                customPrinciplal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);

                // Update UI
                NotifyPropertyChanged("AuthenticatedUser");
                NotifyPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _cancelCommand.RaiseCanExecuteChanged();
                Username = string.Empty;
                passwordBox.Password = string.Empty;
            }
            catch (Exception ex)
            {
                ;
            }
        }

        
        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        private void Cancel(object parameter)
        {
            App.Current.Shutdown();
        }

        private bool CanCancel(object parameter)
        {
            return true;
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
