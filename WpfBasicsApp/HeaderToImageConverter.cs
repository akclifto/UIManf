using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfBasicsApp
{
    /// <summary>
    /// Class to convert header type to use the corresponding correct image (drive, file, folder_closed, folder_open)
    /// </summary>
    ///
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
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
            //default image used if can't find the binded image path
            var image = "Images/file.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/drive.png";
                    break;

                case DirectoryItemType.Folder:
                    image = "Images/folder_closed.png";
                    break;
            }

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