using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;


namespace Lunchtime
{

  
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IAuthenticationService authenticationService = new AuthenticationService();

            try
            {
                // Validate user through validation service (db)
                User user = authenticationService.AuthenticateUser(username.Text, passwordBox.Password);

                //Get current principal object
                CustomPrincipal customPrinciplal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrinciplal == null)
                    throw new ArgumentException("Set the default CustomPrincipal at start-up!");

                // Authenticate user
                customPrinciplal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);

                username.Text = string.Empty;
                passwordBox.Password = string.Empty;
            }
            catch (Exception ex)
            {
                ;
            }
            
            this.Close(); // Close the Login window
        }
    }
}
