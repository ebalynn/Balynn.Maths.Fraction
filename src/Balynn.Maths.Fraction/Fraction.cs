using System;
using System.Runtime.InteropServices;
using static System.Math;
using static Balynn.Maths.MathUtils;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Balynn.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public partial struct Fraction : IEquatable<Fraction>, IEquatable<long>, IEquatable<float>, 
        IEquatable<double>, IEquatable<decimal>, IComparable<Fraction>
    {
        private readonly long _numerator;
        private readonly long _denominator;

        public static readonly Fraction Zero = new Fraction(0, 1);
        public static readonly Fraction One = new Fraction(1, 1);
        public static readonly Fraction MinusOne = new Fraction(-1, 1);
        public const long LargestDenominator = 3037000499;
        public Fraction(decimal number)
        {
            throw new NotImplementedException();
        }

        public Fraction(long numerator, long denominator)
        {
            if (denominator > LargestDenominator)
            {
                throw new ArgumentException($"{nameof(denominator)} cannot be greater than {LargestDenominator}");
            }
            else if (denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero");
            }
            else if (numerator == 0)
            {
                _numerator = 0;
                _denominator = 1;
            }
            else if (numerator == denominator)
            {
                _numerator = 1;
                _denominator = 1;
            }
            else if (numerator == 1)
            {
                _numerator = 1;
                _denominator = denominator;
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
            var numeratorComparison = _numerator.CompareTo(other._numerator);
            if (numeratorComparison != 0) return numeratorComparison;
            return _denominator.CompareTo(other._denominator);
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

        public Fraction Add(Fraction fraction)
        {
            var lcd = Lcd(_denominator, fraction._denominator);
            var lhsMult = lcd / _denominator;
            var rhsMult = lcd / fraction._denominator;
            return new Fraction(_numerator * lhsMult + fraction._numerator * rhsMult, lcd);
        }
        public Fraction Subtract(Fraction fraction)
        {
            var lcd = Lcd(_denominator, fraction._denominator);
            var lhsMult = lcd / _denominator;
            var rhsMult = lcd / fraction._denominator;
            return new Fraction(_numerator * lhsMult - fraction._numerator * rhsMult, lcd);
        }
        public Fraction MultiplyBy(Fraction fraction)
        {
            return new Fraction(_numerator * fraction._numerator, _denominator * fraction._denominator);
        }
        public Fraction DivideBy(Fraction fraction)
        {
            return new Fraction(_numerator * fraction._denominator, _denominator * fraction._numerator);
        }
        public long ToInt64()
        {
            return _numerator / _denominator;
        }
        public double ToDouble()
        {
            return _numerator / (double)_denominator;
        }

        public float ToFloat()
        {
            return _numerator / (float)_denominator;
        }

        public decimal ToDecimal()
        {
            return _numerator / (decimal)_denominator;
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
            return this.ToDecimal() == other;
        }
        public bool Equals(float other)
        {
            return this.ToFloat() == other;
        }
        public bool Equals(double other)
        {
            return this.ToDouble() == other;
        }
        public bool Equals(decimal other)
        {
            return this.ToDecimal() == other;
        }
    }
}
