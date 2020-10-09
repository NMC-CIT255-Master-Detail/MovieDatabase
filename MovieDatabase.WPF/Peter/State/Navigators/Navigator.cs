using System;
using System.ComponentModel;
using System.Windows.Input;
using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.WPF.Peter.Commands;
using MovieDatabase.WPF.Peter.ViewModels;
using MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories;

namespace MovieDatabase.WPF.Peter.State.Navigator
{
    public class Navigator : ObservableCollection, INavigator
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public Navigator(IMovieDatabaseViewModelAbstractFactory viewModelFactory)
        {
            UpdateViewModelCommand = new UpdateViewModelCommand(this, viewModelFactory);
    }

        #region ICommands
        public ICommand UpdateViewModelCommand { get; set; }
        public ICommand QuitCommand => new QuitCommand();
        public ICommand AboutButtonCommand => new AboutButtonCommand();
        public ICommand HelpButtonCommand => new HelpButtonCommand();
        public ICommand ColeCommand => new ColeCommand();
        #endregion

    }
}