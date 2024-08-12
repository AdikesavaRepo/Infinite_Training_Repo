using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the string: ");
            string str1 = Console.ReadLine();
            if (!string.IsNullOrEmpty(str1))
            {
                string nstr = Ex(str1);
                Console.WriteLine($"New string : {nstr}");
            }
            else
            {
                Console.WriteLine("Input string is empty");
            }
            Console.Read();
        }
        static string Ex(string input)
        {
            if (input.Length < 2)
            {
                return input;
            }

            char firstChar = input[0];
            char lastChar = input[input.Length - 1];

            string nstr = lastChar + input.Substring(1, input.Length - 2) + firstChar;
            return nstr;
        }
    }
}
