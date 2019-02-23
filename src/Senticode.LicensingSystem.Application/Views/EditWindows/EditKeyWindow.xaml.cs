using System.Windows;
using Senticode.LicensingSystem.Common.Models;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditKeyWindow : EditEntityWindowBase<Key>
    {
        public EditKeyWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
