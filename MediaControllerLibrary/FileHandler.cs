using MediaControllerLibrary.Entities;
using MediaControllerLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaControllerLibrary
{
    public class FileHandler
    {
        private readonly FileType fileType;
        private readonly string folderPath;
        readonly List<FileModel> FileList = new();

        public FileHandler(string folderPath, FileType fileType)
        {
            this.fileType = fileType;
            this.folderPath = folderPath;
        }

        /// <summary>
        /// Returns a built FileList with FileModels
        /// </summary>
        /// <returns>
        /// List of FileModels
        /// </returns>
        public List<FileModel> GetFileList()
        {
            if(FileList == null)
                throw new Exception("FileList is null");

            return FileList;
        }

        /// <summary>
        /// Adds files that match the extension provided at FileHandler creation.
        /// </summary>
        public void BuildFileList()
        {
            // Fetch files with the chosen filetype
            // map each file to a FileModel then
            // Add each supported file to the file list
            ClearFileList();

            DirectoryInfo directoryInfo = new(folderPath);

            foreach(var file in directoryInfo.GetFiles())
            {
                if(file.Extension != fileType.ToString()) {
                    return;
                }

                FileModel fileListItem = new()
                {
                    Name = file.Name,
                    Path = file.FullName
                };

                FileList.Add(fileListItem);
            }
        }

        private void ClearFileList()
            => FileList.Clear();
    }
}
