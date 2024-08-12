using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonEg Employee = SingletonEg.GetInstance();  //first singleton class instance is created here
            Employee.Show("This message is from Employee");
            Console.WriteLine("Employee's Hash Code :" + " " + Employee.GetHashCode());

            Console.WriteLine("-----------------------------------------");
            //let us try creating another object
            SingletonEg Manager = SingletonEg.GetInstance();
            Manager.Show("This message is from Manager");
            Console.WriteLine("Manager's Hash Code :" + " " + Manager.GetHashCode());
            

            Client2.Client2Method();
            Console.Read();
        }
    }
}
