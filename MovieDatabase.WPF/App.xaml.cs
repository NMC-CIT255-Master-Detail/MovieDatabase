using System.Windows;
using MovieDatabase.WPF.Peter;
using MovieDatabase.WPF.Peter.ViewModels;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.Domain.Services;
using MovieDatabase.Domain.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieDatabase.EntityFramework.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.EntityFramework;

namespace MovieDatabase.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            IServiceProvider serviceProvider = CreateServiceProvider();


            Window main = new MainWindow();
            main.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            main.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MovieDatabaseDbContextFactory>();
            services.AddSingleton<IDataService<Movie>, GenericDataService<Movie>>();
            services.AddSingleton<IDataService<Producer>, GenericDataService<Producer>>();
            services.AddSingleton<IDataService<Studio>, GenericDataService<Studio>>();

            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}