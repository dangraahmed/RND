using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Overriding.Example_3
{
    class A
    {
        public virtual void show()
        {
            Console.WriteLine("Hello: Base Class!");
        }
    }

    class B : A
    {
        public override void show()
        {
            Console.WriteLine("Hello: Derived Class!");
        }
    }

    class C : B
    {
        public new void show()
        {
            Console.WriteLine("Am Here!");
        }
    }

    class Polymorphism
    {
        public static void Main1()
        {
            A a1 = new A();
            a1.show();
            B b1 = new B();
            b1.show();
            C c1 = new C();
            c1.show();
            A a2 = new B();
            a2.show();
            A a3 = new C();
            a3.show();
            B b3 = new C();
            b3.show();

            Console.ReadLine();
        }
    }
    
}
