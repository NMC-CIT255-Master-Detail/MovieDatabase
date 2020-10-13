using Microsoft.EntityFrameworkCore.Internal;
using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.WPF.Cole.ColeViews;
using MovieDatabase.WPF.Peter.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.WPF.Peter.Commands;
using MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly IMovieDatabaseViewModelAbstractFactory _viewModelFactory;

        public INavigator Navigator { get; set; }
        public ICommand UpdateViewModelCommand { get; }
        public ICommand QuitCommand => new QuitCommand();
        public ICommand AboutButtonCommand => new AboutButtonCommand();
        public ICommand HelpButtonCommand => new HelpButtonCommand();
        public ICommand ColeCommand => new ColeCommand();

        public MainViewModel(INavigator navigator, IMovieDatabaseViewModelAbstractFactory viewModelFactory)
        {
            Navigator = navigator;
            _viewModelFactory = viewModelFactory;
            UpdateViewModelCommand = new UpdateViewModelCommand(navigator, _viewModelFactory);
            UpdateViewModelCommand.Execute(ViewType.Home);
        }
    }
}