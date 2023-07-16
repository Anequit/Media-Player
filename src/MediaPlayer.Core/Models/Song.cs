using System;
using System.IO;

namespace MediaPlayer.Core.Models;

public class Song
{
    public Song(string filePath)
    {
        FilePath = filePath;
        Name = Path.GetFileNameWithoutExtension(filePath);
    }

    public Song(string filePath, string name)
    {
        FilePath = filePath;
        Name = name;
    }

    public string FilePath { get; set; }
    public string Name { get; private set; }
    public TimeSpan Length { get; internal set; }
}
