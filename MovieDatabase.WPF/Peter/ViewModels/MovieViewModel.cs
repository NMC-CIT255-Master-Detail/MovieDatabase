using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        IDataService<Movie> _movieRepo;

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public string IMDBLink { get; set; }
        public int Studio { get; set; }
        public int Producer { get; set; }


        public ICommand SaveMovieCommand => new RelayCommand(SaveMovieToDB);

        public MovieViewModel(IDataService<Movie> movieRepo)
        {
            _movieRepo = movieRepo;
            Title = "";
        }

        void SaveMovieToDB()
        {
            var title = Title;
        }


    }
}