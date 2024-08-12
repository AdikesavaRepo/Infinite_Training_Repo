using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Integers
    {
        static void Main()
        {
            Console.WriteLine("----------first Program to find sum of two integers--------");
            TotalSum();
            Console.WriteLine("----------Second Program to find a day to a number--------");
            DisplayDay();
            Console.Read();
        }
        static void TotalSum()
        {
            Console.WriteLine("Enter First Integer");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second Integer");
            int n2 = Convert.ToInt32(Console.ReadLine());

            int n3 = n1 + n2;

            if (n1 == n2)
            {
                Console.WriteLine($"The Triple of to sum is : {n3 * 3}");
            }
            else
            {
                Console.WriteLine($"The Sum is : {n3}");
            }
        }

        static void DisplayDay()
        {
            Console.WriteLine("Enter Number");
            int n1 = Convert.ToInt32(Console.ReadLine());

            if(n1<=7)
            {
                switch (n1)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Fri");
                        break;
                    case 6:
                        Console.WriteLine("Sat");
                        break;
                    case 7:
                        Console.WriteLine("Sun");
                        break;
                    //default:
                     //   Console.WriteLine("Enter Valid Day number");
                     //   break;
                }
            }
            else 
            {
                Console.WriteLine("Enter Valid day");
            }  
        }


        
    }
    class Arrays
    {
        static void Main()
        {
            Console.WriteLine("----------first Program in Arrays--------");
            Array1();
            Console.ReadLine();
            Console.WriteLine("----------second Program in Arrays--------");
            Array2();
            Console.ReadLine();
            Console.WriteLine("----------Third Program in Arrays--------");
            Array3();
            Console.ReadLine();

        }
        static void Array1()
        {
            int[] arr1 = { 1, 2, 3, 6, 9, 7 };

            Console.WriteLine("Given array is { 1, 2, 3, 6, 9, 7 }");

            Console.WriteLine("Max is :");
            Console.WriteLine(arr1.Max());

            Console.WriteLine("Minimum is :");
            Console.WriteLine(arr1.Min());

            Console.WriteLine("Average is :");
            Console.WriteLine(arr1.Average());
        }



        static void Array2()
        {
            Console.Write("Enter the size of an array ");
            //Console.WriteLine();
            int size = Convert.ToInt32(Console.ReadLine());
            
            int[] arr2 = new int[size];
            Console.WriteLine("Enter the {0} elements :", size);
            for (int i = 0; i< size; i++)
            {
                arr2[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Sum is :");
            Console.WriteLine(arr2.Sum());

            Console.WriteLine("Average is :");
            Console.WriteLine(arr2.Average());

            Console.WriteLine("Minimum is :");
            Console.WriteLine(arr2.Min());

            Console.WriteLine("Maximum is is :");
            Console.WriteLine(arr2.Max());

            Array.Sort(arr2);
            Console.WriteLine("Ascending Order is :");
            foreach (int i in arr2)
            {
                Console.Write($" {i} ");
              
            }
            Console.WriteLine();

            Array.Reverse(arr2);
            Console.WriteLine("Descending Order is :");
            foreach (int i in arr2)
            {
                Console.Write($" {i} ");
            }

        }

        static void Array3()
        {
            Console.WriteLine("Previous array is : { 1, 2, 3, 5, 6 }");
            int[] arr3_old = { 1, 2, 3, 5, 6 };

            int[] arr3_new = new int[arr3_old.Length];

            for (int j = 0;j< arr3_old.Length; j++)
            {
                arr3_new[j] = arr3_old[j];
            }

            Console.WriteLine("New array is :");
            for (int j = 0; j < arr3_new.Length; j++)
            {
                Console.Write(arr3_new[j] + " ");
            }
           



        }
    }
}
