using System;

namespace Power_Operations
{
    // PowerOperations.cs
        public class PowerCalculator
        {
            public double Exponentiation(double baseValue, double exponent)
            {
                return Math.Pow(baseValue, exponent);
            }

            public double Root(double baseValue, double rootValue)
            {
                return Math.Pow(baseValue, 1.0 / rootValue);
            }

            public double SquareRoot(double number)
            {
                if (number < 0)
                {
                    throw new ArgumentException("Cannot calculate the square root of a negative number.");
                }
                return Math.Sqrt(number);
            }

            public double CubeRoot(double number)
            {
                if (number < 0)
                {
                    throw new ArgumentException("Cannot calculate the cube root of a negative number.");
                }
                return Math.Pow(number, 1.0 / 3.0);
            }
        }
}
