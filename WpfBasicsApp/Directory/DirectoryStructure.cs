using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfBasicsApp
{
    /// <summary>
    /// Class to query information about the directories for the left side of the panel.
    /// </summary>
    public static class DirectoryStructure
    {

        #region GetLogicalDrives
        /// <summary>
        /// Return a list of the logical drives on the machine
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {

            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem
            {
                FullPath = drive,
                Type = DirectoryItemType.Drive
            }).ToList();
        }
        #endregion GetLogicalDrives

        #region GetFileFolderName
        /// <summary>
        /// Helper method to find the file or folder name from a full path. 
        /// </summary>
        /// <param name="filepath">The full path name</param>
        /// <returns>Returns just the last part of the filepath name (C:\Some Folder\file.png would return "file.png")</returns>
        public static string GetFileFolderName(string filepath)
        {
            //if no path, return empty., 
            if (string.IsNullOrEmpty(filepath))
            {
                //Debug("File Folder Name path is empty, returning empty");
                return string.Empty;
            }

            //make all slashes backslashes
            var normalizedPath = filepath.Replace('/', '\\');
            //find the last backslash in the path. 
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If only root directory, return the path itself (ex, file.png)
            if (lastIndex <= 0)
            {
                return filepath;
            }

            //return the string name after the last backslash.
            return filepath.Substring(lastIndex + 1);

        }

        #endregion GetFileFolderName
    }
}
