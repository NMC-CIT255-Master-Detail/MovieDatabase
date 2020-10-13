using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework;
using MovieDatabase.EntityFramework.Services;
using MovieDatabase.WPF.Cole.ColeViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Cole.ColeViewModels.ColeViewModel
{
    public class ColeViewModel : BaseViewModel
    {

        #region Fields

        private ObservableCollection<Movie> _movies;
        
        private readonly IDataService<Movie> _movieRepo;


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

        #region Constructor

        public ColeViewModel()
        {
            _movieRepo = new MovieRepository(new MovieDatabaseDbContextFactory());
            //_studioRepo = new GenericDataService<Studio>(new MovieDatabaseDbContextFactory());
            //_producerRepo = new GenericDataService<Producer>(new MovieDatabaseDbContextFactory());
            Movies = new ObservableCollection<Movie>(_movieRepo.GetAll());

            if (Movies.Any()) SelectedMovie = Movies[0];
        }

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
            _movies = new ObservableCollection<Movie>(_movieRepo.GetAll());
            Movies = _movies;
        }

        private void DeleteMovie()
        {
            if (SelectedMovie != null)
            {
                if (_movieRepo.Delete(SelectedMovie.Id))
                {
                    Movies = new ObservableCollection<Movie>(_movieRepo.GetAll());
                    SelectedMovie = Movies[0];
                    _message = "Movie Deleted";
                    MessageBox.Show(_message);
                }
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

        void SaveMovieToDB()
        {
            if (Title != "" && Description != "" && ReleaseDate != null && RunTime != null && IMDBLink != "" && ProducerId != "" && StudioId != "")
            {
                Movie newMovieToAdd = new Movie();
                newMovieToAdd.Title = _title;
                newMovieToAdd.Description = _description;
                newMovieToAdd.ReleaseDate = (DateTime)_releaseDate;
                newMovieToAdd.Runtime = (int)_runtime;
                newMovieToAdd.IMDBLink = _imdbLink;
                newMovieToAdd.Producer.Id = _selectedProducer.Id;
                newMovieToAdd.Studio.Id = int.Parse(_studioId);
                SaveMovieToDB(newMovieToAdd);
            }
            else
            {
                _message = "Some fields are not filled in!";
                MessageBox.Show(_message);
            }

        }

        public void AddMovie()
        {
            ColeAddEditMovie MovieAdd = new ColeAddEditMovie();
            MovieAdd.Show();



            //Movie NewAddMovie = new Movie();
            //NewAddMovie.Title = _title;
            //NewAddMovie.Description = _description;
            //NewAddMovie.ReleaseDate = (DateTime)_releaseDate;
            //NewAddMovie.Runtime = (int)_runtime;
            //NewAddMovie.Producer = _producerId;
            //NewAddMovie.Studio = _studioId

            //_movieRepo.Create(NewAddMovie);
            //_movieRepo.Update(_selectedMovie.Id, NewAddMovie);

        }


        //public void EditMovie(object param)
        //{


        //}


        #endregion

        #region ICommands

        //Search Buttons
        public ICommand ButtonSearchByMovieCommand => new RelayCommand(SearchByMovie);
        public ICommand ButtonSearchByProducerCommand => new RelayCommand(SearchByProducer);
        public ICommand ButtonSearchByStudioCommand => new RelayCommand(SearchByStudio);
        public ICommand ButtonFilterByRuntimeCommand => new RelayCommand(FilterByRuntime);
        public ICommand ButtonSortByCommand => new RelayCommand(new Action<object>(SortBy));
        public ICommand ButtonResetFormCommand => new RelayCommand(ResetForm);

        public ICommand SaveMovieCommand => new RelayCommand(SaveMovieToDB);



        // Edit, Delete, and Add buttons
        public ICommand ButtonEditMovieCommand { get; set; }
        public ICommand DeleteMovieCommand => new RelayCommand(DeleteMovie);



        #endregion

    }
}