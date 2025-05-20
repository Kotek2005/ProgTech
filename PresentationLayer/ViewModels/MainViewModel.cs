using System.ComponentModel;
using DataLayer;
using LogicLayer;

namespace PresentationLayer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ILogicService _logicService;
        private UsersViewModel _usersViewModel;
        private CatalogViewModel _catalogViewModel;
        private StateViewModel _stateViewModel;

        public MainViewModel()
        {
            try
            {
                // Initialize the database first
                DatabaseInitializer.Initialize();
                
                // Create a new instance of Events_class that uses the database
                var events = new Events_class();
                _logicService = new LogicService(events);
                
                // Initialize ViewModels
                UsersViewModel = new UsersViewModel(_logicService);
                CatalogViewModel = new CatalogViewModel(_logicService);
                StateViewModel = new StateViewModel(_logicService);
            }
            catch (Exception ex)
            {
                // Log the error or show a message to the user
                throw new Exception($"Failed to initialize MainViewModel: {ex.Message}", ex);
            }
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
