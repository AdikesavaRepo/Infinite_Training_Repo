using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Code_Challenge_3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("------------------ Program 1 ------------------------");
            Program1.Display1();

            //Console.WriteLine("------------------ Program 2 ------------------------");
            //Program2.Display2();

            //Console.WriteLine("------------------ Program 3 ------------------------");
            //EmployeeDetails.Display3();

            Console.Read();
        }
    }

    // --------------------------------------- Program 1 ---------------------------------------------------
    class Program1
    {
        public static void Display1()
        {
            Console.WriteLine("write a message which you want to append in the existing file");

            string fname = "newtext.txt";


            string str = Console.ReadLine();
            try
            {

                using (StreamWriter fileStream = File.CreateText(fname))
                {
                    fileStream.WriteLine("Hello there");
                    fileStream.WriteLine("i am new to creating files in c");
                    fileStream.WriteLine("I'm training in dotnet");
                }

                using (StreamWriter sw = new StreamWriter(fname,true))
                {
                    sw.WriteLine(str);
                }

                Console.WriteLine("--------appending above text to existing contents in file--------------");
                StreamReader sr = new StreamReader(fname);
                Console.WriteLine(sr.ReadToEnd());
                Console.WriteLine("Text appended to the file successfully.");
 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }


    // --------------------------------------- Program 2 ---------------------------------------------------

    public delegate int Calculator(int a, int b);
    class Program2
    {
        public static void Display2()
        {
            // Create instances of the delegate
            Calculator add = Addition;
            Calculator subtract = Subtraction;
            Calculator multiply = Multiplication;

            Console.Write("Enter the first number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int n2 = Convert.ToInt32(Console.ReadLine());

            int sum = add(n1, n2);
            int diff = subtract(n1, n2);
            int prod = multiply(n1, n2);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("What operation do you want Perform in the calculator:");
                Console.WriteLine(" 1) To perform Addition use '+'");
                Console.WriteLine(" 2) To perform Subtraction use '-'");
                Console.WriteLine(" 3) To perform Multiplication use '*'");
              
                char c = char.Parse(Console.ReadLine());
                if (c == '+')
                {
                    Console.WriteLine($"Sum: {sum}");
                    Console.WriteLine("------------------");
                }
                else if (c == '-')
                {
                    Console.WriteLine($"Difference: {diff}");
                    Console.WriteLine("------------------");
                }
                else if (c == '*')
                {
                    Console.WriteLine($"Product: {prod}");
                    Console.WriteLine("------------------");
                }
                else
                {
                    Console.WriteLine("That {0} operation is not available in this calculator",c);
                }
            }

        }
        static int Addition(int a, int b)
        {
            return a + b;
        }
        static int Subtraction(int a, int b)
        {
            return a - b;
        }
        static int Multiplication(int a, int b)
        {
            return a * b;
        }
    }


    // --------------------------------------- Program 3 ---------------------------------------------------
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class EmployeeDetails
    {
        public static void Display3()
        {
            List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("1984-11-16"), DOJ = DateTime.Parse("2011-06-08"), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("1984-08-20"), DOJ = DateTime.Parse("2012-07-07"), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("1987-11-14"), DOJ = DateTime.Parse("2015-04-12"), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1990-06-03"), DOJ = DateTime.Parse("2016-02-02"), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1991-03-08"), DOJ = DateTime.Parse("2016-02-02"), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("1989-11-07"), DOJ = DateTime.Parse("2014-08-08"), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("1989-12-02"), DOJ = DateTime.Parse("2015-06-01"), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("1993-11-11"), DOJ = DateTime.Parse("2014-11-06"), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("1992-08-12"), DOJ = DateTime.Parse("2014-12-03"), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("1991-04-12"), DOJ = DateTime.Parse("2016-01-02"), City = "Pune" }
        };

            Console.WriteLine("Details of all employees:");
            foreach (var emp in empList)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }

            //1) Display details of all the employees whose location is not Mumbai
            var notMumbaiEmployees = empList.Where(emp => emp.City != "Mumbai");
            Console.WriteLine("\nDetails of employees whose location is not Mumbai:");
            foreach (var emp in notMumbaiEmployees)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }

            //2) Display details of all the employees whose title is AsstManager
            var asstManagers = empList.Where(emp => emp.Title == "AsstManager");
            Console.WriteLine("\nDetails of employees whose title is AsstManager:");
            foreach (var emp in asstManagers)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }

            //3) Display details of all the employees whose Last Name starts with S
            var lastNameStartsWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
            Console.WriteLine("\nDetails of employees whose Last Name starts with S:");
            foreach (var emp in lastNameStartsWithS)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }
        }
    }
    
}
