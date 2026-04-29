using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using FleetManager.Models;
using FleetManager.Services;
using FleetManager.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FleetManager.ViewModels;

public class EditVehicleWindowViewModel : ViewModelBase
{
    private readonly IWindowService _windowService;
    private Window _window;
    
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
        
        
        
        _windowService.Close(_window);
    }

    public void AttachWindow(Window window)
    {
        _window = window;
    }
}