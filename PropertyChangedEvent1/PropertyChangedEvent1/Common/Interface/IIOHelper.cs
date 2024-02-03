namespace PropertyChangedEvent1.Common.Interface
{
    public interface IIOHelper
    {
        void Load(string filePath);
        object Get(string header, string key);
    }
}
