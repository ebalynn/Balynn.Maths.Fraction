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
        private readonly long _numerator;
        private readonly long _denominator;

        public static readonly Fraction Zero = new Fraction(0, 1);
        public static readonly Fraction One = new Fraction(1, 1);
        public static readonly Fraction MinusOne = new Fraction(-1, 1);
        public static readonly Fraction SmallestFraction = new Fraction(1, long.MaxValue);
        public static readonly Fraction Pi = new Fraction(3126535, 995207);
        public const long LargestDenominatorThanCanBeReduced = 3037000499;
        
        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero");
            }

            if (denominator == 1 || numerator == 1 || denominator > LargestDenominatorThanCanBeReduced)
            {
                _numerator = numerator;
                _denominator = denominator;
            }
            else if (numerator == denominator)
            {
                _numerator = 1;
                _denominator = 1;
            }
            else if(numerator == 0)
            {
                _numerator = 0;
                _denominator = 1;
            }
            else
            {
                var absNumerator = Abs(numerator);
                var absDenominator = Abs(denominator);
                var gcd = Gcd(absNumerator, absDenominator);
                if (numerator > 0 && denominator > 0 || numerator < 0 && denominator < 0)
                {
                    _numerator = absNumerator / gcd;
                }
                else
                {
                    _numerator = absNumerator / -gcd;
                }
                _denominator = absDenominator / gcd;
            }
        }
        public bool IsPositive => _numerator >= 0;

        public bool IsNegative => _numerator < 0;

        public long Numerator => _numerator;

        public long Denominator => _denominator;

        public Fraction Reciprocal() => new Fraction(_denominator, _numerator);

        int IComparable<long>.CompareTo(long other)
        {
            return this.CompareTo(new Fraction(other, 1));
        }
        int IComparable<float>.CompareTo(float other)
        {
            return this.ToSingle().CompareTo(other);
        }
        int IComparable<double>.CompareTo(double other)
        {
            return this.ToDouble().CompareTo(other);
        }
        int IComparable<decimal>.CompareTo(decimal other)
        {
            return this.ToDecimal().CompareTo(other);
        }
        public override string ToString()
        {
            if (_numerator == 0)
            {
                return "0";
            }
            if (_denominator == 1)
            {
                return _numerator.ToString();
            }
            else if (_numerator == _denominator)
            {
                return "1";
            }
            else if (_numerator + _denominator == 0)
            {
                return "-1";
            }
            else
            {
                return $"{_numerator}/{_denominator}";
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_numerator.GetHashCode() * 397) ^ _denominator.GetHashCode();
            }
        }

        public int CompareTo(Fraction other)
        {
            if (_numerator > other._numerator && _denominator < other._denominator)
            {
                return 1;
            }
            else if (_numerator < other._numerator && _denominator > other._denominator)
            {
                return -1;
            }
            else if (_numerator == other._numerator)
            {
                return other._denominator.CompareTo(_denominator);
            }
            else if (_denominator == other._denominator)
            {
                return _numerator.CompareTo(other._numerator);
            }
            else if (this.Equals(other))
            {
                return 0;
            }
            else
            {
                var lcd = Lcd(_denominator, other._denominator);
                var multiplierThis = lcd / _denominator;
                var multiplierOther = lcd / other._denominator;
                return (_numerator * multiplierThis).CompareTo(other._numerator * multiplierOther);
            }
        }

        public bool Equals(Fraction other)
        {
            return _numerator == other._numerator && _denominator == other._denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is long)
            {
                return this.Equals((long)obj);
            }
            else if (obj is float)
            {
                return this.Equals((float)obj);
            }
            else if (obj is double)
            {
                return this.Equals((double)obj);
            }
            else if (obj is decimal)
            {
                return this.Equals((decimal)obj);
            }
            else if (obj is Fraction)
            {
                return this.Equals((Fraction)obj);
            }
            return false;
        }

        public static Fraction Add(Fraction left, Fraction right)
        {
            var lcd = Lcd(right._denominator, left._denominator);
            var lhsMult = lcd / right._denominator;
            var rhsMult = lcd / left._denominator;
            return new Fraction(right._numerator * lhsMult + left._numerator * rhsMult, lcd);
        }
        public static Fraction Subtract(Fraction left, Fraction right)
        {
            var lcd = Lcd(right._denominator, left._denominator);
            var lhsMult = lcd / left._denominator;
            var rhsMult = lcd / right._denominator;
            return new Fraction(left._numerator * lhsMult - right._numerator * rhsMult, lcd);
        }
        public static Fraction MultiplyBy(Fraction left, Fraction right)
        {
            return new Fraction(right._numerator * left._numerator, right._denominator * left._denominator);
        }
        public static Fraction DivideBy(Fraction left, Fraction right)
        {
            return new Fraction(left._numerator * right._denominator, left._denominator * right._numerator);
        }

        public bool IsGreaterThan(Fraction fraction)
        {
            return this.CompareTo(fraction) > 0;
        }
       
        public bool IsGreaterOrEqualThan(Fraction fraction)
        {
            return this.Equals(fraction) || this.CompareTo(fraction) > 0;
        }
        public bool IsLessThan(Fraction fraction)
        {
            return this.CompareTo(fraction) < 0;
        }
        public bool IsLessOrEqualThan(Fraction fraction)
        {
            return this.Equals(fraction) || this.CompareTo(fraction) < 0;
        }
        public bool Equals(long other)
        {
            return this.Equals(new Fraction(other, 1));
        }
        public bool Equals(float other)
        {
            return this.ToSingle() == other;
        }
        public bool Equals(double other)
        {
            return this.ToDouble() == other;
        }
        public bool Equals(decimal other)
        {
            return this.ToDecimal() == other;
        }

        public static Fraction FromInt64(long number)
        {
            return new Fraction(number, 1);
        }

        public static Fraction FromDouble(double number)
        {
            double denominator = 1;

            while (((double)(long)number) != number)
            {
                number = number * 10;
                denominator = denominator * 10;
            }
            return new Fraction((long) number, (long)denominator);
        }

        public static Fraction FromFloat(float number)
        {
            float denominator = 1;

            while (((float)(long)number) != number)
            {
                number = number * 10;
                denominator = denominator * 10;
            }
            return new Fraction((long)number, (long)denominator);
        }

        public static Fraction FromDecimal(decimal number)
        {
            decimal denominator = 1;

            while (((decimal)(long)number) != number)
            {
                number = number * 10;
                denominator = denominator * 10;
            }
            
            return new Fraction((long)number, (long)denominator);
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
            return (int)(_numerator / _denominator);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return this.ToInt32();
        }
        private uint ToUInt32()
        {
            return (uint)(_numerator / _denominator);
        }
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return this.ToUInt32();
        }
        private long ToInt64()
        {
            return _numerator / _denominator;
        }
        
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return this.ToInt64();
        }
        private ulong ToUInt64()
        {
            return (ulong)(_numerator / _denominator);
        }
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return this.ToUInt64();
        }
        private float ToSingle()
        {
            return _numerator / (float)_denominator;
        }
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return this.ToSingle();
        }
        private double ToDouble()
        {
            return _numerator / (double)_denominator;
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return this.ToDouble();
        }

        private decimal ToDecimal()
        {
            return _numerator / (decimal)_denominator;
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return this.ToDecimal();
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return this.ToString();
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
