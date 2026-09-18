using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WeatherVideoApp.Gui.Models;

public partial class IssVideoContentState : ObservableObject
{
    [ObservableProperty] public partial Uri VideoUrl  {get; set; }

    public IssVideoContentState()
    {
        VideoUrl = new Uri("https://www.youtube.com/watch?v=jzkTOu1-BGA");
    }

    public void SetVideoUriTo(string videoUrl)
    {
        VideoUrl = new Uri(videoUrl);
    }

}
