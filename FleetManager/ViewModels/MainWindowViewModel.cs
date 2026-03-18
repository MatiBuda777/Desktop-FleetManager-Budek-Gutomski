using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive.Linq;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Vehicle> Vehicles { get; set; } = [];
    private const string FilePath = "Assets/Vehicles.json";

    public MainWindowViewModel()
    {
        loadVehicles();
    }

    private void loadVehicles()
    {
        if (!File.Exists(FilePath)) return;
    }
}