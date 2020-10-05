using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class MovieViewModelFactory : IMovieDatabaseViewModelFactory<MovieViewModel>
    {
        public MovieViewModel CreateViewModel()
        {
            return new MovieViewModel();
        }
    }
}
