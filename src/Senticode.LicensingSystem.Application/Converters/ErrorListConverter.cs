using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Senticode.LicensingSystem.Application.Converters
{
    [ValueConversion(typeof(IEnumerable<ValidationError>), typeof(string))]
    internal class ErrorListConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = null;

            foreach (var validationError in (IEnumerable<ValidationError>) value)
            {
                result += validationError.ErrorContent + "\n";
            }
            
            return result?.Remove(result.Length - 1, 1); ;
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
