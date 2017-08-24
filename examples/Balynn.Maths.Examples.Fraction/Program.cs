using System;

namespace Balynn.Maths.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new Fraction(2, 6);
            var b = new Fraction(1, 3);

            Console.WriteLine($"{a} == {b} is {a == b}");
            Console.WriteLine($"{a} > {b} is {a > b}");
            Console.WriteLine($"{a} > {5} is {a > 5L}");

            var f = Fraction.FromDecimal(1.5m);
            Console.WriteLine($"{1.5m} == {f}");
            Console.WriteLine($"{f} * {a} = {f * a}");
            Console.WriteLine($"Pi = {Fraction.Pi}");
            Console.Read();
        }
    }
}