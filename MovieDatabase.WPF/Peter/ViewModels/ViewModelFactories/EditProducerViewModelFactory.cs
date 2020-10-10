using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class EditProducerViewModelFactory : IMovieDatabaseViewModelFactory<EditProducerViewModel>
    {
        IDataService<Producer> _producerRepo;
        Producer _selectedProducer;

        public EditProducerViewModelFactory(IDataService<Producer> producerRepo, Producer selectedProducer)
        {
            _selectedProducer = selectedProducer;
            _producerRepo = producerRepo;
        }

        public EditProducerViewModel CreateViewModel()
        {
            return new EditProducerViewModel(_producerRepo, _selectedProducer);
        }
    }
}
