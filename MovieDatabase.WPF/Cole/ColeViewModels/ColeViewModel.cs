﻿using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Seed_Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MovieDatabase.EntityFramework.Services;


namespace MovieDatabase.WPF.Cole.ColeViewModels.ColeViewModel
{
    public class ColeViewModel : BaseViewModel
    {
        #region Constructor

        private MovieRepository _movieRepo;

        public ColeViewModel()
        {
            Movies = new ObservableCollection<Movie>(SeedData.GetAllMovies());
            if (Movies.Any()) SelectedMovie = Movies[0];

        }

        #endregion

        #region Fields

        private ObservableCollection<Movie> _movies;

        private Movie _selectedMovie;
        private Movie _selectedProducer;
        private Movie _selectedStudio;

        private string _searchString;
        private string _minRuntimeText;
        private string _maxRuntimeText;
        private string _errorMessage;

       


        #endregion

        #region Properties



        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                if (_selectedMovie != null) OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }

        public Movie SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        public Movie SelectedStudio
        {
            get => _selectedStudio;
            set
            {
                _selectedStudio = value;
                OnPropertyChanged(nameof(SelectedStudio));
            }
        }

        public string MinRuntimeText
        {
            get => _minRuntimeText;
            set
            {
                _minRuntimeText = value;
                OnPropertyChanged(nameof(MinRuntimeText));
            }
        }

        public string MaxRuntimeText
        {
            get => _maxRuntimeText;
            set
            {
                _maxRuntimeText = value;
                OnPropertyChanged(nameof(MaxRuntimeText));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }




        #endregion

        #region Methods

        public void SearchByMovie()
        {
            if (_searchString != null)
            {
                Movies = new ObservableCollection<Movie>(_movies.Where(m => m.Title.ToLower().Contains(_searchString.ToLower())));
            }
            else
            {
                _errorMessage = "Sorry, you must type a movie name to search by";
            }
        }

        public void SearchByProducer()
        {
            _errorMessage = "";

            if (_selectedProducer != null)
            {
                try
                {
                    Movies = new ObservableCollection<Movie>(_movies.Where(p => p.Producer.Name.ToLower().Contains(_selectedProducer.Producer.Name.ToLower().ToString())));
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.ToString();
                    throw;
                }
            }
            else
            {
                _errorMessage = "Sorry, select a Producer to search by";
            }
        }

        public void SearchByStudio()
        {
            if (_selectedStudio != null)
            {
                Movies = new ObservableCollection<Movie>(_movies.Where(s => s.Studio.Name.ToLower().Contains(_selectedStudio.Studio.Name.ToLower().ToString())));
            }
            else
            {
                _errorMessage = "Sorry, select a Studio to search by";
            }
        }

        public void FilterByRuntime()
        {

            if (int.TryParse(MinRuntimeText, out int minRuntime) && int.TryParse(MaxRuntimeText, out int maxRuntime))
            {
                Movies = new ObservableCollection<Movie>(_movies.Where(r => r.Runtime >= minRuntime && r.Runtime <= maxRuntime));
            }
        }

        public void SortBy(object param)
        {
            string sortBy = param.ToString();
            switch (sortBy)
            {
                case "Producer":
                    Movies = new ObservableCollection<Movie>(Movies.OrderBy(p => p.Producer.Name));
                    break;
                case "Studio":
                    Movies = new ObservableCollection<Movie>(Movies.OrderBy(s => s.Studio.Name));
                    break;
                case "Year":
                    Movies = new ObservableCollection<Movie>(Movies.OrderBy(y => y.ReleaseDate.Date));
                    break;
                default:
                    break;
            }
        }

        public void ResetForm()
        {
            SearchString = "";
            MinRuntimeText = "";
            MaxRuntimeText = "";
            _movies = new ObservableCollection<Movie>(SeedData.GetAllMovies());
            Movies = _movies;
        }

        public void DeleteMovie(object param)
        {
                         

        }

        public void AddMovie(object param)
        {


        }

        public void EditMovie(object param)
        {


        }



        #endregion

        #region ICommands

        //Search Buttons
        public ICommand ButtonSearchByMovieCommand => new RelayCommand(SearchByMovie);
        public ICommand ButtonSearchByProducerCommand => new RelayCommand(SearchByProducer);
        public ICommand ButtonSearchByStudioCommand => new RelayCommand(SearchByStudio);
        public ICommand ButtonFilterByRuntimeCommand => new RelayCommand(FilterByRuntime);
        public ICommand ButtonSortByCommand => new RelayCommand(new Action<object>(SortBy));
        public ICommand ButtonResetFormCommand => new RelayCommand(ResetForm);

        // Edit, Delete, and Add buttons
        public ICommand ButtonEditMovieCommand { get; set; }
        public ICommand ButtonDeleteMovieCommand { get; set; }



        #endregion


    }
}