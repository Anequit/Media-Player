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

        public MediaHandler(List<FileModel> fileModels)
        {
            this.fileModels = fileModels;

            indexHandler = new IndexHandler(fileModels);
            player = new MediaPlayer();

            player.MediaEnded += Player_MediaEnded;

            Open();
        }

        private void Player_MediaEnded(object sender, EventArgs e) => Next();

        public string GetCurrentSong() => fileModels[indexHandler.GetCurrentIndex()].Name;

        public void Play() => player.Play();

        public void Pause() => player.Pause();

        public void Stop() => player.Stop();

        public void Next()
        {
            if (shuffling)
                indexHandler.RandomizeIndex();
            else if (!repeating)
                indexHandler.IndexNext();

            Open();
            Play();
        }

        public void Back()
        {
            indexHandler.IndexBack();
            Open();
            Play();
        }
        
        public void Open() => player.Open(fileModels[indexHandler.GetCurrentIndex()].Path);

        public void ToggleShuffle() => shuffling = BoolInvert(shuffling);

        public void ToggleRepeat() => repeating = BoolInvert(repeating);

        public void ChangeVolume(int volume) => player.Volume = volume * 0.01;

        private bool BoolInvert(bool boolean)
        {
            if (boolean)
                boolean = false;
            else
                boolean = true;

            return boolean;
        }
    }
}
