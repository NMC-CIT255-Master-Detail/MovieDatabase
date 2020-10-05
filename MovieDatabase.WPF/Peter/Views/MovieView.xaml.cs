using MovieDatabase.Domain.Models;
using MovieDatabase.WPF.Peter.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MovieDatabase.WPF.Peter.Views
{
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView : UserControl
    {
        public MovieView()
        {
            //var movieViewModel = new MovieViewModel(movies);
            //DataContext = movieViewModel;
            InitializeComponent();
        }
    }
}