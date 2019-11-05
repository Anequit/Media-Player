using System;
using System.Collections.Generic;
using System.IO;

namespace media_player.Core
{
    public class MediaController
    {
        public Uri MediaPath(string path, FileInfo file)
            => new Uri($@"{path}\{file.Name}");

        public List<FileInfo> GetMediaMp3(string path)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(path);
            List<FileInfo> files = new List<FileInfo>();

            foreach (var file in DirInfo.GetFiles()) // Gathers files
            {
                if (file.Extension == ".mp3") // Gathers mp3 files
                {
                    files.Add(file);
                }
            }

            return files;
        }
    }
}
