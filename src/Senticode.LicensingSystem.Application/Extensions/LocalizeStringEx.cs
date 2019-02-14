using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Resources;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Extensions
{
    public static class LocalizeStringEx
    {
        private static ResourceManager _resourceManager;
        private static ILocalize _localize;

        public static void Initialize()
        {
            _localize = ServiceLocator.Container.Resolve<ILocalize>();
            _resourceManager = ServiceLocator.Container.Resolve<ResourceManager>();
        }

        public static string L(this string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            var resourceKey = value.Replace(' ', '_');

            if (string.IsNullOrWhiteSpace(resourceKey))
            {
                return string.Empty;
            }

            try
            {
                var translate = _resourceManager.GetString(resourceKey, _localize.CultureContext) ?? resourceKey;
                return translate;
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex);
                return _resourceManager.GetString(resourceKey, new CultureInfo(LocalizeSettings.DefaultLanguage));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return resourceKey;
            }
        }
    }
}
