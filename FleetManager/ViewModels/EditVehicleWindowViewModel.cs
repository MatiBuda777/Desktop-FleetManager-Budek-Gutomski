using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using FleetManager.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FleetManager.ViewModels;

public class EditVehicleWindowViewModel : ViewModelBase
{
    [Reactive] private string NewName { get; set; }
    [Reactive] private string NewRegistrationNumber { get; set; }
    [Reactive] private float NewFuel { get; set; }
    [Reactive] private VehicleStatus NewStatus { get; set; }
    
    public VehicleStatus[] VehicleStatuses { get; } = Enum.GetValues<VehicleStatus>();
    
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }

    public EditVehicleWindowViewModel(Vehicle vehicle)
    {
        SaveCommand = ReactiveCommand.Create(SaveChanges);
        
        NewName = vehicle.Name;
        NewRegistrationNumber = vehicle.RegistrationNumber;
        NewFuel = vehicle.Fuel;
        NewStatus = vehicle.Status;
    }

    private void SaveChanges()
    {
        if (new List<string> { NewName, NewRegistrationNumber }.Any(string.IsNullOrWhiteSpace))
        {
            Console.WriteLine("!----------------! Nazwa i rejestracja pojazdu nie może być pusta!!! !-----------------!");
            return;
        }
        
        
    }
}