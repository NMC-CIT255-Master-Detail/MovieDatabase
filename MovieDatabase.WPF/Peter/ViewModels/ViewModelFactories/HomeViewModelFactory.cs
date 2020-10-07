using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class HomeViewModelFactory : IMovieDatabaseViewModelFactory<HomeViewModel>
    {
        public GenericDataService<Movie> movie { get; set; }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}
