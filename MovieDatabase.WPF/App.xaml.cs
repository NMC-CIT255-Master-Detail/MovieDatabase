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
using MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories;
using MovieDatabase.WPF.Peter.Views;

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
            IDataService<Movie> movieRepository = serviceProvider.GetService<IDataService<Movie>>();
            IDataService<Studio> studioRepository = serviceProvider.GetService<IDataService<Studio>>();
            IDataService<Producer> producerRepository = serviceProvider.GetService<IDataService<Producer>>();

            Window main = serviceProvider.GetRequiredService<MainWindow>();
            main.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MovieDatabaseDbContextFactory>();
            services.AddSingleton<IDataService<Movie>, MovieRepository>();
            services.AddSingleton<IDataService<Producer>, GenericDataService<Producer>>();
            services.AddSingleton<IDataService<Studio>, GenericDataService<Studio>>();

            services.AddSingleton<IMovieDatabaseViewModelAbstractFactory, MovieDatabaseViewModelAbstractFactory>();

            services.AddSingleton<IMovieDatabaseViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IMovieDatabaseViewModelFactory<MovieViewModel>, MovieViewModelFactory>();
            services.AddSingleton<IMovieDatabaseViewModelFactory<ProducerViewModel>, ProducerViewModelFactory>();
            services.AddSingleton<IMovieDatabaseViewModelFactory<StudioViewModel>, StudioViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}