using PropertyChangedEvent1.Model.Interface;

namespace PropertyChangedEvent1.Model
{
    public class TimerModel : ITimerModel
    {
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Second { get; set; }
    }
}
