using CommunityToolkit.Mvvm.Input;
using WeatherVideoApp.Gui.Models;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class SettingsIssVideoViewModel : ViewModelBase
{   
    private IssVideoSizeState _issVideoSizeState;
    private IssVideoContentState _issVideoContentState;
    private string _video1Url = "https://www.youtube.com/watch?v=0FBiyFpV__g";
    private string _video2Url = "https://www.youtube.com/watch?v=tj4knR4r1UU";
    private string _video3Url = "https://www.youtube.com/watch?v=jzkTOu1-BGA";
    
    public SettingsIssVideoViewModel(IssVideoSizeState issVideoSizeState, IssVideoContentState  issVideoContentState)
    {
        _issVideoSizeState = issVideoSizeState;
        _issVideoContentState = issVideoContentState;
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

    [RelayCommand]
    public void Video1()
    {   
        _issVideoContentState.SetVideoUriTo(_video1Url);
    }
    
    [RelayCommand]
    public void Video2()
    {   
        _issVideoContentState.SetVideoUriTo(_video2Url);
    }
    
    [RelayCommand]
    public void Video3()
    {   
        _issVideoContentState.SetVideoUriTo(_video3Url);
    }
}