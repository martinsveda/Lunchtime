using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lunchtime
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void cmdLoginCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmdLoginLogin_Click(object sender, RoutedEventArgs e)
        {
            username.Text = username.Text.Trim();           // remove white space characters
            password.Password = password.Password.Trim();

            if ((username.Text == "") || (password.Password == ""))
            {
                MessageBox.Show("Insert credentials!", "Login to lunchtime");
                return;
            }

            MySqlDB connection = new MySqlDB("SVEDAMARTIN", "lunchtime", "martin", "martin");
            if (connection.ValidateUser(username.Text, password.Password) == 1)
            {
                UserSettings user_settings_Window = new UserSettings();
                user_settings_Window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Authentication failed.", "Authentication");
            }

            this.Close();
        }
    }
}
