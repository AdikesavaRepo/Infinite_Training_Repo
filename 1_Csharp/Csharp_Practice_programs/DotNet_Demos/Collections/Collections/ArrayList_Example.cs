using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections
{
    class ArrayList_Example
    {
        public static void ArrayListEg() 
        {
            ArrayList arrlist1 = new ArrayList();
            arrlist1.Add(10);
            arrlist1.Add("aadi");
            arrlist1.Add(565.7f);
            arrlist1.Add(true);
            //arrlist1.
            //arrlist1.Sort();

            foreach (var i in arrlist1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("total elements in arraylist are : "+ arrlist1.Count);


            Console.WriteLine("-----------------------------");
            ArrayList arrlist2 = new ArrayList();
            arrlist2.Add(10);
            arrlist2.Add(33);
            arrlist2.Add(565);
            arrlist2.Add(3);

            arrlist2.Sort();
            Console.WriteLine(arrlist2);
        }



        public static void Main()
        {
            ArrayListEg();
            Console.Read();
        }
    }
}
