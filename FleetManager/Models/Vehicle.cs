using ReactiveUI;

namespace FleetManager.Models;

public class Vehicle : ReactiveObject
{
    private string _name = string.Empty;
    public string Name 
    { 
        get => _name; 
        set => this.RaiseAndSetIfChanged(ref _name, value); 
    }

    private string _registrationNumber = string.Empty;
    public string RegistrationNumber 
    { 
        get => _registrationNumber; 
        set => this.RaiseAndSetIfChanged(ref _registrationNumber, value); 
    }

    private float _fuel;
    public float Fuel 
    { 
        get => _fuel; 
        set => this.RaiseAndSetIfChanged(ref _fuel, value); 
    }

    private VehicleStatus _status;
    public VehicleStatus Status 
    { 
        get => _status; 
        set => this.RaiseAndSetIfChanged(ref _status, value); 
    }
}