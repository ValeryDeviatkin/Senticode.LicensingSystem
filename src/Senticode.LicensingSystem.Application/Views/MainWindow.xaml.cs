using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = ServiceLocator.Container.Resolve<ViewModelBase>();
            //((MainViewModel)mainViewModel).StudentsCollectionView.CustomSort =
            //    ServiceLocator.Container.Resolve<IComparer>();
            DataContext = mainViewModel;
        }
    }
}
