using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CC1
{
    // 3. Using ADO.net classes/methods, insert employee details by calling the procedure
    // 4. Display all employee rows
    class Program
    {
        public static SqlConnection con=null;
        public static SqlCommand cmd;
        public static SqlDataReader dr;


        static void Main(string[] args)
        {
            InsertDataAndDisplay();
            Console.ReadLine();
        }

        private static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = ICS-LT-97LQ4D3\\SQLEXPRESS; initial catalog = Employeemanagement;" +
                "user id= sa; password=Ramsusi@4567;");
            con.Open();
            return con;
        }

        public static void InsertDataAndDisplay()
        {
            con = getConnection();
            //int Empno;
            string Empname;
            float Empsal;
            char Emptype;

            Console.WriteLine("enter Employee details to insert into table");
            //Empno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter employee Name: ");
            Empname = Console.ReadLine();

            Console.Write("Enter employee salary: ");
            Empsal = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter employee type ('F' for Fulltime, 'P' for PartTime): ");
            Emptype = char.ToUpper(Console.ReadKey().KeyChar);

            //cmd = new SqlCommand("Insert into Employee_Details values(@Empno,@Empname,@Empsal,@Emptype)", con);

            cmd = new SqlCommand("sp_insert_emp_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ename", Empname);
            cmd.Parameters.AddWithValue("@Esal", Empsal);
            cmd.Parameters.AddWithValue("@Emptype", Emptype);

            Console.WriteLine(" ");
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                Console.WriteLine("Insertion success in the Employee_Details Table");
            else
                Console.WriteLine("Data not Inserted");

            SqlCommand cmd1 = new SqlCommand("select * from Employee_Details", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " | " + dr[1] + " | " + dr[2] + " | " + dr[3]);

            }
        }
    }
}
