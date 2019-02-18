using System.Windows;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditKeyUserWindow : Window
    {
        public EditKeyUserWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
