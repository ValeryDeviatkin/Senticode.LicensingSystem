using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.AppMain
{
    public class AppSettings : AppSettingsBase
    {
        private readonly IUnityContainer _container;
        private ILocalize _localizeService;

        public ILocalize LocalizeService => _localizeService ??
                                            (_localizeService = _container.Resolve<ILocalize>());

        public AppSettings(IUnityContainer container)
        {
            container.RegisterInstance(this);
            _container = container;
        }
    }
}
