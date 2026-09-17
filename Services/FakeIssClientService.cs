using System;
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

    public void StartListening()
    {   
        _logger.LogInformation("Fake ISS client started");
        _ = Task.Run(async () =>
        {
            Random rand = new Random();
            
            while (true)
            {   
                await Task.Delay(1000); 
                float latitude = (float)(rand.NextDouble()* 180 - 90);
                float longitude = (float)(rand.NextDouble()* 360 - 180);
                
                var locationReading = new IssLocationReading(
                    DateTime.Now,
                    "Success",
                    latitude, 
                    longitude
                );
                
                _logger.LogDebug("Generated fake ISS reading: {Reading}", locationReading);   
                IssLocationReceived?.Invoke(locationReading);
            }
        });
    }
}