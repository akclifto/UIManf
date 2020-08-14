using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfBasicsApp
{
    /// <summary>
    /// This is a view model for each directory Item in the left side fo the panel.
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {

        #region Public Properties   
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

        #endregion Public Properties   

        #region public commands



        #endregion

        #region Helper Methods, Bools

        /// <summary>
        /// List of all children in the selected directory item.
        /// </summary>
        //ObservableCollection is a list that has a INOtifyCollectionChanged event making it easy to work with 
        //for UIs
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Check if the type of item can be expanded. 
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }
        
        /// <summary>
        /// Check if the tree list is already expanded and set bool appropriately.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                //count the number of children in the list that are not null and check if greater than 0;
                return this.Children?.Count(NumChild => NumChild != null) > 0;
            }
            set
            {
                //if UI requests to expand, find all childrent in the given directory item.
                if(value == true)
                {
                    Expand();
                } 
                else
                {
                    this.ClearChildren();
                }
            }
        }

        /// <summary>
        /// Clear the children in the list, and make a new list if required.
        /// This also adds a dummy item to show expand icon if required. 
        /// </summary>
        private void ClearChildren()
        {
            this.Children.Clear();
            //this.Children = new ObservableCollection<DirectoryItemViewModel>();

            // Show expand if not in a file
            if (this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }

        }

        #endregion Helper Methods, Bools

        /// <summary>
        /// Helper Method to Expand directory and find all childrent in the directory item.
        /// </summary>
        private void Expand()
        {
            //TODO: 
            throw new NotImplementedException();
        }
    }
}
