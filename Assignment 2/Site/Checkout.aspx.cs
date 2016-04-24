using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.Site
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Page.IsPostBack)
                return;

            if (Session ["cart"] == null || ((Classes.Cart) (Session ["cart"])).Products.Count == 0)
                Response.Redirect ("~/Site/Default.aspx");
        }

        protected void submit_Click (object sender, EventArgs e)
        {
            Response.Redirect ("~/Site/ThankYou.aspx");
        }

        protected void cancel_Click (object sender, EventArgs e)
        {
            Response.Redirect ("~/Site/Default.aspx");
        }
    }
}