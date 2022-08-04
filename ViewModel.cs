using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuardantFreezeApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private Random rnd = new Random();

        public event PropertyChangedEventHandler PropertyChanged;
        // Служебная функция (синхронизирует интерфейс с коллекциями)
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region States
        private bool state1_Ok;
        public bool State1_Ok
        {
            get { return state1_Ok; }
            set { state1_Ok = value; NotifyPropertyChanged(); }
        }

        private bool state1_Off;
        public bool State1_Off
        {
            get { return state1_Off; }
            set { state1_Off = value; NotifyPropertyChanged(); }
        }

        private bool state1_Error;
        public bool State1_Error
        {
            get { return state1_Error; }
            set { state1_Error = value; NotifyPropertyChanged(); }
        }

        private bool state2_Ok;
        public bool State2_Ok
        {
            get { return state2_Ok; }
            set { state2_Ok = value; NotifyPropertyChanged(); }
        }

        private bool state2_Off;
        public bool State2_Off
        {
            get { return state2_Off; }
            set { state2_Off = value; NotifyPropertyChanged(); }
        }

        private bool state2_Error;
        public bool State2_Error
        {
            get { return state2_Error; }
            set { state2_Error = value; NotifyPropertyChanged(); }
        }

        private bool db_Ok;
        public bool Db_Ok
        {
            get { return db_Ok; }
            set { db_Ok = value; NotifyPropertyChanged(); }
        }

        private bool db_Off;
        public bool Db_Off
        {
            get { return db_Off; }
            set { db_Off = value; NotifyPropertyChanged(); }
        }

        private bool db_Error;
        public bool Db_Error
        {
            get { return db_Error; }
            set { db_Error = value; NotifyPropertyChanged(); }
        }

        private bool startButtonEnabled;
        public bool StartButtonEnabled
        {
            get { return startButtonEnabled; }
            set { startButtonEnabled = value; NotifyPropertyChanged(); }
        }

        private string startTimeString;
        public string StartTimeString
        {
            get { return startTimeString; }
            set { startTimeString = value; NotifyPropertyChanged(); }
        }

        private string currentTimeString;
        public string CurrentTimeString
        {
            get { return currentTimeString; }
            set { currentTimeString = value; NotifyPropertyChanged(); }
        }
        #endregion

        private void SetState1(int state)
        {
            if (state == 0) { State1_Ok = false; State1_Off = true; State1_Error = false; }
            else if (state == 1) { State1_Ok = true; State1_Off = false; State1_Error = false; }
            else if (state == 2) { State1_Ok = false; State1_Off = false; State1_Error = true; }
        }

        private void SetState2(int state)
        {
            if (state == 0) { State2_Ok = false; State2_Off = true; State2_Error = false; }
            else if (state == 1) { State2_Ok = true; State2_Off = false; State2_Error = false; }
            else if (state == 2) { State2_Ok = false; State2_Off = false; State2_Error = true; }
        }

        private void SetStateDB(int state)
        {
            if (state == 0) { Db_Ok = false; Db_Off = true; Db_Error = false; }
            else if (state == 1) { Db_Ok = true; Db_Off = false; Db_Error = false; }
            else if (state == 2) { Db_Ok = false; Db_Off = false; Db_Error = true; }
        }

        public ViewModel()
        {
            SetState1(0);
            SetState2(0);
            SetStateDB(0);
            StartButtonEnabled = true;
        }

        private RelayCommand startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ??
                  (startCommand = new RelayCommand(obj =>
                  {
                      StartButtonEnabled = false;
                      dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                      dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                      dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                      dispatcherTimer.Start();
                      StartTimeString = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
                  }));
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GuardantTestFunction();
            SetState1(rnd.Next(0, 3));
            SetState2(rnd.Next(0, 3));
            SetStateDB(rnd.Next(0, 3));
            CurrentTimeString = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
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
