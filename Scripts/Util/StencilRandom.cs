using System;

namespace Scripts.Util
{
    public static class StencilRandom
    {
        private static readonly Random Rand = new Random();
        
        /// <summary>
        ///   <para>Returns a random integer number between min [inclusive] and max [exclusive] (Read Only).</para>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static int Range(int min, int max)
        {
            return Rand.Next(min, max);
        }

        public static long Range(long min, long max)
        {
            var buf = new byte[8];
            Rand.NextBytes(buf);
            var longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }

        public static double Range(double min, double max)
        {
            return Rand.NextDouble() * (max - min) + min;
        }
        
        public static float Range(float min, float max)
        {
            return (float) Range((double) min, max);
        }
    }
}