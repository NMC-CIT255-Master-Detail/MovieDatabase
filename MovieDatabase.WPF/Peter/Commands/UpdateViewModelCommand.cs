using System;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.WPF.Peter.ViewModels;
using MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories;
using Renci.SshNet;

namespace MovieDatabase.WPF.Peter.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private readonly INavigator _navigator;
        private readonly IMovieDatabaseViewModelAbstractFactory _viewModelFactory;

        public UpdateViewModelCommand(INavigator navigator, IMovieDatabaseViewModelAbstractFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }

        
    }
}