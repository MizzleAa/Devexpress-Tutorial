using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PropertyChangedEvent1.Services;
using PropertyChangedEvent1.Services.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace PropertyChangedEvent1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public AppServices AppServices { get; private set; }
        public AppProcessControls AppProcessControls { get; private set; }
        public AppLoggers AppLoggers { get; private set; }

        public App()
        {
            OnInitialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void OnInitialize()
        {
            InitializeAppLogger();
            InitializeAppServices();
            InitializeAppProcessControls();
        }

        private void InitializeAppServices()
        {
            AppServices = new AppServices();
            //서비스에 종속시킬 하위목록 추가
        }

        private void InitializeAppProcessControls()
        {
            AppProcessControls = new AppProcessControls();
            //프로세스 처리에 종속시킬 하위목록 추가
        }

        private void InitializeAppLogger()
        {
            AppLoggers = new AppLoggers();
            //로거 처리에 종속시킬 하위목록 추가

        }
    }

    /// <summary>
    /// AppServices
    /// </summary>
    public class AppServices
    {
        public IServiceProvider Services { get; }

        public AppServices() 
        {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //해당 위치에 서비스 동작 및 구성을 추가
            services.TryAddSingleton<ITimerService, TimerService>();
            
            return services.BuildServiceProvider();
        }
    }

    /// <summary>
    /// AppProcessControls
    /// </summary>
    public class AppProcessControls
    {
        public AppProcessControls() 
        {
            ConfigureProcessControls();
        }

        public void ConfigureProcessControls() 
        {
            try
            {
                //해당 위치에 처리할 프로세스에 대한 기준을 정의
                IList<string> prcoessNames = new List<string> { "Sample" };

                Process currentProcess = Process.GetCurrentProcess();
                string absoluteRoot = currentProcess.MainModule.FileName;
                //

                foreach (var name in prcoessNames)
                {
                    Process[] processes = Process.GetProcessesByName(name);
                    processes[0]?.Kill();

                    ProcessStartInfo processStartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = name,
                        WorkingDirectory = absoluteRoot,
                        Verb = "runas"
                    };
                    Process.Start(processStartInfo);
                }
            }
            catch (Exception ex) 
            {
            }
            
        }
    }

    /// <summary>
    /// AppLogger
    /// </summary>
    public class AppLoggers
    {
        public AppLoggers()
        {
            ConfigureAppLoggers();
        }

        public void ConfigureAppLoggers()
        {
            //
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Logger(lc => lc
                            .Filter.ByIncludingOnly(evt => evt.Level == Serilog.Events.LogEventLevel.Information)
                            .WriteTo.File("logs/info-log-.txt", rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: 100_000_000, retainedFileCountLimit: 31))
                        .WriteTo.Logger(lc => lc
                            .Filter.ByIncludingOnly(evt => evt.Level == Serilog.Events.LogEventLevel.Warning)
                            .WriteTo.File("logs/warning-log-.txt", rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: 100_000_000, retainedFileCountLimit: 31))
                        .WriteTo.Logger(lc => lc
                            .Filter.ByIncludingOnly(evt => evt.Level == Serilog.Events.LogEventLevel.Error)
                            .WriteTo.File("logs/error-log-.txt", rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: 100_000_000, retainedFileCountLimit: 31))
                        .CreateLogger();

            Log.Information("initializeLogger - information");
            Log.Warning("initializeLogger - warning");
            Log.Error("initializeLogger - error");
        }
    }
}
