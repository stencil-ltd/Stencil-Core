using System;

namespace Dirichlet.Numerics
{
    public struct Fraction
    {
        public readonly Int128 numerator;
        public readonly Int128 denominator;

        public static Fraction Get(decimal d)
        {
            var bits = decimal.GetBits(d);
            var numerator = (1 - ((bits[3] >> 30) & 2)) *
                                   unchecked(((uint)bits[2] << 64) |
                                             ((uint)bits[1] << 32) |
                                             (uint)bits[0]);
            var denominator = (Int128) Math.Pow(10, (bits[3] >> 16) & 0xff);
            return new Fraction(numerator, denominator);
        }

        public Fraction(Int128 numerator, Int128 denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public bool Equals(Fraction other)
        {
            return numerator == other.numerator && denominator == other.denominator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Fraction other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (numerator.GetHashCode() * 397) ^ denominator.GetHashCode();
            }
        }
    }
}