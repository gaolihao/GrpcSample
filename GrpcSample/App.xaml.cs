using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Hosting;

namespace GrpcSample;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
public partial class App : Application
{
    public event EventHandler Loaded;

    public static IHost AppHost { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindowViewModel = new MainViewModel();
        var mainWindow = new MainWindow
        {
            DataContext = mainWindowViewModel
        };

        MainWindow = mainWindow;
        MainWindow.Show();

    }

    public static T GetViewModelInstance<T>()
    {
        _ = AppHost ?? throw new InvalidOperationException("Host not initialized");
        var res = AppHost.Services.GetService<T>();
        if (res == null)
        {
            string error = $"DI: Error occurred loading {typeof(T).Name} in Noviview version: {Assembly.GetEntryAssembly()!.GetName().Version}";
            MessageBox.Show(error, "Error");
            throw new InvalidOperationException(error);
        }
        return res;
    }
}
