using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WeatherVideoApp.Gui.Models;

public partial class IssVideoSizeState : ObservableObject
{
    [ObservableProperty] public partial int VideoWidth {get; set; }
    [ObservableProperty] public partial int VideoHeight {get; set; }
    [ObservableProperty] public partial int VideoColumn {get; set; }
    [ObservableProperty] public partial int VideoRow {get; set; }
    
   

    public IssVideoSizeState()
    {
        VideoHeight = 3;
        VideoWidth = 4;
        VideoColumn = 6;
        VideoRow = 5;
    }

    public void ResizeVideoPlus()
    {
        if (VideoWidth < 9 && VideoHeight < 8)
        {
            VideoWidth +=  1;
            VideoHeight += 1;
            VideoColumn -= 1;
            VideoRow -= 1;
        }
        
        
    }
    
    
    public void ResizeVideoMinus()
    {   
        if (VideoWidth > 4 && VideoHeight > 3)
        {
            VideoWidth -=  1;
            VideoHeight -= 1;
            VideoColumn += 1;
            VideoRow += 1;
        }
        
    }
}