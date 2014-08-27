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
        public Action CloseAction { get; set; }

        public LoginWindow(LoginViewModel viewModel)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
