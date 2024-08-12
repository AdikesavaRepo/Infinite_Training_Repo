using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CachingPrj
{
    public partial class RedirectvsTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Context.Items.Add("Name", txtname.Text);
            Context.Items.Add("Email", txtemail.Text);


            Response.Redirect("OtherForm.aspx");
           // Response.Redirect("https://www.w3schools.com/");

            //Server.Transfer("OtherForm.aspx");
            //Server.Transfer("https://www.w3schools.com/"); // wont work

        }
    }
}