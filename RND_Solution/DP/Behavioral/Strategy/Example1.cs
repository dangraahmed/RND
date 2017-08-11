using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Behavioral.Strategy
{
    public interface IPersonValidationStrategy
    {
        bool IsValid(Person person);
        //Person.PersonType Type { get; }
    }

    public class EmployerValidationStrategy : IPersonValidationStrategy
    {
        public bool IsValid(Person person)
        {
            bool valid = false;

            if (person.FirstName != null && person.LastName != null && person.EIN > 0
                        && (person.DateOfBirth != null
                        && person.DateOfBirth.Value.AddYears(-18) < DateTime.Now.AddYears(18)))
            {
                valid = true;
            }

            Console.WriteLine("From Employer");
            return valid;
        }
    }

    public class EmployeeValidationStrategy : IPersonValidationStrategy
    {
        public bool IsValid(Person person)
        {
            bool valid = false;

            if (person.FirstName != null && person.LastName != null && person.SSN < 0 && person.DateOfBirth != null
                 && person.DateOfBirth >= DateTime.Now.AddYears(-18))
            {
                valid = true;
            }
            Console.WriteLine("From Employee");
            return valid;
        }
    }

    public class CustomerValidationStrategy : IPersonValidationStrategy
    {
        public bool IsValid(Person person)
        {
            bool valid = false;

            if (person.FirstName != null && person.LastName != null && person.DateOfBirth < DateTime.Now.AddYears(13))
            {
                valid = true;
            }
            Console.WriteLine("From Customer");
            return valid;
        }
    }
    
    public class Person
    {
        public enum PersonType
        {
            Employer,
            Employee,
            Customer
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int SSN { get; set; }
        public int EIN { get; set; }

        public PersonType Type { get; set; }

        private static Dictionary<PersonType, IPersonValidationStrategy> _validationStategies;

        public Person(PersonType Type)
        {
            this.Type = Type;
            _validationStategies = new Dictionary<PersonType, IPersonValidationStrategy>();
            _validationStategies.Add(PersonType.Employer, new EmployerValidationStrategy());
            _validationStategies.Add(PersonType.Employee, new EmployeeValidationStrategy());
            _validationStategies.Add(PersonType.Customer, new CustomerValidationStrategy());
        }

        public bool IsValid()
        {
            return _validationStategies[Type].IsValid(this);
        }
    }

    public class Example1
    {
        public static void Main1(string[] agrs)
        {
            Person person;
            person = new Person(Person.PersonType.Employee);
            person.IsValid();

            person = new Person(Person.PersonType.Employer);
            person.IsValid();

            person = new Person(Person.PersonType.Customer);
            person.IsValid();
            
            Console.ReadLine();
        }
    }
}


/*
Developers often run into similar problems when architecting software. To help tackle this problem, software design patterns have become quite popular. 
The Strategy Pattern is a common design pattern that allows an application to dynamically pick an appropriate method at runtime based on its host's context.

The Strategy pattern has three core pieces: a context, a strategy interface and one or many strategy implementations. 
The strategy interface defines the contract that will be used by each of the strategy implementations. The context class contains an interface member that is assigned to a concrete implementation at run-time to select the strategy to use.

One common usage of the Strategy pattern is as a replacement for a complex switch-case statement. 
For example, say you have a Person class that has specific validation logic depending on the PersonType of the person. You may start out by putting this logic into a switch-case statement as shown in Listing 1.

The individual validation logic is not very complex at this point, but it has the potential to grow unwieldy with the addition of new requirements and new fields to validate. 
To tackle this issue of complexity, you can break up each person type validation into its own class, which is responsible for validating its person type. When, and if, the person type changes, you can adapt and pick the correct strategy to meet your domain needs.
 
 */