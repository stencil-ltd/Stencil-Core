using System.Numerics;
using Unity.Collections;

namespace Dirichlet.Numerics
{
    public static class BigMath
    {
        public static UInt128 Multiply(this UInt128 value, decimal d)
        {
            return value.Multiply(Fraction.Get(d));
        }
        
        public static UInt128 Divide(this UInt128 value, decimal d)
        {
            return value.Multiply(1m / d);
        }

        public static UInt128 Multiply(this UInt128 value, Fraction fraction)
        {
            return value * (uint) fraction.numerator / (uint) fraction.denominator;
        }
    }
}