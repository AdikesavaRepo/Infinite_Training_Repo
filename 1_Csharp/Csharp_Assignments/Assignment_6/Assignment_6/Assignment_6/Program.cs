using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Program
    {
        public static void Display1()
        {
            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();

            string[] numberStrings = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = numberStrings.Select(int.Parse).ToList();

            //int[] numbers = { 7, 2, 30 };
            foreach (int i in numbers)
            {
                int square = i * i;
                if (square > 20)
                {
                    Console.WriteLine($" {i} -  {square}");
                }
            }
        }

        //------------------------------------------------------------------------------------------------------

        public static void Display2()
        {
            //List<string> words = new List<string> { "mum", "amsterdam", "bloom" };

            Console.WriteLine("Enter words separated by spaces:");
            string input = Console.ReadLine();

            string[] wordArray = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> words = wordArray.ToList();
            var result = from word in words
                         where word.StartsWith("a", StringComparison.OrdinalIgnoreCase) && word.EndsWith("m", StringComparison.OrdinalIgnoreCase)
                         select word;

            Console.WriteLine("Words starting with 'a' and ending with 'm':");
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }

        //------------------------------------------------------------------------------------------------
        
  
      

        static void Main(string[] args)
        {
            Console.WriteLine("---------------------Program 1---------------------");
            Display1();

            Console.WriteLine("---------------------Program 2---------------------");
            Display2();

            Console.WriteLine("---------------------Program 3---------------------");
            Employee.Display3();

            
            
            Console.ReadLine();
            


        }
    }
    //--------------------------------------------------------------------------------------------------------

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }

        public static void Display3()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Aadi Kesava", EmpCity = "Bangalore", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Deepak Vulchi", EmpCity = "Mumbai", EmpSalary = 48000 },
            new Employee { EmpId = 3, EmpName = "Michael Johnson", EmpCity = "Bangalore", EmpSalary = 55000 },
            new Employee { EmpId = 4, EmpName = "Emily Brown", EmpCity = "Delhi", EmpSalary = 42000 },
            new Employee { EmpId = 5, EmpName = "David Lee", EmpCity = "Bangalore", EmpSalary = 46000 }
        };

            Console.WriteLine("a. Display all employees data:");
            DisplayEmployees(employees);

            Console.WriteLine("\nb. Display all employees data whose salary is greater than 45000:");
            DisplayEmployeesWithSalaryGreaterThan(employees, 45000);

            Console.WriteLine("\nc. Display all employees data who belong to Bangalore:");
            DisplayEmployeesFromCity(employees, "Bangalore");

            Console.WriteLine("\nd. Display all employees data by their names in Ascending order:");
            DisplayEmployeesSortedByName(employees);
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            }
        }

        static void DisplayEmployeesWithSalaryGreaterThan(List<Employee> employees, decimal salary)
        {
            var filteredEmployees = employees.Where(emp => emp.EmpSalary > salary);
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            }
        }

        static void DisplayEmployeesFromCity(List<Employee> employees, string city)
        {
            var filteredEmployees = employees.Where(emp => emp.EmpCity.Equals(city, StringComparison.OrdinalIgnoreCase));
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            }
        }

        static void DisplayEmployeesSortedByName(List<Employee> employees)
        {
            var sortedEmployees = employees.OrderBy(emp => emp.EmpName);
            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine($"EmpId: {emp.EmpId}, EmpName: {emp.EmpName}, EmpCity: {emp.EmpCity}, EmpSalary: {emp.EmpSalary}");
            }
        }
    }

    //----------------------------------------------------------------------------------------------------------


    


}
