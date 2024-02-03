using DevExpress.Mvvm.ModuleInjection;
using ModuleInjectionFramework1.Common;
using ModuleInjectionFramework1.Modules.Views;
using System.Windows;
using AppModules = ModuleInjectionFramework1.Common.Modules;

namespace ModuleInjectionFramework1.App
{
    public partial class App : Application
    {
        protected IModuleManager Manager { get { return ModuleManager.DefaultManager; } }

        public App()
        {
            RegisterModules();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        protected virtual void RegisterModules()
        {
            //Manager.Register(Regions.Navigation, new Module(AppModules.Module1, () => new NavigationItem("Module1")));
            //Manager.Register(Regions.Navigation, new Module(AppModules.Module2, () => new NavigationItem("Module2")));
            Manager.Register(Regions.Documents, new Module(AppModules.Module1, () => ModuleViewModel.Create("Module1"), typeof(ModuleView)));
            Manager.Register(Regions.Documents, new Module(AppModules.Module2, () => ModuleViewModel.Create("Module2"), typeof(ModuleView)));
        }
    }
}
