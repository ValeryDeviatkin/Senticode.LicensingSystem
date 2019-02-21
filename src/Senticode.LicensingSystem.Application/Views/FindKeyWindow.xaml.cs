using System.Windows;

namespace Senticode.LicensingSystem.Application.Views
{
    public partial class FindKeysWindow : Window
    {
        public FindKeysWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
