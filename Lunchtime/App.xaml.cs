/* Git revision information:
 * 
 * @version $Revision:$
 * @author  $Author:$
 * @date    $Date:$
 * 
 * $Id:$
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
            LoginWindow loginWindow = new LoginWindow();
            MainWindow mainWindow = new MainWindow();

            // Create a custom principal with an anonymous identity on start up
            CustomPrincipal customPrincipal= new CustomPrincipal();

            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);
            //base.OnStartup(e);
            // Show login window
            

            loginWindow.ShowDialog();

            
            mainWindow.Show();


            mainWindow.lblLogin.Text = "Logged as: " + Thread.CurrentPrincipal.Identity.Name;
        }      
    }
}
