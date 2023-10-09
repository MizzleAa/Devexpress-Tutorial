namespace CustomService1.Services.Interface
{
    public interface ICustomDispaterService
    {
        int Key { get; set; }
        string Value { get; set; }

        void OnPlus();
        void OnMinus();
    }
}
