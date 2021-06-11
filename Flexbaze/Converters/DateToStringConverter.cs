using System;
using System.Globalization;
using Xamarin.Forms;

namespace Flexbaze.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    DateTime Date = (DateTime)value;
                    return Date.ToString("dd-MMM-yyyy");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al convertir fecha, " + ex.Message);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
