using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfBasicsApp
{
    [AddINotifyPropertyChangedInterface]
    public class Class1Test : INotifyPropertyChanged
    {
        //private string mytest;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; }

        //manual way to get/set property changed event. Can use NuGet tool Fody.PropertyChanged to automatically do this.
        //{
        //    get
        //    {
        //        return mytest;
        //    }
        //    set
        //    {
        //        if (mytest == value)
        //        {
        //            return;
        //        }
        //        mytest = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
        //    }
        //}

        //demo to show binding of property Test to element in UI.  Making a loop that increments value of int i every 1/5 second.  Should get displayed
        //automatically from the propertyChanged INotifier above.
        public Class1Test()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(200);
                    //increment i value to display on button as property.
                    Test = (i++).ToString();
                }
            });
        }

        //Testing the binding property
        //public override string ToString()
        //{
        //    return "Hello World!";
        //}
    }
}