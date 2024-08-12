using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CachingPrj
{
    public partial class OtherForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write(string.Format($"The name is {Context.Items["Name"].ToString()} and Email is " ));
            }
            catch(NullReferenceException ne)
            {
                Response.Write(ne.Message);
            }
        }
    }
}