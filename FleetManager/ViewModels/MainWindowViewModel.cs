using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using FleetManager.Models;
using FleetManager.Services;
using FleetManager.Views;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };
    private const string FilePath = "Data/vehicles.json";
    private readonly IWindowService _windowService;
    
    public ObservableCollection<Vehicle> Vehicles { get; } = [];
    public Vehicle? SelectedVehicle { get; set; }
    
    public ReactiveCommand<Unit, Unit> EditVehiclesCommand { get; } // to implement
    public ReactiveCommand<Unit, Unit> SaveVehiclesCommand { get; }

    public MainWindowViewModel(IWindowService windowService)
    {
        _windowService = windowService;
        
        LoadVehicles();
        EditVehiclesCommand = ReactiveCommand.Create(EditVehicle);
        SaveVehiclesCommand = ReactiveCommand.Create(SaveVehiclesToJson);
    }

    private void LoadVehicles()
    {
        if (!File.Exists(FilePath))
        {
            Console.Write("Vehicles not found");
            return;
        }

        try
        {
            var jsonData = File.ReadAllText(FilePath);
            var list = JsonSerializer.Deserialize<List<Vehicle>>(jsonData, _options);
            Vehicles.Clear();

            if (list == null) return;
            foreach (var vehicle in list)
            {
                Vehicles.Add(vehicle);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    
    private void EditVehicle()
    {
        try
        {
            if (SelectedVehicle != null) _windowService.OpenEditWindow(SelectedVehicle);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    
    private void SaveVehiclesToJson()
    {
        try
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(Vehicles, _options));
            Console.WriteLine("Vehicles saved to {0}", FilePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}