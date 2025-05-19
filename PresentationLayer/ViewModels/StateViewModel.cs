using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DataLayer;

namespace PresentationLayer.ViewModels
{
    public class StateViewModel : INotifyPropertyChanged
    {
        private readonly IEvents _events;
        private ObservableCollection<StateModel> _inventory;
        private float _currentCash;
        private string _newProductName;
        private int _newProductAmount;

        public StateViewModel(IEvents events)
        {
            _events = events;
            Inventory = new ObservableCollection<StateModel>();
            AddStockCommand = new RelayCommand(AddStock, CanAddStock);
            RefreshState();
        }

        public ObservableCollection<StateModel> Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
                OnPropertyChanged(nameof(Inventory));
            }
        }

        public float CurrentCash
        {
            get => _currentCash;
            set
            {
                _currentCash = value;
                OnPropertyChanged(nameof(CurrentCash));
            }
        }

        public string NewProductName
        {
            get => _newProductName;
            set
            {
                _newProductName = value;
                OnPropertyChanged(nameof(NewProductName));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public int NewProductAmount
        {
            get => _newProductAmount;
            set
            {
                _newProductAmount = value;
                OnPropertyChanged(nameof(NewProductAmount));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddStockCommand { get; }

        private void AddStock()
        {
            _events.Add2State(NewProductName, NewProductAmount);
            RefreshState();
            NewProductName = string.Empty;
            NewProductAmount = 0;
        }

        private bool CanAddStock()
        {
            return !string.IsNullOrWhiteSpace(NewProductName) && NewProductAmount > 0;
        }

        private void RefreshState()
        {
            Inventory.Clear();
            // Get inventory from Events_class
            var inventory = _events.GetAllInventory();
            foreach (var item in inventory)
            {
                Inventory.Add(new StateModel { product = item.Key, amount = item.Value });
            }
            CurrentCash = _events.GetCurrentCash();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 