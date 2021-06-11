using System;
using System.Globalization;
using Xamarin.Forms;

namespace Flexbaze.Converters
{
    public class IncidentesToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() + " " + Resources.AppResources.IncidentsButton;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
