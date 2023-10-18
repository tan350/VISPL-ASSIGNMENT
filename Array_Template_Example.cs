using System;


namespace Assignment2
{

    public class Template_Example<T>
    {
        private T[] array;

        public Template_Example(int size)
        {
            array = new T[size];
        }

        public int Length
        {
            get { return array.Length; }
        }

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public void InputArrayInteger()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"Enter a value for index {i}: ");
                //T value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                string input = Console.ReadLine();
                if (int.TryParse(input, out int intValue))
                {
                    this[i] = (T)Convert.ChangeType(intValue, typeof(T));
                }
                else 
                {
                    i--;
                    Console.WriteLine("Please enter the value of integer data type.");
                }
            }
        }

        public void InputArrayDouble()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"Enter a value for index {i}: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double doubleValue))
                {
                    this[i] = (T)Convert.ChangeType(doubleValue, typeof(T));
                }
                else
                {
                    i--;
                    Console.WriteLine("Please enter the value of double data type.");
                }
            }
        }

        public void InputArrayFloat()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"Enter a value for index {i}: ");
                string input = Console.ReadLine();
                if (float.TryParse(input, out float floatValue))
                {
                    this[i] = (T)Convert.ChangeType(floatValue, typeof(T));
                }
                else
                {
                    i--;
                    Console.WriteLine("Please enter the value of float data type.");
                }
            }
        }

        public void OutputArray()
        {
            Console.WriteLine("Array Contents:");
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"Index {i}: {this[i]}");
            }
        }
    }
    internal class Array_Template_Example
    {
        public static void Main()
        {
            Template_Example<string> stringArray = new Template_Example<string>(3);
            Console.WriteLine("Input and output for (Integer) strings:");
            stringArray.InputArrayInteger();
            stringArray.OutputArray();

            Console.WriteLine("Input and output for (Double) strings:");
            stringArray.InputArrayDouble();
            stringArray.OutputArray();

            Console.WriteLine("Input and output for (Float) strings:");
            stringArray.InputArrayFloat();
            stringArray.OutputArray();
        }
    }
}
