using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WeatherVideoApp.Gui.Models;
using Grpc.Core;
using Grpc.Net.Client;


namespace WeatherVideoApp.Gui.Services;

public class IssClientService : IIssClientService
{   
    
    private GrpcChannel _channel;
    private IssLocationService.IssLocationServiceClient _client;
    
    public event Action<IssLocationReading>? IssLocationReceived;
    private readonly ILogger<IssClientService> _logger;
    
    public IssClientService(ILogger<IssClientService> logger, string grpcServerAddress = "http://localhost:5279")
    {
        _logger = logger;
        _channel = GrpcChannel.ForAddress(grpcServerAddress);
        _client = new IssLocationService.IssLocationServiceClient(_channel);
    }
    
    
    public async Task StartListening(CancellationToken cancellationToken = default)
    {  
        _logger.LogInformation("Real ISS client started");
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                using var call = _client.SubscribeToIssLocation(new IssLocationUpdateRequest { Name = "Gui" }, cancellationToken: cancellationToken);

                await foreach (var update in call.ResponseStream.ReadAllAsync(cancellationToken))
                {
                      
                
                    var locationReading = new IssLocationReading(
                        update.Timestamp.ToDateTime(),
                        update.Message,
                        update.Latitude, 
                        update.Longitude
                    );
                    
                    _logger.LogInformation("Generated ISS reading: {Reading}", locationReading);   
                    IssLocationReceived?.Invoke(locationReading);
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _logger.LogWarning("Server ni dosegljiv, poskušam znova čez 3s...");
            }
            catch (RpcException ex)
            {
                _logger.LogError(ex, "gRPC napaka, poskušam znova čez 3s...");
            }

            await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
        }
    }
}