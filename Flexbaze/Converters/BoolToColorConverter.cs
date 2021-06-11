using System;
using System.Globalization;
using Xamarin.Forms;

namespace Flexbaze.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool strStatus = (bool)value;

            switch (strStatus)
            {
                case true:
                    return Color.FromHex("#336ef4");
                default:
                    return Color.FromHex("#202850");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
