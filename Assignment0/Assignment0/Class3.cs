using System;

    namespace Namespace1
    {
        class ClassFirst
        {
            int GetValue(int a)
            {
                return a;
            }
        }
        class ClassSecond
        {
            int GetValue(int a)
            {
                return a;
            }
        }
    }

    namespace Namespace2
    {
        class ClassFirst
        {
            int GetValue(int a)
            {
                return a;
            }
        }
        class ClassSecond
        {
            int GetValue(int a)
            {
                return a;
            }
        }
    }
class ClassThird
{
    Namespace1.ClassFirst c1 = new Namespace1.ClassFirst();
    Namespace1.ClassSecond c2 = new Namespace1.ClassSecond();

    Namespace2.ClassFirst c3 = new Namespace2.ClassFirst();
    Namespace2.ClassSecond c4 = new Namespace2.ClassSecond();
}
