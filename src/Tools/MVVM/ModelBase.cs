using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Senticode.WPF.Tools.Core.Helpers;
using Senticode.WPF.Tools.MVVM.Abstractions;

namespace Senticode.WPF.Tools.MVVM
{
    public abstract class ModelBase : ObesrvableObject
    {
        private readonly Dictionary<string, PropertyInfo> _properties;

        protected ModelBase()
        {
            _properties = GetType().GetPublicProperties()
                .ToDictionary(x => x.Name, x => x);
        }

        protected internal object GetValue(string property)
        {
            PropertyInfo propertyInfo;

            if (_properties.TryGetValue(property, out propertyInfo))
            {
                return propertyInfo.GetValue(this);
            }

            throw new PropertyNotFoundException($"{GetType().FullName} not contains property of {property}.");
        }
    }

    internal class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string message) : base(message)
        {
        }
    }
}