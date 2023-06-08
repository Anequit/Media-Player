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
    private WaveOutEvent? _waveOut;
    private AudioFileReader? _reader;
    private int _volume;

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

        // Load first song
        LoadFile(_songs.First());
    }

    public Song CurrentSong { get; private set; }

    public TimeSpan PlaybackPostition
    {
        get => _waveOut.GetPositionTimeSpan();
        set 
        {
            Seek(value);
        }
    }

    public bool Repeating { get; set; }

    public bool Shuffling { get; set; }

    public int Volume
    {
        get => _volume;
        set
        {
            _volume = value;

            if (_waveOut is not null)
                _waveOut.Volume = value / 100f;
        }
    }

    public bool Playing => _waveOut is not null && _waveOut?.PlaybackState == PlaybackState.Playing;

    // Resume/start playback
    public void Play()
    {
        // Return early since we have no output
        if (_waveOut is null)
            return;

        _waveOut.Play();

        MediaPlayingEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void Pause()
    {
        // Return early since we have no output
        if (_waveOut is null)
            return;

        _waveOut.Pause();

        MediaPausedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void Seek(TimeSpan position)
    {
        // We can't set a position if we have no song loaded
        if (_reader is null)
            return;

        _reader.CurrentTime = position;
    }

    public void NextSong()
    {
        // Note: Repeating should have priority over shuffling/
        if (Shuffling && !Repeating)
            _indexHandler.RandomizeIndex();

        else if (Repeating)
            Seek(TimeSpan.Zero);

        else
            _indexHandler.IndexNext();

        // Load new file
        LoadFile(_songs.ElementAt(_indexHandler.CurrentIndex));

        MediaChangedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void PreviousSong()
    {
        if (Shuffling && !Repeating)
            _indexHandler.RandomizeIndex();

        else if (Repeating)
            Seek(TimeSpan.Zero);

        else
            _indexHandler.IndexBack();

        // Load new file
        LoadFile(_songs.ElementAt(_indexHandler.CurrentIndex));

        MediaChangedEvent?.Invoke(this, new MediaEventArgs(CurrentSong));
    }

    public void ToggleShuffle() => Shuffling = !Shuffling;

    public void ToggleRepeat() => Repeating = !Repeating;

    internal void LoadFile(string filePath)
    {
        // Clean up old WaveOutEvent incase playback failed.
        // WaveOutEvent will throw if we init twice, so this prevents that as well.
        _waveOut?.Dispose();
        _waveOut = null;

        // Clean up old AudioFileReader
        _reader?.Dispose();
        _reader = null;

        // Create new reader with file path provided
        _reader = new AudioFileReader(filePath);

        // Create new WaveOutEvent for playback
        _waveOut = new WaveOutEvent
        {
            // Set volume of playback
            Volume = Volume / 100f
        };

        // Initialize playback device with AudioFileReader
        _waveOut.Init(_reader);

        // Subscribe to playback stopped
        _waveOut.PlaybackStopped += OnPlaybackStopped;

        // Update current song
        CurrentSong = new Song(_songs.ElementAt(_indexHandler.CurrentIndex))
        {
            Length = _reader.TotalTime
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

        NextSong();

        // Play current song
        Play();
    }
}
