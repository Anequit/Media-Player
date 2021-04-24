using MediaControllerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MediaControllerLibrary
{
    public class MediaHandler
    {
        private readonly MediaElement player;
        private readonly IndexHandler indexHandler;
        private List<FileModel> fileModels;

        private bool repeating = false;
        private bool shuffling = false;

        public bool isPaused = true;

        public event EventHandler SongChangedEvent;
        public event EventHandler VolumeChangedEvent;
        public event EventHandler MediaPlayingEvent;
        public event EventHandler MediaPausedEvent;
        public event EventHandler MediaFailedEvent;
        public event EventHandler MediaOpenedEvent;

        public MediaHandler(List<FileModel> fileModels)
        {
            this.fileModels = fileModels;

            indexHandler = new IndexHandler(this.fileModels);
            player = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual,
                Volume = 50,
                ScrubbingEnabled = true
            };

            if (Environment.GetCommandLineArgs().Length == 2)
                SetSelectedSong();

            player.MediaEnded += Player_MediaEnded;
            player.MediaOpened += Player_MediaOpened;
            player.MediaFailed += Player_MediaFailed;

            Open();
        }

        /// <summary>
        /// Updates the File Model list and updates the index.
        /// </summary>
        /// <param name="fileModels"></param>
        public void UpdateMediaHandler(List<FileModel> fileModels)
        {
            // If there is an error, update the fileModels and then update the index handler, so that it's in sync with the new list.

            this.fileModels = fileModels;
            indexHandler.UpdateIndex(fileModels);
        }

        /// <summary>
        /// Play media when it opens.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
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
        /// Gets the current song name.
        /// </summary>
        /// <returns>
        /// Current song name.
        /// </returns>
        public FileModel GetCurrentSong() => fileModels[indexHandler.GetCurrentIndex()];

        /// <summary>
        /// Starts playing the MediaPlayer.
        /// </summary>
        public void Play()
        {
            player.Play();
            isPaused = false;
            MediaPlayingEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Pauses the MediaPlayer.
        /// </summary>
        public void Pause()
        {
            player.Pause();
            isPaused = true;
            MediaPausedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Changes the song to the next one.
        /// </summary>
        public void Next()
        { 
            if (shuffling)
                indexHandler.RandomizeIndex();
            else if (!repeating)
                indexHandler.IndexNext();

            Open();
            Play();

            SongChangedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Changes the song to the previous one.
        /// </summary>
        public void Back()
        {
            indexHandler.IndexBack();
            Open();
            Play();

            SongChangedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Loads the current song.
        /// </summary>
        public void Open() => player.Source = fileModels[indexHandler.GetCurrentIndex()].Path;

        /// <summary>
        /// Toggles shuffle on and off.
        /// </summary>
        public void ToggleShuffle() => shuffling = !shuffling;

        /// <summary>
        /// Toggles repeat on and off
        /// </summary>
        public void ToggleRepeat() => repeating = !repeating;

        /// <summary>
        /// Changes the volume of the media player.
        /// </summary>
        /// <param name="volume"></param>
        public void ChangeVolume(int volume)
        {
            player.Volume = volume * 0.01;

            VolumeChangedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Seeks to the position provided
        /// </summary>
        /// <param name="position"></param>
        public void Seek(double position) => player.Position = TimeSpan.FromSeconds(position);

        public Duration GetCurrentSongDuration()
        {
            if (!player.NaturalDuration.HasTimeSpan)
            {
                MessageBox.Show(player.NaturalDuration.HasTimeSpan.ToString());
            }

            return player.NaturalDuration;
        }
        /// <summary>
        /// Takes command line args and finds a matching fileModel path, then sets the index to that song.
        /// </summary>
        private void SetSelectedSong() => indexHandler.SetCurrentIndex(fileModels.FindIndex(x => x.Path == new Uri(Environment.GetCommandLineArgs()[1])));
    }
}
