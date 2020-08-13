using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfBasicsApp
{
    /// <summary>
    /// Class to convert header type to use the corresponding correct image (drive, file, folder_closed, folder_open)
    /// </summary>
    /// 
    [ValueConversion(typeof(string), typeof(BitmapImage))]

    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        /// <summary>
        /// Convert value of full path to an image type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //get the full path of the value
            var path = (string)value;

            //check for null
            if (path == null)
            {
                return null;
            }

            //default image used if can't find the binded image path
            var image = "Images/file.png";

            // Get the name of the file or folder
            var name = MainWindow.GetFileFolderName(path);


            //Check value of name, if blank  (""), then we assume its a drive (file/folders will not be blank)
            if(string.IsNullOrEmpty(name))
            {
                image = "Images/drive.png";
            }
            //if the path and attirbutes contains a directory, then we know it's a folder.
            if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "Images/folder_closed.png";
            }

            //int count = 0;
            //foreach (char i in name)
            //{
            //    if (i.Equals('\\'))
            //    {
            //        count++;
            //    }
            //}
            ////check if we are in a subdirectory and if so, use folder open icon.
            //if (count >= 3)
            //{
            //    image = "Images/folder_open.png";
            //}



                //hard coding "Images" folder path, specific to WPF as way to access resources using URIs
                return new BitmapImage(new Uri($"pack://application:,,,/{image}"));

        }

        /// <summary>
        /// Convert image back to value.  Not suported for this type of use.  
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
