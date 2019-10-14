using System;
using System.Collections.Generic;
using System.Linq;

namespace _Scripts.Utility
{
    public static class EnumHelper<T>
    {
        public static IEnumerable<T> Iterator
        {
            get
            {
                return Enum.GetValues(typeof(T)).Cast<T>();
            }
        }

    }
}