using System;
using Prefs;

namespace Scripts.Prefs
{
    public static class StencilPrefsExtensions
    {
        public static PrefHolder<T> Get<T>(this StencilPrefs prefs, string key, T defaultValue = default(T))
        {
            return PrefHolders.Get(prefs.config.Process(key), defaultValue);
        }

        public static long Increment(this PrefHolder<long> holder, long amount = 1)
        {
            var current = holder.Get();
            current += amount;
            holder.Set(current);
            return current;
        }

        public static long Decrement(this PrefHolder<long> holder, long amount = 1)
        {
            var current = holder.Get();
            current -= amount;
            holder.Set(current);
            return current;
        }

        public static int Increment(this PrefHolder<int> holder, int amount = 1)
        {
            var current = holder.Get();
            current += amount;
            holder.Set(current);
            return current;
        }

        public static int Decrement(this PrefHolder<int> holder, int amount = 1)
        {
            var current = holder.Get();
            current -= amount;
            holder.Set(current);
            return current;
        }
        

        public static StencilPrefs TodayOnly(this StencilPrefs prefs)
        {
            var config = prefs.config;
            config.key += $"_{DateTime.Now:MMddYYYY}";
            return new StencilPrefs(config);
        }
    }
}