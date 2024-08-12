using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CachingPrj
{
    public partial class CacheForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTrainByName("All");
            }
            lbldata.Text = "This Page is Cached @" + " " + DateTime.Now.ToString();

        }

        private void GetTrainByName(string Train_Name)
        {
            SqlConnection con = new SqlConnection("Data Source = ICS-LT-97LQ4D3\\SQLEXPRESS;"+ "initial catalog = RailwayReservation_Booking_System; user id = sa; password = Ramsusi@4567");
            SqlDataAdapter da = new SqlDataAdapter("sp_Display_Train", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@TName";
            param1.Value = Train_Name;

            da.SelectCommand.Parameters.Add(param1);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dplist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTrainByName(dplist1.SelectedValue);
        }
    }
}