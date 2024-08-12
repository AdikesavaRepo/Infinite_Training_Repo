using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files_Demos
{
    class Program
    {
        public static void WritData()
        {
            FileStream fs = new FileStream(@"C:\Users\adikesavat\infinite\Csharp\Csharp_Practice_programs\Myfile.txt", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            Console.WriteLine("Enter something: ");
            string str = Console.ReadLine();

            sw.Write(str);

            sw.Flush();
            sw.Close();
            fs.Close();

            
        }
        static void Main(string[] args)
        {
            WritData();

        }
    }
}
