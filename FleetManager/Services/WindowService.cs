using Avalonia.Controls;
using FleetManager.Models;
using FleetManager.ViewModels;
using FleetManager.Views;

namespace FleetManager.Services;

public class WindowService : IWindowService
{
    public void OpenEditWindow(Vehicle vehicle)
    {
        var window = new EditVehicleWindow
        {
            DataContext = new EditVehicleWindowViewModel(vehicle)
        };

        window.Show();
    }

    public void Close(Window window)
    {
        window.Close();
    }
}