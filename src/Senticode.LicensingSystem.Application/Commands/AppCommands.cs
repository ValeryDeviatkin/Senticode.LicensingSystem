using System;
using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands : AppCommandsBase
    {
        private readonly IUnityContainer _container;
        private readonly DialogProvider _dialogProvider;
        private readonly Lazy<MainViewModel> _mainViewModel;

        public AppCommands(
            IUnityContainer container,
            DialogProvider dialogProvider)
        {
            container.RegisterInstance(this);
            _container = container;
            _dialogProvider = dialogProvider;
            _mainViewModel = new Lazy<MainViewModel>(() => container.Resolve<MainViewModel>());
        }
    }
}
