using System.Windows;
using Senticode.LicensingSystem.Application.Views.EditWindows.Abstraction;
using Senticode.LicensingSystem.Common.Models;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditContractWindow : EditEntityWindowBase<Contract>
    {
        public EditContractWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
