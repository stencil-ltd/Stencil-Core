using System;

namespace Scripts.Util
{
    public static class StencilDate
    {
        public static double ToUnixSeconds(this DateTime time)
        {
            var epochTicks = new DateTime(1970, 1, 1).Ticks;
            return (DateTime.UtcNow.Ticks - epochTicks) / (double) TimeSpan.TicksPerSecond;
        }

        public static long ToUnixMilliseconds(this DateTime time)
        {
            return (long) (time.ToUnixSeconds() * 1000);
        }
    }
}