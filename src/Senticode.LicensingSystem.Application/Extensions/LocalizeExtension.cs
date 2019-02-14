using System;
using System.Windows.Data;
using System.Windows.Markup;
using Senticode.LicensingSystem.Application.Converters;

namespace Senticode.LicensingSystem.Application.Extensions
{
    public class LocalizeExtension : MarkupExtension
    {
        private static readonly Lazy<LocalizeStringConverter> _converter =
            new Lazy<LocalizeStringConverter>(() => new LocalizeStringConverter());

        public Binding Binding { get; set; }
        public string Key { get; set; }

        public LocalizeExtension()
        {
        }

        public LocalizeExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (!string.IsNullOrEmpty(Key))
            {
                return Key.L();
            }

            if (Binding == null || !(Binding is Binding))
            {
                throw new InvalidOperationException("Binding must be probably set.");
            }

            Binding.Converter = _converter.Value;
            return Binding.ProvideValue(serviceProvider);
        }
    }
}
