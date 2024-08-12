using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    public abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        //public Student(String stn, int stid, double stg)
        //{
        //    Name = stn;
        //    StudentId = stid;
        //    Grade = stg;
        //}
        public abstract bool BoolPassed(double stg);

        //public void Display()
        //{
        //    Console.WriteLine("Enter Student Name : ");
        //    Name = Convert.ToString(Console.ReadLine());

        //    Console.WriteLine("Enter Student id : ");
        //    StudentId = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Enter Student grade : ");
        //    Grade = Convert.ToDouble(Console.ReadLine());

            
        //}

    }

    public class Undergraduate : Student
    {
        //public Undergraduate(string stn, int sid, double stg) : base(stn, sid, stg)
        //{

        //}
        public void set()
        {
            Console.WriteLine("Enter Student Name : ");
            this.Name = Console.ReadLine();

            Console.WriteLine("Enter Student id : ");
            this.StudentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Student grade : ");
            this.Grade = Convert.ToDouble(Console.ReadLine());
        }
        public void get()
        {

        }
        

        public override bool BoolPassed(double stg)
        {
            return stg > 70.0;
        }

    }
    public class Graduate : Student
    {
        public Graduate(string stn, int sid, double stg) : base(stn, sid, stg)
        {

        }

        public override bool BoolPassed(double stg)
        {
             return stg > 80.0;
        } 

    }

    

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----first program -----");
            

            Student undergrad = new Undergraduate();

            Student grad = new Graduate("deepak", 2001, 90.0);

            Console.WriteLine($"Undergraduate {undergrad.Name} passed: {undergrad.BoolPassed(undergrad.Grade)}");
            Console.WriteLine($"Graduate {grad.Name} passed: {grad.BoolPassed(grad.Grade)}");

            Console.ReadLine();

            Console.WriteLine("-------- Second Program ------");
            Product.Display2();
            Console.WriteLine("------");
            Console.ReadLine();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("------ Third Program-----");
            ExceptionInteger.ExceptionUser();
            Console.ReadLine();



        }
    }

    public class Product
    {
        public int ProductId;
        public string ProductName;
        public decimal Price;
        public Product(int id, string name, decimal price)
        {
            ProductId = id;
            ProductName = name;
            Price = price;
        }

        public static void Display2()
        {
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Enter details for Product {i}:");

                Console.Write("Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Product product = new Product(productId, productName, price);
                products.Add(product);

            }
            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            Console.WriteLine("\nSorted Products based on Price:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.Price}");
            }
            Console.ReadLine();
        }
    }

    class ExceptionInteger
    {
        public static void CheckPositiveNumber(int number)
        {

            if (number < 0)
            {
                Console.WriteLine("Number is negative");
            }
        }

        public static void ExceptionUser()
        {
            try
            {
                Console.Write("Enter positive integer: ");
                int number = Convert.ToInt32(Console.ReadLine());

                CheckPositiveNumber(number);

                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        






    }
}
