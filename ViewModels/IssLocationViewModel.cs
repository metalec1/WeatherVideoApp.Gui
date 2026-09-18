using CommunityToolkit.Mvvm.ComponentModel;
using WeatherVideoApp.Gui.Models;
using WeatherVideoApp.Gui.Services;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class IssLocationViewModel : ViewModelBase 
{
    [ObservableProperty] public partial IssLocationState CurrentIssLocationState { get; set; }

    public IssLocationViewModel(IssLocationState issLocationState)
    {
        CurrentIssLocationState = issLocationState;
    }
}