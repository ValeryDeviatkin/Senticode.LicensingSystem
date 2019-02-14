using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM.Abstractions;
using Unity;

namespace Senticode.WPF.Tools.MVVM
{
    public abstract class ViewModelBase : ModelsHolder
    {
        protected ViewModelBase(IUnityContainer container)
        {
            Container = container;
        }

        public IUnityContainer Container { get; }
    }

    public abstract class ViewModelBase<TAppCommands> : ViewModelBase
        where TAppCommands : AppCommandsBase
    {
        protected ViewModelBase(IUnityContainer container) : base(container)
        {
            AppCommands = container.Resolve<AppCommandsBase>();
        }

        public AppCommandsBase AppCommands { get; }
    }

    public abstract class ViewModelBase<TAppCommands, TAppSettings> : ViewModelBase<TAppCommands>
        where TAppCommands : AppCommandsBase
        where TAppSettings : AppSettingsBase
    {
        protected ViewModelBase(IUnityContainer container) : base(container)
        {
            AppSettings = container.Resolve<AppSettingsBase>();
        }

        public AppSettingsBase AppSettings { get; }
    }
}