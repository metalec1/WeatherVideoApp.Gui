using System;
using WeatherVideoApp.Gui.Models; 
    
namespace WeatherVideoApp.Gui.Services;

public interface IIssClientService
{
    public event Action<IssLocationReading>? IssLocationReceived;
    public void StartListening();
}