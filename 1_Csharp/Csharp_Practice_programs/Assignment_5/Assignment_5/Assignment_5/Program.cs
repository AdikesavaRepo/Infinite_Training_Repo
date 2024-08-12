using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Books
    {
        string BookName;
        string AuthorName;

        public Books(string bName, string aName)
        {
            BookName = bName;
            AuthorName = aName;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name = {BookName}, Author Name of book = {AuthorName}");
        }
    }


    class BookShelf
    {
        Books[] books = new Books[5];

        public Books this[int index]
        {
            get
            {
                if (index < 0 || index > books.Length)
                    throw new IndexOutOfRangeException("index is out of range");
                return books[index];
            }

            set
            {
                if (index < 0 || index > books.Length)
                    throw new IndexOutOfRangeException("index is out of range");
                books[index] = value;
            }
        }

        public void displayBooks()
        {
            for(int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"Book #{i + 1}:");
                if (books[i] != null)
                    books[i].Display();
                else
                    Console.WriteLine("Empty");
                Console.WriteLine();
            }
        }

        public static void Display1()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf[0] = new Books(" book alien ", " author predator ");
            bookShelf[1] = new Books(" book tenet ", " author nolan ");
            bookShelf[2] = new Books(" book avengers ", " author marvel ");
            bookShelf[3] = new Books(" book5 vikings ", " author valhalla ");
            bookShelf[4] = new Books(" book6 vampired ", " author salvatore ");

            bookShelf.displayBooks();
            Console.ReadLine();
        }
    }

    public class Box
    {
        double Length;
        double Breadth;

        public Box(double len, double wid)
        {
            Length = len;
            Breadth = wid;
        }

        public static Box AddBoxes(Box box1, Box box2)
        {
            double length = box1.Length + box2.Length;
            double breadth = box1.Breadth + box2.Breadth;

            Box thirdBox = new Box(length, breadth);
            return thirdBox;
        }

        public static void Display2()
        {
            Box box1 = new Box(5, 3);
            Box box2 = new Box(4, 2);

            Box box3 = Box.AddBoxes(box1, box2);

            Console.WriteLine($"Dimensions of Box 1: Length = {box1.Length}, Breadth = {box1.Breadth}");
            Console.WriteLine($"Dimensions of Box 2: Length = {box2.Length}, Breadth = {box2.Breadth}");
            Console.WriteLine($"Dimensions of Box 3 (result): Length = {box3.Length}, Breadth = {box3.Breadth}");
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public float Salary { get; set; }

        public Employee(int id,string name, float sal)
        {
            EmpId = id;
            EmpName = name;
            Salary = sal;
        }

        public void BaseDisplay()
        {
            Console.WriteLine($"Employee ID: {EmpId}");
            Console.WriteLine($"Employee Name: {EmpName}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }

    class PartTimeEmployee : Employee
    {
        public float Wages { get; set; }

        public PartTimeEmployee(int id, string name, float sal,float wages) : base(id, name, sal)
        {
            Wages = wages;
        }

        public static void Display3()
        {
            PartTimeEmployee partTimeEmp = new PartTimeEmployee(101, "John Doe", 2000.0f, 15.5f);

            Console.WriteLine("Details of Part-Time Employee:");
            base.BaseDisplay();
            Console.WriteLine($"Wages = {Wages}");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ Program 1 ----------");
            BookShelf.Display1();
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("------ Program 2 ----------");
            Box.Display2();
            Console.WriteLine("-------------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("------ Program 2 ----------");
            PartTimeEmployee.Display3();
            Console.WriteLine("-------------------------------------------------------------");
            Console.ReadLine();

        }
    }
}
