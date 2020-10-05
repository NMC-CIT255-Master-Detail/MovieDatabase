using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public interface IMovieDatabaseViewModelFactory<T> where T : BaseViewModel
    {
        T CreateViewModel();
    }
}
