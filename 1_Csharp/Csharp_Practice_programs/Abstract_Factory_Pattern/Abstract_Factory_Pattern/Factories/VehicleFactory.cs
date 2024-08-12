using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Pattern.Factories
{
    public abstract class VehicleFactory
    {
        //abstract
        public abstract IBike GetBike(string biketype);
        public abstract ICar GetCar(string cartype);

        //non abstract
        public static VehicleFactory CreateVehicleFactory(string factorytype)
        {
            if (factorytype.Equals("Bike"))
            {
                return new Bike_VehicleFactory();
            }
            else if (factorytype.Equals("Car"))
            {
                return new Car_VehicleFactory();
            }
            else
                return null;
        }
    }
}
