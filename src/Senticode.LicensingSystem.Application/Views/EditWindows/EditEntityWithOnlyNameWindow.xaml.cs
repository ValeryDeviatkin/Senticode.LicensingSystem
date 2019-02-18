using System.Windows;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditEntityWithOnlyNameWindow : Window
    {
        public EditEntityWithOnlyNameWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
