using System;

namespace Arithmetic_Operations
{
    // ArithmeticOperations
    public class ArithmeticCalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {   
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return x / y;
        }

        public double Modulus(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Modulus by zero is not allowed.");
            }
            return x % y;
        }
    }
}
