using MovieDatabase.Domain.Services;
using MovieDatabase.WPF.Peter.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class MovieDatabaseViewModelAbstractFactory : IMovieDatabaseViewModelAbstractFactory
    {
        private readonly IMovieDatabaseViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IMovieDatabaseViewModelFactory<ProducerViewModel> _producerViewModelFactory;
        private readonly IMovieDatabaseViewModelFactory<MovieViewModel> _movieViewModelFactory;

        public MovieDatabaseViewModelAbstractFactory(IMovieDatabaseViewModelFactory<HomeViewModel> homeViewModelFactory, IMovieDatabaseViewModelFactory<ProducerViewModel> producerViewModelFactory, IMovieDatabaseViewModelFactory<MovieViewModel> movieViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _producerViewModelFactory = producerViewModelFactory;
            _movieViewModelFactory = movieViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.AddMovie:
                    return _movieViewModelFactory.CreateViewModel();
                case ViewType.AddProducer:
                    return _producerViewModelFactory.CreateViewModel();
                case ViewType.AddStudio:
                    return new StudioViewModel();
                case ViewType.EditMovie:
                    return _movieViewModelFactory.CreateViewModel();
                case ViewType.EditProducer:
                    return new ProducerViewModel();
                case ViewType.EditStudio:
                    return new StudioViewModel();
                default:
                    throw new ArgumentException("The View Type does not have a View Model", "viewType");
            }
        }
    }
}
