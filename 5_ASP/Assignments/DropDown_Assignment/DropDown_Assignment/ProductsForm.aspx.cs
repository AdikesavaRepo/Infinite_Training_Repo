using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DropDown_Assignment
{
    public partial class ProductsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProductsDropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ProductImage(ProductsDropDownList1.SelectedValue);
        }

        protected void btnprice_Click(object sender, EventArgs e)
        {
            string product = ProductsDropDownList1.SelectedValue;
            string price = ProductPrice(product);
            if(product == "Apples")
            {
                lblprice.Text = $"Price of {product} = {price} /kg";
            }
            else if(product == "Desks")
            {
                lblprice.Text = $"Price of {product} = {price} /1Unit";
            }
            else if (product == "Milk")
            {
                lblprice.Text = $"Price of {product} = {price} /litre";
            }
            else if (product == "Mobiles")
            {
                lblprice.Text = $"Price of {product} = {price} /1Unit";
            }
            else if (product == "RiceBags")
            {
                lblprice.Text = $"Price of {product} = {price} /kg";
            }
            else if (product == "Televisions")
            {
                lblprice.Text = $"Price of {product} = {price} /1Unit";
            }
            
        }

        private void ProductImage(string product)
        {
           
            productsimg.ImageUrl= $"~/Products/{product.ToLower()}.jpg";
        }

        private string ProductPrice(string product)
        {
            switch (product)
            {
                case "Apples":
                    return "100";
                case "Desks":
                    return "1000";
                case "Milk":
                    return "50";
                case "Mobiles":
                    return "20000";
                case "RiceBags":
                    return "1200";
                case "Televisions":
                    return "10000";
                default:
                    return "0";
            }
        }
    }
}