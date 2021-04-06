using MediaControllerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MediaControllerLibrary
{
    public class MediaHandler
    {
        private readonly MediaPlayer player;
        private readonly IndexHandler indexHandler;
        private readonly List<FileModel> fileModels;
        
        private bool repeating = false;
        private bool shuffling = false;

        public event EventHandler SongChangedEvent;
        public event EventHandler VolumeChangedEvent;
        public event EventHandler MediaPlayingEvent;
        public event EventHandler MediaPausedEvent;

        public MediaHandler(List<FileModel> fileModels)
        {
            this.fileModels = fileModels;

            indexHandler = new IndexHandler(fileModels);
            player = new MediaPlayer();
            
            if(Environment.GetCommandLineArgs().Length == 2)
                SetSelectedSong();

            Open();

            player.MediaEnded += Player_MediaEnded;
        }

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
        public string GetCurrentSong() => fileModels[indexHandler.GetCurrentIndex()].Name;

        /// <summary>
        /// Starts playing the MediaPlayer.
        /// </summary>
        public void Play()
        {
            player.Play();
            MediaPlayingEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Pauses the MediaPlayer.
        /// </summary>
        public void Pause()
        {
            player.Pause();
            MediaPausedEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Stops the MediaPlayer.
        /// </summary>
        public void Stop() => player.Stop();

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
        public void Open() => player.Open(fileModels[indexHandler.GetCurrentIndex()].Path);

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
        /// Takes command line args and finds a matching fileModel path, then sets the index to that song.
        /// </summary>
        private void SetSelectedSong() => indexHandler.SetCurrentIndex(fileModels.FindIndex(x => x.Path == new Uri(Environment.GetCommandLineArgs()[1])));
    }
}
