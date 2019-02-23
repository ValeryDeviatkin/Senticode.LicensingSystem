using System.Resources;
using Senticode.LicensingSystem.Application.Commands;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.Properties;
using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Application.ViewModels.Entities;
using Senticode.LicensingSystem.Application.Views;
using Senticode.LicensingSystem.Application.Views.EditWindows;
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

        public void Initialize(IUnityContainer container)
        {
            new AssemblyAgregator().Initialize(container);

            //services
            container.RegisterSingleton<DialogProvider>(new InjectionConstructor(container));
            container.RegisterSingleton<ViewModelsProvider>(new InjectionConstructor(container));

            //Maintetance
            container.RegisterInstance(
                new ResourceManager("Senticode.LicensingSystem.Application.Properties.Resources",
                    typeof(Resources).Assembly));

            container.RegisterSingleton<AppSettingsBase, AppSettings>(new InjectionConstructor(container));
            container.RegisterSingleton<AppCommandsBase, AppCommands>(new InjectionConstructor(
                container,
                container.Resolve<DialogProvider>()));

            //Windows
            container.RegisterType<EditEntityWindowBase<User>, EditUserWindow>();
            container.RegisterType<EditEntityWindowBase<Key>, EditKeyWindow>();
            container.RegisterType<EditEntityWindowBase<KeyUser>, EditKeyUserWindow>();
            container.RegisterType<EditEntityWindowBase<Device>, EditDeviceWindow>();
            container.RegisterType<EditEntityWindowBase<Contract>, EditContractWindow>();
            container.RegisterType<EditEntityWindowBase<Product>, EditProductWindow>();
            container.RegisterType<EditEntityWindowBase<Organization>, EditOrganizationWindow>();
            container.RegisterType<EditEntityWindowBase<Position>, EditPositionWindowxaml>();
            container.RegisterType<FindKeysWindow>();
            
            //ViewModels
            container.RegisterType<EntityViewModelBase<Position>, PositionViewModel>();
            container.RegisterType<EntityViewModelBase<Product>, ProductViewModel>();
            container.RegisterType<EntityViewModelBase<Organization>, OrganizationViewModel>();
            container.RegisterType<EntityViewModelBase<Key>, KeyViewModel>();
            container.RegisterType<EntityViewModelBase<KeyUser>, KeyUserViewModel>();
            container.RegisterType<EntityViewModelBase<Contract>, ContractViewModel>();
            container.RegisterType<EntityViewModelBase<User>, UserViewModel>();
            container.RegisterType<EntityViewModelBase<Device>, DeviceViewModel>();

            container.RegisterType<MenuItemViewModel>();
            container.RegisterSingleton<ViewModelBase, MainViewModel>(new InjectionConstructor(
                container,
                container.Resolve<ViewModelsProvider>()));
        }
    }
}