using Assignment_2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.Site
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Session ["cart"] == null)
                Session ["cart"] = new Classes.Cart ();

            cart.DataSource = ((Classes.Cart) Session ["cart"]).Products;
            cart.DataBind ();
        }

        protected void checkout_Click (object sender, EventArgs e)
        {
            if (((Classes.Cart) Session ["cart"]).Products.Count == 0)
                return;

            Response.Redirect ("~/Site/Checkout.aspx");
        }

        protected void delete_Click (object sender, EventArgs e)
        {
            Button deleteButton = (Button) sender;

            ((Classes.Cart) Session ["cart"]).RemoveProductByIndex (Convert.ToInt32 (deleteButton.CommandArgument));

            cart.DataSource = ((Classes.Cart) Session ["cart"]).Products;
            cart.DataBind ();
        }
    }
}