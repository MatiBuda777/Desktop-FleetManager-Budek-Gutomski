using Avalonia.Reactive;
using FleetManager.ViewModels;
using ReactiveUI.Avalonia;

namespace FleetManager.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}