using System;
using System.Collections.Generic;
using MediaPlayer.Core.EventArgs;
using MediaPlayer.Core.Models;
using NAudio.Wave;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MediaPlayer.Core;

public sealed class MediaHandler : IDisposable
{
    private IndexHandler _indexHandler;
    private IEnumerable<string> _songs;
    readonly WaveOutEvent _playbackDevice;
    private AudioFileReader? _audioReader;
    private int _volume;
    private bool _isSkipping;
    private bool _disposedValue;

    public event EventHandler? MediaChangedEvent;
    public event EventHandler? MediaPlayingEvent;
    public event EventHandler? MediaPausedEvent;
    public event EventHandler? MediaFailedEvent;
    public event EventHandler? MediaOpenedEvent;

    public MediaHandler(string path, int volume = 100, bool repeating = false, bool shuffling = false)
    {
        // Set defaults
        _volume = volume;
        Repeating = repeating;
        Shuffling = shuffling;

        // Collect all files recursively in directory
        _songs = File.GetAttributes(path) == FileAttributes.Directory ? FileHandler.BuildFileList(path) : Enumerable.Repeat(path, 1);

        // Index songs
        _indexHandler = new IndexHandler(_songs.Count());

        // Suppress null warning
        CurrentSong = null!;

        // Initialize playback
        _playbackDevice = new WaveOutEvent()
        {
            Volume = _volume / 100f,
            DesiredLatency = 150
        };

        _playbackDevice.PlaybackStopped += OnPlaybackStopped;

        if (_songs.Any())
            // Load first song
            LoadFile(_songs.First());

        else
            throw new InvalidOperationException("No Songs in folder path.");
    }

    public Song CurrentSong { get; private set; }

    public TimeSpan PlaybackPosition
    {
        get => _audioReader?.CurrentTime ?? TimeSpan.Zero;
        set => Seek(value);
    }

    public bool Repeating { get; set; }

    public bool Shuffling { get; set; }

    public int Volume
    {
        get => _volume;
        set
        {
            _volume = value;

            if (_playbackDevice is not null)
                _playbackDevice.Volume = value / 100f;
        }
    }

    // If not paused, then playing since we are never in stopped state.
    public bool Playing => _playbackDevice.PlaybackState != PlaybackState.Paused;

    // Resume/start playback
    public void Play()
    {
        _playbackDevice.Play();

        MediaPlayingEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void Pause()
    {
        _playbackDevice.Pause();

        MediaPausedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void Seek(TimeSpan position)
    {
        // We can't set a position if we have no song loaded
        if (_audioReader is null)
            return;

        _audioReader.CurrentTime = position;
    }

    public void NextSong()
    {
        _isSkipping = true;
        UpdateCurrentSong(true);
    }

    public void PreviousSong()
    {
        _isSkipping = true;
        UpdateCurrentSong(false);
    }

    public void ToggleShuffle() => Shuffling = !Shuffling;

    public void ToggleRepeat() => Repeating = !Repeating;

    private void UpdateCurrentSong(bool moveForward)
    {
        if (Shuffling && !Repeating)
            _indexHandler.RandomizeIndex();

        else if (Repeating)
            Seek(TimeSpan.Zero);

        else if (moveForward)
            _indexHandler.IndexNext();

        else
            _indexHandler.IndexBack();

        LoadFile(_songs.ElementAt(_indexHandler.CurrentIndex));

        MediaChangedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    private void LoadFile(string filePath)
    {
        // Stop all playback
        _playbackDevice.Stop();

        // Cleanup old audio reader
        _audioReader?.Dispose();
        _audioReader = null;

        // Initialize playback with new audio reader
        _audioReader = new AudioFileReader(filePath);
        _playbackDevice.Init(_audioReader);

        // Update CurrentSong
        CurrentSong = new Song(_songs.ElementAt(_indexHandler.CurrentIndex))
        {
            Length = _audioReader.TotalTime
        };

        MediaOpenedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    // Will be fired when manually stopped, naturally ends, or fails
    private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
    {
        // Occurs when playback device is no longer available
        if (e.Exception is not null)
        {
            Debug.WriteLine(e);
            MediaFailedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
        }

        // If the user is not skipping the current song, then we automatically play the next song.
        if (!_isSkipping)
            UpdateCurrentSong(true);

        // Autoplay
        Play();

        // Reset skipping
        _isSkipping = false;
    }

    private void Dispose(bool disposing)
    {
        if (_disposedValue) return;
        
        if (disposing)
        {
            _audioReader?.Dispose();
            _playbackDevice.Dispose();
        }

        _songs = null!;
        _indexHandler = null!;
        _disposedValue = true;
    }

    ~MediaHandler()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
