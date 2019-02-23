using System.Windows;
using Senticode.LicensingSystem.Common.Models;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditPositionWindowxaml : EditEntityWindowBase<Position>
    {
        public EditPositionWindowxaml()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
