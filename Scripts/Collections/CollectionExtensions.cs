using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Util;

namespace Plugins.Collections
{
    public static class CollectionExtensions
    {
        private static Random rng = new Random();
        
        public static T Front<T>(this Deque<T> deque) => deque.First();
        public static T Back<T>(this Deque<T> deque) => deque.Last();

        public static T Random<T>(this IList<T> coll)
        {
            if (coll.Count == 0) return default(T);
            var idx = StencilRandom.Range(0, coll.Count);
            return coll[idx];
        }
        
        public static void Shuffle<T>(this IList<T> list)  
        {  
            var n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = rng.Next(n + 1);  
                var value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

        public static void MaybeAdd<T>(this ICollection<T> coll, T obj)
        {
            if (obj == null) return;
            coll.Add(obj);
        }
    }
}