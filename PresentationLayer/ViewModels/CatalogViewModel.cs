using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DataLayer;

namespace PresentationLayer.ViewModels
{
    public class CatalogViewModel : INotifyPropertyChanged
    {
        private readonly IEvents _events;
        private ObservableCollection<ProductModel> _products;
        private string _newProductName;
        private float _newProductPrice;

        public CatalogViewModel(IEvents events)
        {
            _events = events;
            Products = new ObservableCollection<ProductModel>();
            AddProductCommand = new RelayCommand(AddProduct, CanAddProduct);
            RefreshProducts();
        }

        public ObservableCollection<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
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

        public float NewProductPrice
        {
            get => _newProductPrice;
            set
            {
                _newProductPrice = value;
                OnPropertyChanged(nameof(NewProductPrice));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddProductCommand { get; }

        private void AddProduct()
        {
            _events.Add2Cat(NewProductName, NewProductPrice);
            RefreshProducts();
            NewProductName = string.Empty;
            NewProductPrice = 0;
        }

        private bool CanAddProduct()
        {
            return !string.IsNullOrWhiteSpace(NewProductName) && NewProductPrice > 0;
        }

        private void RefreshProducts()
        {
            // This is a placeholder - in a real implementation, you would get the products from the database
            Products.Clear();
            // Add some sample products for now
            Products.Add(new ProductModel { name = "Apple", price = 2.50f });
            Products.Add(new ProductModel { name = "Banana", price = 3.40f });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 