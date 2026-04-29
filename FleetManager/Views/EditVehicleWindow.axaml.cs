using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FleetManager.ViewModels;

namespace FleetManager.Views;

public partial class EditVehicleWindow : Window
{
    public EditVehicleWindow()
    {
        InitializeComponent();
        
        if (DataContext is EditVehicleWindowViewModel vm)
        {
            vm.AttachWindow(this);
        }
    }
}