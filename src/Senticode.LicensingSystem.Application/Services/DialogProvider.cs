using Unity;

namespace Senticode.LicensingSystem.Application.Services
{
    internal class DialogProvider
    {
        private readonly IUnityContainer _container;

        public DialogProvider(IUnityContainer container)
        {
            container.RegisterInstance(this);
            _container = container;
        }
    }
}
