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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Globalization;



namespace Lunchtime
{

    public partial class MainWindow : Window, IView
    {
        //private MySqlDB mysqldb = new MySqlDB("SVEDAMARTIN", "lunchtime", "martin", "martin");
        private DateTime actualDate;

        public MainWindow(MainViewModel mainViewModel)
        {
            ViewModel = mainViewModel;
            InitializeComponent();

        }

        #region IView members
        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
        #endregion




        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            DayOfWeek firstDay = culture.DateTimeFormat.FirstDayOfWeek;

            actualDate = calendar.SelectedDate.Value;
            while (actualDate.DayOfWeek != firstDay)
                actualDate = actualDate.AddDays(-1);

            lblActualDate.Text = actualDate.ToShortDateString();

        }

        private void calendar_Initialized(object sender, EventArgs e)
        {
            //CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            //calendar.BlackoutDates.Add(cdr);
        }


    }
}
