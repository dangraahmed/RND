using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Overriding
{
    public class baseClass
    {
        public virtual void method1()
        {
            Console.WriteLine("from Virtual baseClass.method1");
        }

        public virtual void method2()
        {
            Console.WriteLine("from Virtual baseClass.method2");
        }
    }

    public class deriveClass1 : baseClass
    {
        public override void method1()
        {
            Console.WriteLine("from Override deriveClass1.method1");
        }

        public new void method2()
        {
            Console.WriteLine("from New deriveClass1.method2");
        }
        
    }

    public class Example_1
    {
        public static void Main1(string[] args)
        {
            baseClass fullBaseObj = new baseClass();
            baseClass baseObj = new deriveClass1();
            deriveClass1 deriveObj = new deriveClass1();
            //deriveClass1 baseObj1 = new baseClass();

            Console.WriteLine("for fullBaseObj\n----------");
            fullBaseObj.method1();
            fullBaseObj.method2();

            Console.WriteLine("\nfor baseObj\n----------");
            baseObj.method1();
            baseObj.method2();


            Console.WriteLine("\nfor deriveObj\n----------");
            deriveObj.method1();
            deriveObj.method2();

            Console.ReadLine();
        }
    }
}
