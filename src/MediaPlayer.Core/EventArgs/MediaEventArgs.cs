using MediaPlayer.Core.Models;

namespace MediaPlayer.Core.Events;

public class MediaEventArgs : EventArgs
{
    public MediaEventArgs(Song song) => Song = song;

    public Song Song { get; set; }
}
