using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FleetManager.Services;
using FleetManager.ViewModels;
using FleetManager.Views;

namespace FleetManager;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Wstrzykujemy serwis i przekazujemy go do ViewModelu
            var vehicleService = new JsonVehicleService();
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(vehicleService),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}