using Avalonia.Controls;
using FleetManager.Models;
using FleetManager.ViewModels;

namespace FleetManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var vm = new MainWindowViewModel();
        vm.EditRequested += OnEditRequested;
        DataContext = vm;
    }

    private async void OnEditRequested(Vehicle v)
    {
        var vm = new EditVehicleWindowViewModel(v);
        var win = new EditVehicleWindow(vm);
        await win.ShowDialog(this);
    }
}