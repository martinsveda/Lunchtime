using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lunchtime
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Create a custom principal with an anonymous identity on start up
            CustomPrincipal customPrincipal= new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);


            base.OnStartup(e);
            // Show login window
            MainViewModel viewModel = new MainViewModel(new AuthenticationService());
            
            IView loginWindow = new LoginWindow(viewModel);
            loginWindow.ShowDialog();

            if (customPrincipal.Identity.Name != string.Empty)
            {
                // close the window!!!
                ;
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
        
        /*
        public User current_user = new User();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            LoginWindow LoginWindow = new LoginWindow();

            LoginWindow.ShowDialog();
            MainWindow.Show();
        }
        */
    }
}
