using PropertyChangedEvent1.Services.Interface;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PropertyChangedEvent1.Services
{
    public class TimerLibrary
    {
        private System.Timers.Timer timer;

        public event EventHandler<DateTime> DateTimerChangedEventHandler;

        public DateTime DateTimer { set; get; }

        public void Start()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += async (_, __) => await TimerElapsedAsync(() => TimerActionHandler());
            timer.Start();
        }
        public void Stop()
        {
            timer?.Stop();
        }

        private void TimerActionHandler()
        {
            DateTimer = DateTime.Now;
            DateTimerChangedEventHandler?.Invoke(this, DateTimer);
        }

        private async Task TimerElapsedAsync(Action specificFunction)
        {
            specificFunction?.Invoke();
            await Task.Delay(1);
        }
    }
    public class TimerService : ITimerService
    {

        #region EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public readonly TimerLibrary TimerLibrary;
        
        public TimerService()
        {
            TimerLibrary = new TimerLibrary();
            TimerLibrary.DateTimerChangedEventHandler += DateTimerChangedEventHandler;
        }


        public void Start()
        {
            TimerLibrary.Start();
        }

        public void Stop()
        {
            TimerLibrary.Stop();
        }

        public DateTime GetDateTimer()
        {
            return TimerLibrary.DateTimer;
        }

        private void DateTimerChangedEventHandler(object sender, DateTime e)
        {
            OnPropertyChanged(nameof(GetDateTimer));
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
