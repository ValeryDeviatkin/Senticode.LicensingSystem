using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Senticode.LicensingSystem.Application.Behaviors
{
    class ListViewColumnResizeBehavior : Behavior<ListView>
    {
        private GridView _gridView;
        private int _columnCount;

        protected override void OnAttached()
        {
            base.OnAttached();
            _gridView = AssociatedObject.View as GridView;

            if (_gridView != null)
            {
                _columnCount = _gridView.Columns.Count;
                AssociatedObject.SizeChanged += ListViewOnSizeChanged;
            }
        }

        private void ListViewOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            var columnWidth = AssociatedObject.ActualWidth / _columnCount;
            
            foreach (var column in _gridView.Columns)
            {
                column.Width = columnWidth;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (_gridView != null)
            {
                AssociatedObject.SizeChanged -= ListViewOnSizeChanged;
            }
        }
    }
}
