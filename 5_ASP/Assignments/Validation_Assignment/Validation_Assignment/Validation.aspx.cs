using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validation_Assignment
{
    public partial class Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkbtn_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string family = txtfamname.Text;
            string address = txtaddress.Text;
            string city = txtcity.Text;
            string zip = txtzipcode.Text;
            string phone = txtpone.Text;
            string email = txtmail.Text;

            Label1.Text = $"{name} <br /> {family} <br /> {address} <br /> {city} <br /> {zip} <br /> {phone} <br /> {email}";


        }

        
    }
}