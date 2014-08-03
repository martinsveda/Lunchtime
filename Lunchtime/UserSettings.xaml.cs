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
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Window
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void cmdUserSettingsSave_Click(object sender, RoutedEventArgs e)
        {
           
            MySqlDB connection = new MySqlDB("SVEDAMARTIN", "lunchtime", "martin", "martin");

            if (password1.Password != password2.Password) {
                MessageBox.Show("Both passwords must be the same!", "Error");
                return ;
            }
            
            if (connection.SaveUserData(username.Text, name.Text, surname.Text, password1.Password, email.Text, access_rights.SelectedIndex) != 0) {
                MessageBox.Show("User stored to database.", "Confirmation");
            }
            else {
                MessageBox.Show("User NOT stored to database!", "Error");
            }


            this.Close();
            return ;
        }

        private void cmdUserSettingsCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
