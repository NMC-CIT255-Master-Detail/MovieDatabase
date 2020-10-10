using MovieDatabase.Domain.Models;
using MovieDatabase.WPF.Peter.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.Commands
{
    public class SelectedMovieCommand : ICommand
    {
        Movie _selectedMovie;
        HomeViewModel _viewModel;

        public SelectedMovieCommand(Movie selectedMovie, HomeViewModel viewModel)
        {
            _selectedMovie = selectedMovie;
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _selectedMovie = _viewModel.SelectedMovie;

        }
    }
}
