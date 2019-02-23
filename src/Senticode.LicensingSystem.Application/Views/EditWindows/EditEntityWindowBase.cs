using System.Windows;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Application.Views.EditWindows
{
    public abstract class EditEntityWindowBase<TEntity> : Window
        where TEntity : ModelBase
    {
    }
}
