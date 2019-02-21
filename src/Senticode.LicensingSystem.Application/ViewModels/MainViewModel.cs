using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels
{
    internal class MainViewModel : ViewModelBase<AppCommandsBase, AppSettingsBase>
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }
    }
}
