using CommunityToolkit.Mvvm.ComponentModel;
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
    [ObservableProperty] public partial string Video1ButtonContent { get; set; }
    [ObservableProperty] public partial string Video2ButtonContent { get; set; }
    [ObservableProperty] public partial string Video3ButtonContent { get; set; }
    [ObservableProperty] public partial bool Video1ButtonIsActive { get; set; }
    [ObservableProperty] public partial bool Video2ButtonIsActive { get; set; }
    [ObservableProperty] public partial bool Video3ButtonIsActive { get; set; }
    
    private string _watching = "Viewing";
    private string _notWatching = "Watch it!";

    public SettingsIssVideoViewModel(IssVideoSizeState issVideoSizeState, IssVideoContentState  issVideoContentState)
    {
        _issVideoSizeState = issVideoSizeState;
        _issVideoContentState = issVideoContentState;
        Video1ButtonContent = _watching;
        Video2ButtonContent = _notWatching;
        Video3ButtonContent = _notWatching;
        Video1ButtonIsActive = true;
        Video2ButtonIsActive = false;
        Video3ButtonIsActive = false;
    }

    private void ClearButtonContentAndActiveState()
    {
        Video1ButtonContent = _notWatching;
        Video2ButtonContent = _notWatching;
        Video3ButtonContent = _notWatching;
        Video1ButtonIsActive = false;
        Video2ButtonIsActive = false;
        Video3ButtonIsActive = false;
        
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
        ClearButtonContentAndActiveState();
        Video1ButtonContent = _watching;
        Video1ButtonIsActive = true;
    }
    
    [RelayCommand]
    public void Video2()
    {   
        _issVideoContentState.SetVideoUriTo(_video2Url);
        ClearButtonContentAndActiveState();
        Video2ButtonContent = _watching;
        Video2ButtonIsActive = true;
    }
    
    [RelayCommand]
    public void Video3()
    {   
        _issVideoContentState.SetVideoUriTo(_video3Url);
        ClearButtonContentAndActiveState();
        Video3ButtonContent = _watching;
        Video3ButtonIsActive = true;
    }
}