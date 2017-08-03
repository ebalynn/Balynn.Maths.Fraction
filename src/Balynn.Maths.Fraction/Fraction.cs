using System;
using System.Runtime.InteropServices;
using static System.Math;
using static Balynn.Maths.MathUtils;

namespace Balynn.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Fraction : IEquatable<Fraction>, IComparable<Fraction>
    {
        private readonly long _numerator;
        private readonly long _denominator;

        public static readonly Fraction Zero = new Fraction(0);
        public static readonly Fraction One = new Fraction(1);
        public static readonly Fraction MinusOne = new Fraction(-1);
        public const long LargestDenominator = 3037000499;
        public Fraction(long number) : this(number, 1)
        {
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
            if(_numerator > other._numerator && _denominator < other._denominator)
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
            return obj is Fraction && this.Equals((Fraction)obj);
        }

        public static bool operator ==(Fraction lhs, Fraction rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Fraction lhs, Fraction rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            return lhs.Add(rhs);
        }

        public Fraction Add(Fraction fraction)
        {
            var lcd = Lcd(_denominator, fraction._denominator);
            var lhsMult = lcd / _denominator;
            var rhsMult = lcd / fraction._denominator;
            return new Fraction(_numerator * lhsMult + fraction._numerator * rhsMult, lcd);
        }

        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            return lhs.Subtract(rhs);
        }

        public Fraction Subtract(Fraction fraction)
        {
            var lcd = Lcd(_denominator, fraction._denominator);
            var lhsMult = lcd / _denominator;
            var rhsMult = lcd / fraction._denominator;
            return new Fraction(_numerator * lhsMult - fraction._numerator * rhsMult, lcd);
        }

        public static Fraction operator *(Fraction lhs, Fraction rhs)
        {
            return lhs.MultiplyBy(rhs);
        }
        public Fraction MultiplyBy(Fraction fraction)
        {
            return new Fraction(_numerator * fraction._numerator, _denominator * fraction._denominator);
        }

        public static Fraction operator /(Fraction lhs, Fraction rhs)
        {
            return lhs.DivideBy(rhs);
        }

        public Fraction DivideBy(Fraction fraction)
        {
            return new Fraction(_numerator * fraction._denominator, _denominator * fraction._numerator);
        }

        public double ToDouble()
        {
            return _numerator / (double) _denominator;
        }

        public float ToFloat()
        {
            return _numerator / (float) _denominator;
        }

        public decimal ToDecimal()
        {
            return _numerator / (decimal) _denominator;
        }

        public static explicit operator double(Fraction fraction)
        {
            return fraction.ToDouble();
        }

        public static explicit operator float(Fraction fraction)
        {
            return fraction.ToFloat();
        }

        public static explicit operator decimal(Fraction fraction)
        {
            return fraction.ToDecimal();
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

        public static bool operator >(Fraction lhs, Fraction rhs)
        {
            return lhs.IsGreaterThan(rhs);
        }

        public static bool operator <(Fraction lhs, Fraction rhs)
        {
            return lhs.IsLessThan(rhs);
        }

        public static bool operator >=(Fraction lhs, Fraction rhs)
        {
            return lhs.IsGreaterOrEqualThan(rhs);
        }

        public static bool operator <=(Fraction lhs, Fraction rhs)
        {
            return lhs.IsLessOrEqualThan(rhs);
        }
    }
}
