using DevExpress.Mvvm;

namespace DocumentLayout1.ViewModels
{
    public class DocumentViewModel : ViewModelBase
    {

        private string sample;
        public string Sample { get => sample; set => SetValue(ref sample, value); }

        public DocumentViewModel() 
        {
        }
    }
}
