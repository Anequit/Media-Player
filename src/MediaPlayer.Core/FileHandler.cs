using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MediaPlayer.Core;

public static class FileHandler
{
    private static readonly string[] ValidExtensions = { ".mp3", ".wav", ".aiff" };

    // Filters a folder for specific file types
    public static IEnumerable<string> BuildFileList(string folderPath)
    {
        // Process the list of files found in the directory.
        IEnumerable<string> fileEntries = Directory.GetFiles(folderPath).Where(file => ValidExtensions.Any(ex => Path.GetExtension(file) == ex));

        // Recursively process each subdirectory.
        fileEntries = Directory.GetDirectories(folderPath).Aggregate(fileEntries, (current, subdirectory) => current.Concat(BuildFileList(subdirectory)));

        foreach (string filePath in fileEntries.ToList())
            yield return filePath;
    }
}
