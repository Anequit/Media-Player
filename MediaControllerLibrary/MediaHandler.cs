using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MediaControllerLibrary
{
    public class MediaHandler
    {
        //private readonly SoundPlayer player;
        private readonly MediaPlayer player;

        private bool Repeating;
        private bool Shuffling;

        public MediaHandler()
        {
            player = new MediaPlayer();
        }

        public void Play() => player.Play();

        public void Pause() => player.Pause();

        public void Stop() => player.Stop();

        public void Open(Uri source) => player.Open(source);

        public void ToggleShuffle() => Shuffling = BoolInvert(Shuffling);

        public void ToggleRepeat() => Repeating = BoolInvert(Repeating);

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
