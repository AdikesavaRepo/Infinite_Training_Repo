using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class SingletonEg
    {
        private static int counter = 0;

        private static SingletonEg stobj = null;

        public static SingletonEg GetInstance()
        {
            if (stobj == null)
            {
                stobj = new SingletonEg();
                Console.WriteLine("SingleTon Objects hash code :" + " " + stobj.GetHashCode());
            }
            return stobj;
        }

        //private constructor so that no instance is possible outside the class
        private SingletonEg()
        {
            counter++;
            Console.WriteLine("Counter value : " + " " + counter.ToString());
        }

        //normal instance methods
        public void Show(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
