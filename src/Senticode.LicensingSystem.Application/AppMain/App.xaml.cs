using System.Resources;
using Senticode.LicensingSystem.Application.Commands;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.Properties;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Core.AssemblyAgregator;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.Core.Interfaces;
using Senticode.WPF.Tools.MVVM;
using Unity;
using Unity.Injection;

namespace Senticode.LicensingSystem.Application.AppMain
{
    public partial class App : IInitializer
    {
        public App()
        {
            Initialize(ServiceLocator.Container);
            LocalizeStringEx.Initialize();
        }

        public void Initialize(IUnityContainer container)
        {
            //Maintetance
            container.RegisterInstance<ResourceManager>(
                new ResourceManager("Senticode.LicensingSystem.Application.Properties.Resources",
                    typeof(Resources).Assembly));
            container.RegisterSingleton<AppSettingsBase, AppSettings>(new InjectionConstructor(container));
            container.RegisterSingleton<AppCommandsBase, AppCommands>(new InjectionConstructor(container));

            //ViewModels
            container.RegisterSingleton<ViewModelBase, MainViewModel>(new InjectionConstructor(container));

            //Others
            new AssemblyAgregator().Initialize(container);
        }
    }
}
