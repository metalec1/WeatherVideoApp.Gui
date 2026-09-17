using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}
