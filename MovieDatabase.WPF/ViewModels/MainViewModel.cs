using Microsoft.EntityFrameworkCore.Internal;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Seed_Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Text;

namespace MovieDatabase.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Movie _selectedMovie;

        public ObservableCollection<Movie> Movies { get; set; }
        
        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                if(_selectedMovie != null)
                {
                    OnPropertyChanged(nameof(SelectedMovie));
                }
            }
        }

        public MainViewModel()
        {
            Movies = new ObservableCollection<Movie>(SeedData.GetAllMovies());
            if (Movies.Any()) SelectedMovie = Movies[0];
        }

    }
}
