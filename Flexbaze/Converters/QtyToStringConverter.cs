using System;
using System.Globalization;
using Xamarin.Forms;

namespace Flexbaze.Converters
{
    public class QtyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int qty = int.Parse(value.ToString());
            if (qty == 1)
                return qty.ToString() + " " + Resources.AppResources.ElementLabel;
            else
                return qty.ToString() + " " + Resources.AppResources.ElementsLabel;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
