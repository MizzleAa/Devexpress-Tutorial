using CustomService1.Views;
using DevExpress.Mvvm;

namespace CustomService1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object content1;
        public object Content1 { get => content1; set => SetValue(ref content1, value); }

        private object content2;
        public object Content2 { get => content2; set => SetValue(ref content2, value); }

        public MainViewModel()
        {
            content1 = "View1";
            content2 = "View2";
        }
    }
}
