using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherVideoApp.Gui.Models;
using WeatherVideoApp.Gui.Services;

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
    [ObservableProperty] public partial bool VideoButtonsIsVisible  { get; set; }
    [ObservableProperty] public partial bool VideoButtonsIsEnabled  { get; set; }
    [ObservableProperty] public partial int LonLatGridRow  { get; set; }
    [ObservableProperty] public partial int LonLatGridColumn  { get; set; }
    [ObservableProperty] public partial IssVideoSizeState CurrentIssVideoSizeState { get; set; }
    [ObservableProperty] public partial ViewModelBase CurrentIssLocation { get; set; }
    

    private readonly int _issVideoFeedGridColumnSpan = 4;
    private readonly int _issVideoFeedGridRowSpan = 3;
    private readonly int _issVideoFeedGridRow = 2;
    private readonly int _issVideoFeedGridColumn = 2;
    
    private readonly int _issVideoFeedSettingsGridColumnSpan = 3;
    private readonly int _issVideoFeedSettingsGridRowSpan = 7;
    private readonly int _issVideoFeedSettingsGridRow = 1;
    private readonly int _issVideoFeedSettingsGridColumn = 0;
    
    private readonly int _issVideoFeedInformationGridColumnSpan = 8;
    private readonly int _issVideoFeedInformationGridRowSpan = 7;
    private readonly int _issVideoFeedInformationGridRow = 1;
    private readonly int _issVideoFeedInformationGridColumn = 1;
    
    private readonly int _programInformationBackgroundGridColumnSpan = 10;
    private readonly int _programInformationBackgroundGridRowSpan = 7;
    private readonly int _programInformationBackgroundGridRow = 1;
    private readonly int _programInformationBackgroundGridColumn = 0;
    
    private readonly int _programInformationGridColumnSpan = 8;
    private readonly int _programInformationGridRowSpan = 7;
    private readonly int _programInformationGridRow = 1;
    private readonly int _programInformationGridColumn = 2;
    private ViewModelBase _issVideoFeedBackgroundViewModel;
    private ViewModelBase _settingsIssVideoViewModel;
    private ViewModelBase _programInformationViewModel;
    private ViewModelBase _videoInformationViewModel;
    private IIssClientService _issClientService;
   


    public MainViewModel(IssVideoFeedBackgroundViewModel issVideoFeedBackgroundViewModel, 
        SettingsIssVideoViewModel settingsIssVideoViewModel, IssVideoSizeState  issVideoSizeState, 
        ProgramInformationViewModel  programInformationViewModel, IIssClientService issClientService, 
        IssLocationViewModel issLocationViewModel, VideoInformationViewModel videoInformationViewModel)
    {
        _issVideoFeedBackgroundViewModel =  issVideoFeedBackgroundViewModel;
        BackgroundViewModel = _issVideoFeedBackgroundViewModel;
        _settingsIssVideoViewModel = settingsIssVideoViewModel;
        SetSettingsGrid();
        CurrentViewModel = null;
        CurrentIssVideoSizeState =  issVideoSizeState;
        CurrentIssVideoSizeState.PropertyChanged += UpdateVideoSize;
        setIssVideoSizeState();
        _programInformationViewModel = programInformationViewModel;
        VideoButtonsIsEnabled = true;
        VideoButtonsIsVisible = true;
        _issClientService = issClientService;
        _issClientService.StartListening();
        CurrentIssLocation = issLocationViewModel;
        _videoInformationViewModel = videoInformationViewModel;
    }
    
    [RelayCommand]
    public void ShowVideoInformation()
    {
        CurrentViewModel = _videoInformationViewModel;
        CurrentViewGridColumn = _issVideoFeedInformationGridColumn;
        CurrentViewGridRow = _issVideoFeedInformationGridRow;
        CurrentViewGridColumnSpan = _issVideoFeedInformationGridColumnSpan;
        CurrentViewGridRowSpan = _issVideoFeedInformationGridRowSpan;
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
        LonLatGridColumn = BackgroundGridColumn - 2;
        LonLatGridRow = BackgroundGridRow;

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
            SetSettingsGrid();
        }

        
    }

    private void SetSettingsGrid()
    {
        CurrentViewModel = _settingsIssVideoViewModel;
        CurrentViewGridColumn = _issVideoFeedSettingsGridColumn;
        CurrentViewGridRow = _issVideoFeedSettingsGridRow;
        CurrentViewGridColumnSpan = _issVideoFeedSettingsGridColumnSpan;
        CurrentViewGridRowSpan = _issVideoFeedSettingsGridRowSpan;
        
    }

    [RelayCommand]
    public void ShowProgramInformation()
    {
        
        VideoButtonsIsEnabled = false;
        VideoButtonsIsVisible = false;
        CurrentViewGridColumn = _programInformationGridColumn;
        CurrentViewGridRow = _programInformationGridRow;
        CurrentViewGridColumnSpan = _programInformationGridColumnSpan;
        CurrentViewGridRowSpan = _programInformationGridRowSpan;
        CurrentViewModel = _programInformationViewModel;
        
    }

    [RelayCommand]
    public void ShowIssVideoFeed()
    {
        SetSettingsGrid();
        CurrentViewModel = null;
        BackgroundViewModel = _issVideoFeedBackgroundViewModel;
        VideoButtonsIsEnabled = true;
        VideoButtonsIsVisible = true;
        setIssVideoSizeState();
    }

}
