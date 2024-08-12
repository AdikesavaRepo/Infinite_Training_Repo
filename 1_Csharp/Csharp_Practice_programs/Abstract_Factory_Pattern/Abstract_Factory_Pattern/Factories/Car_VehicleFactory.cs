using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_Factory_Pattern.ConcreteClasses;

namespace Abstract_Factory_Pattern.Factories
{
    class Car_VehicleFactory : VehicleFactory
    {
        public override IBike GetBike(string biketype)
        {
            throw new NotImplementedException();
        }

        public override ICar GetCar(string cartype)
        {
            if (cartype.Equals("Regular"))
            {
                return new RegularCar();
            }
            else if (cartype.Equals("Sports"))
            {
                return new SportsCar();

            }
            else return null;
        }
    }
}
