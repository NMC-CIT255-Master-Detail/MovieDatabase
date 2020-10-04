using System;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.WPF.Peter.ViewModels;

namespace MovieDatabase.WPF.Peter.Commands
{
    public class UpdateViewModelCommand : ICommand
    {

        private INavigator _navigator;

        public UpdateViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is INavigator.ViewType viewType)) return;
            switch (viewType)
            {
                case INavigator.ViewType.Main:
                    _navigator.CurrentViewModel = new MainViewModel();
                    break;
                case INavigator.ViewType.AddMovie:
                    _navigator.CurrentViewModel = new MovieViewModel();
                    break;
                case INavigator.ViewType.AddProducer:
                    break;
                case INavigator.ViewType.AddStudio:
                    break;
                case INavigator.ViewType.EditMovie:
                    break;
                case INavigator.ViewType.EditProducer:
                    break;
                case INavigator.ViewType.EditStudio:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}