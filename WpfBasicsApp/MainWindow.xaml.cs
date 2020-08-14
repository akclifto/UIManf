using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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

            this.DataContext = new Class1();

        }
        #endregion

        #region Left Side of Panel

        #endregion Left Side of Panel


        #region Right Side of panel: UI manf static form.
        /// <summary>
        /// Right side of the panel containing UI manf static form and information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //Debug("ApplyButton_Clicked and description field accessed.");
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
            //Debug("All fields reset  in UI");
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            //Debug("Refresh Button Pressed!");
            MessageBox.Show("Placeholder:  Refresh Needs functionality");
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //generic adding to field just to make sure we can get some input we want in the field. 
            this.LengthTextBox.Text += ((CheckBox)sender).Content + " ";
            //Debug("CheckBox Checked function accessed and populated lengthTextBox field.");
        }

        #endregion

    }
}
