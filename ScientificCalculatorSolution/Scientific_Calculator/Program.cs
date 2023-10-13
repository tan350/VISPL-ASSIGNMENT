using System;
using Arithmetic_Operations; // Reference to ArithmeticOperations.dll
using Power_Operations;     // Reference to PowerOperations.dll

namespace Scientific_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticCalculator arithmeticCalculator = new ArithmeticCalculator();
            PowerCalculator powerCalculator = new PowerCalculator();        
            while (true)
            {
                Console.WriteLine("==================Scientific Calculator==================");
                Console.WriteLine("1. Addition (+)");
                Console.WriteLine("2. Subtraction (-)");
                Console.WriteLine("3. Multiplication (*)");
                Console.WriteLine("4. Division (/)");
                Console.WriteLine("5. Modulus (%)");
                Console.WriteLine("6. Exponentiation (x^y)");
                Console.WriteLine("7. Root (x^(1/y))");
                Console.WriteLine("8. Square Root (sqrt)");
                Console.WriteLine("9. Cube Root (cbrt)");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice from the given options: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("==========================================================");

                Console.Write("Enter the first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = 0;
                switch (choice)
                {
                    case 1:
                        result = arithmeticCalculator.Add(num1, num2);
                        break;
                    case 2:
                        result = arithmeticCalculator.Subtract(num1, num2);
                        break;
                    case 3:
                        result = arithmeticCalculator.Multiply(num1, num2);
                        break;
                    case 4:
                        result = arithmeticCalculator.Divide(num1, num2);
                        break;
                    case 5:
                        result = arithmeticCalculator.Modulus(num1, num2);
                        break;
                    case 6:
                        result = powerCalculator.Exponentiation(num1,num2);
                        break;
                    case 7:
                        result = powerCalculator.Root(num1, num2);
                        break;
                    case 8:
                        Console.Write("Enter the number to find Square root: ");
                        double sqRoot = Convert.ToDouble(Console.ReadLine());
                        result = powerCalculator.SquareRoot(sqRoot);
                        break;
                    case 9:
                        Console.Write("Enter the number to find Cube root: ");
                        double cbRoot = Convert.ToDouble(Console.ReadLine());
                        result = powerCalculator.CubeRoot(cbRoot);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            Console.WriteLine("Result: " + result);
            }
        }
    }
}
