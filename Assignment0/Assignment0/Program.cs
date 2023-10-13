//Prperty example
using System;
class Student
{

    private string code = "000";
    private string name = "Unknown";
    private int age = 0;

    public string Code
    {
        get
        {
            return code;
        }
        set
        {
            code = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }
    public string PrintString()
    {
        return "Code = " + Code + ", Name = " + Name + ", Age = " + Age;
    }

    public static void Main1()
    {
        Student s = new Student();
        s.Code = "001";
        s.Name = "Tanu";
        s.Age = 22;
        Console.WriteLine("Student Info: " +  s.PrintString());
        s.Age += 1;
        Console.WriteLine("Student Info: " + s.PrintString());
    }
}
