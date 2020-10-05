using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class ProducerViewModelFactory : IMovieDatabaseViewModelFactory<ProducerViewModel>
    {
        public ProducerViewModel CreateViewModel()
        {
            return new ProducerViewModel();
        }
    }
}
