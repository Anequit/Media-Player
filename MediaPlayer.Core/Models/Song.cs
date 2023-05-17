namespace MediaPlayer.Core.Models;

public class Song
{
    public Song(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; set; }
    public string Name { get; set; }
}
