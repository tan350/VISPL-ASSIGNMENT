//Nullables Program
using System;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? num1 = 10;
            Console.WriteLine("Number1: " + num1.Value);
            int? num2 = null;
            Console.WriteLine("Number2: " + (num2.HasValue ? num2.Value : 0));
            int? null1 = num1;
            int? null2 = num2;
            if (null1.HasValue && null2.HasValue)
            {
                num1 = num1 + num2;
                num2 = num2 + num1;
            }
            else 
            {
                Console.WriteLine("Num1 or Num2 variable is NUll.");
            }
            Console.WriteLine("Numbers after change: ");
            Console.WriteLine("Number1: "+ num1);
            Console.WriteLine("Number2: " + num2);
        }
    }
}
