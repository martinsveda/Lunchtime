/* Git revision information:
 * 
 * @version $Revision: 1e7f611039399b32e9000ec454609a0641dde368 $
 * @author  $Author: Eugen Mihailescu <eugenmihailescux@gmail.com> $
 * @date    $Date:   Thu May 3 01:17:45 2012 +0200 $
 * 
 * $Id:  | Thu May 3 01:17:45 2012 +0200 | Eugen Mihailescu  $
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

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
            LoginViewModel authViewModel = new LoginViewModel(new AuthenticationService());
            IView loginWindow = new LoginWindow(authViewModel);

            MainViewModel mainViewModel = new MainViewModel();
            IView mainWindow = new MainWindow(mainViewModel);


            loginWindow.ShowDialog();

            mainWindow.Show();

            mainViewModel.Status = AppDomain.CurrentDomain.

            
        }      
    }
}
