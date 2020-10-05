using System;
using System.ComponentModel;
using System.Windows.Input;
using MovieDatabase.Domain;
using MovieDatabase.WPF.Peter.Commands;
using MovieDatabase.WPF.Peter.ViewModels;

namespace MovieDatabase.WPF.Peter.State.Navigator
{
    public class Navigator : ObservableObject, INavigator
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

        #region ICommands
        public ICommand UpdateViewModelCommand => new UpdateViewModelCommand(this);
        public ICommand QuitCommand => new QuitCommand();
        public ICommand AboutButtonCommand => new AboutButtonCommand();
        public ICommand HelpButtonCommand => new HelpButtonCommand();
        public ICommand ColeCommand => new ColeCommand();
        #endregion

    }
}