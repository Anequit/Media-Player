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
            
        }

        public void Play()
        {
            // Play the song in the current index

        }

        public void Stop()
        {
            // stop playing the current song
            
        }

        public void Open(Uri source)
        {
            player.Open(source);
        }

        public void ToggleShuffle() => Shuffling = BoolInvert(Shuffling);

        public void ToggleRepeat() => Repeating = BoolInvert(Repeating);

        public void ChangeVolume(int volume)
        {
            player.Volume = volume * 0.01;
        }

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
