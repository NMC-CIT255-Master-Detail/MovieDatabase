using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Seed_Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace MovieDatabase.WPF.Cole.ColeViewModels.ColeViewModel
{
    class ColeViewModel : BaseViewModel
    {

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
                if (_selectedMovie != null)
                {
                    OnPropertyChanged(nameof(SelectedMovie));
                }
            }
        }

        #endregion

        #region Constructor

        public ColeViewModel()
        {
            Movies = new ObservableCollection<Movie>(SeedData.GetAllMovies());
            if (Movies.Any()) SelectedMovie = Movies[0];
        }




        #endregion

        #region Methods



        #endregion


        #region ICommands

        #endregion

    }
}


