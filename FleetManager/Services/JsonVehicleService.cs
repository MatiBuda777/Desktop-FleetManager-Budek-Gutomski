using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public class JsonVehicleService : IVehicleService
{
    private readonly string _filePath = "Assets/vehicles.json";

    public async Task<IEnumerable<Vehicle>> LoadVehiclesAsync()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return new List<Vehicle>();
            }

            using var stream = File.OpenRead(_filePath);
            
            var options = new JsonSerializerOptions 
            { 
                Converters = { new JsonStringEnumConverter() } 
            };
            
            var vehicles = await JsonSerializer.DeserializeAsync<IEnumerable<Vehicle>>(stream, options);
            return vehicles ?? new List<Vehicle>();
        }
        catch (Exception)
        {
            return new List<Vehicle>();
        }
    }

    public async Task SaveVehiclesAsync(IEnumerable<Vehicle> vehicles)
    {
        try
        {
            var options = new JsonSerializerOptions 
            { 
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, vehicles, options);
        }
        catch (Exception)
        {
        }
    }
}