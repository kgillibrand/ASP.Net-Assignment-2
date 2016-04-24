using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using Assignment_2.Classes;

namespace Assignment_2.Menu
{
    public partial class Default : System.Web.UI.Page
    {
        private void bindProducts ()
        {
            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlDataAdapter selectProducts = new MySqlDataAdapter (new MySqlCommand ("Select * from products left join categories on products.categoryID = categories.categoryID order by productAdded desc", database)))
                {
                    using (DataTable table = new DataTable ())
                    {
                        selectProducts.Fill (table);

                        products.DataSource = table;
                        products.DataBind ();
                    }
                }
            }
        }

        protected void Page_Load (object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            bindProducts ();
        }

        protected void items_PageIndexChanging (object sender, GridViewPageEventArgs e)
        {
            products.PageIndex = e.NewPageIndex;

            bindProducts ();
        }
    }
}