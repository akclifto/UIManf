namespace WpfBasicsApp
{
    /// <summary>
    /// Class to store information about a diectory item (drive, file, folder).
    /// <br>The class should provide, the directory type, its absolute path and its name.</br>
    /// </summary>
    public class DirectoryItem
    {

        /// <summary>
        /// The type of this item.
        /// </summary>
        public DirectoryItemType Type { get; set;}

        /// <summary>
        /// The abs path to the item.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Get the name of the file/folder directory item
        /// </summary>
        public string Name 
        { 
            //if the directory item type is a drive, return the fullpath (which will be the logical drive C,D,E, etc.), otherwise return its full path (meaning its a folder or file.)
            get { 
                return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); 
            } 
        }

    }
}
