using System;

namespace Assignment0_Ref_Vs_Out_Keyword
{
    internal class Program
    {
        public static void MathRef(int number1, int number2, ref int Addition, ref int Subtraction)
        {
            Addition = number1 + number2; 
            Subtraction = number1 - number2; 
        }

        public static void MathOut(int number1, int number2, out int Addition, out int Subtraction)
        {
            Addition = number1 + number2; 
            Subtraction = number1 - number2; 
        }

        static void Main(string[] args)
        {
            int AdditionRef = 0;
            int SubtractionRef = 0;
            MathRef(200, 100, ref AdditionRef, ref SubtractionRef);
            Console.WriteLine("AdditionRef: " + AdditionRef);
            Console.WriteLine("SubtractionRef: " + SubtractionRef);

            int AdditionOut;
            int SubtractionOut;
            MathOut(200, 100, out AdditionOut, out SubtractionOut);
            Console.WriteLine("AdditionOut: " + AdditionOut);
            Console.WriteLine("SubtractionOut: " + SubtractionOut);
        }
    }
        
}
