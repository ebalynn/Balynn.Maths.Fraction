namespace Balynn.Maths
{
    public partial struct Fraction
    {
        public static bool operator ==(Fraction lhs, Fraction rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Fraction lhs, Fraction rhs)
        {
            return !lhs.Equals(rhs);
        }
        public static bool operator ==(Fraction fraction, long value)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(Fraction fraction, long value)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(Fraction fraction, float value)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(Fraction fraction, float value)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(Fraction fraction, double value)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(Fraction fraction, double value)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(Fraction fraction, decimal value)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(Fraction fraction, decimal value)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(long value, Fraction fraction)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(long value, Fraction fraction)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(float value, Fraction fraction)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(float value, Fraction fraction)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(double value, Fraction fraction)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(double value, Fraction fraction)
        {
            return !fraction.Equals(value);
        }
        public static bool operator ==(decimal value, Fraction fraction)
        {
            return fraction.Equals(value);
        }
        public static bool operator !=(decimal value, Fraction fraction)
        {
            return !fraction.Equals(value);
        }
        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            return lhs.Add(rhs);
        }
        public static Fraction operator +(Fraction fraction, long value)
        {
            return fraction.Add(new Fraction(value, 1));
        }
        public static Fraction operator -(Fraction fraction, long value)
        {
            return fraction.Subtract(new Fraction(value, 1));
        }
        public static Fraction operator *(Fraction fraction, long value)
        {
            return fraction.MultiplyBy(new Fraction(value, 1));
        }
        public static Fraction operator /(Fraction fraction, long value)
        {
            return fraction.DivideBy(new Fraction(value, 1));
        }
        public static Fraction operator +(long value, Fraction fraction)
        {
            return fraction.Add(new Fraction(value, 1));
        }
        public static Fraction operator -(long value, Fraction fraction)
        {
            return new Fraction(value, 1).Subtract(fraction);
        }
        public static Fraction operator *(long value, Fraction fraction)
        {
            return fraction.MultiplyBy(new Fraction(value, 1));
        }
        public static Fraction operator /(long value, Fraction fraction)
        {
            return new Fraction(value, 1).DivideBy(fraction);
        }

        public static double operator +(double value, Fraction fraction)
        {
            return value + fraction.ToDouble();
        }
        public static double operator +(Fraction fraction, double value)
        {
            return fraction.ToDouble() + value;
        }

        public static double operator -(double value, Fraction fraction)
        {
            return value - fraction.ToDouble();
        }
        public static double operator -(Fraction fraction, double value)
        {
            return fraction.ToDouble() - value;
        }

        public static double operator *(double value, Fraction fraction)
        {
            return value * fraction.ToDouble();
        }
        public static double operator *(Fraction fraction, double value)
        {
            return fraction.ToDouble() * value;
        }

        public static double operator /(double value, Fraction fraction)
        {
            return value / fraction.ToDouble();
        }
        public static double operator /(Fraction fraction, double value)
        {
            return fraction.ToDouble() / value;
        }
        
        public static float operator +(float value, Fraction fraction)
        {
            return value + fraction.ToFloat();
        }
        public static float operator +(Fraction fraction, float value)
        {
            return fraction.ToFloat() + value;
        }

        public static float operator -(float value, Fraction fraction)
        {
            return value - fraction.ToFloat();
        }
        public static float operator -(Fraction fraction, float value)
        {
            return fraction.ToFloat() - value;
        }

        public static float operator *(float value, Fraction fraction)
        {
            return value * fraction.ToFloat();
        }
        public static float operator *(Fraction fraction, float value)
        {
            return fraction.ToFloat() * value;
        }

        public static float operator /(float value, Fraction fraction)
        {
            return value / fraction.ToFloat();
        }
        public static float operator /(Fraction fraction, float value)
        {
            return fraction.ToFloat() / value;
        }
        public static decimal operator +(decimal value, Fraction fraction)
        {
            return value + fraction.ToDecimal();
        }
        public static decimal operator +(Fraction fraction, decimal value)
        {
            return fraction.ToDecimal() + value;
        }

        public static decimal operator -(decimal value, Fraction fraction)
        {
            return value - fraction.ToDecimal();
        }
        public static decimal operator -(Fraction fraction, decimal value)
        {
            return fraction.ToDecimal() - value;
        }

        public static decimal operator *(decimal value, Fraction fraction)
        {
            return value * fraction.ToDecimal();
        }
        public static decimal operator *(Fraction fraction, decimal value)
        {
            return fraction.ToDecimal() * value;
        }

        public static decimal operator /(decimal value, Fraction fraction)
        {
            return value / fraction.ToDecimal();
        }
        public static decimal operator /(Fraction fraction, decimal value)
        {
            return fraction.ToDecimal() / value;
        }

        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            return lhs.Subtract(rhs);
        }
        public static Fraction operator *(Fraction lhs, Fraction rhs)
        {
            return lhs.MultiplyBy(rhs);
        }
        public static Fraction operator /(Fraction lhs, Fraction rhs)
        {
            return lhs.DivideBy(rhs);
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
        public static bool operator >(Fraction lhs, long rhs)
        {
            return lhs.ToDecimal() > rhs;
        }
        public static bool operator <(Fraction lhs, long rhs)
        {
            return lhs.ToDecimal() < rhs;
        }
        public static bool operator >(Fraction lhs, float rhs)
        {
            return lhs.ToFloat() > rhs;
        }
        public static bool operator <(Fraction lhs, float rhs)
        {
            return lhs.ToFloat() < rhs;
        }
        public static bool operator >(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() > rhs;
        }
        public static bool operator <(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() < rhs;
        }
        public static bool operator >(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() > rhs;
        }
        public static bool operator <(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() < rhs;
        }
        public static bool operator >(long lhs, Fraction rhs)
        {
            return new Fraction(lhs, 1) > rhs;
        }
        public static bool operator <(long lhs, Fraction rhs)
        {
            return new Fraction(lhs, 1) < rhs;
        }
        public static bool operator >(float lhs, Fraction rhs)
        {
            return lhs > rhs.ToFloat();
        }
        public static bool operator <(float lhs, Fraction rhs)
        {
            return lhs < rhs.ToFloat();
        }
        public static bool operator >(double lhs, Fraction rhs)
        {
            return lhs > rhs.ToDouble();
        }
        public static bool operator <(double lhs, Fraction rhs)
        {
            return lhs < rhs.ToDouble();
        }
        public static bool operator >(decimal lhs, Fraction rhs)
        {
            return lhs > rhs.ToDecimal();
        }
        public static bool operator <(decimal lhs, Fraction rhs)
        {
            return lhs < rhs.ToDecimal();
        }
        public static bool operator >=(Fraction lhs, long rhs)
        {
            return lhs.ToDecimal() >= rhs;
        }
        public static bool operator <=(Fraction lhs, long rhs)
        {
            return lhs.ToDecimal() <= rhs;
        }
        public static bool operator >=(Fraction lhs, float rhs)
        {
            return lhs.ToFloat() >= rhs;
        }
        public static bool operator <=(Fraction lhs, float rhs)
        {
            return lhs.ToFloat() <= rhs;
        }
        public static bool operator >=(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() >= rhs;
        }
        public static bool operator <=(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() <= rhs;
        }
        public static bool operator >=(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() >= rhs;
        }
        public static bool operator <=(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() <= rhs;
        }
        public static bool operator >=(long lhs, Fraction rhs)
        {
            return lhs >= rhs.ToDecimal();
        }
        public static bool operator <=(long lhs, Fraction rhs)
        {
            return lhs <= rhs.ToDecimal();
        }
        public static bool operator >=(float lhs, Fraction rhs)
        {
            return lhs >= rhs.ToFloat();
        }
        public static bool operator <=(float lhs, Fraction rhs)
        {
            return lhs <= rhs.ToFloat();
        }
        public static bool operator >=(double lhs, Fraction rhs)
        {
            return lhs >= rhs.ToDouble();
        }
        public static bool operator <=(double lhs, Fraction rhs)
        {
            return lhs <= rhs.ToDouble();
        }
        public static bool operator >=(decimal lhs, Fraction rhs)
        {
            return lhs >= rhs.ToDecimal();
        }
        public static bool operator <=(decimal lhs, Fraction rhs)
        {
            return lhs <= rhs.ToDecimal();
        }
        public static explicit operator long(Fraction fraction)
        {
            return fraction.ToInt64();
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
        public static Fraction operator ++(Fraction fraction)
        {
            return fraction.Add(Fraction.One);
        }
        public static Fraction operator --(Fraction fraction)
        {
            return fraction.Subtract(Fraction.One);
        }
    }
}
