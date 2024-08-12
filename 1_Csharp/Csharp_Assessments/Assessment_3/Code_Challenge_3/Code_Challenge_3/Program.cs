using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_3
{
    class Cricket
    {
        public static void PointsCalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter score for match {i + 1}: ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }
            double average = sum / no_of_matches;

            Console.WriteLine($"Sum of the scores: {sum}");
            Console.WriteLine($"Average of the score: {average}");
        }
    }

    //----------------------------------------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------- Program 1 ------------------------");
            Console.Write("Enter the number of matches: ");
            int numberOfMatches = Convert.ToInt32(Console.ReadLine());

            Cricket.PointsCalculation(numberOfMatches);

            Console.WriteLine("------------- Program 2 ------------------------");
            TestClass.Display2();
            Console.ReadLine();
        }
    }

    //--------------------------------------------------------------------------------------------------------

    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box Add(Box box1, Box box2)
        {
            double NewLength = box1.Length + box2.Length;
            double NewBreadth = box1.Breadth + box2.Breadth;
            return new Box(NewLength, NewBreadth);
        }
        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    class TestClass
    {
        public static void Display2()
        {
            Console.WriteLine("Enter dimensions for Box 1:");
            Console.Write("Length: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEnter dimensions for Box 2:");
            Console.Write("Length: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());

            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);
            Box box3 = Box.Add(box1, box2);

            Console.WriteLine("\nDimensions for Box 3 are (Adds 2 Box objects):");
            box3.Display();
        }
    }

}
