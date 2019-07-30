using System;
using Dirichlet.Numerics;

namespace Scripts.Maths
{
    public static class MathExtensions
    {
        public static int AtLeast(this int value, int constraint)
            => Math.Max(value, constraint);
        public static uint AtLeast(this uint value, uint constraint)
            => Math.Max(value, constraint);
        public static long AtLeast(this long value, long constraint)
            => Math.Max(value, constraint);
        public static ulong AtLeast(this ulong value, ulong constraint)
            => Math.Max(value, constraint);
        public static float AtLeast(this float value, float constraint)
            => Math.Max(value, constraint);
        public static double AtLeast(this double value, double constraint)
            => Math.Max(value, constraint);
        
        public static int AtMost(this int value, int constraint)
            => Math.Min(value, constraint);
        public static uint AtMost(this uint value, uint constraint)
            => Math.Min(value, constraint);
        public static long AtMost(this long value, long constraint)
            => Math.Min(value, constraint);
        public static ulong AtMost(this ulong value, ulong constraint)
            => Math.Min(value, constraint);
        public static float AtMost(this float value, float constraint)
            => Math.Min(value, constraint);
        public static double AtMost(this double value, double constraint)
            => Math.Min(value, constraint);
        public static DateTime AtMost(this DateTime value, DateTime constraint)
            => value > constraint ? constraint : value;
        
        // IComparable
        public static T AtLeast<T>(this T value, T constraint) where T : IComparable<T>
            => value.CompareTo(constraint) < 0 ? constraint : value;
        
        public static T AtMost<T>(this T value, T constraint) where T : IComparable<T>
            => value.CompareTo(constraint) > 0 ? constraint : value;
        
        // Enums I guess?
        public static T AtLeastEnum<T>(this T value, T constraint) where T : struct
            => (T) (object) Math.Max((int) (object) value, (int) (object) constraint);
        public static T AtMostEnum<T>(this T value, T constraint) where T : struct
            => (T) (object) Math.Min((int) (object) value, (int) (object) constraint);
    }
}