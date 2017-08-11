using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Abstract
{
    public abstract class AbsClass1
    {
        protected AbsClass1()
        {
            Console.WriteLine("in abstract class AbsClass1");
        }
        
        protected AbsClass1(string ok)
        {
            Console.WriteLine("in abstract class AbsClass1 with parameter ok");
        }
        
        public abstract int add();
    }

    public abstract class AbsClass2 : AbsClass1
    {
        protected AbsClass2()
        {
            Console.WriteLine("in abstract class AbsClass2");
        }

        protected AbsClass2(string ok): base(ok)
        {
            Console.WriteLine("in abstract class AbsClass2 with parameter ok");
        }

        //public abstract int add();
        public abstract int add1();
    }

    class Example_1 : AbsClass2
    {

        public Example_1()
        {
            Console.WriteLine("in class Example_1");
        }

        public Example_1(string ok) : base(ok)
        {
            Console.WriteLine("in class Example_1 with parameter ok");
        }

        public override int add1()
        {
            throw new NotImplementedException();
        }

        public override int add()
        {
            throw new NotImplementedException();
        }

        public static void Main1(string[] args)
        {
            AbsClass1 ok = new Example_1("ok");
            Console.ReadLine();
        }
    }
}
