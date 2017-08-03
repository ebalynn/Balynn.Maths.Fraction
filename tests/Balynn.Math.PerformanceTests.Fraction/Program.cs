using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Balynn.Maths;

namespace Balynn.Math.PerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.Write(".");
                }
            });
            var list = new List<Fraction>();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < 66; i++)
            {
                for (int j = 1; j < 66; j++)
                {
                    list.Add(new Fraction(i, j));
                }
            }
            sw.Stop();
            Console.WriteLine($"Time taken to initialise {list.Count} fractions {sw.Elapsed}");
            sw.Restart();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    var f1 = list[i];
                    var f2 = list[j];
                    var r1 = f1 > f2;
                    var r2 = f1 < f2;
                    var r3 = f1 >= f2;
                    var r4 = f1 <= f2;
                }
            }
            sw.Stop();
            Console.WriteLine($"Time taken to perform {list.Count * list.Count * 4} comparisons {sw.Elapsed}");

            sw.Restart();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    var f1 = list[i];
                    var f2 = list[j];
                    var r1 = f1 + f2;
                    var r2 = f1 - f2;
                    var r3 = f1 * f2;
                    var r4 = f1 / f2;
                }
            }
            sw.Stop();
            Console.WriteLine($"Time taken to perform {list.Count * list.Count * 4} ariphmetic operations {sw.Elapsed}");
            Console.Read();
        }
    }
}
