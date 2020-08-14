using PropertyChanged;
using System.ComponentModel;

namespace WpfBasicsApp
{
    /// <summary>
    /// Here is the base view model that executes property changed events as needed. 
    /// </summary>
    //Fody.propertyChanged weaver 
    [AddINotifyPropertyChangedInterface]



    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event changes when any child property has its value changed. 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


    }
}
