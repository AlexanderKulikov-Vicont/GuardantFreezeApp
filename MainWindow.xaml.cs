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
using DevExpress.Xpf.Core;

namespace GuardantFreezeApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            status1Run.Visibility = Visibility.Collapsed; status1Stop.Visibility = Visibility.Visible; status1Error.Visibility = Visibility.Collapsed;
            status2Run.Visibility = Visibility.Collapsed; status2Stop.Visibility = Visibility.Visible; status2Error.Visibility = Visibility.Collapsed;
            statusDatabaseOk.Visibility = Visibility.Collapsed; statusDatabaseError.Visibility = Visibility.Collapsed; statusDatabaseOff.Visibility = Visibility.Visible;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();
            StartTimeTextBlock.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
            StartButton.IsEnabled = false;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GuardantTestFunction();
            SetState1(rnd.Next(0, 3));
            SetState2(rnd.Next(0, 3));
            SetStateDB(rnd.Next(0, 3));
            CurrentTimeTextBlock.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
        }

        private void SetState1(int state)
        {
            if (state == 0) { status1Run.Visibility = Visibility.Collapsed; status1Stop.Visibility = Visibility.Visible; status1Error.Visibility = Visibility.Collapsed; }
            else if (state == 1) { status1Run.Visibility = Visibility.Visible; status1Stop.Visibility = Visibility.Collapsed; status1Error.Visibility = Visibility.Collapsed; }
            else if (state == 2) { status1Run.Visibility = Visibility.Collapsed; status1Stop.Visibility = Visibility.Collapsed; status1Error.Visibility = Visibility.Visible; }
        }

        private void SetState2(int state)
        {
            if (state == 0) { status2Run.Visibility = Visibility.Collapsed; status2Stop.Visibility = Visibility.Visible; status2Error.Visibility = Visibility.Collapsed; }
            else if (state == 1) { status2Run.Visibility = Visibility.Visible; status2Stop.Visibility = Visibility.Collapsed; status2Error.Visibility = Visibility.Collapsed; }
            else if (state == 2) { status2Run.Visibility = Visibility.Collapsed; status2Stop.Visibility = Visibility.Collapsed; status2Error.Visibility = Visibility.Visible; }
        }

        private void SetStateDB(int state)
        {
            if (state == 0) { statusDatabaseOk.Visibility = Visibility.Collapsed; statusDatabaseError.Visibility = Visibility.Visible; statusDatabaseOff.Visibility = Visibility.Collapsed; }
            else if (state == 1) { statusDatabaseOk.Visibility = Visibility.Visible; statusDatabaseError.Visibility = Visibility.Collapsed; statusDatabaseOff.Visibility = Visibility.Collapsed; }
            else if (state == 2) { statusDatabaseOk.Visibility = Visibility.Collapsed; statusDatabaseError.Visibility = Visibility.Collapsed; statusDatabaseOff.Visibility = Visibility.Visible; }
        }

        /// <summary>
        /// Если защитить данную функцию через Guardant Profiler, то приложение рано или поздно зависнет
        /// </summary>
        private void GuardantTestFunction()
        {
            //Console.WriteLine("GuardantTestFunction");
            int i = 0;
            i++;
            return;
        }
    }
}
