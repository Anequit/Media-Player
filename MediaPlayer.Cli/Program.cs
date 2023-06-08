using MediaPlayer.Core;

internal class Program
{
    private static void Main(string[] args)
    {
        MediaHandler mediaHandler = new(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));

        mediaHandler.MediaOpenedEvent += (x, y) =>
        {
            Console.WriteLine("Media opened " + y);
        };

        mediaHandler.Volume = 50;

        mediaHandler.Play();

        while (true)
        {
            while (mediaHandler.Playing)
            {
                Console.WriteLine("File Name: " + mediaHandler.CurrentSong.Name);
                Console.WriteLine("Total Length: " + mediaHandler.CurrentSong.Length.ToString("mm\\:ss"));
                Console.WriteLine("Current Position: " + mediaHandler.PlaybackPostition.ToString("mm\\:ss"));
                Console.WriteLine("Volume: " + mediaHandler.Volume);

                Thread.Sleep(500);

                Console.Clear();
            }

            Console.WriteLine("Finished playing " + mediaHandler.CurrentSong.Name);

            Thread.Sleep(2000);
        }
    }
}