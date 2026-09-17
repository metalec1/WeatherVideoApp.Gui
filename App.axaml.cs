using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WeatherVideoApp.Gui.Models;
using WeatherVideoApp.Gui.Services;
using WeatherVideoApp.Gui.ViewModels;
using WeatherVideoApp.Gui.Views;

namespace WeatherVideoApp.Gui;

public partial class App : Application
{
    private bool _debug = true;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {   
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var serviceCollection = new ServiceCollection();
        if (_debug)
        {
            serviceCollection.AddSingleton<IIssClientService, FakeIssClientService>();
        }
        else
        {
            //serviceCollection.AddSingleton<IIssClientService, IssClientService>(); // yet to create and implement
        }
        
        serviceCollection.AddSingleton<IssLocationState>();
        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddSingleton<IssVideoFeedBackgroundViewModel>();
        serviceCollection.AddSingleton<SettingsIssVideoViewModel>();
        serviceCollection.AddSingleton<IssVideoSizeState>();
        serviceCollection.AddLogging(builder => builder.AddSerilog());
        var serviceProvider = serviceCollection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}