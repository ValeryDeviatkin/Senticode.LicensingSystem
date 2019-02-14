using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using Senticode.LicensingSystem.Application.Extensions;

namespace Senticode.LicensingSystem.Application.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class LocalizeStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<string>)
            {
                return ((IEnumerable<string>) value).Select(x => x.ToString().L()).ToArray();
            }

            if (value is string || value is Enum)
            {
                return value?.ToString().L();
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
