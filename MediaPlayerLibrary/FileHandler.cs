using MediaPlayerLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using WK.Libraries.BetterFolderBrowserNS;

namespace MediaPlayerLibrary
{
    public class FileHandler
    {
        readonly string _folderPath;
        readonly List<FileModel> _fileList = new List<FileModel>();
        readonly string[] _fileTypes = { ".mp3", ".m4a", ".wav" };

        public FileHandler()
        {
            if (Environment.GetCommandLineArgs().Length == 2)
                _folderPath = new FileInfo(Environment.GetCommandLineArgs()[1]).DirectoryName;
            else
                _folderPath = OpenFolderDialog();
        }

        #region Properties

        public List<FileModel> FileList
        {
            get
            {

                if (_fileList.Count == 0)
                    Environment.Exit(1);


                return _fileList;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds files that match the extension provided at FileHandler creation.
        /// </summary>
        public void BuildFileList()
        {
            ClearFileList();

            if (!Directory.Exists(_folderPath))
                return;

            DirectoryInfo directoryInfo = new DirectoryInfo(_folderPath);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                foreach (string type in _fileTypes)
                {
                    if (file.Extension == type)
                    {
                        FileModel fileListItem = new FileModel()
                        {
                            Name = Path.GetFileNameWithoutExtension(file.Name),
                            Path = new Uri(file.FullName)
                        };

                        _fileList.Add(fileListItem);

                        break;
                    }
                    else
                        continue;
                }
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
            => _fileList.Clear();

        #endregion
    }
}
