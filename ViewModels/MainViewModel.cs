using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherVideoApp.Gui.Models;

namespace WeatherVideoApp.Gui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
    [ObservableProperty] public partial ViewModelBase BackgroundViewModel { get; set; }
    [ObservableProperty] public partial ViewModelBase CurrentViewModel { get; set; }
    [ObservableProperty] public partial int BackgroundGridRow { get; set; }
    [ObservableProperty] public partial int BackgroundGridColumn { get; set; }
    [ObservableProperty] public partial int BackgroundGridColumnSpan { get; set; }
    [ObservableProperty] public partial int BackgroundGridRowSpan { get; set; }
    [ObservableProperty] public partial int CurrentViewGridRow { get; set; }
    [ObservableProperty] public partial int CurrentViewGridColumn { get; set; }
    [ObservableProperty] public partial int CurrentViewGridColumnSpan { get; set; }
    [ObservableProperty] public partial int CurrentViewGridRowSpan { get; set; }

    private readonly int _issVideoFeedGridColumnSpan = 4;
    private readonly int _issVideoFeedGridRowSpan = 3;
    private readonly int _issVideoFeedGridRow = 2;
    private readonly int _issVideoFeedGridColumn = 2;
    
    private readonly int _issVideoFeedSettingsGridColumnSpan = 10;
    private readonly int _issVideoFeedSettingsGridRowSpan = 7;
    private readonly int _issVideoFeedSettingsGridRow = 1;
    private readonly int _issVideoFeedSettingsGridColumn = 0;
    
    private readonly int _issVideoFeedInformationGridColumnSpan = 10;
    private readonly int _issVideoFeedInformationGridRowSpan = 7;
    private readonly int _issVideoFeedInformationGridRow = 1;
    private readonly int _issVideoFeedInformationGridColumn = 0;
    
    private readonly int _programInformationBackgroundGridColumnSpan = 10;
    private readonly int _programInformationBackgroundGridRowSpan = 7;
    private readonly int _programInformationBackgroundGridRow = 1;
    private readonly int _programInformationBackgroundGridColumn = 0;
    
    private readonly int _programInformationGridColumnSpan = 10;
    private readonly int _programInformationGridRowSpan = 7;
    private readonly int _programInformationGridRow = 1;
    private readonly int _programInformationGridColumn = 0;
    private ViewModelBase _issVideoFeedBackgroundViewModel;
    private ViewModelBase _settingsIssVideoViewModel;
    [ObservableProperty] public partial IssVideoSizeState CurrentIssVideoSizeState { get; set; }


    public MainViewModel(IssVideoFeedBackgroundViewModel issVideoFeedBackgroundViewModel, SettingsIssVideoViewModel settingsIssVideoViewModel, IssVideoSizeState  issVideoSizeState)
    {
        _issVideoFeedBackgroundViewModel =  issVideoFeedBackgroundViewModel;
        BackgroundViewModel = _issVideoFeedBackgroundViewModel;
       // BackgroundGridRow = _issVideoFeedGridRow;
        //BackgroundGridColumn = _issVideoFeedGridColumn;
        //BackgroundGridColumnSpan = _issVideoFeedGridColumnSpan;
        //BackgroundGridRowSpan = _issVideoFeedGridRowSpan;
        _settingsIssVideoViewModel = settingsIssVideoViewModel;
        CurrentViewModel = null;
        CurrentIssVideoSizeState =  issVideoSizeState;
        CurrentIssVideoSizeState.PropertyChanged += UpdateVideoSize;
        setIssVideoSizeState();

    }

    public void UpdateVideoSize(object? sender, PropertyChangedEventArgs args)
    {
        setIssVideoSizeState();
    }

    public void setIssVideoSizeState()
    {
        BackgroundGridRow = CurrentIssVideoSizeState.VideoRow;
        BackgroundGridColumn = CurrentIssVideoSizeState.VideoColumn;
        BackgroundGridColumnSpan = CurrentIssVideoSizeState.VideoWidth;
        BackgroundGridRowSpan = CurrentIssVideoSizeState.VideoHeight;
    }

    [RelayCommand]
    public void ShowSettings()
    {
        if (CurrentViewModel == _settingsIssVideoViewModel)
        {
            CurrentViewModel = null;
        }
        else
        {
            CurrentViewModel = _settingsIssVideoViewModel;
        }

        
    }

    public void UpdateIssVideoSize()
    {
        
    }

}
