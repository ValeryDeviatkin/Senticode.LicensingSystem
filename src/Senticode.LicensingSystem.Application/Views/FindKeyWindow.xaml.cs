using System.Windows;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Views
{
    public partial class FindKeysWindow : Window
    {
        public FindKeysWindow()
        {
            InitializeComponent();
            ServiceLocator.Container.RegisterInstance(this);
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
