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
        IDataService<Movie> _movieRepo;
        IDataService<Studio> _studioRepo;
        IDataService<Producer> _producerRepo;
        string _title;
        string _description;
        DateTime? _releaseDate;
        int? _runtime;
        string _imdbLink;
        ObservableCollection<Movie> _movies;
        ObservableCollection<Studio> _studios;
        ObservableCollection<Producer> _producers;
        string _message;
        Producer _selectedProducer;
        Studio _selectedStudio;

        public string Title {
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
        public DateTime? ReleaseDate {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
        public int? RunTime {
            get => _runtime;
            set
            {
                _runtime = value;
                OnPropertyChanged(nameof(RunTime));
            }
        }
        public string IMDBLink {
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


        public ICommand SaveMovieCommand => new RelayCommand(SaveMovieToDB);

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
                Title = _selectedMovie.Title;
                Description = _selectedMovie.Description;
                ReleaseDate = _selectedMovie.ReleaseDate;
                RunTime = _selectedMovie.Runtime;
                SelectedProducer = _selectedMovie.Producer;
                SelectedStudio = _selectedMovie.Studio;
                IMDBLink = _selectedMovie.IMDBLink;
            }

        }

        void SaveMovieToDB()
        {
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                Movie newMovieToAdd = new Movie();
                newMovieToAdd.Title = _title;
                newMovieToAdd.Description = _description;
                newMovieToAdd.ReleaseDate = (DateTime)_releaseDate;
                newMovieToAdd.Runtime = (int)_runtime;
                newMovieToAdd.IMDBLink = _imdbLink;
                newMovieToAdd.ProducerId = _selectedProducer.Id;
                newMovieToAdd.StudioId = _selectedStudio.Id;
                UpdateMovieToDB(newMovieToAdd);
            } else
            {
                if (Title != "")
                {
                    Movie movieToEdit = new Movie();
                    movieToEdit.Title = _title;
                    movieToEdit.Description = _description;
                    movieToEdit.ReleaseDate = (DateTime)_releaseDate;
                    movieToEdit.Runtime = (int)_runtime;
                    movieToEdit.IMDBLink = _imdbLink;
                    movieToEdit.ProducerId = _selectedProducer.Id;
                    movieToEdit.StudioId = _selectedStudio.Id;
                    SaveMovieToDB(movieToEdit);
                }
                else
                {
                    _message = "Looks like some fields are not filled in!";
                    MessageBox.Show(_message);
                }
            }
        }

        private void UpdateMovieToDB(Movie movieToEdit)
        {
            if (movieToEdit != null)
            {
                _movieRepo.Update(_selectedMovie.Id, movieToEdit);
            }
        }

        private void SaveMovieToDB(Movie newMovieToAdd)
        {
            if (newMovieToAdd != null)
            {
                _movieRepo.Create(newMovieToAdd);
            }
            ResetForm();
        }

        private void ResetForm()
        {
            _message = "Added the Movie to the Database";
            MessageBox.Show(_message);
        }
    }
}