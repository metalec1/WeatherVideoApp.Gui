using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherVideoApp.Gui.Models;

public partial class IssVideoContentState : ObservableObject
{
    [ObservableProperty] public partial Uri VideoUrl  {get; set; }

    public IssVideoContentState()
    {
        VideoUrl = new Uri("https://www.youtube.com/watch?v=0FBiyFpV__g");
    }

    public void SetVideoUriTo(string videoUrl)
    {
        VideoUrl = new Uri(videoUrl);
    }

}
