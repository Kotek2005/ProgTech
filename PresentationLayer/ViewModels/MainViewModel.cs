using System.ComponentModel;
using DataLayer;
using LogicLayer;

namespace PresentationLayer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //uses logic layer abstract API
        private readonly ILogicService _logicService; //readonly dziala
        private UsersViewModel _usersViewModel;
        private CatalogViewModel _catalogViewModel;
        private StateViewModel _stateViewModel;

        public MainViewModel() //jest na tyle nullable ze dziala
        {
            try
            {
                DatabaseInitializer.Initialize();

                var events = new Events_class();
                _logicService = new LogicService(events);
                
                UsersViewModel = new UsersViewModel(_logicService);
                CatalogViewModel = new CatalogViewModel(_logicService);
                StateViewModel = new StateViewModel(_logicService);
            }
            catch (Exception ex) //jak cos wywala idk
            {
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
