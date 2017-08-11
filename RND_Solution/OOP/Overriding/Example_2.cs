using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Overriding
{
    class A
    {
        public void show()
        {
            Console.WriteLine("Hello: Base Class!");
            
        }
    }

    class B : A
    {
        public new void show()
        {
            Console.WriteLine("Hello: Derived Class!");
            
        }
    }

    class Example_2
    {
        public static void Main1()
        {
            A a1 = new A();
            a1.show();
            B b1 = new B();
            b1.show();
            A a2 = new B();
            a2.show();
            Console.ReadLine();
        }
    }
}
