using System;
using System.Windows;
using BLL;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using TRPZ_v27.Services;

namespace TRPZ_v27
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            
            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }
        
        public IServiceProvider ServiceProvider { get; set; }
        public DisplayRootRegistry DisplayRootRegistry { get; } = new DisplayRootRegistry();
        
        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDal();
            serviceCollection.AddBll();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindowViewModel =
                new MainWindowViewModel(ServiceProvider.GetService<ITrainService>(), 
                    ServiceProvider.GetService<ICarriageService>(),
                    ServiceProvider.GetService<ITicketService>(),
                    ServiceProvider.GetService<ISeatService>());
            
            DisplayRootRegistry.ShowModalPresentation(mainWindowViewModel);
            
            Shutdown();
        }
    }
}