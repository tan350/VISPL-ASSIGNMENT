using System;

namespace Assignment0_Ref_Keyword
{
    internal class Program
    {
        static void SetValue(ref string str1)
        {
            if (str1 == "Ram")
            {
                Console.WriteLine("Strig is Ram");
            }

            str1 = "Sita Ram";
        }
        static void Main(string[] args)
        {
            string str = "Ram";

            SetValue(ref str);
            Console.WriteLine(str);
        }

    }
}
