using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Seed_Data;
using MovieDatabase.EntityFramework.Services;
using System.Collections.ObjectModel;
using System.Linq;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework;

namespace MovieDatabase.WPF.Cole.ColeViewModels.ColeViewModel
{
    public class ColeViewModel : BaseViewModel
    {
        #region Constructor
        private readonly IDataService<Movie> _movieRepo;
        private MovieDatabaseDBContext _context;
        public ColeViewModel()
        {
            _movieRepo = new MovieRepository(new MovieDatabaseDbContextFactory());
            Movies = new ObservableCollection<Movie>(_movieRepo.GetAll());
            if (Movies.Any()) SelectedMovie = Movies[0];
        }

        #endregion

        #region Fields

        private ObservableCollection<Movie> _movies;
        private Movie _selectedMovie;

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

        #endregion

        #region Methods

        #endregion

        #region ICommands

        #endregion
    }
}