using System;
using UnityEngine;

namespace Util
{
    public static class Maths
    {
        public const float TOLERANCE = 0.0001f;

        public static bool SetMax(ref int self, int other)
        {
            if (other > self)
            {
                self = other;
                return true;
            }

            return false;
        }

        public static bool IsZero(this float self)
        {
            return self.IsAbout(0f);
        }
        
        public static bool IsAbout(this float self, float other, float tolerance = TOLERANCE)
        {
            return Math.Abs(self - other) < tolerance;
        }
        
        public static bool IsAbout(this Vector2 self, Vector2 other)
        {
            return self.x.IsAbout(other.x) && self.y.IsAbout(other.y);
        }

        public static bool IsAbout(this Vector3 self, Vector3 other, bool skipZ = false)
        {
            return self.x.IsAbout(other.x) && self.y.IsAbout(other.y) && (skipZ || self.z.IsAbout(other.z));
        }
    }
}