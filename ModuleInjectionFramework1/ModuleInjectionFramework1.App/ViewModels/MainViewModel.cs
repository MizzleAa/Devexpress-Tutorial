using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace ModuleInjectionFramework1.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }
    }
}
