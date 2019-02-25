using System.Windows;
using Senticode.LicensingSystem.Application.Views.EditWindows.Abstraction;
using Senticode.LicensingSystem.Common.Models;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditUserWindow : EditEntityWindowBase<User>
    {
        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
