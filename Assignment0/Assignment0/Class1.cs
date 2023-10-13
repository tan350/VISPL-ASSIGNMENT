using System;


namespace Assignment0
{
    internal class Class1
    {
        public static void Main2()
        {
            int? x = null;
            int? y = 0;
            int ? z = 5;
            int? w = 6;

            int? a = x ?? y;
            int? b = z ?? x;
            int? c = w ?? x;

            Console.WriteLine(a.Value);
            Console.WriteLine(b.Value);
            Console.WriteLine(c.Value);
            Console.WriteLine(x.HasValue);
            Console.WriteLine(y.HasValue);

            if (x is null)
            {
                Console.WriteLine(x is null);
            }
            else
            {
                Console.WriteLine("x is not  null ");
            }

        }
    }
}
