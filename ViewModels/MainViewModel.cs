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
    
    
    private readonly int _issVideoFeedSettingsGridColumnSpan = 3;
    private readonly int _issVideoFeedSettingsGridRowSpan = 7;
    private readonly int _issVideoFeedSettingsGridRow = 1;
    private readonly int _issVideoFeedSettingsGridColumn = 0;
    
    private readonly int _issVideoFeedInformationGridColumnSpan = 8;
    private readonly int _issVideoFeedInformationGridRowSpan = 7;
    private readonly int _issVideoFeedInformationGridRow = 1;
    private readonly int _issVideoFeedInformationGridColumn = 2;
    
    
    private readonly int _programInformationGridColumnSpan = 8;
    private readonly int _programInformationGridRowSpan = 7;
    private readonly int _programInformationGridRow = 1;
    private readonly int _programInformationGridColumn = 2;
    private ViewModelBase _issVideoFeedBackgroundViewModel;
    private ViewModelBase _settingsIssVideoViewModel;
    private ViewModelBase _programInformationViewModel;
    private ViewModelBase _videoInformationViewModel;
    private IIssClientService _issClientService;
    
    [ObservableProperty] public partial bool SettingsButtonActive { get; set; }
    [ObservableProperty] public partial bool IssVideoFeedButtonActive { get; set; }
    [ObservableProperty] public partial bool VideoInformationButtonActive { get; set; }
    [ObservableProperty] public partial bool ProgramInformationButtonActive { get; set; }



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
        _ = _issClientService.StartListening();
        CurrentIssLocation = issLocationViewModel;
        _videoInformationViewModel = videoInformationViewModel;
        
        ClearActiveButtons();
        IssVideoFeedButtonActive = true;
        
    }

    public void ClearActiveButtons()
    {
        SettingsButtonActive = false;
        IssVideoFeedButtonActive = false;
        VideoInformationButtonActive = false;
        ProgramInformationButtonActive = false;
    }

    [RelayCommand]
    public void ShowVideoInformation()
    {
        if (CurrentViewModel == _videoInformationViewModel)
        {
            CurrentViewModel = null;
            ClearActiveButtons();
            IssVideoFeedButtonActive = true;
        }
        else
        {
            ClearActiveButtons();
            VideoInformationButtonActive = true;
            CurrentViewModel = _videoInformationViewModel;
            CurrentViewGridColumn = _issVideoFeedInformationGridColumn;
            CurrentViewGridRow = _issVideoFeedInformationGridRow;
            CurrentViewGridColumnSpan = _issVideoFeedInformationGridColumnSpan;
            CurrentViewGridRowSpan = _issVideoFeedInformationGridRowSpan;
        }

        
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
            ClearActiveButtons();
            IssVideoFeedButtonActive = true;

        }
        else
        {
            SetSettingsGrid();
            ClearActiveButtons();
            SettingsButtonActive = true;
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
        if (CurrentViewModel == _programInformationViewModel)
        {
            CurrentViewModel = null;
            ClearActiveButtons();
            IssVideoFeedButtonActive = true;
            VideoButtonsIsEnabled = true;
            VideoButtonsIsVisible = true;
        }
        else
        {
            ClearActiveButtons();
            ProgramInformationButtonActive = true;
            VideoButtonsIsEnabled = false;
            VideoButtonsIsVisible = false;
            CurrentViewGridColumn = _programInformationGridColumn;
            CurrentViewGridRow = _programInformationGridRow;
            CurrentViewGridColumnSpan = _programInformationGridColumnSpan;
            CurrentViewGridRowSpan = _programInformationGridRowSpan;
            CurrentViewModel = _programInformationViewModel;
        }

        
        
    }

    [RelayCommand]
    public void ShowIssVideoFeed()
    {
        if (CurrentViewModel != null)
        {
            ClearActiveButtons();
            IssVideoFeedButtonActive = true;
            CurrentViewModel = null;
            VideoButtonsIsEnabled = true;
            VideoButtonsIsVisible = true;
            setIssVideoSizeState();
        }

        
    }

}
