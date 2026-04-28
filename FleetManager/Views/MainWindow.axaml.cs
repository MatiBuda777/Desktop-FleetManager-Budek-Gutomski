using Avalonia.Controls;
using FleetManager.Models;
using FleetManager.Services;
using FleetManager.ViewModels;

namespace FleetManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(new WindowService());
    }
}