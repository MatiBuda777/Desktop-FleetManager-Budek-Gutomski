using System.Reactive;
using ReactiveUI;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ViewModelBase
{
    public Vehicle Vehicle { get; }

    // Komendy
    public ReactiveCommand<Unit, Unit> RefuelCommand { get; }
    public ReactiveCommand<Unit, Unit> DispatchCommand { get; }
    public ReactiveCommand<Unit, Unit> ServiceCommand { get; }
    public ReactiveCommand<Unit, Unit> MakeAvailableCommand { get; }

    public VehicleItemViewModel(Vehicle vehicle)
    {
        Vehicle = vehicle;

        // Walidacja: Blokada tankowania, gdy pojazd jest InRoute
        var canRefuel = this.WhenAnyValue(
            x => x.Vehicle.Status,
            status => status != VehicleStatus.InRoute
        );

        // Walidacja: Blokada wysyłki w trasę, gdy paliwo < 15% lub status to Service
        var canDispatch = this.WhenAnyValue(
            x => x.Vehicle.Status,
            x => x.Vehicle.Fuel,
            (status, fuel) => status != VehicleStatus.Service && fuel >= 15.0f
        );

        // Inicjalizacja komend
        RefuelCommand = ReactiveCommand.Create(() => 
        { 
            Vehicle.Fuel = 100f; 
        }, canRefuel);

        DispatchCommand = ReactiveCommand.Create(() => 
        { 
            Vehicle.Status = VehicleStatus.InRoute; 
        }, canDispatch);

        ServiceCommand = ReactiveCommand.Create(() => 
        { 
            Vehicle.Status = VehicleStatus.Service; 
        });

        MakeAvailableCommand = ReactiveCommand.Create(() => 
        { 
            Vehicle.Status = VehicleStatus.Available; 
        });
    }
}