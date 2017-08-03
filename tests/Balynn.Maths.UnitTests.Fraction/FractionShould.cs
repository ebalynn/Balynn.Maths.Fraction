using System;
using NUnit.Framework;

namespace Balynn.Maths.Tests
{
    [TestFixture]
    public class FractionShould
    {
        [Test]
        public void NotAllowDenominatorToBeZero()
        {
            Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0));
        }

        [Test]
        public void PromoteSignToNumerator()
        {
            var f = new Fraction(2, -3);
            Assert.AreEqual(-2, f.Numerator);
            Assert.AreEqual(3, f.Denominator);
            Console.WriteLine(f);
        }

        [Test]
        public void ReducePositiveFractionToGcd()
        {
            var f = new Fraction(5, 15);
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(3, f.Denominator);
            Console.WriteLine(f);
        }

        [Test]
        public void ReduceNegativeFractionToGcd()
        {
            var f = new Fraction(5, -15);
            Assert.AreEqual(-1, f.Numerator);
            Assert.AreEqual(3, f.Denominator);
            Console.WriteLine(f);
        }

        [Test]
        public void BeZeroIfNumeratorIsZero()
        {
            var f = new Fraction(0, -15);
            Assert.AreEqual(0, f.Numerator);
            Assert.AreEqual(1, f.Denominator);
            Assert.AreEqual(Fraction.Zero, f);
            Console.WriteLine(f);
        }

        [Test]
        public void ShouldBeOneIfNumeratorIsEqualToDenominator()
        {
            var f = new Fraction(12, 12);
            Assert.AreEqual(Fraction.One, f);
            Console.WriteLine(f);
            f = new Fraction(-12, -12);
            Assert.AreEqual(Fraction.One, f);
            Console.WriteLine(f);
        }

        [Test]
        public void NoReduceFractionIfCgdIsOne()
        {
            var f = new Fraction(23, 7);
            Assert.AreEqual(23, f.Numerator);
            Assert.AreEqual(7, f.Denominator);
            Console.WriteLine(f);
        }

        [Test]
        public void SwapValuesWhenReciprocalIsCalled()
        {
            var f = new Fraction(4, 3);
            f = f.Reciprocal();
            Assert.AreEqual(3, f.Numerator);
            Assert.AreEqual(4, f.Denominator);
            Console.WriteLine(f);
        }

        [Test]
        public void Add()
        {
            var f1 = new Fraction(1, 3);
            var f2 = new Fraction(2, 3);
            f1 += f2;
            Assert.AreEqual(Fraction.One, f1);
            Console.WriteLine(f1);

            f1 = new Fraction(-2, 3);
            f2 = new Fraction(2, 3);
            f1 += f2;
            Assert.AreEqual(Fraction.Zero, f1);
            Console.WriteLine(f1);
        }

        [Test]
        public void Subtract()
        {
            var f1 = new Fraction(2, 3);
            var f2 = new Fraction(1, 3);
            f1 -= f2;
            Assert.AreEqual(1, f1.Numerator);
            Assert.AreEqual(3, f1.Denominator);
            Console.WriteLine(f1);

            f1 = new Fraction(2, 3);
            f2 = new Fraction(-1, 3);
            f1 -= f2;
            Assert.AreEqual(Fraction.One, f1);
            Console.WriteLine(f1);
        }

        [Test]
        public void Multiply()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            var r = f1 * f2;
            Assert.AreEqual(1, r.Numerator);
            Assert.AreEqual(4, r.Denominator);
            Console.WriteLine(r);
        }

        [Test]
        public void Devide()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            var r = f1 / f2;
            Assert.AreEqual(1, r.Numerator);
            Assert.AreEqual(1, r.Denominator);
            Console.WriteLine(r);
        }

        [Test]
        public void ConvertToDouble()
        {
            var f = new Fraction(1, 2);
            var r = (double)f;
            Assert.AreEqual(0.5, r);
            Console.WriteLine(r);
        }

        [Test]
        public void ConvertToFloat()
        {
            var f = new Fraction(1, 2);
            var r = (float)f;
            Assert.AreEqual(0.5, r);
            Console.WriteLine(r);
        }

        [Test]
        public void ConvertToDecimal()
        {
            var f = new Fraction(1, 2);
            var r = (float)f;
            Assert.AreEqual(0.5, r);
            Console.WriteLine(r);
        }

        [Test]
        public void ComputeGreaterThan()
        {
            var l = new Fraction(1, 2);
            var s = new Fraction(1, 3);
            Assert.IsTrue(l > s);
        }

        [Test]
        public void ComputeLessThan()
        {
            var l = new Fraction(1, 2);
            var s = new Fraction(1, 3);
            Assert.IsTrue(s < l);

            l = new Fraction(1, 3);
            s = new Fraction(1, 397);

            Assert.IsTrue(s < l);
        }

        [Test]
        public void ComparePositiveWithNegative()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(-1, 2);
            Assert.IsTrue(f1 > f2);
            Assert.IsTrue(f2 < f1);
        }

        [Test]
        public void CompareEqualFractions()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(2, 4);
            Assert.IsTrue(f1 == f2);
            Assert.AreEqual(0, f1.CompareTo(f1));
        }

        [Test]
        public void CompareDifferentFractions()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(3, 4);
            Assert.IsTrue(f1 != f2);
            Assert.AreEqual(1, f2.CompareTo(f1));
            Assert.AreEqual(-1, f1.CompareTo(f2));
        }

        [Test]
        public void CompareFractionsWithTheSameNumerator()
        {
            var f1 = new Fraction(4, 7);
            var f2 = new Fraction(4, 6);
            Assert.IsTrue(f2 > f1);
            Assert.IsTrue(f1 < f2);
        }

        [Test]
        public void CompareFractionWithTheSameDenominator()
        {
            var f1 = new Fraction(1, 45);
            var f2 = new Fraction(2, 45);
            Assert.IsTrue(f2 > f1);
            Assert.IsTrue(f1 < f2);
        }

        [Test]
        public void CompareComplexFractions()
        {
            var f1 = new Fraction(397, 1023);
            var f2 = new Fraction(398, 1022);
            Console.WriteLine($"{f2} > {f1}");
            Assert.IsTrue(f2 > f1);
            Assert.IsTrue(f1 < f2);
        }

        [Test]
        public void ComputesWithLargestDenominator()
        {
            
            var f1 = new Fraction(1, Fraction.LargestDenominator);
            var f2 = new Fraction(2, Fraction.LargestDenominator);
            Assert.IsTrue(f2 > f1);
            Console.WriteLine($"{f2} > {f1}");
        }

        [Test]
        public void DoesntComputeWithDenomininatorLargerThanMax()
        {
            Assert.Throws<ArgumentException>(() => new Fraction(1, Fraction.LargestDenominator + 1));
        }
    }
}
