using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ.SampleData
{
    public class Contact 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string State { get; set; }

        private Contact(string FirstName, string LastName, string Email, string Phone, DateTime DateOfBirth, string State)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.DateOfBirth = DateOfBirth;
            this.State = State;
        }

        public static List<Contact> SampleData()
        {
            List<Contact> Contacts = new List<Contact>();
            Contacts.Add(new Contact("Barney", "Gottshall", "Barney.Gottshall@contact.com", "885 983 8858", Convert.ToDateTime("19/10/1945"), "CA"));
            Contacts.Add(new Contact("Armando", "Valdes", "Armando.Valdes@contact.com", "848 553 8487", Convert.ToDateTime("09/12/1973"), "WA"));
            Contacts.Add(new Contact("Adam", "Gauwain", "Adam.Gauwain@contact.com", "115 999 1154", Convert.ToDateTime("03/10/1959"), "AK"));
            Contacts.Add(new Contact("Jeffery", "Deane", "Jeffery.Deane@contact.com", "677 602 6774", Convert.ToDateTime("16/12/1950"), "CA"));
            Contacts.Add(new Contact("Collin", "Zeeman", "Collin.Zeeman@contact.com", "603 303 6030", Convert.ToDateTime("10/02/1935"), "FL"));
            Contacts.Add(new Contact("Stewart", "Kagel", "Stewart.Kagel@contact.com", "546 607 5462", Convert.ToDateTime("20/02/1950"), "WA"));
            Contacts.Add(new Contact("Chance", "Lard", "Chance.Lard@contact.com", "278 918 2789", Convert.ToDateTime("21/10/1951"), "WA"));
            Contacts.Add(new Contact("Blaine", "Reifsteck", "Blaine.Reifsteck@contact.com", "715 920 7157", Convert.ToDateTime("18/05/1946"), "TX"));
            Contacts.Add(new Contact("Mack", "Kamph", "Mack.Kamph@contact.com", "364 202 3644", Convert.ToDateTime("17/09/1977"), "TX"));
            Contacts.Add(new Contact("Ariel", "Hazelgrove", "Ariel.Hazelgrove@contact.com", "165 737 1656", Convert.ToDateTime("23/05/1922"), "OR"));

            return Contacts;
        }
    }
    public class CallLog 
    {
        public string Number { get; set; }
        public int Duration { get; set; }
        public bool Incoming { get; set; }
        public DateTime When { get; set; }

        private CallLog(string Number, int Duration, bool Incoming, DateTime When)
        {
            this.Number = Number;
            this.Duration = Duration;
            this.Incoming = Incoming;
            this.When = When;
        }

        public static List<CallLog> SampleData()
        {
            List<CallLog> CallLogs = new List<CallLog>();
            CallLogs.Add(new CallLog("885 983 8858", 2, true, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("165 737 1656", 15, true, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("364 202 3644", 1, false, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("603 303 6030", 2, false, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("546 607 5462", 4, true, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("885 983 8858", 15, false, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("885 983 8858", 3, true, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("546 607 5462", 1, false, Convert.ToDateTime("07/08/2006")));
            CallLogs.Add(new CallLog("546 607 5462", 3, false, Convert.ToDateTime("08/08/2006")));
            CallLogs.Add(new CallLog("603 303 6030", 23, false, Convert.ToDateTime("08/08/2006")));
            CallLogs.Add(new CallLog("848 553 8487", 3, false, Convert.ToDateTime("08/08/2006")));
            CallLogs.Add(new CallLog("848 553 8487", 7, true, Convert.ToDateTime("08/08/2006")));
            CallLogs.Add(new CallLog("278 918 2789", 6, true, Convert.ToDateTime("08/08/2006")));
            CallLogs.Add(new CallLog("364 202 3644", 20, true, Convert.ToDateTime("08/08/2006")));

            return CallLogs;
        }
    }
}
