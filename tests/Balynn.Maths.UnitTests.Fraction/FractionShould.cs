﻿using System;
using NUnit.Framework;

// ReSharper disable EqualExpressionComparison

namespace Balynn.Maths.Tests
{
    [TestFixture]
    public class FractionShould
    {
        [Test]
        public void Add()
        {
            var f1 = new Fraction(1, 3);
            var f2 = new Fraction(2, 3);
            f1 += f2;
            Assert.AreEqual(Fraction.One, f1);
            Assert.Pass(f1.ToString());

            f1 = new Fraction(-2, 3);
            f2 = new Fraction(2, 3);
            f1 += f2;
            Assert.AreEqual(Fraction.Zero, f1);
            Assert.Pass(f1.ToString());
        }

        [Test]
        public void BeZeroIfNumeratorIsZero()
        {
            var f = new Fraction(0, -15);
            Assert.AreEqual(0, f.Numerator);
            Assert.AreEqual(1, f.Denominator);
            Assert.AreEqual(Fraction.Zero, f);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void CompareComplexFractions()
        {
            var f1 = new Fraction(397, 1023);
            var f2 = new Fraction(398, 1022);
            Assert.Pass($"{f2} > {f1}");
            Assert.IsTrue(f2 > f1);
            Assert.IsTrue(f1 < f2);
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
        public void CompareEqualFractions()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(2, 4);
            Assert.IsTrue(f1 == f2);
            Assert.AreEqual(0, f1.CompareTo(f1));
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
        public void ComparePositiveWithNegative()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(-1, 2);
            Assert.IsTrue(f1 > f2);
            Assert.IsTrue(f2 < f1);
        }

        [Test]
        public void ComputeArithmeticOperations()
        {
            var big = new Fraction(1, 2);
            var small = new Fraction(1, 4);

            var toIncrement = new Fraction(1, 2);
            var toDecrement = new Fraction(1, 2);
            Assert.AreEqual(new Fraction(3, 2), ++toIncrement);
            Assert.AreEqual(new Fraction(-1, 2), --toDecrement);

            Assert.AreEqual(new Fraction(3, 4), big + small);
            Assert.AreEqual(new Fraction(1, 4), big - small);
            Assert.AreEqual(new Fraction(1, 8), big * small);
            Assert.AreEqual(new Fraction(2, 1), big / small);

            Assert.AreEqual(new Fraction(3, 2), big + 1L);
            Assert.AreEqual(new Fraction(-1, 2), big - 1L);
            Assert.AreEqual(new Fraction(1, 1), big * 2L);
            Assert.AreEqual(new Fraction(1, 4), big / 2L);
            Assert.AreEqual(new Fraction(3, 2), 1L + big);
            Assert.AreEqual(new Fraction(1, 2), 1L - big);
            Assert.AreEqual(new Fraction(1, 1), 2L * big);
            Assert.AreEqual(new Fraction(4, 1), 2L / big);

            Assert.AreEqual(big + 1f, ((IConvertible) new Fraction(3, 2)).ToSingle(null));
            Assert.AreEqual(big - 1f, ((IConvertible) new Fraction(-1, 2)).ToSingle(null));
            Assert.AreEqual(big * 2f, ((IConvertible) new Fraction(1, 1)).ToSingle(null));
            Assert.AreEqual(big / 2f, ((IConvertible) new Fraction(1, 4)).ToSingle(null));
            Assert.AreEqual(1f + big, ((IConvertible) new Fraction(3, 2)).ToSingle(null));
            Assert.AreEqual(1f - big, ((IConvertible) new Fraction(1, 2)).ToSingle(null));
            Assert.AreEqual(2f * big, ((IConvertible) new Fraction(1, 1)).ToSingle(null));
            Assert.AreEqual(2f / big, ((IConvertible) new Fraction(4, 1)).ToSingle(null));

            Assert.AreEqual(big + 1d, ((IConvertible) new Fraction(3, 2)).ToDouble(null));
            Assert.AreEqual(big - 1d, ((IConvertible) new Fraction(-1, 2)).ToDouble(null));
            Assert.AreEqual(big * 2d, ((IConvertible) new Fraction(1, 1)).ToDouble(null));
            Assert.AreEqual(big / 2d, ((IConvertible) new Fraction(1, 4)).ToDouble(null));
            Assert.AreEqual(1d + big, ((IConvertible) new Fraction(3, 2)).ToDouble(null));
            Assert.AreEqual(1d - big, ((IConvertible) new Fraction(1, 2)).ToDouble(null));
            Assert.AreEqual(2d * big, ((IConvertible) new Fraction(1, 1)).ToDouble(null));
            Assert.AreEqual(2d / big, ((IConvertible) new Fraction(4, 1)).ToDouble(null));

            Assert.AreEqual(big + 1m, ((IConvertible) new Fraction(3, 2)).ToDecimal(null));
            Assert.AreEqual(big - 1m, ((IConvertible) new Fraction(-1, 2)).ToDecimal(null));
            Assert.AreEqual(big * 2m, ((IConvertible) new Fraction(1, 1)).ToDecimal(null));
            Assert.AreEqual(big / 2m, ((IConvertible) new Fraction(1, 4)).ToDecimal(null));
            Assert.AreEqual(1m + big, ((IConvertible) new Fraction(3, 2)).ToDecimal(null));
            Assert.AreEqual(1m - big, ((IConvertible) new Fraction(1, 2)).ToDecimal(null));
            Assert.AreEqual(2m * big, ((IConvertible) new Fraction(1, 1)).ToDecimal(null));
            Assert.AreEqual(2m / big, ((IConvertible) new Fraction(4, 1)).ToDecimal(null));
        }

        [Test]
        public void ComputeComparisons()
        {
            var big = new Fraction(5, 1);
            var small = new Fraction(1, 5);
            Assert.IsTrue(big > small);
            Assert.IsTrue(small < big);
            Assert.IsTrue(big >= big);
            Assert.IsTrue(big >= small);
            Assert.IsTrue(small <= big);
            Assert.IsTrue(big <= big);
            Assert.IsTrue(big == big);
            Assert.IsTrue(big != small);

            Assert.IsTrue(big > 1L);
            Assert.IsTrue(big < 10L);
            Assert.IsTrue(big >= 1L);
            Assert.IsTrue(big <= 10L);
            Assert.IsTrue(big >= 5L);
            Assert.IsTrue(big <= 5L);
            Assert.IsTrue(big == 5L);
            Assert.IsTrue(big != 1L);
            Assert.IsTrue(big > 1L);
            Assert.IsTrue(big < 10L);
            Assert.IsTrue(big >= 1L);
            Assert.IsTrue(big <= 10L);
            Assert.IsTrue(big >= 5L);
            Assert.IsTrue(big <= 5L);

            Assert.IsTrue(1L > small);
            Assert.IsTrue(1L < big);
            Assert.IsTrue(1L >= small);
            Assert.IsTrue(1L <= big);
            Assert.IsTrue(5L >= big);
            Assert.IsTrue(5L <= big);
            Assert.IsTrue(5L == big);
            Assert.IsTrue(1L != big);
            Assert.IsTrue(1L > small);
            Assert.IsTrue(1L < big);
            Assert.IsTrue(1L >= small);
            Assert.IsTrue(1L <= big);
            Assert.IsTrue(5L >= big);
            Assert.IsTrue(5L <= big);

            Assert.IsTrue(big > 1f);
            Assert.IsTrue(big < 10f);
            Assert.IsTrue(big >= 1f);
            Assert.IsTrue(big <= 10f);
            Assert.IsTrue(big >= 5f);
            Assert.IsTrue(big <= 5f);
            Assert.IsTrue(big == 5f);
            Assert.IsTrue(big != 1f);
            Assert.IsTrue(big > 1f);
            Assert.IsTrue(big < 10f);
            Assert.IsTrue(big >= 1f);
            Assert.IsTrue(big <= 10f);
            Assert.IsTrue(big >= 5f);
            Assert.IsTrue(big <= 5f);

            Assert.IsTrue(1f > small);
            Assert.IsTrue(1f < big);
            Assert.IsTrue(1f >= small);
            Assert.IsTrue(1f <= big);
            Assert.IsTrue(5f >= big);
            Assert.IsTrue(5f <= big);
            Assert.IsTrue(5f == big);
            Assert.IsTrue(1f != big);
            Assert.IsTrue(1f > small);
            Assert.IsTrue(1f < big);
            Assert.IsTrue(1f >= small);
            Assert.IsTrue(1f <= big);
            Assert.IsTrue(5f >= big);
            Assert.IsTrue(5f <= big);

            Assert.IsTrue(big > 1d);
            Assert.IsTrue(big < 10d);
            Assert.IsTrue(big >= 1d);
            Assert.IsTrue(big <= 10d);
            Assert.IsTrue(big >= 5d);
            Assert.IsTrue(big <= 5d);
            Assert.IsTrue(big == 5d);
            Assert.IsTrue(big != 1d);
            Assert.IsTrue(big > 1d);
            Assert.IsTrue(big < 10d);
            Assert.IsTrue(big >= 1d);
            Assert.IsTrue(big <= 10d);
            Assert.IsTrue(big >= 5d);
            Assert.IsTrue(big <= 5d);

            Assert.IsTrue(1d > small);
            Assert.IsTrue(1d < big);
            Assert.IsTrue(1d >= small);
            Assert.IsTrue(1d <= big);
            Assert.IsTrue(5d >= big);
            Assert.IsTrue(5d <= big);
            Assert.IsTrue(5d == big);
            Assert.IsTrue(1d != big);
            Assert.IsTrue(1d > small);
            Assert.IsTrue(1d < big);
            Assert.IsTrue(1d >= small);
            Assert.IsTrue(1d <= big);
            Assert.IsTrue(5d >= big);
            Assert.IsTrue(5d <= big);

            Assert.IsTrue(big > 1m);
            Assert.IsTrue(big < 10m);
            Assert.IsTrue(big >= 1m);
            Assert.IsTrue(big <= 10m);
            Assert.IsTrue(big >= 5m);
            Assert.IsTrue(big <= 5m);
            Assert.IsTrue(big == 5m);
            Assert.IsTrue(big != 1m);
            Assert.IsTrue(big > 1m);
            Assert.IsTrue(big < 10m);
            Assert.IsTrue(big >= 1m);
            Assert.IsTrue(big <= 10m);
            Assert.IsTrue(big >= 5m);
            Assert.IsTrue(big <= 5m);

            Assert.IsTrue(1m > small);
            Assert.IsTrue(1m < big);
            Assert.IsTrue(1m >= small);
            Assert.IsTrue(1m <= big);
            Assert.IsTrue(5m >= big);
            Assert.IsTrue(5m <= big);
            Assert.IsTrue(5m == big);
            Assert.IsTrue(1m != big);
            Assert.IsTrue(1m > small);
            Assert.IsTrue(1m < big);
            Assert.IsTrue(1m >= small);
            Assert.IsTrue(1m <= big);
            Assert.IsTrue(5m >= big);
            Assert.IsTrue(5m <= big);
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
        public void ComputesWithDenomininatorLargerThanMax()
        {
            var f = new Fraction(1, Fraction.LargestDenominatorThanCanBeReduced + 1);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void ComputesWithLargestDenominator()
        {
            var f1 = new Fraction(1, Fraction.LargestDenominatorThanCanBeReduced);
            var f2 = new Fraction(2, Fraction.LargestDenominatorThanCanBeReduced);
            Assert.IsTrue(f2 > f1);
            Assert.Pass($"{f2} > {f1}");
        }

        [Test]
        public void ConvertToDecimal()
        {
            var f = new Fraction(1, 2);
            var r = (float) f;
            Assert.AreEqual(0.5, r);
            Assert.Pass(r.ToString());
        }

        [Test]
        public void ConvertToDouble()
        {
            var f = new Fraction(1, 2);
            var r = (double) f;
            Assert.AreEqual(0.5, r);
            Assert.Pass(r.ToString());
        }

        [Test]
        public void ConvertToFloat()
        {
            var f = new Fraction(1, 2);
            var r = (float) f;
            Assert.AreEqual(0.5, r);
            Assert.Pass(r.ToString());
        }

        [Test]
        public void CreateFractionFromDecimal()
        {
            var f = Fraction.FromDecimal(3 / 15.0m);
            Assert.AreEqual(0.2m, (decimal) f);
        }

        [Test]
        public void CreateFractionFromDouble()
        {
            var f = Fraction.FromDouble(3 / 15.0d);
            Assert.AreEqual(0.2, (double) f);
        }

        [Test]
        public void CreateFractionFromFloat()
        {
            var f = Fraction.FromFloat(3 / 15.0f);
            Assert.AreEqual(0.2f, (float) f);
        }

        [Test]
        public void Devide()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            var r = f1 / f2;
            Assert.AreEqual(1, r.Numerator);
            Assert.AreEqual(1, r.Denominator);
            Assert.Pass(r.ToString());
        }

        [Test]
        public void Multiply()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            var r = f1 * f2;
            Assert.AreEqual(1, r.Numerator);
            Assert.AreEqual(4, r.Denominator);
            Assert.Pass(r.ToString());
        }

        [Test]
        public void NotAllowDenominatorToBeZero()
        {
            Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0));
        }

        [Test]
        public void NotReduceFractionIfCgdIsOne()
        {
            var f = new Fraction(23, 7);
            Assert.AreEqual(23, f.Numerator);
            Assert.AreEqual(7, f.Denominator);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void PromoteSignToNumerator()
        {
            var f = new Fraction(2, -3);
            Assert.AreEqual(-2, f.Numerator);
            Assert.AreEqual(3, f.Denominator);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void ReduceNegativeFractionToGcd()
        {
            var f = new Fraction(5, -15);
            Assert.AreEqual(-1, f.Numerator);
            Assert.AreEqual(3, f.Denominator);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void ReducePositiveFractionToGcd()
        {
            var f = new Fraction(5, 15);
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(3, f.Denominator);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void ShouldBeOneIfNumeratorIsEqualToDenominator()
        {
            var f = new Fraction(12, 12);
            Assert.AreEqual(Fraction.One, f);
            Assert.Pass(f.ToString());
            f = new Fraction(-12, -12);
            Assert.AreEqual(Fraction.One, f);
            Assert.Pass(f.ToString());
        }

        [Test]
        public void Subtract()
        {
            var f1 = new Fraction(2, 3);
            var f2 = new Fraction(1, 3);
            f1 -= f2;
            Assert.AreEqual(1, f1.Numerator);
            Assert.AreEqual(3, f1.Denominator);
            Assert.Pass(f1.ToString());

            f1 = new Fraction(2, 3);
            f2 = new Fraction(-1, 3);
            f1 -= f2;
            Assert.AreEqual(Fraction.One, f1);
            Assert.Pass(f1.ToString());
        }

        [Test]
        public void SwapValuesWhenReciprocalIsCalled()
        {
            var f = new Fraction(4, 3);
            f = f.Reciprocal();
            Assert.AreEqual(3, f.Numerator);
            Assert.AreEqual(4, f.Denominator);
            Assert.Pass(f.ToString());
        }
    }
}