using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
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
        int? _studioId;
        int? _producerId;
        ObservableCollection<Movie> _movies;
        ObservableCollection<Studio> _studios;
        ObservableCollection<Producer> _producers;
        string _message;

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
        public int? StudioId {
            get => _studioId;
            set
            {
                _studioId = value;
                OnPropertyChanged(nameof(Studio));
            }
        }
        public int? ProducerId {
            get => _producerId;
            set
            {
                _producerId = value;
                OnPropertyChanged(nameof(Producer));
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


        public ICommand SaveMovieCommand => new RelayCommand(SaveMovieToDB);

        public MovieViewModel(IDataService<Movie> movieRepo, IDataService<Studio> studioRepo, IDataService<Producer> producerRepo)
        {
            _movieRepo = movieRepo;
            _studioRepo = studioRepo;
            _producerRepo = producerRepo;

            Movies = new ObservableCollection<Movie>(_movieRepo.GetAll());
            Studios = new ObservableCollection<Studio>(_studioRepo.GetAll());
            Producers = new ObservableCollection<Producer>(_producerRepo.GetAll());

        }

        void SaveMovieToDB()
        {
            if (Title != "" && Description != "" && ReleaseDate != null && RunTime != null && IMDBLink != "" && ProducerId != null && StudioId != null)
            {
                Movie newMovieToAdd = new Movie();
                newMovieToAdd.Title = _title;
                newMovieToAdd.Description = _description;
                newMovieToAdd.ReleaseDate = (DateTime)_releaseDate;
                newMovieToAdd.Runtime = (int)_runtime;
                newMovieToAdd.IMDBLink = _imdbLink;
                newMovieToAdd.Producer.Id = (int)_producerId;
                newMovieToAdd.Studio.Id = (int)_studioId;
                SaveMovieToDB(newMovieToAdd);
            } else
            {
                _message = "Looks like some fields are not filled in!";
                MessageBox.Show(_message);
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