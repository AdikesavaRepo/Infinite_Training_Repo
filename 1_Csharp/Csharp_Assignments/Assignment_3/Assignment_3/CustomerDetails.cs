using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Customer
    {
        public int Customerid;
        public string Name;
        public int Age;
        public long Phone;
        public string City;


        public Customer()
        {
            Console.WriteLine("---Default Constructor withoit Arguments-----");
        }

        public Customer(int custid,string name,int age,long phone,string city)
        {
            Customerid = custid;
            Name = name;
            Age = age;
            Phone = phone;
            City = city;
            Console.WriteLine("---Parameterized Constructor with all Arguments---");
        }

        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine($"Customer ID: {customer.Customerid}");
            Console.WriteLine($"Customer Name: {customer.Name}");
            Console.WriteLine($"Age of Customer: {customer.Age}");
            Console.WriteLine($"Phone number: {customer.Phone}");
            Console.WriteLine($"City: {customer.City}");
        }

        ~Customer()
        {
            Console.WriteLine($"Destructor called for customer {Name}");
 
        }
    }

    class CustomerDetails
    {
        static void Main()
        {

            Customer c1 = new Customer(1,"aadi",23,7036775977,"chennai");
            Customer.DisplayCustomer(c1);


            Console.WriteLine("--------------------------------------------------------------");
            //Customer c2 = new Customer();

            Console.WriteLine("--------------------------------------------------------------");

            //Customer c3 = new Customer(34, "Deepak", 22, 9353525435, "Banglore");

            Console.Read();
        }
    }
}
