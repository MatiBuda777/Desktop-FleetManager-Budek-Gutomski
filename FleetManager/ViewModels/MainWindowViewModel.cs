using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.Json;
using FleetManager.Models;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Vehicle> Vehicles { get; set; } = [];
    private const string FilePath = "Assets/Vehicles.json";
    
    public ReactiveCommand<Unit, Unit> AddVehiclesCommand { get; } // to implement
    public ReactiveCommand<Unit, Unit> SaveVehiclesCommand { get; }

    public MainWindowViewModel()
    {
        LoadVehicles();
        AddVehiclesCommand = ReactiveCommand.Create(EditVehicleWindowViewModel);
        SaveVehiclesCommand = ReactiveCommand.Create(SaveVehiclesToJson);
    }

    private void LoadVehicles()
    {
        if (!File.Exists(FilePath)) return;

        try
        {
            var jsonData = File.ReadAllText(FilePath);
            var list = JsonSerializer.Deserialize<List<Vehicle>>(jsonData);
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