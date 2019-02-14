using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands : AppCommandsBase
    {
        public AppCommands(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }
    }
}
