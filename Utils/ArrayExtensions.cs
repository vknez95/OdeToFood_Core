using System;
using System.Collections.Generic;

namespace OdeToFood.Utils
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this Array array)
        {
            foreach (var item in array)
                yield return (T)item;
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this Array array, Func<TSource, TResult> selector)
        {
            foreach (var item in array)
                yield return selector((TSource)item);
        }
    }
}