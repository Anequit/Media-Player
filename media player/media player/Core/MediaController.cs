using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace media_player.Core
{
    class MediaController
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
