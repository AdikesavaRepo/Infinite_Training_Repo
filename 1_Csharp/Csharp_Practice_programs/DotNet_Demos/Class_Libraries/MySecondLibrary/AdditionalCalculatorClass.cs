using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstLibrary;

namespace MySecondLibrary
{
    public static class AdditionalCalculatorClass
    {
        public static int MultiplyNos(this CalculatorClass ccobg , int x, int y)
        {
            return x * y;
        }
    }
}
