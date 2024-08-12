using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library;

namespace TravelConcessionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age entered.");
                return;
            }

        
            TravelConcession tc = new TravelConcession();

            string result = tc.CalculateConcession(age);
            Console.WriteLine($"Hello {name}, {result}");

            Console.ReadLine(); 
        }
    }
}
