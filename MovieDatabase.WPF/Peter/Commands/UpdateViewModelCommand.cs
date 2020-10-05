using System;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.WPF.Peter.ViewModels;

namespace MovieDatabase.WPF.Peter.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
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
            if (parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Main:
                        _navigator.CurrentViewModel = new MainViewModel();
                        break;
                    case ViewType.AddMovie:
                        _navigator.CurrentViewModel = new MovieViewModel();
                        break;
                    case ViewType.AddProducer:
                        _navigator.CurrentViewModel = new ProducerViewModel();
                        break;
                    case ViewType.AddStudio:
                        _navigator.CurrentViewModel = new StudioViewModel();
                        break;
                    case ViewType.EditMovie:
                        _navigator.CurrentViewModel = new MovieViewModel();
                        break;
                    case ViewType.EditProducer:
                        _navigator.CurrentViewModel = new ProducerViewModel();
                        break;
                    case ViewType.EditStudio:
                        _navigator.CurrentViewModel = new StudioViewModel();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        
    }
}