using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstLibrary;
using MySecondLibrary;

namespace CalculatorLibrary_Client
{
    class MainCalculatorClient
    {
        static void Main(string[] args)
        {
            CalculatorClass c = new CalculatorClass();
            Console.WriteLine("The sum is : {0}", c.Addnos(10, 3));
            Console.WriteLine("The Difference is : {0}", c.Subtractnos(10, 3));

            Console.WriteLine("The product is : {0} ",c.MultiplyNos(10, 7));
            
            Console.Read();
        }
    }
}
