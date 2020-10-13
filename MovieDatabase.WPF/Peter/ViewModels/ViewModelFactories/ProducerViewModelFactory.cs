using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.WPF.Peter.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class ProducerViewModelFactory : IMovieDatabaseViewModelFactory<ProducerViewModel>
    {
        IDataService<Producer> _producerRepo;

        public ProducerViewModelFactory(IDataService<Producer> producerRepo)
        {
            _producerRepo = producerRepo;
        }

        public ProducerViewModel CreateViewModel()
        {
            return new ProducerViewModel(_producerRepo);
        }
    }
}
