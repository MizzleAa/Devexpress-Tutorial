using Microsoft.Extensions.DependencyInjection;
using CustomService1.Services;
using CustomService1.Services.Interface;
using System;
using System.Windows;

namespace CustomService1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        public App()
        {
            Services = ConfigureServices();
        }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            //
            services.AddSingleton<ICustomDispaterService, CustomDispaterService>();
            //
            //services.AddSingleton<MainWindow>();
            //services.AddSingleton<MainView>();
            //
            //services.AddTransient<MainViewModel>();
            //
            return services.BuildServiceProvider();
        }
    }
}
