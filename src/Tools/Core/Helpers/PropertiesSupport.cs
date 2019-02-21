using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Senticode.WPF.Tools.Core.Helpers
{
    public static class PropertiesSupport
    {
        public static PropertyInfo ExtractPropertyInfo<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            if (!(propertyExpression.Body is MemberExpression))
            {
                throw new ArgumentException("Not Member Access Expression");
            }

            var propertyInfo =
                ((MemberExpression)propertyExpression.Body).Member as PropertyInfo;

            if (propertyInfo == null)
            {
                throw new ArgumentException("Expression Not Property");
            }

            return propertyInfo;
        }

        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            if (!(propertyExpression.Body is MemberExpression))
            {
                throw new ArgumentException("Not Member Access Expression");
            }

            var member = ((MemberExpression)propertyExpression.Body).Member;
            var propertyInfo = member as PropertyInfo;

            if (propertyInfo == null)
            {
                throw new ArgumentException("Expression Not Property");
            }

            return member.Name;
        }

        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            if (!type.IsInterface)
            {
                return type.GetProperties(BindingFlags.FlattenHierarchy
                                          | BindingFlags.Public | BindingFlags.Instance);
            }

            var propertyInfos = new List<PropertyInfo>();
            var considered = new List<Type>();
            var queue = new Queue<Type>();
            considered.Add(type);
            queue.Enqueue(type);

            while (queue.Count > 0)
            {
                var subType = queue.Dequeue();

                foreach (var subInterface in subType.GetInterfaces())
                {
                    if (considered.Contains(subInterface)) continue;
                    considered.Add(subInterface);
                    queue.Enqueue(subInterface);
                }

                var typeProperties = subType.GetProperties(
                    BindingFlags.FlattenHierarchy
                    | BindingFlags.Public
                    | BindingFlags.Instance);

                var newPropertyInfos = typeProperties
                    .Where(x => !propertyInfos.Contains(x));

                propertyInfos.InsertRange(0, newPropertyInfos);
            }

            return propertyInfos.ToArray();
        }
    }
}
