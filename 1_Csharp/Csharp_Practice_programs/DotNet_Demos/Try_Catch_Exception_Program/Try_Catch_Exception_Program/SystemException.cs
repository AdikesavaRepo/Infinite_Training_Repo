using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Catch_Exception_Program
{
    class SystemException
    {
        static void Main(string[] args)
        {
            int n1, n2, n3;
            try
            {
                Console.WriteLine("Enter two numbers :");
                n1 = int.Parse(Console.ReadLine());
                n2 = Convert.ToInt32(Console.ReadLine());
                n3 = n1 / n2;
                //int[] arr = { 1, 2, 3, 4 };
                //Console.WriteLine(arr[6]);
                Console.WriteLine("The result is: "+ n3);
                Console.Read();
            }

            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message+ " " + fe.StackTrace);
            }
            catch (DivideByZeroException de)
            {
                Console.WriteLine("You cannot divide a number by Zero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("All exceptions are caught here..");

            }
            finally
            {
                Console.WriteLine("Reached Finally... Press Enter to Exit....");
                Console.Read();

            }
        }
    }
}
