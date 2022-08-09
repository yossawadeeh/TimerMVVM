using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using TimerMvvm.Model;

namespace TimerMvvm.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        #region Members
        _Timer timer;
        int time_count = 0;
        System.Timers.Timer aTimer = new System.Timers.Timer(500);
        #endregion

        #region Properties
        public _Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public string setTimer
        {
            get { return timer.setTimer; }
            set
            {
                if (timer.setTimer != value)
                {
                    timer.setTimer = value;
                    RaisePropertyChanged("setTimer");
                }
            }
        }
        #endregion

        #region Constructor
        public TimerViewModel()
        {
            timer = new _Timer { setTimer = "0" };
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent); // set my period timer
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ++time_count;
            setTimer = time_count.ToString();
        }
        #endregion

        #region Command
        // start
        void StartCountExecute()
        {
            aTimer.Start();
        }
        bool CanStartCountExecute()
        {
            return true;
        }
        public ICommand StartCount { get { return new RelayCommand(StartCountExecute, CanStartCountExecute); } }

        // pause
        void PauseCountExecute()
        {
            aTimer.Stop();
        }
        bool CanPauseCountExecute()
        {
            return true;
        }
        public ICommand PauseCount { get { return new RelayCommand(PauseCountExecute, CanPauseCountExecute); } }

        // restart
        public void RestartCountExecute()
        {
            aTimer.Stop();
            time_count = 0;
            setTimer = time_count.ToString();
            aTimer.Start();
        }
        bool CanRestartCountExecute()
        {
            return true;
        }
        public ICommand RestartCount { get { return new RelayCommand(RestartCountExecute, CanRestartCountExecute); } }

        // stop
        public void StopCountExecute()
        {
            aTimer.Stop();
            time_count = 0;
            setTimer = time_count.ToString();
        }
        bool CanStopCountExecute()
        {
            return true;
        }
        public ICommand StopCount { get { return new RelayCommand(StopCountExecute, CanStopCountExecute); } }

        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
