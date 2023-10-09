using DevExpress.Mvvm;

namespace DialogService1.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string userName;
        public string UserName { get => userName; set => SetValue(ref userName, value); }
    }
}
