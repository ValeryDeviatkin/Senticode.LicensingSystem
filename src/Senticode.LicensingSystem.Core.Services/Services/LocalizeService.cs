using System.Collections.Generic;
using System.Globalization;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.MVVM.Abstractions;
using Unity;

namespace Senticode.LicensingSystem.Core.Services.Services
{
    internal class LocalizeService : ObesrvableObject, ILocalize
    {
        public LocalizeService(IUnityContainer container)
        {
            container.RegisterInstance(this);
            CultureContext = AvailableImplementation[1];
        }

        #region CultureContext property

        /// <summary>
        /// Gets or sets the CultureContext value.
        /// </summary>
        public CultureInfo CultureContext
        {
            get { return _cultureContext; }
            set { SetProperty(ref _cultureContext, value); }
        }

        /// <summary>
        /// CultureContext property data.
        /// </summary>
        private CultureInfo _cultureContext;

        #endregion

        public List<CultureInfo> AvailableImplementation { get; } = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("ru")
        };
    }
}
