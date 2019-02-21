using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.LicensingSystem.Core.Services.Services;
using Senticode.WPF.Tools.Core.Interfaces;
using Unity;
using Unity.Injection;

namespace Senticode.LicensingSystem.Core.Services
{
    public class ServicesInitializer : IInitializer
    {
        public IInitializer Initialize(IUnityContainer container)
        {
            container.RegisterSingleton<ILocalize, LocalizeService>(new InjectionConstructor(container));
            return this;
        }
    }
}
