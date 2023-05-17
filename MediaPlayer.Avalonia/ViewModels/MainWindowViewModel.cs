using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using MediaPlayer.Core;
using MediaPlayer.Core.Events;
using MediaPlayer.Core.Models;
using System;

namespace MediaPlayer.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    readonly MediaHandler _handler;
    readonly Window _mainWindow;

    // For xaml previewer
    public MainWindowViewModel()
    {
        _mainWindow = null!;
        _handler = null!;
    }

    public MainWindowViewModel(Window window)
    {
        _mainWindow = window;

        _handler = new MediaHandler(GetFolderDirectory(), 50);

        _handler.MediaOpenedEvent += OnMediaOpenedEvent;
    }

    public Song CurrentSong => _handler is not null ? _handler.CurrentSong : new Song("", "Nothing is playing");

    public int Volume
    {
        get => _handler is not null ? _handler.Volume : 50;
        set
        {
            _handler?.SetVolume(value);
            OnPropertyChanged(nameof(Volume));
        }
    }

    public bool Repeating
    {
        get => _handler is not null && _handler.Repeating;
        set
        {
            _handler?.ToggleRepeat();
            OnPropertyChanged(nameof(Repeating));
        }
    }

    public bool Shuffling
    {
        get => _handler is not null && _handler.Shuffling;
        set
        {
            _handler?.ToggleShuffle();
            OnPropertyChanged(nameof(Shuffling));
        }
    }

    [RelayCommand]
    public void Play() => _handler?.Play();

    [RelayCommand]
    public void Pause() => _handler?.Pause();

    [RelayCommand]
    public void Next() => _handler?.NextSong();

    [RelayCommand]
    public void Back() => _handler?.PreviousSong();

    private void OnMediaOpenedEvent(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(CurrentSong));
    }

    private string GetFolderDirectory()
    {

        // Not working in preview 5 of avalonia
        /*      var folderPicker = _mainWindow.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions()
                {
                    AllowMultiple = true,
                    Title = "Media location.",
                    SuggestedStartLocation = await _mainWindow.StorageProvider.TryGetWellKnownFolder(WellKnownFolder.Music)
                }).Result;*/

        return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        //return folderPicker[0].Path.AbsolutePath;
    }
}
