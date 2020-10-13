using System;
using System.Windows;
using System.Windows.Input;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework;
using MovieDatabase.EntityFramework.Services;
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
                switch (viewType)
                {
                    case ViewType.EditMovie:
                    case ViewType.EditProducer:
                    case ViewType.EditStudio:
                        HomeViewModel.ActionToTake = HomeViewModel.Action.EDIT;
                        break;
                    case ViewType.AddMovie:
                    case ViewType.AddProducer:
                    case ViewType.AddStudio:
                        HomeViewModel.ActionToTake = HomeViewModel.Action.ADD;
                        break;
                }

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}