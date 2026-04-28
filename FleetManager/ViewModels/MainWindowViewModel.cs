using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FleetManager.Services;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IVehicleService _vehicleService;
    
    public ObservableCollection<VehicleItemViewModel> Vehicles { get; } = new();

    // Konstruktor bezparametrowy dla Designera (Avalonia)
    public MainWindowViewModel() 
    {
        _vehicleService = new JsonVehicleService();
        _ = LoadVehiclesAsync();
    }

    public MainWindowViewModel(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
        _ = LoadVehiclesAsync();
    }

    private async Task LoadVehiclesAsync()
    {
        try
        {
            var vehicles = await _vehicleService.LoadVehiclesAsync();
            Vehicles.Clear();
            
            foreach (var vehicle in vehicles)
            {
                Vehicles.Add(new VehicleItemViewModel(vehicle));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd ładowania: {ex.Message}");
        }
    }
}