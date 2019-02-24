using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Senticode.WPF.Tools.MVVM.Abstractions;
using Senticode.WPF.Tools.Core.Helpers;

namespace Senticode.WPF.Tools.MVVM
{
    public abstract class ModelBase: ObesrvableObject
    {
        private const string INDEXER_PROPERTY_NAME = "Item"; //todo crutch

        protected Dictionary<string, PropertyInfo> ModelProperties { get; }

        protected ModelBase()
        {
            ModelProperties = GetType().GetPublicProperties()
                .Where(x => !x.Name.Equals(INDEXER_PROPERTY_NAME))
                .ToDictionary(x => x.Name, x => x);
        }

        protected internal object GetValue(string property)
        {
            PropertyInfo propertyInfo;

            if (ModelProperties.TryGetValue(property, out propertyInfo))
            {
                return propertyInfo.GetValue(this);
            }

            throw new PropertyNotFoundException($"{GetType().FullName} not contains property of {property}.");
        }
    }

    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string message) : base(message)
        {

        }
    }
}