using System.Collections.ObjectModel;
using System.ComponentModel;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ProductService _service;
    public ObservableCollection<Product> Products { get; set; }

    public MainViewModel()
    {
        string connStr = @"Data Source=.;Initial Catalog=ShopDatabase;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
        var repo = new ProductRepository(connStr);
        _service = new ProductService(repo);

        Products = new ObservableCollection<Product>(_service.LoadProducts());
    }

    // Tu dodasz RelayCommand, Add/Delete itd.
    public event PropertyChangedEventHandler PropertyChanged;
}
