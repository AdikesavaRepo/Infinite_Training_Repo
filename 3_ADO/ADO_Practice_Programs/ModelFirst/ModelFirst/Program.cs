using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {

        static ModelContainer db = new ModelContainer();
        static void Main(string[] args)
        {
            //ShowAllManufacturers();
            ShowCars();

            Console.WriteLine("------Insertions of cars Data----------");
            AddCars();
            ShowCars();

            Console.WriteLine("-------Modifying/Updating-----------");
            UpdateCar();
            ShowCars();

            Console.WriteLine("----------Deleting Particular data or record------");
            DeleteCar();
            ShowCars();
            Console.Read();
        }

        static void ShowAllManufacturers()
        {
            var m = db.Manufacturers.ToList();

            foreach (var item in m)
            {
                Console.WriteLine($"{item.MfrId}, {item.MName},{item.CarType}");
            }
        }

        static void AddCars()
        {
            Car c = new Car();
            Console.WriteLine("Enter Car Details");

            Console.WriteLine("Enter Car Name");
            c.CarName = Console.ReadLine();

            Console.WriteLine("Enter Car Cost");
            c.CarCost = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Manufacturer Id(1 or 2)");
            c.ManufacturerMfrId = Convert.ToInt32(Console.ReadLine());

            db.Cars.Add(c);
            db.SaveChanges();
        }

        public static void ShowCars()
        {
            var car = db.Cars.ToList();

            foreach (var item in car)
            {
                Console.WriteLine(item.CarId + " " + item.CarName + " " + item.CarCost + " " + item.ManufacturerMfrId);
            }
        }

        public static void UpdateCar()
        {
            Console.WriteLine("Enter CarId for what data has to be modified :");
            int BookId = Convert.ToInt32(Console.ReadLine());
            Car c = db.Cars.Find(BookId);
            if (c != null)
            {
                Console.WriteLine("Rename the Car name for which carid u want to modify");
                c.CarName = Console.ReadLine();
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Car Record not found");
            }

        }

        public static void DeleteCar()
        {
            Console.WriteLine("Enter CarID to delete");
            int BookId = Convert.ToInt32(Console.ReadLine());
            Car c1 = db.Cars.Find(BookId);
            db.Cars.Remove(c1);

            db.SaveChanges();
        }
    }
}