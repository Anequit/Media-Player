using MediaPlayer.Core.Models;
using NAudio.Wave;

namespace MediaPlayer.Core;

internal static class SongFactory
{
    public static Song CreateSong(string filePath)
    {
        return new Song(filePath, Path.GetFileNameWithoutExtension(filePath));
    }
}
