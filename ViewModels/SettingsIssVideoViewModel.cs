using CommunityToolkit.Mvvm.Input;
using WeatherVideoApp.Gui.Models;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class SettingsIssVideoViewModel : ViewModelBase
{   
    private IssVideoSizeState _issVideoSizeState;
    public SettingsIssVideoViewModel(IssVideoSizeState issVideoSizeState)
    {
        _issVideoSizeState = issVideoSizeState;
    }
    
    [RelayCommand]
    public void VideoBigger()
    {
        _issVideoSizeState.ResizeVideoPlus();
    }
    
    [RelayCommand]
    public void VideoSmaller()
    {
        _issVideoSizeState.ResizeVideoMinus();
    }
}