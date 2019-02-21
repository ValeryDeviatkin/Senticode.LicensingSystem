using System;
using Senticode.WPF.Tools.Core;
using Unity;

namespace Senticode.WPF.Tools.MVVM.Extensions
{
    public static class ModelBaseEx
    {
        public static TViewModel ToViewModel<TViewModel>(this ModelBase model)
            where TViewModel : ViewModelBase
        {
            var vm = ServiceLocator.Container.Resolve<TViewModel>();
            vm.SetModel(model);
            return vm;
        }

        public static ViewModelBase ToViewModel(this ModelBase model)
        {
            throw new NotImplementedException();
            var type = model.GetType();
            var vm = (ViewModelBase) ServiceLocator.Container.Resolve(type);
            vm?.SetModel(model);
            return vm;
        }
    }
}
