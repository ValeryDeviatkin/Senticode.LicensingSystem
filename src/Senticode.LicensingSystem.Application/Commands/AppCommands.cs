using Senticode.LicensingSystem.Application.Services;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands : AppCommandsBase
    {
        private readonly IUnityContainer _container;
        private readonly DialogProvider _dialogProvider;

        public AppCommands(
            IUnityContainer container,
            DialogProvider dialogProvider)
        {
            container.RegisterInstance(this);
            _container = container;
            _dialogProvider = dialogProvider;
        }
    }
}
