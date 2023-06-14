using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using MediaPlayer.Core;
using MediaPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;
using Avalonia.Threading;
using System.Diagnostics;

namespace MediaPlayer.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    readonly MediaHandler _handler;
    readonly Window _mainWindow;
    readonly DispatcherTimer _timer;
    readonly Slider _positionSlider;
    bool _seeking = false;

    // For xaml previewer
    public MainWindowViewModel()
    {
        _mainWindow = null!;
        _handler = null!;

        _timer = null!;
        _positionSlider = null!;
    }

    public MainWindowViewModel(Window window)
    {
        _mainWindow = window;

        _mainWindow.Closing += OnWindowClosingEvent;

        _positionSlider = _mainWindow.GetControl<Slider>("PositionSlider");

        _handler = new MediaHandler(Task.Run(GetFolderDirectory).Result, 50);

        _handler.MediaOpenedEvent += OnMediaOpenedEvent;

        _timer = new DispatcherTimer(DispatcherPriority.Default)
        {
            Interval = TimeSpan.FromMilliseconds(500),
            IsEnabled = true
        };

        _positionSlider.ValueChanged += (_, e) =>
        {
            if (!_seeking)
                return;

            _handler.PlaybackPostition = TimeSpan.FromSeconds(e.NewValue);
        };

        _positionSlider.TemplateApplied += (_, e) =>
        {
            Track? track = e.NameScope.Find<Track>("PART_Track") ?? throw new InvalidOperationException("Track not found");

            if (track.Thumb is null || track.IncreaseButton is null)
                throw new InvalidOperationException("Critical Track button not found");

            track.Thumb.DragStarted += (_, e) =>
            {
                _timer.Stop();
                _seeking = true;
                Pause();
            };

            track.Thumb.DragCompleted += (_, e) =>
            {
                _timer.Start();
                Play();
                _seeking = false;
            };
        };

        _timer.Tick += (_, e) =>
        {
            if (!_seeking)
                OnPropertyChanged(nameof(CurrentPosition));
        };

        _timer.Start();
        _handler.Play();
    }

    public Song CurrentSong => _handler is not null ? _handler.CurrentSong : new Song("", "No Songs Loaded");

    public double CurrentPosition
    {
        get => _handler is not null ? _handler.PlaybackPostition.TotalSeconds : 0;
        set
        {
            if (_handler is not null)
                _handler.PlaybackPostition = TimeSpan.FromSeconds(_positionSlider.Value);
        }
    }

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
        _positionSlider.Value = 0;
        OnPropertyChanged(nameof(CurrentSong));
    }

    private void OnWindowClosingEvent(object? sender, WindowClosingEventArgs e) => _handler.Dispose();

    private async Task<string> GetFolderDirectory()
    {
        FolderPickerOpenOptions options = new()
        {
            AllowMultiple = true,
            Title = "Media Location",
            SuggestedStartLocation = await _mainWindow.StorageProvider.TryGetWellKnownFolderAsync(WellKnownFolder.Music)
        };

        IReadOnlyList<IStorageFolder> folderPicker = await _mainWindow.StorageProvider.OpenFolderPickerAsync(options);

        return folderPicker[0].Path.LocalPath;
    }
}
