using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework;
using MovieDatabase.EntityFramework.Services;
using MovieDatabase.WPF.Peter.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Cole.ColeViewModels
{
    class ColeEditViewModel : BaseViewModel
    {

        #region Fields

        private ObservableCollection<Movie> _movies;
        private ObservableCollection<Producer> _producers;
        private ObservableCollection<Studio> _studios;

        readonly IDataService<Movie> _movieRepo;
        readonly IDataService<Studio> _studioRepo;
        readonly IDataService<Producer> _producerRepo;

        private Movie _selectedMovie;
        private Movie _selectedProducer;
        private Movie _selectedStudio;
        Producer _theProducer;
        Studio _theStudio;

        private string _searchString;
        private string _minRuntimeText;
        private string _maxRuntimeText;
        private string _errorMessage;

        string _message;
        string _title;
        string _description;
        string _imdbLink;
        string _studioId;
        string _producerId;
        DateTime? _releaseDate;
        int? _runtime;


        #endregion

        #region Properties

        public ObservableCollection<Studio> Studios
        {
            get
            {
                return _studios;
            }
            set
            {
                _studios = value;
                OnPropertyChanged(nameof(Studios));
            }
        }
        public ObservableCollection<Producer> Producers
        {
            get
            {
                return _producers;
            }
            set
            {
                _producers = value;
                OnPropertyChanged(nameof(Producers));
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
        public string StudioId
        {
            get => _studioId;
            set
            {
                _studioId = value;
                OnPropertyChanged(nameof(Studio));
            }
        }
        public string ProducerId
        {
            get => _producerId;
            set
            {
                _producerId = value;
                OnPropertyChanged(nameof(Producer));
            }
        }

        public Producer TheProducer
        {
            get => _theProducer;
            set
            {
                _theProducer = value;
                OnPropertyChanged(nameof(TheProducer));
            }
        }

        public Studio TheStudio
        {
            get => _theStudio;
            set
            {
                _theStudio = value;
                OnPropertyChanged(nameof(TheStudio));
            }
        }

        #endregion

        #region Constructor

        public ColeEditViewModel()        
        {
            _movieRepo = new MovieRepository(new MovieDatabaseDbContextFactory());
            _studioRepo = new GenericDataService<Studio>(new MovieDatabaseDbContextFactory());
            _producerRepo = new GenericDataService<Producer>(new MovieDatabaseDbContextFactory());

            Movies = new ObservableCollection<Movie>(_movieRepo.GetAll());
            Producers = new ObservableCollection<Producer>(_producerRepo.GetAll());
            Studios = new ObservableCollection<Studio>(_studioRepo.GetAll());
            _selectedMovie = ColeViewModel.ColeViewModel.Selection;

            Title = _selectedMovie.Title;
            Description = _selectedMovie.Description;
            ReleaseDate = _selectedMovie.ReleaseDate;
            RunTime = _selectedMovie.Runtime;
            IMDBLink = _selectedMovie.IMDBLink;
            TheProducer = _selectedMovie.Producer;
            TheStudio = _selectedMovie.Studio;
        }



        #endregion

        #region ICommand

        public ICommand SaveMovieCommand => new RelayCommand(SaveMovieToDB);

        public ICommand ResetFormCommand => new RelayCommand(ResetForm);

        #endregion

        #region Methods

        void SaveMovieToDB()
        {                        
                if (Title != "")
                {
                    Movie movieToEdit = new Movie()
                    {
                        Title = _title,
                        Description = _description,
                        ReleaseDate = (DateTime)_releaseDate,
                        Runtime = (int)_runtime,
                        IMDBLink = _imdbLink,
                        ProducerId = _theProducer.Id,
                        StudioId = _theStudio.Id
                    };
                    UpdateMovieToDB(movieToEdit);
                }
                else
                {
                    _message = "Some fields are not filled in!";
                    string title = "Blank Fields ERROR";
                    MessageBox.Show(_message, title);
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
            string message = "You want to reset the form?";
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
            TheProducer = _selectedMovie.Producer; // Ask John about why this doesn't work
            TheStudio = _selectedMovie.Studio; // Ask John about why this doesn't work
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
