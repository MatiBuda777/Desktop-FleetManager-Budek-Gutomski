using System.Collections.Generic;
using FleetManager.Models;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<Vehicle> Vehicles { get; set; } = [];
}