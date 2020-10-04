﻿using MovieDatabase.WPF.Peter.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.State.Navigator
{
    public enum ViewType
    {
        Main,
        AddMovie,
        AddProducer,
        AddStudio,
        EditMovie,
        EditProducer,
        EditStudio,

    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateViewModelCommand { get; }
    }
    
}