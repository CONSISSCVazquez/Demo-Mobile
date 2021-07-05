using Flexbaze.Resources;
using System;
using System.Globalization;

namespace Flexbaze.Converters
{
    public class MonthNumberToStringConverter
    {
        public string Convert(string value)
        {
            try
            {
                string strMonth = "";
                if (value != null)
                {
                    switch (value)
                    {
                        case "01":
                            strMonth = AppResources._01;
                            break;
                        case "02":
                            strMonth = AppResources._02;
                            break;
                        case "03":
                            strMonth = AppResources._03;
                            break;
                        case "04":
                            strMonth = AppResources._04;
                            break;
                        case "05":
                            strMonth = AppResources._05;
                            break;
                        case "06":
                            strMonth = AppResources._06;
                            break;
                        case "07":
                            strMonth = AppResources._07;
                            break;
                        case "08":
                            strMonth = AppResources._08;
                            break;
                        case "09":
                            strMonth = AppResources._09;
                            break;
                        case "10":
                            strMonth = AppResources._10;
                            break;
                        case "11":
                            strMonth = AppResources._11;
                            break;
                        case "12":
                            strMonth = AppResources._12;
                            break;
                    }
                    return strMonth;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al convertir el mes, " + ex.Message);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
