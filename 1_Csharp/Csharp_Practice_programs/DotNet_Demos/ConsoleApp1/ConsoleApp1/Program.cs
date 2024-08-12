using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age");
            string ageIn = Console.ReadLine();

            try
            {
                int age = Convert.ToInt32(ageIn);
                Console.WriteLine($"your name is {name} and Your age is {age}")
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Age, pls enter valid age");
            }
            Console.Read();
        }
    }
}
