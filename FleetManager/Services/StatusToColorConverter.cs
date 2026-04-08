using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using FleetManager.Models;

namespace FleetManager.Services;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            VehicleStatus.Available => new SolidColorBrush(Color.FromRgb(46, 204, 113)),
            VehicleStatus.InRoute   => new SolidColorBrush(Color.FromRgb(52, 152, 219)),
            VehicleStatus.Service   => new SolidColorBrush(Color.FromRgb(231, 76, 60)),
            _ => Brushes.Gray
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}