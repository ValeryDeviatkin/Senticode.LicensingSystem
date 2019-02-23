using System;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Common.Interfaces.Enums;
using Unity;
using Unity.Resolution;

namespace Senticode.LicensingSystem.Application.Services
{
    internal class ViewModelsProvider
    {
        private readonly IUnityContainer _container;

        public ViewModelsProvider(IUnityContainer container)
        {
            container.RegisterInstance(this);
            _container = container;
        }

        public MenuItemViewModel GetMenuItemViewModel(Type type)
        {
            return _container.Resolve<MenuItemViewModel>(
                new ParameterOverride(Param.container.ToString(), _container),
                new ParameterOverride(Param.type.ToString(), type));
        }
    }
}
