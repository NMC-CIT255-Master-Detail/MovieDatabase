using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.State.Navigator
{
    public interface INavigator
    {
        
        public enum ViewType
        {
            Main,
            AddMovie,
            AddProducer,
            AddStudio,
            EditMovie,
            EditProducer,
            EditStudio,
            
        }
        
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateViewModelCommand { get; }
    }
    
}