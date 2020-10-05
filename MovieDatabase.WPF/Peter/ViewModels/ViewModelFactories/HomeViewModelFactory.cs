using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class HomeViewModelFactory : IMovieDatabaseViewModelFactory<HomeViewModel>
    {
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}
