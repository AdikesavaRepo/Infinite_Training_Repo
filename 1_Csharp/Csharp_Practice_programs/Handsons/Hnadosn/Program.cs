using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnadosn
{
    class Program
    {
        public enum Direction { East, West, North, South };

        static void Main(string[] args)
        {
            int n1 = 10;
            int n2 = 10;
            Console.WriteLine($"Number 1 == Number2 : {n1 == n2}");
            Console.WriteLine($"Number1.Equals(Number2) ?: {n1.Equals(n2)}");
            Console.WriteLine("---------------------------------------------");
            Console.ReadLine();
            Direction d1 = Direction.East;
            Direction d2 = Direction.East;

            Console.WriteLine(d1 == d2);
            Console.WriteLine(d1.Equals(d2));

        }            
    }
}
