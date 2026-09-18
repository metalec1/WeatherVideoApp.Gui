using CommunityToolkit.Mvvm.ComponentModel;
using WeatherVideoApp.Gui.Models;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class IssVideoFeedBackgroundViewModel : ViewModelBase
{
    //[ObservableProperty] public partial string VideoUrl {get; set; }
    [ObservableProperty] public partial IssVideoContentState CurrentIssVideoContentState {get; set; }

    public IssVideoFeedBackgroundViewModel(IssVideoContentState  issVideoContentState)
    {   
        CurrentIssVideoContentState = issVideoContentState;
        //VideoUrl = "https://www.youtube.com/watch?v=0FBiyFpV__g";
        //VideoUrl = "https://www.youtube.com/watch?v=jzkTOu1-BGA";
    }

}