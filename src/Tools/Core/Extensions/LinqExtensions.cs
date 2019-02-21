using System.Collections.Generic;

namespace Senticode.WPF.Tools.Core.Extensions
{
    public static class LinqExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source,
            IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }
    }
}
