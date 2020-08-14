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

        /// <summary>
        /// Get directory's top-level content
        /// </summary>
        /// <param name="FullPath"> The full path to directory content</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string FullPath)
        {
            //List to hold directory items.
            var items = new List<DirectoryItem>();

            #region GetFolders

            //try/catch to check each drive to make sure something is there to populate the tree.  Bad practice to not handle errors.
            //get directories and add to list
            try
            {
                var dirs = Directory.GetDirectories(FullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DirectoryItem
                    {
                        FullPath = dir,
                        Type = DirectoryItemType.Folder
                    }));
                }
            }
            catch
            {
                Debug("Caught an error when getting directories!");
            }

            #endregion GetFolders

            #region GetFiles

            //try/catch to check each drive to make sure something is there to populate the tree.  Bad practice to not handle errors.
            //get files and add to list
            try
            {
                var fileDirs = Directory.GetFiles(FullPath);
                if (fileDirs.Length > 0)
                {
                    items.AddRange(fileDirs.Select(fileDir => new DirectoryItem
                    {
                        FullPath = fileDir,
                        Type = DirectoryItemType.File
                    }));
                }
            }
            catch
            {
                Debug("Caught an error when getting file names!");
            }

            return items;

            #endregion GetFiles
        }

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

        #region Debugger

        /// <summary>
        /// Debug for testing purposes.  Writes out to console with a message.
        /// </summary>
        /// <param name="message">  Message to pass through the debugger. </param>
        private static void Debug(string message)
        {
            //this is called an interpolated string.  Basically the message from debug gets passed in the { }.
            //      format:
            //          $ + some text + {message being passed as a parameter}
            System.Diagnostics.Debug.WriteLine($"Debug: {message}");
        }

        #endregion Debugger
    }
}