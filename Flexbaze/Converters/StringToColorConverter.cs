using System;
using System.Globalization;
using Xamarin.Forms;

namespace Flexbaze.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string strStatus = value as string;

                if (strStatus != null)
                {
                    switch (strStatus)
                    {
                        case "0":
                            return Color.FromHex("#00a889");
                        case "1":
                            return Color.FromHex("#ea8800");
                        case "2":
                            return Color.FromHex("#d2434a");
                        default:
                            return Color.FromHex("#d2434a");
                    }

                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
