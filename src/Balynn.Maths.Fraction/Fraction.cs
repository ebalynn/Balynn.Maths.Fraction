using System;
using System.Runtime.InteropServices;
using static System.Math;
using static Balynn.Maths.MathUtils;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Balynn.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public partial struct Fraction :
        IEquatable<Fraction>,
        IEquatable<long>,
        IEquatable<float>,
        IEquatable<double>,
        IEquatable<decimal>,
        IComparable<Fraction>,
        IComparable<long>,
        IComparable<float>,
        IComparable<double>,
        IComparable<decimal>,
        IConvertible
    {
        public static readonly Fraction Zero = new Fraction(0, 1);
        public static readonly Fraction One = new Fraction(1, 1);
        public static readonly Fraction MinusOne = new Fraction(-1, 1);
        public static readonly Fraction SmallestFraction = new Fraction(1, long.MaxValue);
        public static readonly Fraction Pi = new Fraction(3126535, 995207);
        public const long LargestDenominatorThanCanBeReduced = 3037000499;

        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero");

            if (denominator == 1 || numerator == 1 || denominator > LargestDenominatorThanCanBeReduced)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            else if (numerator == denominator)
            {
                Numerator = 1;
                Denominator = 1;
            }
            else if (numerator == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            else
            {
                var absNumerator = Abs(numerator);
                var absDenominator = Abs(denominator);
                var gcd = Gcd(absNumerator, absDenominator);
                if (numerator > 0 && denominator > 0 || numerator < 0 && denominator < 0)
                    Numerator = absNumerator / gcd;
                else
                    Numerator = absNumerator / -gcd;
                Denominator = absDenominator / gcd;
            }
        }

        public bool IsPositive => Numerator >= 0;

        public bool IsNegative => Numerator < 0;

        public long Numerator { get; }

        public long Denominator { get; }

        public Fraction Reciprocal()
        {
            return new Fraction(Denominator, Numerator);
        }

        int IComparable<long>.CompareTo(long other)
        {
            return CompareTo(new Fraction(other, 1));
        }

        int IComparable<float>.CompareTo(float other)
        {
            return ToSingle().CompareTo(other);
        }

        int IComparable<double>.CompareTo(double other)
        {
            return ToDouble().CompareTo(other);
        }

        int IComparable<decimal>.CompareTo(decimal other)
        {
            return ToDecimal().CompareTo(other);
        }

        public override string ToString()
        {
            if (Numerator == 0)
                return "0";
            if (Denominator == 1)
                return Numerator.ToString();
            if (Numerator == Denominator)
                return "1";
            if (Numerator + Denominator == 0)
                return "-1";
            return $"{Numerator}/{Denominator}";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode() * 397) ^ Denominator.GetHashCode();
            }
        }

        public int CompareTo(Fraction other)
        {
            if (Numerator > other.Numerator && Denominator < other.Denominator)
                return 1;
            if (Numerator < other.Numerator && Denominator > other.Denominator)
                return -1;
            if (Numerator == other.Numerator)
                return other.Denominator.CompareTo(Denominator);
            if (Denominator == other.Denominator)
                return Numerator.CompareTo(other.Numerator);
            if (Equals(other))
                return 0;
            var lcd = Lcd(Denominator, other.Denominator);
            var multiplierThis = lcd / Denominator;
            var multiplierOther = lcd / other.Denominator;
            return (Numerator * multiplierThis).CompareTo(other.Numerator * multiplierOther);
        }

        public bool Equals(Fraction other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is long)
                return Equals((long) obj);
            if (obj is float)
                return Equals((float) obj);
            if (obj is double)
                return Equals((double) obj);
            if (obj is decimal)
                return Equals((decimal) obj);
            if (obj is Fraction)
                return Equals((Fraction) obj);
            return false;
        }

        public static Fraction Add(Fraction left, Fraction right)
        {
            var lcd = Lcd(right.Denominator, left.Denominator);
            var lhsMult = lcd / right.Denominator;
            var rhsMult = lcd / left.Denominator;
            return new Fraction(right.Numerator * lhsMult + left.Numerator * rhsMult, lcd);
        }

        public static Fraction Subtract(Fraction left, Fraction right)
        {
            var lcd = Lcd(right.Denominator, left.Denominator);
            var lhsMult = lcd / left.Denominator;
            var rhsMult = lcd / right.Denominator;
            return new Fraction(left.Numerator * lhsMult - right.Numerator * rhsMult, lcd);
        }

        public static Fraction MultiplyBy(Fraction left, Fraction right)
        {
            return new Fraction(right.Numerator * left.Numerator, right.Denominator * left.Denominator);
        }

        public static Fraction DivideBy(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }

        public bool IsGreaterThan(Fraction fraction)
        {
            return CompareTo(fraction) > 0;
        }

        public bool IsGreaterOrEqualThan(Fraction fraction)
        {
            return Equals(fraction) || CompareTo(fraction) > 0;
        }

        public bool IsLessThan(Fraction fraction)
        {
            return CompareTo(fraction) < 0;
        }

        public bool IsLessOrEqualThan(Fraction fraction)
        {
            return Equals(fraction) || CompareTo(fraction) < 0;
        }

        public bool Equals(long other)
        {
            return Equals(new Fraction(other, 1));
        }

        public bool Equals(float other)
        {
            return ToSingle() == other;
        }

        public bool Equals(double other)
        {
            return ToDouble() == other;
        }

        public bool Equals(decimal other)
        {
            return ToDecimal() == other;
        }

        public static Fraction FromInt64(long number)
        {
            return new Fraction(number, 1);
        }

        public static Fraction FromDouble(double number)
        {
            double denominator = 1;

            while ((long) number != number)
            {
                number = number * 10;
                denominator = denominator * 10;
            }
            return new Fraction((long) number, (long) denominator);
        }

        public static Fraction FromFloat(float number)
        {
            float denominator = 1;

            while ((long) number != number)
            {
                number = number * 10;
                denominator = denominator * 10;
            }
            return new Fraction((long) number, (long) denominator);
        }

        public static Fraction FromDecimal(decimal number)
        {
            decimal denominator = 1;

            while ((long) number != number)
            {
                number = number * 10;
                denominator = denominator * 10;
            }

            return new Fraction((long) number, (long) denominator);
        }

        TypeCode IConvertible.GetTypeCode()
        {
            throw new NotImplementedException();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        private int ToInt32()
        {
            return (int) (Numerator / Denominator);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ToInt32();
        }

        private uint ToUInt32()
        {
            return (uint) (Numerator / Denominator);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ToUInt32();
        }

        private long ToInt64()
        {
            return Numerator / Denominator;
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ToInt64();
        }

        private ulong ToUInt64()
        {
            return (ulong) (Numerator / Denominator);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ToUInt64();
        }

        private float ToSingle()
        {
            return Numerator / (float) Denominator;
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ToSingle();
        }

        private double ToDouble()
        {
            return Numerator / (double) Denominator;
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ToDouble();
        }

        private decimal ToDecimal()
        {
            return Numerator / (decimal) Denominator;
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ToDecimal();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return ToString();
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}