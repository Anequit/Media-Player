using MediaControllerLibrary.Entities;
using MediaControllerLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MediaControllerLibrary
{
    public class FileHandler
    {
        private readonly FileType fileType;
        private readonly string folderPath;
        readonly List<FileModel> FileList = new List<FileModel>();

        public FileHandler(FileType fileType)
        {
            this.fileType = fileType;

            folderPath = OpenFolderDialog();
        }

        public FileHandler(FileType fileType, string filePath)
        {
            this.fileType = fileType;

            folderPath = new FileInfo(filePath).DirectoryName;
        }

        /// <summary>
        /// Returns a built FileList with FileModels
        /// </summary>
        /// <returns>
        /// List of FileModels
        /// </returns>
        public List<FileModel> GetFileList()
        {
            if(FileList.Count == 0)
                throw new Exception("FileList is null");

            return FileList;
        }

        /// <summary>
        /// Adds files that match the extension provided at FileHandler creation.
        /// </summary>
        public void BuildFileList()
        {
            ClearFileList();

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
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.Description = "Media location.";

                folderBrowserDialog.ShowDialog();

                return folderBrowserDialog.SelectedPath;
            }
        }

        private void ClearFileList()
            => FileList.Clear();
    }
}
