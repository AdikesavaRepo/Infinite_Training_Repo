using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BuildingRelations
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Let us create an in-memory cache dataset
            DataSet dsEmployment = new DataSet("Employement");

            // ----------------------------------------------------------------------------------------
            // 2. creating table 1
            DataTable dtEmployees = new DataTable("Employees");

            // 3. Define columns to data table 1
            DataColumn[] dcEmployees = new DataColumn[4];
            dcEmployees[0] = new DataColumn("EmpCode", System.Type.GetType("System.Int32"));
            dcEmployees[1] = new DataColumn("EmpName", System.Type.GetType("System.String"));
            dcEmployees[2] = new DataColumn("EmpDept", System.Type.GetType("System.String"));
            dcEmployees[3] = new DataColumn("EmpStatusID", System.Type.GetType("System.Int32"));

            // 4. Add the column data to above dtemployees 1
            dtEmployees.Columns.Add(dcEmployees[0]);
            dtEmployees.Columns.Add(dcEmployees[1]);
            dtEmployees.Columns.Add(dcEmployees[2]);
            dtEmployees.Columns.Add(dcEmployees[3]);

            // ---------- Add columns to Table Employees -----------------
            //dtEmployees.Columns.Add("EmpCode", typeof(int));
            //dtEmployees.Columns.Add("EmpName", typeof(string));
            //dtEmployees.Columns.Add("EmpDept", typeof(string));
            //dtEmployees.Columns.Add("EmpStatusID", typeof(int));

            // 5. Add rows/Records with data
            DataRow drEmprows = dtEmployees.NewRow();
            drEmprows["EmpCode"] = 1;
            drEmprows["EmpName"] = "Aishwarya";
            drEmprows["EmpDept"] = "IT";
            drEmprows["EmpStatusID"] = 1;

            // 6. add this data into table dtemployees 1
            dtEmployees.Rows.Add(drEmprows);

            // add more rows/records with data
            drEmprows = dtEmployees.NewRow();
            drEmprows["EmpCode"] = 2;
            drEmprows["EmpName"] = "Rajesh";
            drEmprows["EmpDept"] = "Finance";
            drEmprows["EmpStatusID"] = 3;
            dtEmployees.Rows.Add(drEmprows);

            drEmprows = dtEmployees.NewRow();
            drEmprows["EmpCode"] = 3;
            drEmprows["EmpName"] = "Suraj";
            drEmprows["EmpDept"] = "Accounts";
            drEmprows["EmpStatusID"] = 1;
            dtEmployees.Rows.Add(drEmprows);

            drEmprows = dtEmployees.NewRow();
            drEmprows["EmpCode"] = 4;
            drEmprows["EmpName"] = "Swapna";
            drEmprows["EmpDept"] = "Finance";
            drEmprows["EmpStatusID"] = 3;
            dtEmployees.Rows.Add(drEmprows);

            drEmprows = dtEmployees.NewRow();
            drEmprows["EmpCode"] = 5;
            drEmprows["EmpName"] = "Gurukiran";
            drEmprows["EmpDept"] = "Operations";
            drEmprows["EmpStatusID"] = 4;
            dtEmployees.Rows.Add(drEmprows);

            drEmprows = dtEmployees.NewRow();
            drEmprows["EmpCode"] = 6;
            drEmprows["EmpName"] = "Tanmayee";
            drEmprows["EmpDept"] = "Admin";
            drEmprows["EmpStatusID"] = 4;
            dtEmployees.Rows.Add(drEmprows);

            //--------------------------------------------------------------------------------------
            // 7. Create table dtempstatus table 2
            DataTable dtEmpStatus = new DataTable("EmployeeStatus");

            // 8.  columns for table 2
            DataColumn[] dcstatus = new DataColumn[2];
            dcstatus[0] = new DataColumn("EmpStatusID", System.Type.GetType("System.Int32"));
            dcstatus[1] = new DataColumn("EmpStatus", System.Type.GetType("System.String"));

            // 9. Adding those columns in table 2
            dtEmpStatus.Columns.Add(dcstatus[0]);
            dtEmpStatus.Columns.Add(dcstatus[1]);

            // 10. Rows for table 2
            DataRow drstatus = dtEmpStatus.NewRow();

            drstatus["EmpStatusID"] = "1";
            drstatus["EmpStatus"] = "Full Time";
            dtEmpStatus.Rows.Add(drstatus);

            drstatus = dtEmpStatus.NewRow();
            drstatus["EmpStatusID"] = "2";
            drstatus["EmpStatus"] = "Pert Time";
            dtEmpStatus.Rows.Add(drstatus);

            drstatus = dtEmpStatus.NewRow();
            drstatus["EmpStatusID"] = "3";
            drstatus["EmpStatus"] = "Contract";
            dtEmpStatus.Rows.Add(drstatus);

            drstatus = dtEmpStatus.NewRow();
            drstatus["EmpStatusID"] = "4";
            drstatus["EmpStatus"] = "Intern";
            dtEmpStatus.Rows.Add(drstatus);


            // ---------------------------------------------------------------------------------------------
            // 11. add tables into datasets

            dsEmployment.Tables.Add(dtEmployees);
            dsEmployment.Tables.Add(dtEmpStatus);

            // 12. setting relationships between 2 tables

            // 12.1 Primary ket and Foreign key
            DataColumn parent = dsEmployment.Tables["EmployeeStatus"].Columns["EmpStatusID"];
            DataColumn child = dsEmployment.Tables["Employees"].Columns["EmpStatusID"];

            // 12.2 setting relation
            DataRelation emprel = new DataRelation("EmpStatusRelation", parent, child);

            // 12.3 adding relation to that dataset
            dsEmployment.Relations.Add(emprel);

            // 13. display data as per relationship
            Console.WriteLine("===================================================================");
            Console.WriteLine("Status ID             |             Employee Status     ");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (DataRow row in dsEmployment.Tables["EmployeeStatus"].Rows)
            {
                Console.WriteLine("{0}             |          {1}", row["EmpStatusID"], row["EmpStatus"]);
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("EmpCode \t     |      Empname\t       |    Department\t        |        EmployeeStatus");
            Console.WriteLine("---------------------------------------------------------------------------------------");


            foreach (DataRow row in dsEmployment.Tables["Employees"].Rows)
            {
                Console.WriteLine("{0}    \t     |      {1}   \t       |     {2}    \t      |       {3}", row["Empcode"],
                    row["EmpName"], row["EmpDept"], row["EmpStatusID"]);


            }
            Console.ReadLine();
        }
    }
}
