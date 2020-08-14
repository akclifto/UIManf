
namespace WpfBasicsApp
{
    /// <summary>
    /// This is a view model for each directory Item in the left side fo the panel.
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The type of this item.
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The abs path to the item.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Get the name of the file/folder directory item
        /// </summary>
        public string Name
        {
            // if the directory item type is a drive, return the fullpath (which will be the logical drive C,D,E, etc.), 
            // otherwise return its full path (meaning its a folder or file.)
            get
            {
                return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }

        //ObservableCollection is a list that has a INOtifyCollectionChanged event making it easy to work with 
        //for UIs

        public bool CanExpand { get { return } }


    }
}
