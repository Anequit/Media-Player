namespace MediaPlayer.Core;

public static class FileHandler
{
    readonly static string[] _validExtensions = { ".mp3", ".wav", ".aiff" };

    // Filters a folder for specific file types
    public static IEnumerable<string> BuildFileList(string folderPath)
    {
        // Process the list of files found in the directory.
        IEnumerable<string> fileEntries = Directory.GetFiles(folderPath).Where(file => _validExtensions.Any(ex => Path.GetExtension(file) == ex));

        // Recursively process each subdirectory.
        foreach (string subdirectory in Directory.GetDirectories(folderPath))
            fileEntries = fileEntries.Concat(BuildFileList(subdirectory));

        foreach (string filePath in fileEntries.ToList())
            yield return filePath;
    }
}
