using MediaControllerLibrary.Entities;
using MediaControllerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaControllerLibrary
{
    public class FileHandler
    {
        private readonly FileType fileType;
        private readonly string folderPath;

        List<FileModel> FileList = new List<FileModel>();

        public FileHandler(string folderPath, FileType fileType)
        {
            this.fileType = fileType;
            this.folderPath = folderPath;

            GetFiles(folderPath);
        }

        private void GetFiles(string folderPath)
        {
            // Fetch files with the chosen filetype
            // map each file to a FileModel then
            // Add each supported file to the file list
        }
    }
}
