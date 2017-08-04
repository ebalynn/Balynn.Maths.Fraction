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
                    Console.WriteLine(".");
                }
            });
            var list = new List<Fraction>();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < 50; i++)
            {
                for (int j = 1; j < 50; j++)
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

                    var r5 = f1 > 1L;
                    var r6 = f1 < 1L;
                    var r7 = f1 >= 1L;
                    var r8 = f1 >= 1L;

                    var r9 = f1 > 1f;
                    var r10 = f1 < 1f;
                    var r11 = f1 >= 1f;
                    var r12 = f1 >= 1f;

                    var r13 = f1 > 1d;
                    var r14 = f1 < 1d;
                    var r15 = f1 >= 1d;
                    var r16 = f1 >= 1d;

                    var r17 = f1 > 1m;
                    var r18 = f1 < 1m;
                    var r19 = f1 >= 1m;
                    var r20 = f1 >= 1m;

                }
            }
            sw.Stop();
            Console.WriteLine($"Time taken to perform comparisons on {list.Count * list.Count} items: {sw.Elapsed}");

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

                    f1 += 1L;
                    f2 += 2L;
                    var rf = f1 + 1f;
                    var rd = f1 + 1d;
                    var rm = f1 + 1m;

                }
            }
            sw.Stop();
            Console.WriteLine($"Time taken to perform ariphmetic operations on {list.Count * list.Count} items: {sw.Elapsed}");
            //Console.Read();
        }
    }
}
