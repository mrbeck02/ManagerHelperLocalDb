using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TeamStatistics.CsvImporter;
using TeamStatistics.DAL;
using TeamStatistics.Data;
using TeamStatistics.ViewModels;

namespace TeamStatistics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// Help from: https://executecommands.com/dependency-injection-in-wpf-net-core-csharp/
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            configureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void configureServices(ServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite("Data Source=c:\\Temp\\mydb.db");
                options.LogTo(Console.WriteLine);
            });

            services.AddScoped<IStatisticsCsvReader, StatisticsCsvReader>();
            services.AddScoped<IDesignTimeDbContextFactory<DataContext>, DesignTimeDataContextFactory>();
            services.AddScoped<IDbContextFactory<DataContext>, DataContextFactory>();
            services.AddScoped<IStatisticsCsvImporter, StatisticsCsvImporter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMainViewModel, MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
