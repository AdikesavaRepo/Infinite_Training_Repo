using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sqlconnection1
{
    class Region
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
        public DataAccess da;
        public String InsertRegion()
        {
            Console.WriteLine("Enter Region ID");
            RegionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Region Description");
            RegionDescription = Console.ReadLine();
            String retval = DataAccess.InsertRegion(RegionId, RegionDescription);
            return retval;
        }
        public SqlDataReader DisplayRegion()
        {
            SqlDataReader sdr = DataAccess.DisplayRegion();
            return sdr;
        }

        public int RegionCount()
        {
            int count = DataAccess.RegionCount();
            return count;
        }

        public string GetRegion()
        {
            Console.WriteLine("enter region id");
            RegionId = Convert.ToInt32(Console.ReadLine());

            string rname = (string)DataAccess.GetRegion(RegionId);
            return rname;
        }


    }

    //----------------------------------------------------------------
    public class DataAccess
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlConnection getcon()
        {
            con = new SqlConnection("data source = ICS-LT-97LQ4D3\\SQLEXPRESS; initial catalog = northwind;" +
                "user id= sa; password=Ramsusi@4567;");
            con.Open();
            return con;
        }
        public static String InsertRegion(int Rid, string rdesc)
        {
            con = getcon();
            cmd = new SqlCommand("insert into region values(@rid,@rdesc)", con);
            cmd.Parameters.AddWithValue("@rid", Rid);
            cmd.Parameters.AddWithValue("@rdesc", rdesc);
            int res = cmd.ExecuteNonQuery();
            if (res > 0) return "Success";
            else return "Failure";
        }
        public static SqlDataReader DisplayRegion()
        {
            con = getcon();
            cmd = new SqlCommand("Select * from region", con);
            dr = cmd.ExecuteReader();
            return dr;
        }

        public static int RegionCount()
        {
            con = getcon();
            cmd = new SqlCommand("Select count(regionid) from region", con);
            int count = (int)cmd.ExecuteScalar();

            return count;
        }

        public static string GetRegion(int Rid)
        {
            con = getcon();
            cmd = new SqlCommand("sp_getDescription", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rid", Rid);
            string regionname = cmd.ExecuteScalar().ToString();
            return regionname;
        }


    }

    //----------------------------- CLIENT ------------------------------------------------------
    class Client
    {
        static void Main()
        {
            Region region = new Region();
            // 1) Insert new region
            string inserted = region.InsertRegion();
            Console.WriteLine("Insert Result: " + inserted);
            // 2) Display regions
            SqlDataReader myreader = region.DisplayRegion();
            while (myreader.Read())
            {
                Console.WriteLine(myreader[0] + " " + myreader[1]);
            }

            // 3) count regions
            Console.WriteLine("The total count of regions are {0}", region.RegionCount());

            // 4) Get Region name
            Console.WriteLine("The Region name is  {0}", region.GetRegion());

            // 5) Delete Region

            Console.ReadLine();
        }
    }
}