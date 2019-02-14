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
            ModelsHolder mh;

            model.PropertyChanged += (sender, args) =>
            {
                weekmh.TryGetTarget(out mh);
                mh?.OnPropertyChanged(args.PropertyName);
            };

            model.PropertyChanging += (sender, args) =>
            {
                weekmh.TryGetTarget(out mh);
                mh?.OnPropertyChanging(args.PropertyName);
            };
        }

        public T GetFromModel<T, TModel>(Func<TModel, T> func)
            where TModel : ModelBase
        {
            return func.Invoke((TModel) _models.Value[typeof(TModel).Name]);
        }

        public T GetFromModel<T, TModel>([CallerMemberName] string propertyName = "")
            where TModel : ModelBase
        {
            var model = _models.Value[typeof(TModel).Name];
            return (T) model.GetValue(propertyName);
        }
    }
}