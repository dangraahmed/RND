using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Structural.DecoratorPattern
{
    public abstract class BakeryComponent
    {
        public abstract string GetName();
        public abstract double GetPrice();
    }

    public class CakeBase : BakeryComponent
    {
        // In real world these values will typically come from some data store
        private string m_Name = "Cake Base";
        private double m_Price = 200.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }

    public class PastryBase : BakeryComponent
    {
        // In real world these values will typically come from some data store
        private string m_Name = "Pastry Base";
        private double m_Price = 20.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }

    public abstract class Decorator : BakeryComponent
    {
        BakeryComponent m_BaseComponent = null;

        protected string m_Name = "Undefined Decorator";
        protected double m_Price = 0.0;

        protected Decorator(BakeryComponent baseComponent)
        {
            m_BaseComponent = baseComponent;
        }

        #region BakeryComponent Members

        public override string GetName()
        {
            return string.Format("{0}, {1}", m_BaseComponent.GetName(), m_Name);
        }

        public override double GetPrice()
        {
            return m_Price + m_BaseComponent.GetPrice();
        }
        #endregion
    }

    public class ArtificialScentDecorator : Decorator
    {
        public ArtificialScentDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Artificial Scent";
            this.m_Price = 3.0;
        }
    }

    public class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cherry";
            this.m_Price = 2.0;
        }
    }

    public class CreamDecorator : Decorator
    {
        public CreamDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Cream";
            this.m_Price = 1.0;
        }
    }

    public class NameCardDecorator : Decorator
    {
        private int m_DiscountRate = 5;

        public NameCardDecorator(BakeryComponent baseComponent)
            : base(baseComponent)
        {
            this.m_Name = "Name Card";
            this.m_Price = 4.0;
        }

        public override string GetName()
        {
            return base.GetName() +
                string.Format("\n(Please Collect your discount card for {0}%)",
                m_DiscountRate);
        }
    }

    

    public class Example1
    {
        static CakeBase cakeBase;
        static CreamDecorator creamCake;
        static CherryDecorator cherryCake;
        static ArtificialScentDecorator scentedCake;
        static NameCardDecorator nameCardOnCake;
        static PastryBase pastry;
        static CreamDecorator creamPastry;
        static CherryDecorator cherryPastry;
        public static void Main1(string[] args)
        {
            // Let us create a Simple Cake Base first
            cakeBase = new CakeBase();
            PrintProductDetails(cakeBase);

            // Lets add cream to the cake
            creamCake = new CreamDecorator(cakeBase);
            PrintProductDetails(creamCake);

            // Let now add a Cherry on it
            cherryCake = new CherryDecorator(creamCake);
            PrintProductDetails(cherryCake);

            // Lets now add Scent to it
            scentedCake = new ArtificialScentDecorator(cherryCake);
            PrintProductDetails(scentedCake);

            // Finally add a Name card on the cake
            nameCardOnCake = new NameCardDecorator(scentedCake);
            PrintProductDetails(nameCardOnCake);

            // Lets now create a simple Pastry
            pastry = new PastryBase();
            PrintProductDetails(pastry);

            // Lets just add cream and cherry only on the pastry 
            creamPastry = new CreamDecorator(pastry);
            cherryPastry = new CherryDecorator(creamPastry);
            PrintProductDetails(cherryPastry);

            Console.ReadLine();
        }

        private static void PrintProductDetails(BakeryComponent product)
        {
            Console.WriteLine(); // some whitespace for readability
            Console.WriteLine("Item: {0}, Price: {1}", product.GetName(), product.GetPrice());
        }
    }
}



/*
Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality. 
 
There are some occasions in our applications when we need to create an object with some basic functionality in such a way that some extra functionality can be added to this object dynamically. 
For example, Lets say we need to create a Stream object to handle some data but in some cases we need this stream object to be able to encrypt the stream in some cases. 
So what we can do is that we can have the basic Stream object ready and then dynamically add the encryption functionality when it is needed.

One may also say that why not keep this encryption logic in the stream class itself and turn it on or off by using a Boolean property. 
But this approach will have problems like - How can we add the type custom encryption logic inside a class? 
Now this can be done easily by subclassing the existing class and have custom encryption logic in the derived class.

This is a valid solution but only when this encryption is the only functionality needed with this class. 
But what if there are multiple functionalities that could be added dynamically to this class and also the combination of functionalities too. 
If we use the subclassing approach then we will end up with derievd classes equal to the number of combination we could have for all our functionalities and the actual object.

This is exactly the scenario where the decorator patter can be useful. GoF defines Decorator pattern as "Attach additional responsibilities to an object dynamically. 
Decorators provide a flexible alternative to subclassing for extending functionality."

To understand the decorator pattern let us look at an example of a billing system of a Bakery. 
This Bakery specializes in Cakes and Pastries. Customers can buy cakes and pastries and then choose to have extra stuff added on the base product. 
The extra Product are Cream, Cherry, Scent and Name card. 

http://www.codeproject.com/Articles/479635/UnderstandingplusandplusImplementingplusDecoratorp
 * 
 */