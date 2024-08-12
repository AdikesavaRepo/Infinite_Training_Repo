using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Strings
    {
        static void Main()
        {
            Console.WriteLine("-----Write a program in C# to accept a word from the user and display the length of it-----");
            String1();
            Console.ReadLine();

            Console.WriteLine("-----Write a program in C# to accept a word from the user and display the reverse of it.----- ");
            String2();
            Console.ReadLine();

            Console.WriteLine("-----Write a program in C# to accept two words from user and find out if they are same----");
            String3();
            Console.Read();


        }

        static void String1()
        {
            Console.WriteLine("Enter a word: ");
            string str1 = Console.ReadLine();
            Console.WriteLine("length of the given string is : "+ str1.Length);
        }


        static void String2()
        {
            Console.WriteLine("Enter a word: ");
            string str2 = Console.ReadLine();

            string rev = "";
                for(int i = 0; i < str2.Length; i++)
            {
                rev = str2[i] + rev;
            }
            Console.WriteLine("Reverse of the given string is: "+rev);
        }

        static void String3()
        {
            Console.WriteLine("Enter first word: ");
            string str3 = Console.ReadLine();
            Console.WriteLine("Enter second word: ");
            string str4 = Console.ReadLine();

            if (str3 == str4)
            {
                Console.WriteLine("Both are same");
            }
            else
            {
                Console.WriteLine("Both are Different");
            }
        }
    }
}
