using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaControllerLibrary
{
    public class MediaHandler
    {
        private bool Repeating;
        private bool Shuffling;

        public void Pause()
        {
            // Pause the current song
        }

        public void Play()
        {
            // Play the song in the current index
        }

        public void Stop()
        {
            // stop playing the current song
        }

        public void ToggleShuffle()
        {
            Shuffling = BoolInvert(Shuffling);
        }

        public void ToggleRepeat()
        {
            Repeating = BoolInvert(Repeating);
        }

        public void ChangeVolume(int volume)
        {

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
