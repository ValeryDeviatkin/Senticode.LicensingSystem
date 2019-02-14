using Senticode.LicensingSystem.Application.AppMain;
using Senticode.LicensingSystem.Application.Commands;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels
{
    internal class MainViewModel : ViewModelBase<AppCommands, AppSettings>
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);
        }
    }
}
