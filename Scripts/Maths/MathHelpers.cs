using System;

namespace Scripts.Maths
{
    public static class MathHelpers
    {
        public static float LogNorm(float z) {
            double x = 0;
            double y = 1;
            double b = Math.Log(y/x)/(y-x);
            double a = y / Math.Exp(b*y);
            double tempAnswer = a * Math.Exp(b*z);
            double finalAnswer = Math.Max(Math.Round(tempAnswer) - 1, 0);
            return (float) finalAnswer;

        }
        
    }
}