using MovieDatabase.Domain.Models;
using MovieDatabase.WPF.Peter.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace MovieDatabase.WPF.Peter.Views
{
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {

        public MovieView(ObservableCollection<Movie> movies)
        {
            MovieViewModel movieViewModel = new MovieViewModel(movies);
            DataContext = movieViewModel;
            InitializeComponent();
        }
    }
}
