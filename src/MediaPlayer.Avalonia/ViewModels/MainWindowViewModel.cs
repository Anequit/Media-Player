using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using MediaPlayer.Core;
using MediaPlayer.Core.Models;

namespace MediaPlayer.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly MediaHandler? _handler;
    private readonly Window _mainWindow;
    private readonly Slider _positionSlider;
    private readonly DispatcherTimer _timer;
    private bool _seeking;

    // For xaml previewer
    public MainWindowViewModel()
    {
        _mainWindow = null!;
        _handler = null!;

        _timer = null!;
        _positionSlider = null!;
    }

    public MainWindowViewModel(Window window, string[]? args)
    {
        _mainWindow = window;

        _mainWindow.Closing += OnWindowClosingEvent;

        _positionSlider = _mainWindow.GetControl<Slider>("PositionSlider");

        try
        {
            _handler = args is null || args.Length == 0
                ? new MediaHandler(Task.Run(GetFolderDirectory).Result, 50)
                : new MediaHandler(args[0], 50);

            _handler.MediaOpenedEvent += OnMediaOpenedEvent;
        }
        catch (InvalidOperationException)
        {
            _handler = null;
        }

        _timer = new DispatcherTimer(DispatcherPriority.Default)
        {
            Interval = TimeSpan.FromMilliseconds(500),
            IsEnabled = true
        };

        _positionSlider.ValueChanged += (_, e) =>
        {
            if (!_seeking || _handler is null)
                return;

            _handler.PlaybackPostition = TimeSpan.FromSeconds(e.NewValue);
        };

        _positionSlider.TemplateApplied += (_, e) =>
        {
            Track? track = e.NameScope.Find<Track>("PART_Track") ??
                           throw new InvalidOperationException("Track not found");

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
        _handler?.Play();

        OnPropertyChanged(nameof(Title));
    }

    public Song CurrentSong => _handler is not null ? _handler.CurrentSong : new Song("", "No Songs Loaded");

    public string Title => _handler is null ? "Media Player" : string.Format(_handler.Playing ? "Playing - {0}" : "Paused - {0}", _handler?.CurrentSong.Name);

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
        get => _handler?.Volume ?? 50;
        set
        {
            if (_handler is not null)
                _handler.Volume = value;
            OnPropertyChanged();
        }
    }

    public bool Repeating
    {
        get => _handler is not null && _handler.Repeating;
        set
        {
            _handler?.ToggleRepeat();
            OnPropertyChanged();
        }
    }

    public bool Shuffling
    {
        get => _handler is not null && _handler.Shuffling;
        set
        {
            _handler?.ToggleShuffle();
            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private void Play()
    {
        _handler?.Play();
        OnPropertyChanged(nameof(Title));
    }

    [RelayCommand]
    private void Pause()
    {
        _handler?.Pause();
        OnPropertyChanged(nameof(Title));
    }

    [RelayCommand]
    private void Next()
    {
        _handler?.NextSong();
    }

    [RelayCommand]
    private void Back()
    {
        _handler?.PreviousSong();
    }

    private void OnMediaOpenedEvent(object? sender, EventArgs e)
    {
        _positionSlider.Value = 0;
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(CurrentSong));
    }

    private void OnWindowClosingEvent(object? sender, WindowClosingEventArgs e)
    {
        _handler?.Dispose();
    }

    private async Task<string> GetFolderDirectory()
    {
        FolderPickerOpenOptions options = new FolderPickerOpenOptions
        {
            AllowMultiple = true,
            Title = "Media Location",
            SuggestedStartLocation = await _mainWindow.StorageProvider.TryGetWellKnownFolderAsync(WellKnownFolder.Music)
        };

        IReadOnlyList<IStorageFolder> folderPicker = await _mainWindow.StorageProvider.OpenFolderPickerAsync(options);

        return folderPicker[0].Path.LocalPath;
    }
}