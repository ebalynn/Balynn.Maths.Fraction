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
        IComparable<decimal>
    {
        private readonly long _numerator;
        private readonly long _denominator;

        public static readonly Fraction Zero = new Fraction(0, 1);
        public static readonly Fraction One = new Fraction(1, 1);
        public static readonly Fraction MinusOne = new Fraction(-1, 1);
        public static readonly Fraction SmallestFraction = new Fraction(1, LargestDenominatorThanCanBeReduced);
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

        public int CompareTo(long other)
        {
            return this.CompareTo(new Fraction(other, 1));
        }
        public int CompareTo(float other)
        {
            return this.ToFloat().CompareTo(other);
        }
        public int CompareTo(double other)
        {
            return this.ToDouble().CompareTo(other);
        }
        public int CompareTo(decimal other)
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
            return this.Equals(new Fraction(other, 1));
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
    }
}
