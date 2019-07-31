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
        
        public static DateTime GetNext(this DayOfWeek day)
        {
            var start = DateTime.Today.AddDays(1);
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int) day - (int) start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
    }
}