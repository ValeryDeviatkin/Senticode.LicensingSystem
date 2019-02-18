using System.Windows;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditContractWindow : Window
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
