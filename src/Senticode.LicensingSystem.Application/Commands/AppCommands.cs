using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Unity;
namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands : AppCommandsBase
    {
        private readonly DialogProvider _dialogProvider;

        public AppCommands(
            IUnityContainer container,
            DialogProvider dialogProvider)
        {
            container.RegisterInstance(this);
            _dialogProvider = dialogProvider;
        }
    }
}
