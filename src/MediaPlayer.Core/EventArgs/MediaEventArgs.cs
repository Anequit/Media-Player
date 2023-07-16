using MediaPlayer.Core.Models;

namespace MediaPlayer.Core.EventArgs;

public class MediaEventArgs : System.EventArgs
{
    public MediaEventArgs(Song song) => Song = song;

    public Song Song { get; set; }
}
