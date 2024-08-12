using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_Factory_Pattern.ConcreteClasses;

namespace Abstract_Factory_Pattern.Factories
{
    class Bike_VehicleFactory : VehicleFactory
    {
        public override IBike GetBike(string biketype)
        {
            if (biketype.Equals("Regular"))
            {
                return new RegularBike();
            }
            else if (biketype.Equals("Sports"))
            {
                return new SportsBike();
            }
            else
                return null;
        }

        public override ICar GetCar(string cartype)
        {
            throw new NotImplementedException();
        }
    }
}
