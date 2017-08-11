using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Sealed
{
    public abstract class Triangle
    {
        private double bs;
        private double hgt;

        public Triangle(double length, double height)
        {
            bs = length;
            hgt = height;
        }

        public virtual double Area()
        {
            return bs * hgt / 2;
        }

        public void Describe(string type)
        {
            Console.WriteLine("Triangle - {0}", type);
            Console.WriteLine("Base:   {0}", bs);
            Console.WriteLine("Height: {0}", hgt);
            Console.WriteLine("Area:   {0}", Area());
        }
    }

    sealed public class Irregular : Triangle
    {
        public Irregular(double Base, double Height)
            : base(Base, Height)
        {
        }
    }

    class Example_1
    {
        static void Main1(string[] args)
        {
            Irregular tri = new Irregular(42.73, 35.05);
            tri.Describe("Irregular");
            Console.ReadLine();
        }
    }
}
