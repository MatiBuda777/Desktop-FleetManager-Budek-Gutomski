using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FleetManager.Models;

public class Vehicle : ReactiveObject
{
    [Reactive] public string Name { get; set; } = string.Empty;
    [Reactive] public string RegistrationNumber { get; set; } = string.Empty;
    [Reactive] public float Fuel { get; set; } = 0;
    [Reactive] public VehicleStatus Status { get; set; } = VehicleStatus.Service;
}