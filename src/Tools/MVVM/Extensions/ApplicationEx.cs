using System.Windows;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.WPF.Tools.MVVM.Extensions
{
    public static class ApplicationEx
    {
        public static void SetMainWindow<TWindow, TViewModel>(this ApplicationBase app)
            where TWindow : Window
            where TViewModel : ViewModelBase
        {
            if (!app.Container.IsRegistered<TWindow>())
            {
                app.Container.RegisterType<TWindow>();
            }
            if (!app.Container.IsRegistered<TViewModel>())
            {
                app.Container.RegisterType<TViewModel>();
            }

            app.MainWindow = app.Container.Resolve<TWindow>();
            if (app.MainWindow != null)
            {
                app.MainWindow.DataContext = app.Container.Resolve<TViewModel>();
            }
        }
    }
}
