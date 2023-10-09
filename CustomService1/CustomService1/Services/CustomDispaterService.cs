using CustomService1.Services.Interface;

namespace CustomService1.Services
{
    public class CustomDispaterService : ICustomDispaterService
    {
        public int Key { get; set; } = 0;
        public string Value { get; set; } = string.Empty;

        public void OnPlus()
        {
            Key += 1;
        }

        public void OnMinus()
        {
            Key -= 1;
        }
    }
}
