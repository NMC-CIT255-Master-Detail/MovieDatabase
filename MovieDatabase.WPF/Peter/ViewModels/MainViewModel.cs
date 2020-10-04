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
        #region Constructor

        public MainViewModel()
        {
            Movies = new ObservableCollection<Movie>(SeedData.GetAllMovies());
            if (Movies.Any()) SelectedMovie = Movies[0];
        }

        #endregion

        #region Fields

        private Movie _selectedMovie;
        private string _searchString;
        private ObservableCollection<Movie> _movies;
        private Movie _selectedProducer;
        private Movie _selectedStudio;
        private string _minRuntimeText;
        private string _maxRuntimeText;
        private string _errorMessage;

        #endregion

        #region ICommands

        public ICommand ButtonSearchByMovieCommand => new RelayCommand(SearchByMovie);
        public ICommand ButtonSearchByProducerCommand => new RelayCommand(SearchByProducer);

        public ICommand ButtonSearchByStudioCommand => new RelayCommand(SearchByStudio);
        public ICommand ButtonFilterByRuntimeCommand => new RelayCommand(FilterByRuntime);

        public ICommand ButtonSortByCommand => new RelayCommand(new Action<object>(SortBy));

        public ICommand ButtonResetFormCommand => new RelayCommand(ResetForm);

        public ICommand ButtonEditMovieCommand { get; set; }
        public ICommand ButtonDeleteMovieCommand { get; set; }

        public ICommand ButtonQuitCommand => new RelayCommand(QuitApp);

        public ICommand ButtonAboutCommand => new RelayCommand(OpenAboutWindow);

        public ICommand ButtonHelpCommand => new RelayCommand(OpenHelpWindow);

        public ICommand ButtonProducerCommand => new RelayCommand(OpenProducerWindow);

        public ICommand ButtonStudioCommand => new RelayCommand(OpenStudioWindow);

        public ICommand ButtonMovieCommand => new RelayCommand(OpenMovieWindow);

        public ICommand ButtonPeterCommand => new RelayCommand(OpenPeterApp);

        public ICommand ButtonColeCommand => new RelayCommand(OpenColeApp);

        #endregion

        #region Properties

        public INavigator Navigator { get; set; } = new Navigator();
        
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

        private void SearchByMovie()
        {
            if (_searchString != null)
                Movies = new ObservableCollection<Movie>(_movies.Where(m =>
                    m.Title.ToLower().Contains(_searchString.ToLower())));
            else
                _errorMessage = "Sorry, you must type a movie name to search by";
        }

        private void SearchByProducer()
        {
            _errorMessage = "";

            if (_selectedProducer != null)
                try
                {
                    Movies = new ObservableCollection<Movie>(_movies.Where(p =>
                        p.Producer.Name.ToLower().Contains(_selectedProducer.Producer.Name.ToLower().ToString())));
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.ToString();
                    throw;
                }
            else
                _errorMessage = "Sorry, you must select a Producer to search by";
        }

        private void SearchByStudio()
        {
            if (_selectedStudio != null)
                Movies = new ObservableCollection<Movie>(_movies.Where(s =>
                    s.Studio.Name.ToLower().Contains(_selectedStudio.Studio.Name.ToLower().ToString())));
            else
                _errorMessage = "Sorry, you must select a Studio to search by";
        }

        private void FilterByRuntime()
        {
            if (int.TryParse(MinRuntimeText, out var minRuntime) && int.TryParse(MaxRuntimeText, out var maxRuntime))
                Movies = new ObservableCollection<Movie>(_movies.Where(r =>
                    r.Runtime >= minRuntime && r.Runtime <= maxRuntime));
        }

        private void SortBy(object param)
        {
            var sortBy = param.ToString();
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

        private void ResetForm()
        {
            SearchString = "";
            MinRuntimeText = "";
            MaxRuntimeText = "";
            _movies = new ObservableCollection<Movie>(SeedData.GetAllMovies());
            Movies = _movies;
        }

        public void EditMovie(object param)
        {
        }

        public void DeleteMovie(object param)
        {
        }

        private static void QuitApp()
        {
            Environment.Exit(1);
        }

        private static void OpenAboutWindow()
        {
            var about = new About();
            about.ShowDialog();
        }

        private static void OpenHelpWindow()
        {
            var help = new Help();
            help.ShowDialog();
        }

        private static void OpenProducerWindow()
        {
            var prodView = new ProducerView();
            prodView.ShowDialog();
        }

        private static void OpenStudioWindow()
        {
            var studioView = new StudioView();
            studioView.ShowDialog();
        }

        private void OpenMovieWindow()
        {
            var movieView = new MovieView(Movies);
            movieView.ShowDialog();
        }

        private static void OpenPeterApp()
        {
            var main = new MainWindow();
            main.Show();
        }

        private static void OpenColeApp()
        {
            var cole = new ColeWindow();
            cole.Show();
        }

        #endregion
    }
}