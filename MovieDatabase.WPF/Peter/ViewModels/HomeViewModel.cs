using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework.Services;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MovieDatabase.WPF.Peter.Commands;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Enums
        
        public enum Action
        {
            ADD,
            EDIT
        }

        #endregion

        #region Fields

        string _searchString;
        ObservableCollection<Movie> _movies;
        ObservableCollection<Producer> _producers;
        ObservableCollection<Studio> _studios;
        Producer _selectedProducer;
        Studio _selectedStudio;
        Movie _selectedMovie;
        string _minRuntimeText;
        string _maxRuntimeText;
        IDataService<Producer> _producerSet;
        IDataService<Studio> _studioSet;
        IDataService<Movie> _movieSet;

        #endregion

        #region Properties

        public static Action ActionToTake { get; set; }
        public static Movie Selection { get; set; }

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
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

        public ObservableCollection<Studio> Studios
        {
            get => _studios;
            set
            {
                _studios = value;
                OnPropertyChanged(nameof(Studios));
            }
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                if (_selectedMovie != null) OnPropertyChanged(nameof(SelectedMovie));
                Selection = SelectedMovie;
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

        #endregion

        #region ICommands

        public ICommand ButtonSearchByMovieCommand => new RelayCommand(SearchByMovie);
        public ICommand ButtonSearchByProducerCommand => new RelayCommand(SearchByProducer);
        public ICommand ButtonSearchByStudioCommand => new RelayCommand(SearchByStudio);
        public ICommand ButtonFilterByRuntimeCommand => new RelayCommand(FilterByRuntime);
        public ICommand ButtonSortByCommand => new RelayCommand(new Action<object>(SortBy));
        public ICommand ButtonResetFormCommand => new RelayCommand(ResetForm);
        public ICommand DeleteMovieCommand => new RelayCommand(DeleteMovie);

        #endregion

        #region Constructor

        public HomeViewModel(IDataService<Movie> movieRepo, IDataService<Studio> studioRepo, IDataService<Producer> producerRepo)
        {
            _movieSet = movieRepo;
            _studioSet = studioRepo;
            _producerSet = producerRepo;
            Movies = new ObservableCollection<Movie>(_movieSet.GetAll());
            Studios = new ObservableCollection<Studio>(_studioSet.GetAll());
            Producers = new ObservableCollection<Producer>(_producerSet.GetAll());

            if (Movies.Any()) SelectedMovie = Movies[0];
        }

        #endregion

        #region Methods

        private void SearchByMovie()
        {
            if ( _searchString != null)
            {
                try
                {
                    Movies = new ObservableCollection<Movie>(_movies.Where(m => 
                        m.Title.ToLower().Contains(_searchString.ToLower())));
                }
                catch (Exception ex)
                {
                    string message = "Looks like something went wrong " + ex;
                    string title = "ERROR";
                    MessageBox.Show(message, title);
                }
            } 
            else
            {
                string message = "You must enter some text first!";
                string title = "ERROR";
                MessageBox.Show(message, title);
            }
            

        }

        private void SearchByProducer()
        {
            if (_selectedProducer != null)
            {
                try
                {
                    Movies = new ObservableCollection<Movie>(_movies.Where(p =>
                        p.Producer.Name.ToLower().Contains(_selectedProducer.Name.ToLower().ToString())));
                }
                catch (Exception ex)
                {
                    string message = "Looks like something went wrong" + ex;
                    string title = "ERROR";
                    MessageBox.Show(message, title);
                    throw;
                }
            }
            else
            {
                string message = "You must select a Producer First!";
                string title = "ERROR";
                MessageBox.Show(message, title);
            }
            
        }

        private void SearchByStudio()
        {
            if (_selectedStudio != null)
            {
                try
                {
                    Movies = new ObservableCollection<Movie>(_movies.Where(s =>
                        s.Studio.Name.ToLower().Contains(_selectedStudio.Name.ToLower().ToString())));
                }
                catch (Exception ex)
                {
                    string message = "Looks like something went wrong " + ex;
                    string title = "ERROR";
                    MessageBox.Show(message, title);
                }
            } 
            else
            {
                string message = "You must select a Studio First!";
                string title = "ERROR";
                MessageBox.Show(message, title);
            }
            
        }

        private void FilterByRuntime()
        {
            if (_maxRuntimeText != null && _minRuntimeText != null)
            {
                if (int.TryParse(MinRuntimeText, out var minRuntime) && int.TryParse(MaxRuntimeText, out var maxRuntime))
                    Movies = new ObservableCollection<Movie>(_movies.Where(r =>
                        r.Runtime >= minRuntime && r.Runtime <= maxRuntime));
            }
            else
            {
                string message = "You must enter a MIN and a MAX runtime as NUMBERS first!";
                string title = "ERROR";
                MessageBox.Show(message, title);
            }
            
        }

        private void SortBy(object param)
        {
            var sortBy = param.ToString();
            switch (sortBy)
            {
                case "Producer":
                    Movies = new ObservableCollection<Movie>(_movies.OrderBy(p => p.Producer.Name));
                    break;
                case "Studio":
                    Movies = new ObservableCollection<Movie>(_movies.OrderBy(s => s.Studio.Name));
                    break;
                case "Year":
                    Movies = new ObservableCollection<Movie>(_movies.OrderBy(y => y.ReleaseDate.Date));
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
            SelectedProducer = null;
            SelectedStudio = null;

            Movies = new ObservableCollection<Movie>(_movieSet.GetAll());
        }

        private void DeleteMovie()
        {
            if (SelectedMovie != null)
            {
                string message = "Are you sure you want to DELETE the Movie?";
                string title = "Confirm Deletion";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons);

                if (result == MessageBoxResult.Yes)
                {
                    if (_movieSet.Delete(SelectedMovie.Id))
                    {
                        Movies = new ObservableCollection<Movie>(_movieSet.GetAll());
                        SelectedMovie = Movies[0];
                        string messageSuccess = "Movie Successfully Deleted";
                        string titleSuccess = "SUCCESS";
                        MessageBox.Show(messageSuccess, titleSuccess);
                    }
                } 
            }
        }

        #endregion

    }
}
