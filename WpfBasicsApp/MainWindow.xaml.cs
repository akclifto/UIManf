using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasicsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description of the item is: \n\n{this.DescrTextBox.Text}");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            //example:  sets all checked boxes from work centers to flase (unchecked)
            this.WeldChBox.IsChecked = this.AssemblyChBox.IsChecked = this.PlasmaChBox.IsChecked = this.LaserChBox.IsChecked =
                this.PurchaseChBox.IsChecked = this.LatheChBox.IsChecked = this.DrillChBox.IsChecked = this.FoldChBox.IsChecked = 
                this.RollChBox.IsChecked = this.SawChBox.IsChecked = false;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Placeholder:  Refresh Needs functionality");
        }
    }
}
