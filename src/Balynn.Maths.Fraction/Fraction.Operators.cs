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
        public static bool operator ==(Fraction lhs, long rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Fraction lhs, long rhs)
        {
            return !lhs.Equals(rhs);
        }
        public static bool operator ==(Fraction lhs, float rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Fraction lhs, float rhs)
        {
            return !lhs.Equals(rhs);
        }
        public static bool operator ==(Fraction lhs, double rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Fraction lhs, double rhs)
        {
            return !lhs.Equals(rhs);
        }
        public static bool operator ==(Fraction lhs, decimal rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Fraction lhs, decimal rhs)
        {
            return !lhs.Equals(rhs);
        }
        public static bool operator ==(long lhs, Fraction rhs)
        {
            return rhs.Equals(lhs);
        }
        public static bool operator !=(long lhs, Fraction rhs)
        {
            return !rhs.Equals(lhs);
        }
        public static bool operator ==(float lhs, Fraction rhs)
        {
            return rhs.Equals(lhs);
        }
        public static bool operator !=(float lhs, Fraction rhs)
        {
            return !rhs.Equals(lhs);
        }
        public static bool operator ==(double lhs, Fraction rhs)
        {
            return rhs.Equals(lhs);
        }
        public static bool operator !=(double lhs, Fraction rhs)
        {
            return !rhs.Equals(lhs);
        }
        public static bool operator ==(decimal lhs, Fraction rhs)
        {
            return rhs.Equals(lhs);
        }
        public static bool operator !=(decimal lhs, Fraction rhs)
        {
            return !rhs.Equals(lhs);
        }
        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            return Add(lhs, rhs);
        }
        public static Fraction operator +(Fraction lhs, long rhs)
        {
            return Add(lhs, new Fraction(rhs, 1));
        }
        public static Fraction operator -(Fraction lhs, long rhs)
        {
            return Subtract(lhs, new Fraction(rhs, 1));
        }
        public static Fraction operator *(Fraction lhs, long rhs)
        {
            return MultiplyBy(lhs, new Fraction(rhs, 1));
        }
        public static Fraction operator /(Fraction lhs, long rhs)
        {
            return DivideBy(lhs, new Fraction(rhs, 1));
        }
        public static Fraction operator +(long lhs, Fraction rhs)
        {
            return Add(rhs, new Fraction(lhs, 1));
        }
        public static Fraction operator -(long lhs, Fraction rhs)
        {
            return Subtract(new Fraction(lhs, 1), rhs);
        }
        public static Fraction operator *(long lhs, Fraction rhs)
        {
            return MultiplyBy(rhs, new Fraction(lhs, 1));
        }
        public static Fraction operator /(long lhs, Fraction rhs)
        {
            return DivideBy(new Fraction(lhs, 1), rhs);
        }
        public static double operator +(double lhs, Fraction rhs)
        {
            return lhs + rhs.ToDouble();
        }
        public static double operator +(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() + rhs;
        }
        public static double operator -(double lhs, Fraction rhs)
        {
            return lhs - rhs.ToDouble();
        }
        public static double operator -(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() - rhs;
        }
        public static double operator *(double lhs, Fraction rhs)
        {
            return lhs * rhs.ToDouble();
        }
        public static double operator *(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() * rhs;
        }
        public static double operator /(double lhs, Fraction rhs)
        {
            return lhs / rhs.ToDouble();
        }
        public static double operator /(Fraction lhs, double rhs)
        {
            return lhs.ToDouble() / rhs;
        }
        public static float operator +(float lhs, Fraction rhs)
        {
            return lhs + rhs.ToSingle();
        }
        public static float operator +(Fraction lhs, float rhs)
        {
            return lhs.ToSingle() + rhs;
        }
        public static float operator -(float lhs, Fraction rhs)
        {
            return lhs - rhs.ToSingle();
        }
        public static float operator -(Fraction lhs, float rhs)
        {
            return lhs.ToSingle() - rhs;
        }
        public static float operator *(float lhs, Fraction rhs)
        {
            return lhs * rhs.ToSingle();
        }
        public static float operator *(Fraction lhs, float rhs)
        {
            return lhs.ToSingle() * rhs;
        }
        public static float operator /(float lhs, Fraction rhs)
        {
            return lhs / rhs.ToSingle();
        }
        public static float operator /(Fraction lhs, float rhs)
        {
            return lhs.ToSingle() / rhs;
        }
        public static decimal operator +(decimal lhs, Fraction rhs)
        {
            return lhs + rhs.ToDecimal();
        }
        public static decimal operator +(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() + rhs;
        }

        public static decimal operator -(decimal lhs, Fraction rhs)
        {
            return lhs - rhs.ToDecimal();
        }
        public static decimal operator -(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() - rhs;
        }
        public static decimal operator *(decimal lhs, Fraction rhs)
        {
            return lhs * rhs.ToDecimal();
        }
        public static decimal operator *(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() * rhs;
        }
        public static decimal operator /(decimal lhs, Fraction rhs)
        {
            return lhs / rhs.ToDecimal();
        }
        public static decimal operator /(Fraction lhs, decimal rhs)
        {
            return lhs.ToDecimal() / rhs;
        }
        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            return Subtract(lhs, rhs);
        }
        public static Fraction operator *(Fraction lhs, Fraction rhs)
        {
            return MultiplyBy(lhs, rhs);
        }
        public static Fraction operator /(Fraction lhs, Fraction rhs)
        {
            return DivideBy(lhs, rhs);
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
            return lhs.ToSingle() > rhs;
        }
        public static bool operator <(Fraction lhs, float rhs)
        {
            return lhs.ToSingle() < rhs;
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
            return lhs > rhs.ToSingle();
        }
        public static bool operator <(float lhs, Fraction rhs)
        {
            return lhs < rhs.ToSingle();
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
            return lhs.ToSingle() >= rhs;
        }
        public static bool operator <=(Fraction lhs, float rhs)
        {
            return lhs.ToSingle() <= rhs;
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
            return lhs >= rhs.ToSingle();
        }
        public static bool operator <=(float lhs, Fraction rhs)
        {
            return lhs <= rhs.ToSingle();
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
        public static Fraction operator ++(Fraction fraction)
        {
            return Add(fraction, One);
        }
        public static Fraction operator --(Fraction fraction)
        {
            return Subtract(fraction, One);
        }
        public static explicit operator float(Fraction fraction)
        {
            return fraction.ToSingle();
        }
        public static explicit operator decimal(Fraction fraction)
        {
            return fraction.ToDecimal();
        }
    }
}
