using MediaPlayerLibrary.Entities;
using MediaPlayerLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using WK.Libraries.BetterFolderBrowserNS;

namespace MediaPlayerLibrary
{
    public class FileHandler
    {
        private readonly FileType fileType;
        private readonly string folderPath;
        readonly List<FileModel> FileList = new List<FileModel>();

        public FileHandler(FileType fileType)
        {
            this.fileType = fileType;

            if (Environment.GetCommandLineArgs().Length == 2)
                folderPath = new FileInfo(Environment.GetCommandLineArgs()[1]).DirectoryName;
            else
                folderPath = OpenFolderDialog();
        }

        /// <summary>
        /// Returns a built FileList with FileModels
        /// </summary>
        /// <returns>
        /// List of FileModels
        /// </returns>
        public List<FileModel> GetFileList()
        {
            if (FileList.Count == 0)
                Environment.Exit(1);
            
            return FileList;
        }

        /// <summary>
        /// Adds files that match the extension provided at FileHandler creation.
        /// </summary>
        public void BuildFileList()
        {
            ClearFileList();

            if (!Directory.Exists(folderPath))
                return;

            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            foreach(var file in directoryInfo.GetFiles())
            {
                if(file.Extension != $".{fileType}") {
                    continue;
                }

                FileModel fileListItem = new FileModel()
                {
                    Name = Path.GetFileNameWithoutExtension(file.Name),
                    Path = new Uri(file.FullName)
                };

                FileList.Add(fileListItem);
            }
        }

        private string OpenFolderDialog()
        {
            using (BetterFolderBrowser folderBrowser = new BetterFolderBrowser())
            {
                folderBrowser.Multiselect = false;
                folderBrowser.Title = "Media location.";
                folderBrowser.ShowDialog();

                return folderBrowser.SelectedPath;
            };
        }

        private void ClearFileList()
            => FileList.Clear();
    }
}
