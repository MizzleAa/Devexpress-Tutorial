using CustomService1.Services.Interface;
using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace CustomService1.ViewModels
{
    public class ViewModel2 : ViewModelBase
    {
        private readonly ICustomDispaterService customDispaterService = App.Current.Services.GetService<ICustomDispaterService>();
        #region
        private string text = string.Empty;
        public string Text { get => text; set => SetValue(ref text, value); }

        private DelegateCommand startButtonCommand;
        public ICommand StartButtonCommand => startButtonCommand ??= new DelegateCommand(StartButton);

        private DelegateCommand stopButtonCommand;
        public ICommand StopButtonCommand => stopButtonCommand ??= new DelegateCommand(StopButton);
        #endregion

        public ViewModel2()
        {
        }

        private void StartButton()
        {
            customDispaterService.OnPlus();
            Text += $"{customDispaterService.Key}\n";
        }

        private void StopButton()
        {
            customDispaterService.OnMinus();
            Text += $"{customDispaterService.Key}\n";
        }
    }
}
