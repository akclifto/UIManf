namespace WpfBasicsApp
{
    /// <summary>
    /// Class to query information about the directories for the left side of the panel.
    /// </summary>
    public static class DirectoryStructure
    {

        

        #region Helper Methods:  GetFileFolderName
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

        #endregion Helper Methods:  GetFileFolderName
    }
}
