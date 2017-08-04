# Balynn.Maths.Fraction
Fraction Implementation in C#

I’m not really sure why Microsoft have never bother to implement a Fraction primitive in .NET. I’m sure there are plenty of uses, as fraction allows to preserve the maximum possible precision.I have therefore decided to create my own implementation.

My implementation automatically simplifies the fraction, so if you were to create new Function(6, 3) that would be simplified to 2. The Fraction struct implements all the arithmetic operators on itself and on Int64, float, double and decimal: +, -, * /

Internally the Fraction is represented as two Int64: Numerator and Denominator and is always simplified upon initialisation. I initially intended to have it as an option, however following profiling the cost of simplification is not that great and the benefits outweigh the performance drawbacks.

Fraction has explicit conversion to Int64 (although that is bound to lose precision), float, double and decimal. It supports comparison with Int64, float, double and decimal and even supports ++ and — operations.
