using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class MovieViewModelFactory : IMovieDatabaseViewModelFactory<MovieViewModel>
    {
        IDataService<Movie> _movieRepo;

        public MovieViewModelFactory(IDataService<Movie> movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public MovieViewModel CreateViewModel()
        {
            return new MovieViewModel(_movieRepo);
        }
    }
}
