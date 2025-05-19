using System.ComponentModel;
using DataLayer;

namespace PresentationLayer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IEvents _events;
        private UsersViewModel _usersViewModel;
        private CatalogViewModel _catalogViewModel;
        private StateViewModel _stateViewModel;

        public MainViewModel()
        {
            // Create a new instance of Events_class that uses the database
            _events = new Events_class();
            
            // Initialize ViewModels
            UsersViewModel = new UsersViewModel(_events);
            CatalogViewModel = new CatalogViewModel(_events);
            StateViewModel = new StateViewModel(_events);
        }

        public UsersViewModel UsersViewModel
        {
            get => _usersViewModel;
            set
            {
                _usersViewModel = value;
                OnPropertyChanged(nameof(UsersViewModel));
            }
        }

        public CatalogViewModel CatalogViewModel
        {
            get => _catalogViewModel;
            set
            {
                _catalogViewModel = value;
                OnPropertyChanged(nameof(CatalogViewModel));
            }
        }

        public StateViewModel StateViewModel
        {
            get => _stateViewModel;
            set
            {
                _stateViewModel = value;
                OnPropertyChanged(nameof(StateViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
