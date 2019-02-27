using Senticode.LicensingSystem.Core.Database;
using Senticode.LicensingSystem.Core.Services;
using Senticode.WPF.Tools.Core.Interfaces;
using Unity;

namespace Senticode.LicensingSystem.Core.AssemblyAgregator
{
    public class AssemblyAgregator : IInitializer
    {
        public IInitializer Initialize(IUnityContainer container)
        {
            new DatabaseServicesinitializer().Initialize(container);
            new ServicesInitializer().Initialize(container);

            return this;
        }
    }
}
