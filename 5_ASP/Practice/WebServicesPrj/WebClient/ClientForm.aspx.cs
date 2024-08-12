using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class ClientForm : System.Web.UI.Page
    {
        OurServices.WebService1SoapClient client = new OurServices.WebService1SoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnhello_Click(object sender, EventArgs e)
        {
            lblmsg.Text = client.HelloWorld();
        }

        

        protected void btnsquare_Click(object sender, EventArgs e)
        {
            float square = client.square(float.Parse(txtnum.Text));
            lblmsg.Text = "The Square root is : " + square.ToString();
        }
    }
}