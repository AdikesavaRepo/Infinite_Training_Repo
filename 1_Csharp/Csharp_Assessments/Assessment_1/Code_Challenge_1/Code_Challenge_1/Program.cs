using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a string: ");
            string s1 = Console.ReadLine();

            Console.WriteLine("Enter position to remove: ");
            int n1;
            bool isValidPosition = int.TryParse(Console.ReadLine(), out n1);

            if (isValidPosition && n1 >=0 && n1 < s1.Length)
            {
                string result = Rem(s1, n1);
                Console.WriteLine("Resulting String: " + result);
            }
            else
            {
                Console.WriteLine("Invalid position");
            }
            Console.Read();
        }

        static string Rem(string str, int pos)
        {
            return str.Substring(0, pos) + str.Substring(pos + 1);
        }
    }
}
