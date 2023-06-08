using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using MediaPlayer.Core;
using MediaPlayer.Core.Events;
using MediaPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        _handler = new MediaHandler(Task.Run(GetFolderDirectory).Result, 50);

        _handler.MediaOpenedEvent += OnMediaOpenedEvent;
    }

    public Song CurrentSong => _handler is not null ? _handler.CurrentSong : new Song("", "Nothing playing");

    public int Volume
    {
        get => _handler is not null ? _handler.Volume : 50;
        set
        {
            if (_handler is not null)
                _handler.Volume = value;
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

    private async Task<string> GetFolderDirectory()
    {
        FolderPickerOpenOptions options = new()
        {
            AllowMultiple = true,
            Title = "Media location.",
            SuggestedStartLocation = await _mainWindow.StorageProvider.TryGetWellKnownFolderAsync(WellKnownFolder.Music)
        };

        IReadOnlyList<IStorageFolder> folderPicker = await _mainWindow.StorageProvider.OpenFolderPickerAsync(options);

        return folderPicker[0].Path.LocalPath;
    }
}
