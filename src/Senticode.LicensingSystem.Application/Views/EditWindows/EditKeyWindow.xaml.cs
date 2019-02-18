using System.Windows;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditKeyWindow : Window
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
