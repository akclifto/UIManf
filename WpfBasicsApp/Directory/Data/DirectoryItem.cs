namespace WpfBasicsApp.Directory.Data
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
        public string name 
        { 
            get { 
                return DirectoryStructure.GetFileFolderName(this.FullPath); 
            } 
        }

    }
}
