using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using DataLayer.Repositories;
using DataLayer.Models;
using LogicLayer;

namespace PresentationLayer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _service;
        public ObservableCollection<Product> Products { get; set; }

        public MainViewModel(IProductRepository productRepository)
        {
            _service = new ProductService(productRepository);
            Products = new ObservableCollection<Product>();
            LoadProductsAsync().ConfigureAwait(false);
        }

        private async Task LoadProductsAsync()
        {
            var products = await _service.LoadProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
