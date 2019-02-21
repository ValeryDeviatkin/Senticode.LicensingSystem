using System;
using System.Windows;
using Unity;

namespace Senticode.WPF.Tools.Core
{
    public abstract class ApplicationBase : Application
    {
        protected ApplicationBase(IUnityContainer container)
        {
            Container = container;
        }

        public IUnityContainer Container { get; }
    }
    
    public abstract class ApplicationBase<TAppSettings, TAppCommands> : ApplicationBase
        where TAppSettings : AppSettingsBase
        where TAppCommands : AppCommandsBase
    {

        private Lazy<TAppCommands> _appCommands;
        private Lazy<TAppSettings> _appSettings;

        protected ApplicationBase() : this(ServiceLocator.Container)
        {

        }

        protected ApplicationBase(IUnityContainer container) : base(container)
        {
           
        }

        protected virtual void RegisterTypes()
        {
            InternalInitialaize(Container);
        }
        
        public TAppSettings AppSettings => _appSettings.Value;
        public TAppCommands AppCommands => _appCommands.Value;

        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterTypes();
        }

        #endregion

        private void InternalInitialaize(IUnityContainer container)
        {
            container.RegisterType<AppSettingsBase, TAppSettings>();
            container.RegisterType<AppCommandsBase, TAppCommands>();

            _appCommands =
                new Lazy<TAppCommands>(() => container.Resolve<TAppCommands>());
            _appSettings =
                new Lazy<TAppSettings>(() => container.Resolve<TAppSettings>());
        }
    }
}