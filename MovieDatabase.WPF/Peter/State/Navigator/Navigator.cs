using System;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.Commands;

namespace MovieDatabase.WPF.Peter.State.Navigator
{
    public class Navigator : INavigator
    {
        public BaseViewModel CurrentViewModel { get; set; }
        public ICommand UpdateViewModelCommand => new UpdateViewModelCommand(this);
    }
}