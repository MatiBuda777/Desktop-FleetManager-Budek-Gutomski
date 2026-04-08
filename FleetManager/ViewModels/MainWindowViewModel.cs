using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text.Json;
using System.Text.Json.Serialization;
using FleetManager.Models;
using FleetManager.Services;
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
    private readonly IVehicleService _vehicleService;
    
    public ObservableCollection<Vehicle> Vehicles { get; } = [];
    
    public ReactiveCommand<Unit, Unit> AddVehiclesCommand { get; } // to implement
    public ReactiveCommand<Unit, Unit> SaveVehiclesCommand { get; }

    public MainWindowViewModel()
    {
        LoadVehicles();
        //AddVehiclesCommand = ReactiveCommand.Create(EditVehicleWindowViewModel);
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

    private void SaveVehiclesToJson()
    {
        try
        {
            var jsonData = JsonSerializer.Serialize(Vehicles);
            File.WriteAllText(FilePath, jsonData);
            Console.WriteLine("Vehicles saved to {0}", FilePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}