﻿using MovieDatabase.WPF.Peter.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.Commands
{
    public class ProducerButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

        }
    }
}
