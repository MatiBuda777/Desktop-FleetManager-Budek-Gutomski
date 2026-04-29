using Avalonia.Controls;
using FleetManager.Models;

namespace FleetManager.Services;

public interface IWindowService
{
    void OpenEditWindow(Vehicle vehicle);
    void Close(Window window);
}