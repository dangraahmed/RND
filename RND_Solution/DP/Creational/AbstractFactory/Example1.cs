using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Creational.AbstractFactory
{
    interface IDumb
    {
        string Name();
    }

    interface ISmart
    {
        string Name();
    }

    class Asha : IDumb
    {
        public string Name()
        {
            return "Asha ";
        }
    }

    class Primo : IDumb
    {
        public string Name()
        {
            return "Primo";
        }
    }

    class Genie : IDumb
    {
        public string Name()
        {
            return "Genie";
        }
    }

    class Lumia : ISmart
    {
        public string Name()
        {
            return "Lumia";
        }
    }

    class GalaxyS2 : ISmart
    {
        public string Name()
        {
            return "GalaxyS2";
        }
    }

    class Titan : ISmart
    {
        public string Name()
        {
            return "Titan";
        }
    }


    interface IPhoneFactory
    {
        IDumb GetDumb();
        ISmart GetSmart();
    }

    class NokiaFactory : IPhoneFactory
    {

        public IDumb GetDumb()
        {
            return new Asha();
        }

        public ISmart GetSmart()
        {
            return new Lumia();
        }
    }

    class HTCFactory : IPhoneFactory
    {

        public IDumb GetDumb()
        {
            return new Genie();
        }

        public ISmart GetSmart()
        {
            return new Titan();
        }
    }

    class SamsungFactory : IPhoneFactory
    {

        public IDumb GetDumb()
        {
            return new Primo();
        }

        public ISmart GetSmart()
        {
            return new GalaxyS2();
        }
    }


    enum Manufacturers
    {
        Samsung,
        HTC,
        Nokia
    }

    class PhoneTypeChecker
    {

        IPhoneFactory _factory;
        readonly Manufacturers _manu;

        public PhoneTypeChecker()
        {
        }

        public PhoneTypeChecker(Manufacturers m)
        {
            _manu = m;
        }

        /// <summary>
        /// This method will create new object using _manu and then will provide its details
        /// </summary>
        public void CheckProducts()
        {
            switch (_manu)
            {
                case Manufacturers.Samsung:
                    _factory = new SamsungFactory();
                    break;
                case Manufacturers.HTC:
                    _factory = new HTCFactory();
                    break;
                case Manufacturers.Nokia:
                    _factory = new NokiaFactory();
                    break;
            }

            Console.WriteLine(_manu.ToString() + ":\nSmart Phone: " +
            _factory.GetSmart().Name() + "\nDumb Phone: " + _factory.GetDumb().Name());
        }

        /// <summary>
        /// This method provide its details using passed parameter
        /// </summary>
        /// <param name="iPhoneFactory">Object whose details need to view</param>
        public void CheckProducts(IPhoneFactory iPhoneFactory)
        {
            Console.WriteLine("Smart Phone: " + iPhoneFactory.GetSmart().Name() + "\nDumb Phone: " + iPhoneFactory.GetDumb().Name());
        }
    }

    class PhoneCreation
    {

        private Manufacturers PhoneManufacturers { get; set; }

        private static Dictionary<Manufacturers, IPhoneFactory> _phoneDictionary;

        private PhoneCreation()
        {
            _phoneDictionary = new Dictionary<Manufacturers, IPhoneFactory>();
            _phoneDictionary.Add(Manufacturers.Nokia, new NokiaFactory());
            _phoneDictionary.Add(Manufacturers.Samsung, new SamsungFactory());
            _phoneDictionary.Add(Manufacturers.HTC, new HTCFactory());
        }
        public PhoneCreation(Manufacturers m) : this()
        {
            this.PhoneManufacturers = m;
        }

        public IPhoneFactory GetProducts()
        {
            return _phoneDictionary[PhoneManufacturers];
        }
    }

    class Example1
    {
        static PhoneTypeChecker checker;
        static PhoneCreation phoneCreation;
        static void Main(string[] args)
        {
            //PhoneTypeChecker checker;

            //checker = new PhoneTypeChecker(Manufacturers.Samsung);
            //checker.CheckProducts();

            //checker = new PhoneTypeChecker(Manufacturers.HTC);
            //checker.CheckProducts();


            //checker = new PhoneTypeChecker(Manufacturers.Nokia);
            //checker.CheckProducts();

            //Console.ReadLine();


            checker = new PhoneTypeChecker();

            phoneCreation = new PhoneCreation(Manufacturers.Samsung);
            Console.WriteLine("Samsung");
            checker.CheckProducts(phoneCreation.GetProducts());
            Console.WriteLine("");

            phoneCreation = new PhoneCreation(Manufacturers.HTC);
            Console.WriteLine("HTC");
            checker.CheckProducts(phoneCreation.GetProducts());
            Console.WriteLine("");

            phoneCreation = new PhoneCreation(Manufacturers.Nokia);
            Console.WriteLine("Nokia");
            checker.CheckProducts(phoneCreation.GetProducts());
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}


/*
Abstract factory pattern in useful when the client needs to create objects which are somehow related. If we need to create the family of related or dependent objects, then we can use Abstract Factory Pattern.

This pattern is particularly useful when the client doesn't know exactly what type to create. As an example, let's say a Showroom exclusively selling cellphones gets a query for the smart phones made by Samsung. Here we don't know the exact type of object to be created (assuming all the information for a phone is wrapped in the form of a concrete object). But we do know that we are looking for smart phones that are manufactured by Samsung. This information can actually be utilized if our design has Abstract factory implementation.

So with this idea of Abstract Factory pattern, we will now try to create a design that will facilitate the creation of related objects. We will go ahead and write a rudimentary application for the scenario we just talked about. 


 
Abstract factory pattern in very useful in GUI based applications where we need to create related GUI components. My example here is solely for the purpose of understanding and there is no way the "Cell-phone-information-system" be designed this way (otherwise we will end up adding new classes every week). Please do let me know if I missed something. Perhaps for the experienced guys this article is not very useful but it could really be useful for beginners. 
 
 
 */
