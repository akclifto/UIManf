using System.Collections.ObjectModel;
using System.Linq;

namespace WpfBasicsApp
{
    /// <summary>
    /// ViewModel for the main directory view of the left panel of the UI;
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// A list of the directories on a given machine (logical drives)
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion Constructor

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            //get the logical drives
            var children = DirectoryStructure.GetLogicalDrives();

            //create the view models from the data.
            this.Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }

        #endregion Constructor
    }
}