using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Common.Models;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels
{
    internal class MainViewModel : ViewModelBase<AppCommandsBase, AppSettingsBase>
    {
        #region EntityMenuItems property

        /// <summary>
        /// Gets or sets the EntityMenuItems value.
        /// </summary>
        public MenuItemViewModel[] EntityMenuItems
        {
            get { return _entityMenuItems; }
            set { SetProperty(ref _entityMenuItems, value); }
        }

        /// <summary>
        /// EntityMenuItems property data.
        /// </summary>
        private MenuItemViewModel[] _entityMenuItems;

        #endregion

        public MainViewModel(
            IUnityContainer container, 
            ViewModelsProvider provider) : base(container)
        {
            container.RegisterInstance(this);

            EntityMenuItems = new []
            {
                provider.GetMenuItemViewModel(typeof(Position)),
                provider.GetMenuItemViewModel(typeof(Product)),
                provider.GetMenuItemViewModel(typeof(Device)),
                provider.GetMenuItemViewModel(typeof(KeyUser)),
                provider.GetMenuItemViewModel(typeof(Key)),
                provider.GetMenuItemViewModel(typeof(Organization)),
                provider.GetMenuItemViewModel(typeof(Contract)),
                provider.GetMenuItemViewModel(typeof(User))
            };
        }
    }
}
