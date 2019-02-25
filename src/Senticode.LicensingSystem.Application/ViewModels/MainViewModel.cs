using System.Linq;
using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.LicensingSystem.Common.Models;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels
{
    internal class MainViewModel : ViewModelBase<AppCommandsBase, AppSettingsBase>
    {
        public MainViewModel(
            IUnityContainer container,
            ViewModelsProvider provider) : base(container)
        {
            container.RegisterInstance(this);

            EntityMenuItems = new[]
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

        #region EntityMenuItems property

        /// <summary>
        ///     Gets or sets the EntityMenuItems value.
        /// </summary>
        public MenuItemViewModel[] EntityMenuItems
        {
            get { return _entityMenuItems; }
            set { SetProperty(ref _entityMenuItems, value); }
        }

        /// <summary>
        ///     EntityMenuItems property data.
        /// </summary>
        private MenuItemViewModel[] _entityMenuItems;

        #endregion

        #region EntityListViewModel property

        /// <summary>
        /// Gets or sets the EntityListViewModel value.
        /// </summary>
        public ViewModelBase<AppCommandsBase> EntityListViewModel
        {
            get { return _entityListViewModel; }
            set { SetProperty(ref _entityListViewModel, value); }
        }

        /// <summary>
        /// EntityListViewModel property data.
        /// </summary>
        private ViewModelBase<AppCommandsBase> _entityListViewModel;

        #endregion

        public string[] PositionNames
        {
            get
            {
                return Container.Resolve<ICrud<Position>>().LocalEntities
                    .Select(x => x.PositionName).ToArray();
            }
        }

        public string[] OrganizationNames
        {
            get
            {
                return Container.Resolve<ICrud<Organization>>().LocalEntities
                    .Select(x => x.OrganizationName).ToArray();
            }
        }

        public string[] ProductNames
        {
            get
            {
                return Container.Resolve<ICrud<Product>>().LocalEntities
                    .Select(x => x.ProductName).ToArray();
            }
        }

        public string[] DeviceSerials
        {
            get
            {
                return Container.Resolve<ICrud<Device>>().LocalEntities
                    .Select(x => x.DeviceSerial).ToArray();
            }
        }

        public string[] KeyUserNames
        {
            get
            {
                return Container.Resolve<ICrud<KeyUser>>().LocalEntities
                    .Select(x => x.KeyUserName).ToArray();
            }
        }
    }
}