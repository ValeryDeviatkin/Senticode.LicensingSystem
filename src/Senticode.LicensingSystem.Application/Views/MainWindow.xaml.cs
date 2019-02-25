using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Common.Models;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var container = ServiceLocator.Container;
            var mainViewModel = container.Resolve<MainViewModel>();
            container.Resolve<EntityListViewModel<Key>>().Initialize();
            container.Resolve<EntityListViewModel<KeyUser>>().Initialize();
            container.Resolve<EntityListViewModel<Product>>().Initialize();
            container.Resolve<EntityListViewModel<Position>>().Initialize();
            container.Resolve<EntityListViewModel<User>>().Initialize();
            container.Resolve<EntityListViewModel<Organization>>().Initialize();
            container.Resolve<EntityListViewModel<Device>>().Initialize();
            container.Resolve<EntityListViewModel<Contract>>().Initialize();
            DataContext = mainViewModel;
        }
    }
}
