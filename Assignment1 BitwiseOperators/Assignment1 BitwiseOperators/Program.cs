using System;

namespace Assignment1_BitwiseOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 12;   // Binary: 1100
            int num2 = 10;   // Binary: 1010

            // Bitwise AND
            int resultAnd = num1 & num2;
            Console.WriteLine($"num1 & num2 = {resultAnd}"); // Output: num1 & num2 = 8 (Binary: 1000)

            // Bitwise OR
            int resultOr = num1 | num2;
            Console.WriteLine($"num1 | num2 = {resultOr}"); // Output: num1 | num2 = 14 (Binary: 1110)

            // Bitwise XOR (Exclusive OR)
            int resultXor = num1 ^ num2;
            Console.WriteLine($"num1 ^ num2 = {resultXor}"); // Output: num1 ^ num2 = 6 (Binary: 0110)

            // Bitwise NOT (Complement)
            int resultNot1 = ~num1;
            Console.WriteLine($"~num1 = {resultNot1}"); // Output: ~num1 = -13 

            // Left Shift
            int resultLeftShift = num1 << 2; // Shift left by 2 positions
            Console.WriteLine($"num1 << 2 = {resultLeftShift}"); // Output: num1 << 2 = 48 (Binary: 110000)

            // Right Shift
            int resultRightShift = num1 >> 2; // Shift right by 2 positions
            Console.WriteLine($"num1 >> 2 = {resultRightShift}"); // Output: num1 >> 2 = 3 (Binary: 0011)

        }
    }
}
