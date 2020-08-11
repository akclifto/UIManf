using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;


namespace WpfBasicsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// NOTE:  The logic here really shouldn't be in this file.  The is the UI code behind the layout.  Follow the MVC pattern and keep the logic in controller class(es)
    /// separate from the model and view.  
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Left Side of Panel: On loaded
        /// <summary>
        /// Initialization of application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //loop through and get drive directories, then add each to the folderView panel on the left side of the UI window.  Brute force and not good practice.  Ideally, make a new class that
            //contains all the info of the drive and then display it.  Minimize login in the View.  
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //set properties for a treeviewitem, basically creates TreeViewItem() ctor and sets the header and full path in the body of the ctor
                var item = new TreeViewItem()
                {
                    //set the header and full path for each drive.
                    Header = drive,
                    Tag = drive //gives the full path

                };

                //dummy item to get expandable tree.
                item.Items.Add(null);

                //listen for item expansion
                item.Expanded += Folder_Expanded;

                //Add the item to the folderview panel
                FolderView.Items.Add(item);
            }
        }
        #endregion On Loaded

        #region Folder Expanded Method
        /// <summary>
        /// Expands the tree, gets all subitems in the tree and populates left side of panel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Folder_Expanded: Initial Checks
            //get the tree view item, root item (parent)
            var item = (TreeViewItem)sender;
            //check for dummy data:  if the item count is not 1 or it is and the item is not null
            if(item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            //clear dummy data 
            item.Items.Clear();
            var fullPath = (string) item.Tag;

            #endregion Folder_Expanded: Initial Checks

            #region Folder_Expanded: Get Folders

            //create list to hold directories
            var directories = new List<string>();

            //try/catch to check each drive to make sure something is there to populate the tree.  Bad practice to not handle errors. 
            //get directories and add to list
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if(dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }

            } catch {
                Debug("Caught an error when getting directories!");
            }


            //For each directory, add to the folder view tree
            directories.ForEach(directoryPath =>
            {
                //create directory item
                var subItem = new TreeViewItem()
                {
                    //set the header as the folder name
                    Header = GetFileFolderName(directoryPath),
                    //set tag as full path name
                    Tag = directoryPath
                };

                //add a dummy item to the subItem to expand the folder. 
                subItem.Items.Add(null);

                //recursive call to get all the subtrees as tree expands.
                subItem.Expanded += Folder_Expanded;

                //add child subitem to parent
                item.Items.Add(subItem);
                //Debug("Subitem added to folderview");

            });
            #endregion Folder_Expanded:  Get Folders

            #region Folder_Expanded: Get Files

            //create list to hold files
            var files = new List<string>();

            //try/catch to check each drive to make sure something is there to populate the tree.  Bad practice to not handle errors. 
            //get files and add to list
            try
            {
                var fileDirs = Directory.GetFiles(fullPath);
                if (fileDirs.Length > 0)
                {
                    files.AddRange(fileDirs);
                }

            }
            catch
            {
                Debug("Caught an error when getting file names!");
            }

            #region Folder_Expanded: Get Folders

            //For each directory, add to the folder view tree
            files.ForEach(filepath =>
            {
                //create file item
                var subItem = new TreeViewItem()
                {
                    //set the header as the file name
                    Header = GetFileFolderName(filepath),
                    //set tag as full path name
                    Tag = filepath
                };

                //add child subitem to parent
                item.Items.Add(subItem);
                //Debug("Subitem added to folderview");

            });

            #endregion Folder_Expanded: Get Files

        }
        #endregion Folder_Expanded
        #endregion Left Side of Panel

        #region Helper Methods:  GetFileFolderName
        /// <summary>
        /// Helper method to find the file or folder name from a full path. 
        /// </summary>
        /// <param name="filepath">The full path name</param>
        /// <returns>Returns just the last part of the filepath name (C:\Some Folder\file.png would return "file.png")</returns>
        private string GetFileFolderName(string filepath)
        {
            //if no path, return empty., 
            if (string.IsNullOrEmpty(filepath))
            {
                Debug("File Folder Name path is empty, returning empty");
                return string.Empty;
            }

            //make all slashes backslashes
            var normalizedPath = filepath.Replace('/', '\\');
            //find the last backslash in the path. 
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If only root directory, return the path itself (ex, file.png)
            if(lastIndex <= 0)
            {
                return filepath;
            }

            //return the string name after the last backslash.
            return filepath.Substring(lastIndex + 1);

        }

        #endregion

        #region Right Side of panel: UI manf static form.
        /// <summary>
        /// Right side of the panel containing UI manf static form and information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            Debug("ApplyButton_Clicked and description field accessed.");
            MessageBox.Show($"The description of the item is: \n\n{this.DescrTextBox.Text}");
        }

        /// <summary>
        /// ResetButton method to reset all the fields in the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            //example:  sets all checked boxes from work centers to flase (unchecked)
            this.WeldChBox.IsChecked = this.AssemblyChBox.IsChecked = this.PlasmaChBox.IsChecked = this.LaserChBox.IsChecked =
                this.PurchaseChBox.IsChecked = this.LatheChBox.IsChecked = this.DrillChBox.IsChecked = this.FoldChBox.IsChecked =
                this.RollChBox.IsChecked = this.SawChBox.IsChecked = false;
            //clear the description test box
            this.DescrTextBox.Clear();
            //clear the materials dropdown, length, mass, set defaults to finish, purchase info, supplier name/code/note
            this.MaterialDropDown.SelectedIndex = 0;
            this.LengthTextBox.Clear();
            this.MassTextBox.Clear();
            this.FinishDropDown.SelectedIndex = 0;
            this.PurchaseInfoDropDown.SelectedIndex = 0;
            this.SupplierNameTextBox.Clear();
            this.SupplierCodeTextBox.Clear();
            this.NoteTextBox.Clear();
            Debug("All fields reset  in UI");
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Debug("Refresh Button Pressed!");
            MessageBox.Show("Placeholder:  Refresh Needs functionality");
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //generic adding to field just to make sure we can get some input we want in the field. 
            this.LengthTextBox.Text += ((CheckBox)sender).Content + " ";
            Debug("CheckBox Checked function accessed and populated lengthTextBox field.");
        }

        #endregion

        #region Debugger
        /// <summary>
        /// Debug for testing purposes.  Writes out to console with a message.
        /// </summary>
        /// <param name="message">  Message to pass through the debugger. </param> 
        private void Debug(String message)
        {
            //this is called an interpolated string.  Basically the message from debug gets passed in the { }.
            //      format:
            //          $ + some text + {message being passed as a parameter}
            System.Diagnostics.Debug.WriteLine($"Debug: {message}");
        }
        #endregion

    }
}
