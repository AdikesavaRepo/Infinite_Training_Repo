using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link_Assignment
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine("--------------------------------------------");

            // 1. Display a list of all the employee who have joined before 1/1/2015
            DateTime dt1 = new DateTime(2015,01,01);
            var result1 = from emp in empList where emp.DOJ < dt1 select emp;
            Console.WriteLine("list of all the employee who have joined before 1/1/2015");
            foreach (var emp in result1)
            {
                Console.WriteLine(emp.EmployeeID+" "+emp.FirstName+" "+emp.LastName+" "+emp.DOJ); 
            }
            Console.WriteLine("--------------------------------------------");

            // 2. Display a list of all the employee whose date of birth is after 1/1/1990
            DateTime dt2 = new DateTime(1990, 01, 01);
            var result2 = from emp in empList where emp.DOB > dt2 select emp;
            Console.WriteLine("list of all the employee whose date of birth is after 1/1/1990");
            foreach (var emp in result2)
            {
                Console.WriteLine(emp.EmployeeID + " " + emp.FirstName + " " + emp.LastName + " " + emp.DOB);
            }
            Console.WriteLine("--------------------------------------------");

            // 3. Display a list of all the employee whose designation is Consultant and Associate
            var result3 = from emp in empList where emp.Title == "Consultant" || emp.Title == "Associate" select emp;
            Console.WriteLine("list of all the employee whose designation is Consultant and Associate");
            foreach (var emp in result3)
            {
                Console.WriteLine(emp.EmployeeID + " " + emp.FirstName + " " + emp.LastName + " " + emp.Title);
            }
            Console.WriteLine("--------------------------------------------");

            // 4. Display total number of employees
            var result4 = empList.Count();
            Console.WriteLine($"Total number of employees: {result4}");
            Console.WriteLine("--------------------------------------------");

            // 5. Display total number of employees belonging to “Chennai”
            var result5 = empList.Count(emp => emp.City == "Chennai");
            Console.WriteLine($"total number of employees belonging to “Chennai ”:{result5}");
            Console.WriteLine("--------------------------------------------");

            // 6. Display highest employee id from the list
            var result6 = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine($"highest employee id from the list is :{result6}");
            Console.WriteLine("--------------------------------------------");

            // 7. Display total number of employee who have joined after 1/1/2015
            DateTime dt3 = new DateTime(2015, 01, 01);
            var result7 = empList.Count(emp => emp.DOJ > dt3);
            Console.WriteLine($"total number of employee who have joined after 1/1/2015 are :{result7}");
            Console.WriteLine("--------------------------------------------");

            // 8. Display total number of employee whose designation is not “Associate”
            var result8 = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"total number of employee whose designation is not “Associate” are :{result8}");
            Console.WriteLine("--------------------------------------------");

            // 9. Display total number of employee based on City
            var result9 = empList.GroupBy(emp => emp.City).Select(group => new { City = group.Key, Count = group.Count() });
            Console.WriteLine("Total number of employees based on City:");
            foreach (var c in result9)
            {
                Console.WriteLine($"{c.City}: {c.Count}");
            }
            Console.WriteLine("--------------------------------------------");

            // 10. Display total number of employee based on city and title
            var result10 = empList.GroupBy(emp => new { emp.City, emp.Title }).Select(group => new
            {
                City = group.Key.City,
                Title = group.Key.Title,
                Count = group.Count()
            });
            Console.WriteLine("Total number of employees based on City and Title:");
            foreach (var ct in result10)
            {
                Console.WriteLine($"{ct.City} - {ct.Title}: {ct.Count}");
            }
            Console.WriteLine("--------------------------------------------");

            // 11. Display total number of employee who is youngest in the list
            var result11 = empList.GroupBy(emp => emp.DOB).OrderBy(group => group.Key).First().Count();
            Console.WriteLine($"total number of employee who is youngest in the list :{result11}");
            Console.WriteLine("--------------------------------------------");


            Console.ReadLine();
        }
    }

    


}
