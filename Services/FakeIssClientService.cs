using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using WeatherVideoApp.Gui.Models;


namespace WeatherVideoApp.Gui.Services;

public class FakeIssClientService : IIssClientService
{
    public event Action<IssLocationReading>? IssLocationReceived;
    private readonly ILogger<FakeIssClientService> _logger;
    
    public FakeIssClientService(ILogger<FakeIssClientService> logger)
    {
        _logger = logger;
    }
    
    
    public async Task StartListening(CancellationToken cancellationToken = default)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Random rand = new Random();
            float latitude = (float)(rand.NextDouble()* 180 - 90);
            float longitude = (float)(rand.NextDouble()* 360 - 180);
        
            var locationReading = new IssLocationReading(
                DateTime.Now,
                "Success",
                latitude, 
                longitude
            );
            
            _logger.LogInformation("Generated fake ISS reading: {Reading}", locationReading);   
            IssLocationReceived?.Invoke(locationReading);
            
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        }
        
    }
}