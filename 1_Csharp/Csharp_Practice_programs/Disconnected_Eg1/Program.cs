using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Disconnected_Eg1
{
    class Program
    {
        public static SqlConnection con = null;
        public static SqlDataAdapter da;
        static void Main(string[] args)
        {
            Disconnected_approach();
            Console.Read();
        }

        public static void Disconnected_approach()
        {
            con = new SqlConnection("data source = ICS-LT-97LQ4D3\\SQLEXPRESS; initial catalog = northwind;" +
                "user id= sa; password=Ramsusi@4567;");
            con.Open();

            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select * from Region", con);
            da.Fill(ds, "NorthwindRegion");
            DataTable dt = ds.Tables["NorthwindRegion"];

            //to access the rows and columns from the datatable
            foreach (DataRow drow in dt.Rows)
            {
                foreach (DataColumn dcol in dt.Columns)
                {
                    Console.Write(drow[dcol]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
        public static void Add_Record_Region()
        {
            con = new SqlConnection("data source = ICS-LT-97LQ4D3\\SQLEXPRESS; initial catalog = northwind;" +
                "user id= sa; password=Ramsusi@4567;");
            con.Open();

            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select * from Region", con);
            da.Fill(ds, "NorthwindRegion");
            DataTable dt = ds.Tables["NorthwindRegion"];

            //inserting new row
            DataRow row = ds.Tables["NorthwindRegion"].NewRow();
            // giving values
            row["RegionID"]= 5;
            row["RegionDescription"] = "SouthEast";

            // add that row into row collection
            ds.Tables["NorthwindRegion"].Rows.Add(row);

            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.InsertCommand = scb.GetInsertCommand();

            da.Update(ds, "NorthwindRegion");
            Console.WriteLine("---- After Insertion --------");
            da.Fill(ds);
            dt = ds.Tables["NorthwindRegion"];


        }
        //



    }
}