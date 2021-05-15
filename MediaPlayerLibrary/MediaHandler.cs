using MediaPlayerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MediaPlayerLibrary
{
    public class MediaHandler
    {
        private readonly MediaElement _player;
        private readonly IndexHandler _indexHandler;
        private List<FileModel> _fileModels;

        private Duration _naturalDuration;

        private bool _isRepeating = false;
        private bool _isShuffling = false;
        private bool _isPaused = false;

        public event EventHandler SongChangedEvent;
        public event EventHandler VolumeChangedEvent;
        public event EventHandler MediaPlayingEvent;
        public event EventHandler MediaPausedEvent;
        public event EventHandler MediaFailedEvent;
        public event EventHandler MediaOpenedEvent;

        public MediaHandler(List<FileModel> fileModels)
        {
            _fileModels = fileModels;

            _indexHandler = new IndexHandler(_fileModels);

            if (Environment.GetCommandLineArgs().Length == 2)
                SetCurrentSong();

            _player = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual,
                Volume = 50,
                ScrubbingEnabled = true,
                Source = fileModels[_indexHandler.CurrentIndex].Path,
                Balance = 0
            };

            _player.MediaEnded += Player_MediaEnded;
            _player.MediaOpened += Player_MediaOpened;
            _player.MediaFailed += Player_MediaFailed;

            _player.Play(); // play, so that the natural duration of the song is set

            do
            {
                if (_player.NaturalDuration.HasTimeSpan)
                {
                    _naturalDuration = _player.NaturalDuration;
                    _player.Pause();
                }
            } while (!_naturalDuration.HasTimeSpan);
        }

        #region Properties

        public double CurrentSongDuration => _naturalDuration.TimeSpan.TotalSeconds;

        public double CurrentSongPosition => _player.Position.TotalSeconds;

        public FileModel CurrentSong => _fileModels[_indexHandler.CurrentIndex];

        public bool Repeating
        {
            get => _isRepeating;
            set => _isRepeating = value;
        }

        public bool Shuffling
        {
            get => _isShuffling;
            set => _isShuffling = value;
        }

        public bool IsPaused
        {
            get => _isPaused;
            set => _isPaused = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts playing the MediaPlayer.
        /// </summary>
        public void Play()
        {
            _player.Play();
            _isPaused = false;

            MediaPlayingEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Pauses the MediaPlayer.
        /// </summary>
        public void Pause()
        {
            _player.Pause();
            _isPaused = true;

            MediaPausedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Changes the song to the next one.
        /// </summary>
        public void Next()
        {
            if (_isShuffling)
                _indexHandler.RandomizeIndex();
            else if (!_isRepeating)
                _indexHandler.IndexNext();

            Open();
            Play();

            SongChangedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Changes the song to the previous one.
        /// </summary>
        public void Back()
        {
            if (_isShuffling)
                _indexHandler.RandomizeIndex();
            else if (!_isRepeating)
                _indexHandler.IndexBack();

            Open();
            Play();

            SongChangedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Loads the current song.
        /// </summary>
        public void Open()
        {
            _player.Source = _fileModels[_indexHandler.CurrentIndex].Path;
            MediaOpenedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Toggles shuffle on and off.
        /// </summary>
        public void ToggleShuffle() => _isShuffling = !_isShuffling;

        /// <summary>
        /// Toggles repeat on and off
        /// </summary>
        public void ToggleRepeat() => _isRepeating = !_isRepeating;

        /// <summary>
        /// Changes the volume of the media player.
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeVolume(int volume)
        {
            _player.Volume = volume * 0.01;

            VolumeChangedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Seeks to the position provided
        /// </summary>
        /// <param name="position"></param>
        public void Seek(double position) => _player.Position = TimeSpan.FromSeconds(position);

        /// <summary>
        /// Play media when it opens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            _naturalDuration = _player.NaturalDuration;

            Play();
            MediaOpenedEvent.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Invoke MediaFailed event when media fails to open. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_MediaFailed(object sender, ExceptionRoutedEventArgs e) => MediaFailedEvent.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Plays the next song when it finishes playing the current one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_MediaEnded(object sender, EventArgs e) => Next();

        /// <summary>
        /// Updates the File Model list and updates the index.
        /// </summary>
        /// <param name="fileModels"></param>
        public void UpdateMediaHandler(List<FileModel> fileModels)
        {
            // If there is an error, update the fileModels and then update the index handler, so that it's in sync with the new list.

            _fileModels = fileModels;
            _indexHandler.IndexMax = fileModels.Count;
        }

        /// <summary>
        /// Takes command line args and finds a matching fileModel path, then sets the index to that song.
        /// </summary>
        private void SetCurrentSong() => _indexHandler.CurrentIndex = _fileModels.FindIndex(x => x.Path == new Uri(Environment.GetCommandLineArgs()[1]));

        #endregion
    }
}
