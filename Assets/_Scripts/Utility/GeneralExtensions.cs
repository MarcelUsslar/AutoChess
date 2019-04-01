using System;
using System.Collections;
using System.Collections.Generic;

namespace _Scripts.Utility
{
    public static class GeneralExtensions
    {
        public static void ForEach(this IEnumerable enumerable, Action action)
        {
            foreach (var entry in enumerable)
            {
                action();
            }
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var entry in enumerable)
            {
                action(entry);
            }
        }
    }
}