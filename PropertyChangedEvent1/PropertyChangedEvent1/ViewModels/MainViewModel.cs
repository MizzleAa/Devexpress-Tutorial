using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using PropertyChangedEvent1.Model.Interface;
using PropertyChangedEvent1.Services.Interface;
using System.ComponentModel;

namespace PropertyChangedEvent1.ViewModels
{
    public class TimerUIModel : ViewModelBase, ITimerModel
    {
        private string hour;
        public string Hour { get => hour; set => SetValue(ref hour, value); }

        private string minute;
        public string Minute { get => minute; set => SetValue(ref minute, value); }

        private string second;
        public string Second { get => second; set => SetValue(ref second, value); }
    }

    public class MainViewModel : ViewModelBase
    {
        #region Service
        private readonly ITimerService sTimerService = App.Current.AppServices.Services.GetService<ITimerService>();
        #endregion

        #region Model Params

        private TimerUIModel timerModel = new TimerUIModel();
        public TimerUIModel TimerModel { get => timerModel; set => SetValue(ref timerModel, value); }

        #endregion

        public MainViewModel() 
        {
            InitializePropertyChanged();
            OnServiceStart();
        }

        private void InitializePropertyChanged()
        {
            sTimerService.PropertyChanged += TimerPropertyChanged;
        }

        private void OnServiceStart()
        {
            sTimerService.Start();
        }

        private void TimerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(sTimerService.GetDateTimer))
            {
                TimerModel.Hour = sTimerService.GetDateTimer().Hour.ToString();
                TimerModel.Minute = sTimerService.GetDateTimer().Minute.ToString();
                TimerModel.Second = sTimerService.GetDateTimer().Second.ToString();
            }
        }
    }
}
