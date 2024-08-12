using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_Factory_Pattern.Factories;

namespace Abstract_Factory_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IBike bike = null;
            ICar car = null;
            Factories.VehicleFactory vehicleFactory = null;

            string sound = null;

            //creating respective factory objects
            Console.WriteLine("Enter the Factory Type Bike/Car:");
            string factorytype = Console.ReadLine();
            vehicleFactory = Factories.VehicleFactory.CreateVehicleFactory(factorytype);
            
            Console.WriteLine("Factory Type Chosen is {0}" , vehicleFactory.GetType().Name);
            Console.WriteLine();

            if (factorytype.Equals("Bike"))
            {
                Console.WriteLine("Enter Regular/Sports :");
                string reqbike = Console.ReadLine();
                bike = vehicleFactory.GetBike(reqbike);
                
                //Console.WriteLine("The Chosen bike is  : {0}", bike.GetType().Name);

                sound = bike.Sound();
                Console.WriteLine($" The Factory is  : {vehicleFactory}, and the vehicle is  : {bike} producing" +
                    $"the sound   : {sound}");
            }

            else if (factorytype.Equals("Car"))
            {
                Console.WriteLine("Enter Regular/Sports :");
                string reqcar = Console.ReadLine();
                car = vehicleFactory.GetCar(reqcar);
               // Console.WriteLine("The Chosen Animal is {0}", car.GetType().Name);

                sound = car.Sound();
                Console.WriteLine($" The Factory is :  {vehicleFactory}, and the vehicle is : {car} Producing" +
                    $"the sound : {sound}");
            }
            else
                Console.WriteLine("Please choose correct vehicle");
            Console.ReadLine();

        }
    }
}
