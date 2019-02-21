using System.Resources;
using Senticode.LicensingSystem.Application.Commands;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.Properties;
using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Application.Views;
using Senticode.LicensingSystem.Application.Views.EditWindows;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.LicensingSystem.Common.Models;
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

        public IInitializer Initialize(IUnityContainer container)
        {
            new AssemblyAgregator().Initialize(container);

            //Maintetance
            container.RegisterInstance<ResourceManager>(
                new ResourceManager("Senticode.LicensingSystem.Application.Properties.Resources",
                    typeof(Resources).Assembly));

            container.RegisterSingleton<AppSettingsBase, AppSettings>(new InjectionConstructor(container));

            container.RegisterSingleton<AppCommandsBase, AppCommands>(new InjectionConstructor(
                container,
                container.Resolve<ICrud<Position>>(),
                container.Resolve<ICrud<Contract>>(),
                container.Resolve<ICrud<Device>>(),
                container.Resolve<ICrud<Key>>(),
                container.Resolve<ICrud<KeyUser>>(),
                container.Resolve<ICrud<Organization>>(),
                container.Resolve<ICrud<Product>>(),
                container.Resolve<ICrud<User>>()
            ));

            //Windows
            container.RegisterType<EditUserWindow>();
            container.RegisterType<EditKeyWindow>();
            container.RegisterType<EditKeyUserWindow>();
            container.RegisterType<EditDeviceWindow>();
            container.RegisterType<EditContractWindow>();
            container.RegisterType<EditEntityWithOnlyNameWindow>();
            container.RegisterType<FindKeysWindow>();

            //ViewModels
            container.RegisterSingleton<ViewModelBase, MainViewModel>(new InjectionConstructor(container));

            //services
            container.RegisterSingleton<DialogProvider>(new InjectionConstructor(container));
            
            return this;
        }
    }
}
