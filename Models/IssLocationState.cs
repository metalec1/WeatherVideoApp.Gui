using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using WeatherVideoApp.Gui.Services;

namespace WeatherVideoApp.Gui.Models;

public partial class IssLocationState : ObservableObject
{   
    [ObservableProperty] public partial DateTime Timestamp { get; set; }
    [ObservableProperty] public partial string Message { get; set; }
    [ObservableProperty] public partial float Latitude { get; set; }
    [ObservableProperty] public partial float Longitude { get; set; }

    private readonly ILogger <IssLocationState> _logger;

    public IssLocationState(IIssClientService issClientService, ILogger<IssLocationState> logger)
    {   
        _logger = logger;
        _logger.LogInformation("IssLocationState initialized");
        _logger.LogInformation("IssLocationState subscribing to IssLocationReceived");
        issClientService.IssLocationReceived += UpdateIssLocationValues;
    }


    public void UpdateIssLocationValues(IssLocationReading issLocationReading)
    {
        Dispatcher.UIThread.Post(() =>
        {   _logger.LogInformation("IssLocationState: sending values to UI thread");
            Timestamp = issLocationReading.Timestamp;
            Message = issLocationReading.Message;
            Latitude = issLocationReading.Latitude;
            Longitude = issLocationReading.Longitude;

        });
    }
    
}