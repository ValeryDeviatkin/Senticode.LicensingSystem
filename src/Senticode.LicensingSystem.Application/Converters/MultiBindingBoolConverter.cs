using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Senticode.LicensingSystem.Application.Converters
{
    [ValueConversion(typeof(bool[]), typeof(bool))]
    internal class MultiBindingBoolConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var condition in values)
            {
                if ((bool) condition) return false;
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
