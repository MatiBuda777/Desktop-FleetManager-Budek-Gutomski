// (ViewModel dla UserControl)

using FleetManager.Models;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ViewModelBase
{
    public string Name;
    public string RegistrationNumber;
    public float Fuel;
    public VehicleStatus Status;


    public VehicleItemViewModel(Vehicle vehicle)
    {
        Name = vehicle.Name;
        RegistrationNumber = vehicle.RegistrationNumber;
        Fuel = vehicle.Fuel;
        Status = vehicle.Status;
    }
}