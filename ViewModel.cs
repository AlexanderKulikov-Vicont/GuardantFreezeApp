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

        public ViewModel()
        {
            StartButtonEnabled = true;
        }

    }
}
