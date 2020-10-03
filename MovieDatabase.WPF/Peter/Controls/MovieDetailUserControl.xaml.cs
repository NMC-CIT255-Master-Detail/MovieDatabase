using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MovieDatabase.WPF.Peter.Controls
{
    /// <summary>
    /// Interaction logic for MovieDetailUserControl.xaml
    /// </summary>
    public partial class MovieDetailUserControl : UserControl
    {
        public MovieDetailUserControl()
        {
            InitializeComponent();
        }

        private void IMDB_Link(object sender, RequestNavigateEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = e.Uri.ToString(), //Shocked as hell I figured that out so fast lol
                UseShellExecute = true
            };
            Process.Start(psi);
            e.Handled = true;
        }
    }
}
