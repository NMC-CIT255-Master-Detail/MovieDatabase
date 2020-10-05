using System.Windows;
using MovieDatabase.WPF.Peter;
using MovieDatabase.WPF.Peter.ViewModels;
using MovieDatabase.WPF.Peter.State.Navigator;

namespace MovieDatabase.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window main = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            main.Show();
            base.OnStartup(e);
        }
    }
}