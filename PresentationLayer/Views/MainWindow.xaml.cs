using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PresentationLayer.ViewModels;
using DataLayer;
using LogicLayer;

namespace PresentationLayer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        try
        {
            // Initialize the database first
            DatabaseInitializer.Initialize();
            
            // Then initialize the component
            InitializeComponent();
            
            // Get the logic service from ServiceLocator and create MainViewModel
            ILogicService logicService = ServiceLocator.GetLogicService();
            DataContext = new MainViewModel(logicService);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing application: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}