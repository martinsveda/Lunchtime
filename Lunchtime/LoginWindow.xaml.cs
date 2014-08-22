using System;
using System.Windows;



namespace Lunchtime
{

    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }

        void Show();
        Nullable<bool> ShowDialog();
    }

    
    public partial class LoginWindow : Window, IView
    {
        public LoginWindow(AuthenticationViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        #region IView members
        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
        #endregion



        /*        
        private void cmdLoginLogin_Click(object sender, RoutedEventArgs e)
        {
            username.Text = username.Text.Trim();           // remove white space characters
            password.Password = password.Password.Trim();

            if ((username.Text == "") || (password.Password == ""))
            {
                MessageBox.Show("Insert credentials!", "Login to lunchtime");
                return;
            }

            MySqlDB connection = new MySqlDB();
            if (connection.ValidateUser(username.Text, password.Password) != 1)
            {
                MessageBox.Show("Authentication failed. Contact your admin to get access to Lunchtime.", "Authentication");
                // O tomto si nejsem jisty, ze ma byt tady
                Application.Current.Shutdown();
            }

            this.Close();
        }
 */
    }
}
