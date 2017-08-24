using System.Runtime.CompilerServices;

namespace Balynn.Maths
{
    internal static class MathUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long Gcd(long a, long b)
        {
            while (a != 0 && b != 0)
                if (a > b)
                    a %= b;
                else
                    b %= a;

            return a == 0 ? b : a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long Lcd(long a, long b)
        {
            return a * b / Gcd(a, b);
        }
    }
}