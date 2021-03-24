# Balynn.Maths.Fraction
## Fraction Implementation in C#

I’m not really sure why Microsoft have never bothered to implement a Fraction primitive in .NET. I’m sure there are plenty of uses, as fraction allows to preserve the maximum possible precision.I have therefore decided to create my own implementation.

This implementation automatically simplifies each fraction upon initialisation (unless the number is greater than 3037000499, in this case, the fraction is not simplified, as doing so will result in an overflow), so if you were to create new Function(6, 3) that would be simplified to 2. The Fraction struct implements all the arithmetic operators on itself and on Int64, float, double and decimal: +, -, * /

Internally the Fraction is represented as two Int64: Numerator and Denominator. I initially intended to have it as an option, however, following profiling the cost of simplification is not that great and the benefits outweigh the performance drawbacks.

Fraction has the explicit conversion to Int64 (although that is bound to lose precision), float, double and decimal. It supports comparison with Int64, float, double and decimal and even supports ++ and — operations.

At this stage the provided the implementation is functionally 90% complete, albeit it's quite naive and lacks thorough profiling analysis.
