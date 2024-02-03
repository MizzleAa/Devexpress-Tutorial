using System;
using System.ComponentModel;

namespace PropertyChangedEvent1.Services.Interface
{
    public interface ITimerService
    {
        event PropertyChangedEventHandler PropertyChanged;
        void Start();
        void Stop();

        DateTime GetDateTimer();
    }
}
