using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieDatabase.WPF.Controls
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
