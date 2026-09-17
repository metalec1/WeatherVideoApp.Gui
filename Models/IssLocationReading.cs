using System;

namespace WeatherVideoApp.Gui.Models;

public record IssLocationReading
{
    public DateTime Timestamp { get; init; }
    public string Message { get; init; }
    public float Latitude { get; init; }
    public float Longitude { get; init; }

    public IssLocationReading(DateTime timestamp, string message, float latitude, float longitude)
    {
        Timestamp = timestamp;
        Message = message;
        Latitude = latitude;
        Longitude = longitude;
            
    }
}