using MovieDatabase.Domain.Models;
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
        private readonly IMovieDatabaseViewModelFactory<StudioViewModel> _studioViewModelFactory;

        public MovieDatabaseViewModelAbstractFactory(IMovieDatabaseViewModelFactory<HomeViewModel> homeViewModelFactory, IMovieDatabaseViewModelFactory<ProducerViewModel> producerViewModelFactory, IMovieDatabaseViewModelFactory<MovieViewModel> movieViewModelFactory, IMovieDatabaseViewModelFactory<StudioViewModel> studioViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _producerViewModelFactory = producerViewModelFactory;
            _movieViewModelFactory = movieViewModelFactory;
            _studioViewModelFactory = studioViewModelFactory;
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
                    return _studioViewModelFactory.CreateViewModel();
                case ViewType.EditMovie:
                    return _movieViewModelFactory.CreateViewModel();
                case ViewType.EditProducer:
                    return _producerViewModelFactory.CreateViewModel();
                case ViewType.EditStudio:
                    return _studioViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("The View Type does not have a View Model", "viewType");
            }
        }
    }
}
