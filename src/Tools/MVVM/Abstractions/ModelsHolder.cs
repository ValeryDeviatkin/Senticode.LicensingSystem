using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Senticode.WPF.Tools.MVVM.Abstractions
{
    public abstract class ModelsHolder : ModelBase
    {
        private readonly Lazy<Dictionary<string, ModelBase>> _models =
            new Lazy<Dictionary<string, ModelBase>>(() => new Dictionary<string, ModelBase>());

        public void SetModel(ModelBase model)
        {
            _models.Value.Add(model.GetType().Name, model);
            var weekmh = new WeakReference<ModelsHolder>(this);

            model.PropertyChanged += (sender, args) =>
            {
                ModelsHolder mh;
                weekmh.TryGetTarget(out mh);
                mh?.OnPropertyChanged(args.PropertyName);
            };

            model.PropertyChanging += (sender, args) =>
            {
                ModelsHolder mh;
                weekmh.TryGetTarget(out mh);
                mh?.OnPropertyChanging(args.PropertyName);
            };
        }

        protected T GetFromModel<TModel, T>(Func<TModel, T> func)
            where TModel : ModelBase
        {
            return func((TModel) _models.Value[typeof(TModel).Name]);
        }

        protected T GetFromModel<TModel, T>([CallerMemberName] string propertyName = "")
            where TModel : ModelBase
        {
            var model = _models.Value[typeof(TModel).Name];
            return (T) model.GetValue(propertyName);
        }
    }
}