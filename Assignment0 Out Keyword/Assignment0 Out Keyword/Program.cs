using System;

namespace Assignment0_Out_Keyword
{
    internal class Program
    {
        public static void Sum(out int num1)
        {
            num1 = 80;
            num1 = num1 + 1;
        }
        static void Main(string[] args)
        {
            int num1;
            Sum(out num1);

            Console.WriteLine("The Number is: " + num1);
        }

    }
}
