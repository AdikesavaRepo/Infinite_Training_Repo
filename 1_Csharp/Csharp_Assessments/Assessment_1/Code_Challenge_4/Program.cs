using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Table(number);
        }
        static void Table(int number)
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{number}*{i}={number * i}");
                
            }
            Console.Read();
        }
    }
}
