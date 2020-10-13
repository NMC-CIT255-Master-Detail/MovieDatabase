using MovieDatabase.Domain.Models;
using MovieDatabase.WPF.Peter.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public interface IMovieDatabaseViewModelAbstractFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
