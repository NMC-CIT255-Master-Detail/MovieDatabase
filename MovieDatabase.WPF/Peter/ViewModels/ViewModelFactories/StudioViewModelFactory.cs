using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class StudioViewModelFactory : IMovieDatabaseViewModelFactory<StudioViewModel>
    {
        IDataService<Studio> _studioRepo;

        public StudioViewModelFactory(IDataService<Studio> studioRepo)
        {
            _studioRepo = studioRepo;
        }

        public StudioViewModel CreateViewModel()
        {
            return new StudioViewModel(_studioRepo);
        }
    }
}
