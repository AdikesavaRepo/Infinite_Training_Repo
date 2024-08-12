using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Program
    {
        static void Display1()
        {
            Console.WriteLine("Enter First Name");
            string FirstName = Console.ReadLine();
            //FirstName.ToUpper();

            Console.WriteLine("Enter Last Name");
            string LastName = Console.ReadLine();
            //LastName.ToUpper();

            Console.WriteLine("The full Name is: ");
            Console.WriteLine(FirstName.ToUpper());
            Console.WriteLine(LastName.ToUpper());
        }

        static void Display2()
        {
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();

            Console.WriteLine("Enter the Letter to count it occurences in the given string");
            char c = Convert.ToChar(Console.Read());

            int count=0;
            foreach (char i in str)
            {
                if (i == c)
                    count++;
            }
            Console.WriteLine($" {c} appeared {count} times");
            Console.ReadLine();
         


        }
        static void Main()
        {
            Console.WriteLine("1. Create a Class Program which would be used to accepts two  Strings - FirstName and LastName and call the static method Display() that displays the first name in one line and the LastName in the second line after converting the same to upper case.");
            Console.WriteLine("---");
            Display1();
            Console.WriteLine("---------------------------");

            Console.WriteLine("2. Create a Program to count the no. of occurrences of a letter in a given string");
            Console.WriteLine("---");
            Display2();
            Console.WriteLine("---------------------------");


            Console.WriteLine("4. Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input. ");
            Console.WriteLine("---");
            Scholarship.Merit();
            Console.WriteLine("---------------------------");

            Console.WriteLine("5. Create a Class called Doctor with RegnNo, Name, Feescharged as Private members. Create properties to give values and also to display the same.");
            Console.WriteLine("---");
            Doctor doctor = new Doctor(1, "aadi", 10000);
            doctor.GetData();
            doctor.display5();

            Console.ReadLine();

        }
    }

    class Scholarship
    {
        public static void Merit()
        {
            Console.WriteLine("Enter Marks");
            int marks = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Fees");
            int Fees = Convert.ToInt32(Console.ReadLine());

            double ScholarshipAmount = 0;
            if (marks >= 70 && marks <= 80)
            {
                ScholarshipAmount = 20 * Fees / 100;
            }
            else if(marks>80 && marks <= 90)
            {
                ScholarshipAmount = 30 * Fees / 100;
            }
            else if (marks > 90)
            {
                ScholarshipAmount = 50 * Fees / 100;
            }

            Console.WriteLine($"Scholarship amount is {ScholarshipAmount}");
            Console.ReadLine();
             

        }
    }

    class Doctor
    {

        private int regNo;
        private string name;
        private double feesCharged;

        public int RegNo
        {
            get { return regNo; }
            set { regNo = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double FeesCharged
        {
            get { return feesCharged; }
            set { feesCharged = value; }
        }

        public Doctor(int rno, string rname, double fees)
        {
            RegNo = rno;
            Name = rname;
            FeesCharged = fees;
        }

        public void GetData()
        {
            Console.WriteLine("Enter Registration Number: ");
            regNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Fees Charged: ");
            feesCharged = Convert.ToInt32(Console.ReadLine());

        }

        public void display5()
        {


            Console.WriteLine("Registration Number is " + regNo);
            Console.WriteLine("Name is " + name);
            Console.WriteLine("Fees Charged is " + feesCharged);

            Console.ReadLine();

        }


    }

    




    


}
