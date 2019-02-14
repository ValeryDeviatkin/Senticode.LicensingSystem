using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.AppMain
{
    public class AppSettings : AppSettingsBase
    {
        public AppSettings(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }
    }
}
