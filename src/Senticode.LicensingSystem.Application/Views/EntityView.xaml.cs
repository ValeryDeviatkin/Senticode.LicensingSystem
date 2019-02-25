using System.Windows.Controls;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.LicensingSystem.Application.Views
{
    public partial class EntityView : UserControl
    {
        public EntityView()
        {
            InitializeComponent();
            var container = ServiceLocator.Container;
            container.RegisterInstance(this);
        }
    }
}
