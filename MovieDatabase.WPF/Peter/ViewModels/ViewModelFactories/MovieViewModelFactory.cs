using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.WPF.Peter.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class MovieViewModelFactory : IMovieDatabaseViewModelFactory<MovieViewModel>
    {
        IDataService<Movie> _movieRepo;
        IDataService<Studio> _studioRepo;
        IDataService<Producer> _producerRepo;

        public MovieViewModelFactory(IDataService<Movie> movieRepo, IDataService<Studio> studioRepo, IDataService<Producer> producerRepo)
        {
            _movieRepo = movieRepo;
            _studioRepo = studioRepo;
            _producerRepo = producerRepo;
        }

        public MovieViewModel CreateViewModel()
        {
            return new MovieViewModel(_movieRepo, _studioRepo, _producerRepo);
        }
    }
}
