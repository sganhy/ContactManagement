using System;
using System.Collections.Generic;

namespace ContactManagement.Web.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Execute<T>(this IEnumerable<T> values, Action<T> execute)
        {
            if (values == null)
                return;

            foreach (var value in values) execute(value);
        }
    }
}
