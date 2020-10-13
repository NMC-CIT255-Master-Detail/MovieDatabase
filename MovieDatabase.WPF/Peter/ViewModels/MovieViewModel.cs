using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.WPF.Peter.Commands;
using MovieDatabase.WPF.Peter.State.Navigator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {

        #region Fields

        string _title;
        string _description;
        string _message;
        int? _runtime;
        string _imdbLink;
        DateTime? _releaseDate;
        ObservableCollection<Movie> _movies;
        ObservableCollection<Studio> _studios;
        ObservableCollection<Producer> _producers;
        Producer _selectedProducer;
        Studio _selectedStudio;
        IDataService<Movie> _movieRepo;
        IDataService<Studio> _studioRepo;
        IDataService<Producer> _producerRepo;

        #endregion

        #region Properties

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
        public int? RunTime
        {
            get => _runtime;
            set
            {
                _runtime = value;
                OnPropertyChanged(nameof(RunTime));
            }
        }
        public string IMDBLink
        {
            get => _imdbLink;
            set
            {
                _imdbLink = value;
                OnPropertyChanged(nameof(IMDBLink));
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        private int _studioId;
        public int StudioId
        {
            get
            {
                return _studioId;
            }
            set
            {
                _studioId = value;
                OnPropertyChanged(nameof(StudioId));
            }
        }

        private int _producerId;
        public int ProducerId
        {
            get
            {
                return _producerId;
            }
            set
            {
                _producerId = value;
                OnPropertyChanged(nameof(ProducerId));
            }
        }

        public ObservableCollection<Studio> Studios
        {
            get => _studios;
            set
            {
                _studios = value;
                OnPropertyChanged(nameof(Studios));
            }
        }

        public ObservableCollection<Producer> Producers
        {
            get => _producers;
            set
            {
                _producers = value;
                OnPropertyChanged(nameof(Producers));
            }
        }

        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        public Studio SelectedStudio
        {
            get => _selectedStudio;
            set
            {
                _selectedStudio = value;
                OnPropertyChanged(nameof(SelectedStudio));
            }
        }

        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        #endregion

        #region ICommands

        public ICommand SaveMovieCommand => new RelayCommand(SaveMovieToDB);
        public ICommand ResetFormCommand => new RelayCommand(ResetForm);

        #endregion

        #region Constructor

        public MovieViewModel(IDataService<Movie> movieRepo, IDataService<Studio> studioRepo, IDataService<Producer> producerRepo)
        {
            _movieRepo = movieRepo;
            _studioRepo = studioRepo;
            _producerRepo = producerRepo;

            Movies = new ObservableCollection<Movie>(_movieRepo.GetAll());
            Studios = new ObservableCollection<Studio>(_studioRepo.GetAll());
            Producers = new ObservableCollection<Producer>(_producerRepo.GetAll());
            _selectedMovie = HomeViewModel.Selection;

            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                _selectedMovie = HomeViewModel.Selection;
                SetSelectedData();
            }
        }

        #endregion

        #region Methods

        void SaveMovieToDB()
        {
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                if (Title != "" && Description != "" && ReleaseDate != null && RunTime != null && IMDBLink != "")
                {

                }
                Movie newMovieToAdd = new Movie() 
                {
                    Title = _title,
                    Description = _description,
                    ReleaseDate = (DateTime)_releaseDate,
                    Runtime = (int)_runtime,
                    IMDBLink = _imdbLink,
                    ProducerId = _selectedProducer.Id,
                    StudioId = _selectedStudio.Id
                };
                UpdateMovieToDB(newMovieToAdd);
            }
            else
            {
                if (Title != "" && Description != "" && ReleaseDate != null && RunTime != null && IMDBLink != "")
                {
                    Movie movieToEdit = new Movie() 
                    {
                        Title = _title,
                        Description = _description,
                        ReleaseDate = (DateTime)_releaseDate,
                        Runtime = (int)_runtime,
                        IMDBLink = _imdbLink,
                        ProducerId = _selectedProducer.Id,
                        StudioId = _selectedStudio.Id
                };
                    SaveMovieToDB(movieToEdit);
                }
                else
                {
                    _message = "Looks like some fields are not filled in!";
                    string title = "Blank Fields ERROR";
                    MessageBox.Show(_message, title);
                }
            }
        }

        private void UpdateMovieToDB(Movie movieToEdit)
        {
            if (movieToEdit != null)
            {
                _movieRepo.Update(_selectedMovie.Id, movieToEdit);
                ResetFormAfterAdd();
            }
        }

        private void SaveMovieToDB(Movie newMovieToAdd)
        {
            if (newMovieToAdd != null)
            {
                _movieRepo.Create(newMovieToAdd);
                ResetFormAfterAdd();
            }
        }

        private void ResetFormAfterAdd()
        {
            ResetData();
            _message = "Successfully Added/Updated the Movie to the Database";
            string title = "SUCCESS";
            MessageBox.Show(_message, title);
        }

        void ResetForm()
        {
            string title = "Reset Form";
            string message = "Are you sure you want to reset the form?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.Yes)
            {
                if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
                {
                    SetSelectedData();
                }
                else
                {
                    ResetData();
                }
            }
        }

        void SetSelectedData()
        {
            Title = _selectedMovie.Title;
            Description = _selectedMovie.Description;
            ReleaseDate = _selectedMovie.ReleaseDate;
            RunTime = _selectedMovie.Runtime;
            SelectedProducer = _selectedMovie.Producer; // Ask John about why this doesn't work
            SelectedStudio = _selectedMovie.Studio; // Ask John about why this doesn't work
            IMDBLink = _selectedMovie.IMDBLink;
        }

        void ResetData()
        {
            Title = "";
            Description = "";
            ReleaseDate = new DateTime?();
            RunTime = null;
            SelectedProducer = null;
            SelectedStudio = null;
            IMDBLink = "";
        }
        #endregion

    }
}