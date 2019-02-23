using System.Windows;
using Senticode.LicensingSystem.Common.Models;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public partial class EditProductWindow : EditEntityWindowBase<Product>
    {
        public EditProductWindow()
        {
            InitializeComponent();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
