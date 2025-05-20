using System.Configuration;
using System.Data;
using System.Windows;
using PresentationLayer.ViewModels;

namespace PresentationLayer;
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainViewModel = new MainViewModel(ServiceLocator.GetLogicService());
        var mainWindow = new MainWindow
        {
            DataContext = mainViewModel
        };
        mainWindow.Show();
    }
}

