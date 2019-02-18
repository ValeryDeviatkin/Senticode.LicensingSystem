using Senticode.LicensingSystem.Application.AppMain;
using Senticode.LicensingSystem.Application.Commands;
using Senticode.LicensingSystem.Application.Views.EditWindows;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels
{
    internal class MainViewModel : ViewModelBase<AppCommands, AppSettings>
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
            container.RegisterInstance(this);

            //dialog tests
            //container.Resolve<EditEntityWithOnlyNameWindow>().ShowDialog();
            //container.Resolve<EditContractWindow>().ShowDialog();
            //container.Resolve<EditDeviceWindow>().ShowDialog();
            //container.Resolve<EditKeyUserWindow>().ShowDialog();
            //container.Resolve<EditKeyWindow>().ShowDialog();
            //container.Resolve<EditUserWindow>().ShowDialog();
        }
    }
}
