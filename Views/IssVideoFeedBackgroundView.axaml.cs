using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;

namespace WeatherVideoApp.Gui.Views;

public partial class IssVideoFeedBackgroundView : UserControl
{
    public IssVideoFeedBackgroundView()
    {   
        InitializeComponent();
        
        MyWebView.EnvironmentRequested += (sender, args) =>
        {
            if (args is WindowsWebView2EnvironmentRequestedEventArgs webView2Args)
            {
                webView2Args.ExperimentalOffscreen = true;
            }
        };
        
        
    }
    private async void OnNavigationCompleted(object? sender, WebViewNavigationCompletedEventArgs e)
    {
        if (e.IsSuccess)
        {
            await MyWebView.InvokeScript("""
                                         var style = document.createElement('style');
                                         style.textContent = `
                                             html, body {
                                                 margin: 0 !important;
                                                 padding: 0 !important;
                                                 overflow: hidden !important;
                                                 width: 100% !important;
                                                 height: 100% !important;
                                                 background: #000 !important;
                                             }
                                             ytd-masthead, #secondary, #comments, ytd-watch-metadata,
                                             #related, #meta, ytd-guide-renderer {
                                                 display: none !important;
                                             }
                                             #player, #movie_player, #player-container {
                                                 position: fixed !important;
                                                 top: 0 !important;
                                                 left: 0 !important;
                                                 width: 100vw !important;
                                                 height: 100vh !important;
                                             }
                                         `;
                                         document.head.appendChild(style);
                                         """);
        }
    }
    
    public async Task SetVideoMuted(bool muted)
    {
        await MyWebView.InvokeScript($$"""
                                       var video = document.querySelector('video');
                                       if (video) {
                                           video.muted = {{muted.ToString().ToLower()}};
                                       }
                                       """);
    }
}