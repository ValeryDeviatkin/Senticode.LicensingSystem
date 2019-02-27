using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.ViewModels.Abstraction;

namespace Senticode.LicensingSystem.Application.Behaviors
{
    internal class ListViewColumnBehavior : Behavior<ListView>
    {
        private GridView _gridView;
        private readonly List<GridViewColumn> _columns = new List<GridViewColumn>();
        private GridViewColumn[] _startColumns;

        protected override void OnAttached()
        {
            base.OnAttached();
            _gridView = AssociatedObject.View as GridView;
            if (_gridView == null) return;
            _startColumns = _gridView.Columns.ToArray();
            AssociatedObject.SizeChanged += ListViewOnSizeChanged;
            AssociatedObject.DataContextChanged += AssociatedObjectOnDataContextChanged;
        }

        private void AssociatedObjectOnDataContextChanged(object sender,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (_gridView == null) return;
            var viewModel = AssociatedObject.DataContext as IPropertyNames;
            if (viewModel == null) return;
            _gridView.Columns.Clear();
            _columns.Clear();

            foreach (var column in _startColumns)
            {
                _gridView.Columns.Add(column);
            }
            
            foreach (var name in viewModel.PropertyNames)
            {
                _columns.Add(new GridViewColumn
                {
                    Header = name.L(),
                    DisplayMemberBinding = new Binding(name)
                });

                _gridView.Columns.Add(_columns.Last());
            }

            ListViewOnSizeChanged(AssociatedObject, null);
            AssociatedObject.UpdateLayout();
        }

        private void ListViewOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            if (_gridView == null) return;
            var columnWidth = AssociatedObject.ActualWidth / _gridView.Columns.Count;
            
            foreach (var column in _gridView.Columns)
            {
                column.Width = columnWidth;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (_gridView == null) return;
            AssociatedObject.SizeChanged -= ListViewOnSizeChanged;
            AssociatedObject.DataContextChanged -= AssociatedObjectOnDataContextChanged;
        }
    }
}
