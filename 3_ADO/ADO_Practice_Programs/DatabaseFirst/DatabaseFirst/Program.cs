using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    // add adoframework
    // entities
    class Program
    {
        //let us create an object of the context class
        static InfiniteTrainingdbEntities db = new InfiniteTrainingdbEntities();
        static void Main(string[] args)
        {
            ShowEmployees();
            //let us verify various entity states
            Console.WriteLine("***********Entity States***********");
            tblemployee emp1 = new tblemployee();
            Console.WriteLine($"State of a newly created Object : {db.Entry(emp1).State}");

            Console.WriteLine("Enter Details of who you need to insert into the table");
            
            Console.WriteLine("Enter empid: ");
            emp1.Empid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter empname: ");
            emp1.Empname =Console.ReadLine();

            Console.WriteLine("Enter Gender: ");
            emp1.Gender = Console.ReadLine();

            Console.WriteLine("Enter salary: ");
            emp1.Salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter phoneNo: ");
            emp1.Phoneno = Console.ReadLine();

            Console.WriteLine("--------Insertion----------");
            AddEmp(emp1);
            ShowEmployees();
            Console.WriteLine("---------Updation---------");
            UpdateEmp();
            ShowEmployees();
            Console.WriteLine("---------Deletion---------");
            DeleteEmp();
            ShowEmployees();
            Console.Read();
        }

        public static void ShowEmployees()
        {
            var emp = db.tblemployees.ToList();

            foreach (var e in emp)
            {
                Console.WriteLine(e.Empid + " " + e.Empname + " " + e.Salary + " " + e.DeptNo);
            }
        }
        public static void AddEmp(tblemployee e)
        {
            Console.WriteLine($"Before Add/Insert, the Entity State : {db.Entry(e).State}");
            db.tblemployees.Add(e);
            Console.WriteLine($"Before Saving Changes , the Entity State :{db.Entry(e).State}");
            db.SaveChanges(); //this functions ensures the changes are made to the database
            Console.WriteLine($"After Insertion, The Entity State : {db.Entry(e).State}");
        }

        public static void UpdateEmp()
        {
            Console.WriteLine("Enter Empid for whom data has to be modified :");
            int eid = Convert.ToInt32(Console.ReadLine());
            tblemployee te = db.tblemployees.Find(eid);
            Console.WriteLine($"Before Update , the Entity State : {db.Entry(te).State}");

            if (te != null)
            {
                te.DeptNo = 1;
                Console.WriteLine($"After Updation, The Entity State : {db.Entry(te).State}");
                db.SaveChanges();
                Console.WriteLine($"After save changes, The Entity State : {db.Entry(te).State}");
            }
            else
            {
                Console.WriteLine("matching Record not found");
            }

        }

        public static void DeleteEmp()
        {
            Console.WriteLine("Enter EmployeeID to delete");
            int empid = Convert.ToInt32(Console.ReadLine());
            tblemployee temp = db.tblemployees.Find(empid);
            Console.WriteLine($" Before Deleting , The Entity State : {db.Entry(temp).State}");
            db.tblemployees.Remove(temp);
            Console.WriteLine($"After Deleting, The Entity State : {db.Entry(temp).State}");
            db.SaveChanges();
            Console.WriteLine($"After save changes , The Entity State : {db.Entry(temp).State}");
        }
    }
}