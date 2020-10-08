using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.EntityFramework.Services;

namespace MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories
{
    public class HomeViewModelFactory : IMovieDatabaseViewModelFactory<HomeViewModel>
    {
        private IDataService<Movie> _movieRepository;
        private IDataService<Studio> _studioRepository;
        private IDataService<Producer> _producerRepository;

        public HomeViewModelFactory(IDataService<Movie> movieRepository, IDataService<Studio> studioRepository, IDataService<Producer> producerRepository)
        {
            _movieRepository = movieRepository;
            _studioRepository = studioRepository;
            _producerRepository = producerRepository;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_movieRepository, _studioRepository, _producerRepository);
        }
    }
}
