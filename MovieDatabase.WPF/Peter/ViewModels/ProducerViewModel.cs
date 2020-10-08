using MovieDatabase.Domain;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class ProducerViewModel : BaseViewModel
    {
        public ICommand SaveButtonCommand => new RelayCommand(SaveButton);

        public ProducerViewModel()
        {

        }

        void SaveButton()
        {

        }
    }
}