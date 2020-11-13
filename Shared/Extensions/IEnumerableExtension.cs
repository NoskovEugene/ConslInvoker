using System.Security.AccessControl;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shared.Extensions
{
    public static class IEnumerableExtension
    {
        public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }        
    }
}