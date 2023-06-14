using MediaPlayer.Core.Events;
using MediaPlayer.Core.Models;
using NAudio.Utils;
using NAudio.Wave;
using System.Diagnostics;

namespace MediaPlayer.Core;

public class MediaHandler
{
    readonly private IndexHandler _indexHandler;
    readonly private IEnumerable<string> _songs;
    readonly WaveOutEvent _playbackDevice;
    private AudioFileReader? _audioReader;
    private int _volume;
    private bool _isSkipping;

    public event EventHandler? MediaChangedEvent;
    public event EventHandler? MediaPlayingEvent;
    public event EventHandler? MediaPausedEvent;
    public event EventHandler? MediaFailedEvent;
    public event EventHandler? MediaOpenedEvent;

    public MediaHandler(string folderPath, int volume = 100, bool repeating = false, bool shuffling = false)
    {
        // Set defaults
        _volume = volume;
        Repeating = repeating;
        Shuffling = shuffling;

        // Create song objects out of folder path
        _songs = FileHandler.BuildFileList(folderPath);

        // Index songs
        _indexHandler = new IndexHandler(_songs.Count());

        // Suppress null warning
        CurrentSong = null!;

        // Initalize playback
        _playbackDevice = new WaveOutEvent()
        {
            Volume = _volume / 100f,
            DesiredLatency = 150
        };

        _playbackDevice.PlaybackStopped += OnPlaybackStopped;

        // TODO: No songs will cause exception
        // Load first song
        LoadFile(_songs.First());
    }

    public Song CurrentSong { get; private set; }

    public TimeSpan PlaybackPostition
    {
        get => _audioReader is not null ? _audioReader.CurrentTime : TimeSpan.Zero;
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

    public bool Playing => _playbackDevice is not null && _playbackDevice?.PlaybackState == PlaybackState.Playing;

    // Resume/start playback
    public void Play()
    {
        // Return early since we have no output
        if (_playbackDevice is null)
            return;

        _playbackDevice.Play();

        MediaPlayingEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void Pause()
    {
        // Return early since we have no output
        if (_playbackDevice is null)
            return;

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

        Debug.WriteLine("OnPlayackStopped Fired");

        // If the user is not skipping the current song, then we automatically play the next song.
        if (!_isSkipping)
            UpdateCurrentSong(true);

        // Autoplay
        Play();

        // Reset skipping
        _isSkipping = false;
    }
}
