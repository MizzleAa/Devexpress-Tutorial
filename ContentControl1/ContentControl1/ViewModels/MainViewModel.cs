using DevExpress.Mvvm;
using System;
using System.Windows.Input;

namespace ContentControl1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private object mainViewRegion;

        public object MainViewRegion { get => mainViewRegion; set => SetValue(ref mainViewRegion, value); }

        private DelegateCommand view1Command;
        public ICommand View1Command => view1Command ??= new DelegateCommand(View1);

        private void View1()
        {
            MainViewRegion = "View1";
        }

        private DelegateCommand view2Command;
        public ICommand View2Command => view2Command ??= new DelegateCommand(View2);

        private void View2()
        {
            MainViewRegion = "View2";
        }
    }
}
