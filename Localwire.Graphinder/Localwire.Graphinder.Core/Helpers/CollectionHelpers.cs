namespace Localwire.Graphinder.Core.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionHelpers
    {
        public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> enumerable)
        {
            foreach (var element in enumerable.Where(e => e != null))
                hashSet.Add(element);
        }
    }
}
