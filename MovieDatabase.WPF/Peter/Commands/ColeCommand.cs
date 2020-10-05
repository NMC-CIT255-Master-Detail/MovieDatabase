using MovieDatabase.WPF.Cole.ColeViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.Commands
{
    public class ColeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ColeWindow cole = new ColeWindow();
            cole.Show();
        }
    }
}
