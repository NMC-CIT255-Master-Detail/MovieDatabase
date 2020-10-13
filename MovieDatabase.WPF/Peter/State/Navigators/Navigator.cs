using System;
using System.ComponentModel;
using System.Windows.Input;
using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
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

    }
}