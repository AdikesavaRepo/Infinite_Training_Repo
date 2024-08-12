using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BuildingRelations
{
    class Relations_Constraints
    {
        public static void Main()
        {
            DataSet ds = new DataSet();

            DataTable ClassTable = ds.Tables.Add("OurClass");
            ClassTable.Columns.Add("CId", typeof(int));
            ClassTable.Columns.Add("ClassName", typeof(string));

            DataTable StudentTable = ds.Tables.Add("Students");
            StudentTable.Columns.Add("ClassId", typeof(int));
            StudentTable.Columns.Add("SId", typeof(int));
            StudentTable.Columns.Add("SName", typeof(string));

            // Initialize PK(Primary Key) constraint
            ClassTable.PrimaryKey = new DataColumn[] { ClassTable.Columns["CId"] };
            //StudentTable.PrimaryKey = new DataColumn[] { StudentTable.Columns["SId"] };

            // Add relation 
            ds.Relations.Add("classstudent", ClassTable.Columns["CId"], StudentTable.Columns["ClassId"]);

            // Initialize FK(Foreign Key) constraint
            DataColumn dcclassid = ds.Tables["OurClass"].Columns["CId"];
            DataColumn dcstudentid = ds.Tables["Students"].Columns["ClassId"];

            ForeignKeyConstraint fkc = new ForeignKeyConstraint("csfkc", dcclassid, dcstudentid);

            // set rules for foreign key constraint
            fkc.DeleteRule = Rule.SetNull;
            fkc.UpdateRule = Rule.Cascade;

            //add a unique constraint
            UniqueConstraint namecons = new UniqueConstraint(new DataColumn[] { ClassTable.Columns["ClassName"] });

            ds.Tables["OurClass"].Constraints.Add(namecons);

            //add data to class table
            DataRow dr1 = ClassTable.NewRow();
            dr1["CId"] = 1;
            dr1["ClassName"] = "Fifth";
            ClassTable.Rows.Add(dr1);

            dr1 = ClassTable.NewRow();
            dr1["CId"] = 4;
            dr1["ClassName"] = "Sixth";
            ClassTable.Rows.Add(dr1);

            //add data to student table
            DataRow dr2 = StudentTable.NewRow();
            dr2["ClassId"] = 1;
            dr2["SId"] = 1;
            dr2["SName"] = "Infinite";
            StudentTable.Rows.Add(dr2);

            dr2 = StudentTable.NewRow();
            dr2["ClassId"] = 4;
            dr2["SId"] = 2;
            dr2["SName"] = "Computer";
            StudentTable.Rows.Add(dr2);

            dr2 = StudentTable.NewRow();
            dr2["ClassId"] = 1;
            dr2["SId"] = 3;
            dr2["SName"] = "Solutions";
            StudentTable.Rows.Add(dr2);

            // check all violations and display ( unique and pk and fk )

            Console.WriteLine("===================================================================");
            Console.WriteLine("CId               |             ClassName     ");
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (DataRow row in ds.Tables["OurClass"].Rows)
            {
                Console.WriteLine("{0}             |          {1}", row["CId"], row["ClassName"]);
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("ClassId \t     |      SId\t       |    SName");
            Console.WriteLine("---------------------------------------------------------------------------------------");


            foreach (DataRow row in ds.Tables["Students"].Rows)
            {
                Console.WriteLine("{0}    \t     |      {1}   \t       |     {2}", row["ClassId"],
                    row["SId"], row["SName"]);


            }

            Console.Read();

        }
    }
}
