using System;
using System.Globalization;
using System.Windows.Data;

namespace GesTransBand
{
    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? "Sí" : "No";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return stringValue.Equals("Sí", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
