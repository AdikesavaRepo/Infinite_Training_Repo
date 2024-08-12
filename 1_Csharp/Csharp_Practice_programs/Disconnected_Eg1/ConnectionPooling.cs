using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Disconnected_Eg1
{
    class ConnectionPooling
    {
        public static string connectstr = "data source = ICS-LT-97LQ4D3\\SQLEXPRESS; initial catalog = northwind;" +
                "user id= sa; password=Ramsusi@4567;";

        public static void Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                SqlConnection con = new SqlConnection(connectstr);
                con.Open();
                con.Close();
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken : {stopwatch.ElapsedMilliseconds} ms ");

            Transaction_Eg(connectstr);
            Console.ReadLine();
        }

        public static void Transaction_Eg(string str)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                SqlTransaction tran;

                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                try
                {
                    int RegionID;
                    string RegionDescription;
                    Console.WriteLine("enter details of id and name to insert new row :");

                    RegionID = Convert.ToInt32(Console.ReadLine());
                    RegionDescription = Console.ReadLine();

                    cmd.CommandText = "Insert into Region values(@RegionID,@RegionDescription)";
                    cmd.Parameters.AddWithValue("@RegionID", RegionID);
                    cmd.Parameters.AddWithValue("@RegionDescription", RegionDescription);
                    cmd.ExecuteNonQuery();

                    //cmd.CommandText = "Insert into Region values(100, 'New Region')";
                    //cmd.ExecuteNonQuery();

                    cmd.CommandText = "update Region set regiondescription = 'SouthEastern' where regionid = 1";
                    cmd.ExecuteNonQuery();

                    tran.Commit();
                    Console.WriteLine("2 Transaction successful");

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Something went wrong in transaction...try later");
                    try
                    {
                        tran.Rollback();
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                    }
                }

            }
        }
    }
}
