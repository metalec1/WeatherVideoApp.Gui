using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherVideoApp.Gui.Models; 
    
namespace WeatherVideoApp.Gui.Services;

public interface IIssClientService
{
    public event Action<IssLocationReading>? IssLocationReceived;
    public Task StartListening(CancellationToken cancellationToken = default);
}