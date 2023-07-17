using DevExpress.Mvvm;

namespace NavigationFrame1.ViewModels
{
    public class ViewModel3 : ViewModelBase
    {

        private object mainViewNavigationTo = "MainView";

        public object MainViewNavigationTo { get => mainViewNavigationTo; set => SetValue(ref mainViewNavigationTo, value); }

        private object view1NavigationTo = "View1";

        public object View1NavigationTo { get => view1NavigationTo; set => SetValue(ref view1NavigationTo, value); }

        private object view2NavigationTo = "View2";

        public object View2NavigationTo { get => view2NavigationTo; set => SetValue(ref view2NavigationTo, value); }

        private object view3NavigationTo = "View3";

        public object View3NavigationTo { get => view3NavigationTo; set => SetValue(ref view3NavigationTo, value); }
    }
}
