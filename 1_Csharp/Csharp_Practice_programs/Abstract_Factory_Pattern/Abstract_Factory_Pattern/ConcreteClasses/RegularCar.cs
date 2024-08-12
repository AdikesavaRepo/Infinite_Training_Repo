using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Pattern.ConcreteClasses
{
    public class RegularCar : ICar
    {
        public string Sound()
        {
            return "Car sound is normal";
        }
    }
}
