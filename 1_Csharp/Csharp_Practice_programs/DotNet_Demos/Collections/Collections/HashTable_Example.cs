using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections
{
    class HashTable_Example
    {
        public static void HashTableEg()
        {
            Hashtable ht1 = new Hashtable(); //key cannot be null
            ht1.Add("id1", "aadi");
            ht1.Add("id2", "deep");
            ht1.Add("id4", "sam");
            ht1.Add("id3", "sant");

            Console.WriteLine("---------keys----------");
            foreach (var i in ht1.Keys)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("---------values----------");
            foreach (var i in ht1.Values)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------key and values together----------");
            foreach (DictionaryEntry de in ht1)
            {
                Console.Write(de.Key+" ");
                Console.Write(de.Value);
                Console.WriteLine();
            }

            Console.WriteLine("---------searching records by key----------");
            Console.WriteLine("Enter key: ");
            string ekey = Console.ReadLine();
            if (ht1.ContainsKey(ekey))
            {
                Console.WriteLine(ekey + " = " + ht1[ekey]);
            }
            else
            {
                Console.WriteLine(ekey + " does not in dictionary");
            }

            Console.WriteLine("---------searching records by values----------");
            Console.WriteLine("Enter key: ");
            string evalue = Console.ReadLine();
            if (ht1.ContainsValue(evalue))
            {
                Console.WriteLine(evalue);
            }
            else
            {
                Console.WriteLine(evalue + " does not in dictionary");
            }
        }

        public static void SortedListEg()
        {
            SortedList sl1 = new SortedList();
            sl1.Add("ora", "oracle");
            sl1.Add("vb", "virtual basic");
            sl1.Add("aadi", "kesava");

            foreach (DictionaryEntry de in sl1)
            {
                Console.Write(de.Key + " "+ de.Value);
                Console.WriteLine();
            }

        }

        public static void stackEg()
        {
            Stack s = new Stack();
            s.Push("aadi");
            s.Push(56);
            s.Push("gf");

            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----------------");   //last in (push) First out(pop)
            s.Pop();
            foreach (var i in s)
            {
                Console.WriteLine(i);
            }

        }
        public static void QueueEg()
        {
            Queue q1 = new Queue();


        }





        static void Main()
        {
            //HashTableEg();
            //SortedListEg();
            stackEg();
            Console.Read();
        }
    }
}
