using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Program
    {
        static void Main()
        {
            

            Console.WriteLine("-------------- program 1 -----------------");
            BookShelf.Display1();
            Console.WriteLine("----------------");


            Console.WriteLine("-------------- program 2 -----------------");
            Box.Display2();
            Console.WriteLine("----------------");


            Console.WriteLine("-------------- program 3 -----------------");
            ParttimeEmployee.Display3();
            Console.WriteLine("----------------");


            Console.WriteLine("-------------- program 4 -----------------");
            Resident.Dispaly4();
            Console.WriteLine("----------------");
            Console.Read();
        }

        //------------------------------------ Program 1 ---------------------------------------------------------
        public class Books
        {
            public string BookName { get; set; }
            public string AuthorName { get; set; }
            public Books(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }
            public void Display()
            {
                Console.WriteLine($"Book Name: {BookName}, Author: {AuthorName}");
            }
        }
        public class BookShelf
        {
            private Books[] books = new Books[10];
            public Books this[int index]
            {
                get
                {
                    if (index >= 0 && index < books.Length)
                    {
                        return books[index];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index is out of range for BookShelf.");
                    }
                }
                set
                {
                    if (index >= 0 && index < books.Length)
                    {
                        books[index] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index is out of range for BookShelf.");
                    }
                }
            }
            public static void Display1()
            {
                BookShelf shelf = new BookShelf();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Enter details for Book {i + 1}:");
                    Console.Write("Book Name: ");
                    string bookName = Console.ReadLine();
                    Console.Write("Author Name: ");
                    string authorName = Console.ReadLine();
                    shelf[i] = new Books(bookName, authorName);
                }
                Console.WriteLine("\nBooks on the shelf:");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($"Book {i + 1}: ");
                    shelf[i].Display();
                }
            }
        }



        //-------------------------------- Program 2 ----------------------------------------------------

        public class Box
        {
            public double Length { get; set; }
            public double Breadth { get; set; }
            public Box(double length, double breadth)
            {
                Length = length;
                Breadth = breadth;
            }
            public static Box Add(Box box1, Box box2)
            {
                double sumLength = box1.Length + box2.Length;
                double sumBreadth = box1.Breadth + box2.Breadth;
                return new Box(sumLength, sumBreadth);
            }
            public void Display()
            {
                Console.WriteLine($"Box Dimensions - Length: {Length}, Breadth: {Breadth}");
            }

            public static void Display2()
            {
                Console.WriteLine("Enter dimensions for Box 1:");
                Console.Write("Length: ");
                double length1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Breadth: ");
                double breadth1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nEnter dimensions for Box 2:");
                Console.Write("Length: ");
                double length2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Breadth: ");
                double breadth2 = Convert.ToDouble(Console.ReadLine());
                Box box1 = new Box(length1, breadth1);
                Box box2 = new Box(length2, breadth2);
                Box box3 = Box.Add(box1, box2);
                Console.WriteLine("\nBox 1:");
                box1.Display();
                Console.WriteLine("\nBox 2:");
                box2.Display();
                Console.WriteLine("\nBox 3 (Sum of Box 1 and Box 2):");
                box3.Display();
            }
        }




        // ---------------------------------------- Program 3 ------------------------------------------
        public class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public float Salary { get; set; }
            public Employee(int empId, string empName, float salary)
            {
                EmpId = empId;
                EmpName = empName;
                Salary = salary;
            }
            public virtual void Display()
            {
                Console.WriteLine($"Employee ID: {EmpId}, Employee Name: {EmpName}, Salary: {Salary}");
            }
        }
        public class ParttimeEmployee : Employee
        {
            public float Wages { get; set; }
            public ParttimeEmployee(int empId, string empName, float wages)
                : base(empId, empName, 0)
            {
                Wages = wages;
            }
            public override void Display()
            {
                Console.WriteLine($"Part-time Employee ID: {EmpId}, Employee Name: {EmpName}, Wages: {Wages}");
            }

            public static void Display3()
            {
                Console.WriteLine("Enter details for Full-time Employee:");
                Console.Write("Employee ID: ");
                int empId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Employee Name: ");
                string empName = Console.ReadLine();
                Console.Write("Salary: ");
                float salary = Convert.ToSingle(Console.ReadLine());
                Employee emp = new Employee(empId, empName, salary);
                Console.WriteLine("\nEnter details for Part-time Employee:");
                Console.Write("Employee ID: ");
                int empIdPartTime = Convert.ToInt32(Console.ReadLine());
                Console.Write("Employee Name: ");
                string empNamePartTime = Console.ReadLine();
                Console.Write("Wages: ");
                float wages = Convert.ToSingle(Console.ReadLine());
                ParttimeEmployee partTimeEmp = new ParttimeEmployee(empIdPartTime, empNamePartTime, wages);
                Console.WriteLine("\nFull-time Employee Details:");
                emp.Display();
                Console.WriteLine("\nPart-time Employee Details:");
                partTimeEmp.Display();
            }
        }


        //----------------------------------- Program 4 -------------------------------------------------
        public interface IStudent
        {
            int StudentId { get; set; }
            string Name { get; set; }

            void ShowDetails();
        }
        public class Dayscholar : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }

            public void ShowDetails()
            {
                Console.WriteLine($"Dayscholar - Student ID: {StudentId}, Name: {Name}");
            }
        }
        public class Resident : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public void ShowDetails()
            {
                Console.WriteLine($"Resident - Student ID: {StudentId}, Name: {Name}");
            }


            public static void Dispaly4()
            {
                Console.WriteLine("Enter details for Dayscholar:");
                Console.Write("Student ID: ");
                int studentIdDayscholar = Convert.ToInt32(Console.ReadLine());
                Console.Write("Name: ");
                string nameDayscholar = Console.ReadLine();
                Dayscholar dayscholar = new Dayscholar
                {
                    StudentId = studentIdDayscholar,
                    Name = nameDayscholar
                };
                Console.WriteLine("\nEnter details for Resident:");
                Console.Write("Student ID: ");
                int studentIdResident = Convert.ToInt32(Console.ReadLine());
                Console.Write("Name: ");
                string nameResident = Console.ReadLine();
                Resident resident = new Resident
                {
                    StudentId = studentIdResident,
                    Name = nameResident
                };
                Console.WriteLine("\nStudent Details:");
                dayscholar.ShowDetails();
                resident.ShowDetails();
            }

        }

    }
}