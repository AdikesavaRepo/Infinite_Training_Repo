using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Pattern.ConcreteClasses
{
    public class SportsBike : IBike
    {
        public string Sound()
        {
            return " Bike sound is soooooo loud with high power";
        }
    }
}
