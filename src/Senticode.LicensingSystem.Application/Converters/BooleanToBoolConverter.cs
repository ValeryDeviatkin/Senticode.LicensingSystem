using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using Boolean = Senticode.LicensingSystem.Common.Interfaces.Enums.Boolean;

namespace Senticode.LicensingSystem.Application.Converters
{
    [ValueConversion(typeof(Boolean), typeof(bool))]
    public class BooleanToBoolConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return bool.Parse(value.ToString().ToLower());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (bool) value;
            return b ? Boolean.True : Boolean.False;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
