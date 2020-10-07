using Microsoft.EntityFrameworkCore.Internal;
using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Seed_Data;
using MovieDatabase.WPF.Cole.ColeViews;
using MovieDatabase.WPF.Peter.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.State.Navigator;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateViewModelCommand.Execute(ViewType.Home);\

        }
    }
}