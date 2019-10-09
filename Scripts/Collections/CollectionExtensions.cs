using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Scripts.Maths;
using Scripts.Util;
using UnityEngine;
using Random = System.Random;

namespace Plugins.Collections
{
    public static class CollectionExtensions
    {
        private static Random rng = new Random();
        
        public static T Front<T>(this Deque<T> deque) => deque.First();
        public static T Back<T>(this Deque<T> deque) => deque.Last();

        public static V GetValueOrDefault<K, V>(this Dictionary<K, V> dict, K key)
        {
            if (key == null) return default;
            var success = dict.TryGetValue(key, out var retval);
            return !success ? default(V) : retval;
        }

        public static T Random<T>(this IList<T> coll)
        {
            if (coll.Count == 0) return default;
            var idx = StencilRandom.Range(0, coll.Count);
            return coll[idx];
        }
        
        public static List<T> Random<T>(this IList<T> coll, int count)
        {
            var idxs = new List<int>();
            for (var i = 0; i < coll.Count; i++) 
                idxs.Add(i);
            var retval = new List<T>();
            count = count.AtMost(coll.Count);
            for (var i = 0; i < count; i++)
            {
                var idx = StencilRandom.Range(0, idxs.Count);
                retval.Add(coll[idxs[idx]]);
                idxs.RemoveAt(idx);
            }
            return retval; 
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

        public static TResult FirstNotDefault<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> func)
        {
            foreach (var it in collection)
            {
                var result = func(it);
                if (!Equals(result, default(TResult)))
                    return result;
            }
            return default(TResult);
        }
        
        public static IEnumerable<TResult> SelectNotDefault<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var thedefault = default(TResult);
            return source.Select(selector).Where(value => !EqualityComparer<TResult>.Default.Equals(thedefault, value));
        }

        public static void SetActive(this IEnumerable<GameObject> coll, bool active)
        {
            foreach (var gameObject in coll)
            {
                if (gameObject == null) continue;
                gameObject.SetActive(active);
            }
        }
    }
}