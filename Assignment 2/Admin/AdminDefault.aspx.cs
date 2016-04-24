using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using Assignment_2.Classes;

namespace Assignment_2.Admin
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

        private void bindCategories ()
        {
            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlDataAdapter selectCategories = new MySqlDataAdapter (new MySqlCommand ("Select * from categories", database)))
                {
                    using (DataTable table = new DataTable ())
                    {
                        selectCategories.Fill (table);

                        categories.DataSource = table;
                        categories.DataBind ();
                    }
                }
            }
        }

        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Page.IsPostBack)
                return;

            bindProducts ();

            bindCategories ();
        }

        protected void deleteProduct_Click (object sender, EventArgs e)
        {
            Button delete = (Button) sender;

            UInt64 productID = Convert.ToUInt64 (delete.CommandArgument);

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand deleteProduct = new MySqlCommand ("delete from products where productID = @productID", database))
                {
                    deleteProduct.Parameters.AddWithValue ("@productID", productID);

                    deleteProduct.ExecuteNonQuery ();
                }

                bindProducts ();
            }
        }

        protected void deleteCategory_Click (object sender, EventArgs e)
        {
            Button delete = (Button) sender;

            UInt64 categoryID = Convert.ToUInt64 (delete.CommandArgument);

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand deleteProduct = new MySqlCommand ("delete from categories where categoryID = @categoryID", database))
                {
                    deleteProduct.Parameters.AddWithValue ("@categoryID", categoryID);

                    deleteProduct.ExecuteNonQuery ();
                }

                bindCategories ();
            }
        }

        protected void editProduct_Click (object sender, EventArgs e)
        {
            Button edit = (Button) sender;
            string productID = Server.UrlEncode (edit.CommandArgument);
             
            Response.Redirect ("~/Admin/EditProduct.aspx?productID=" + productID);
        }

        protected void editCategory_Click (object sender, EventArgs e)
        {
            Button edit = (Button) sender;
            string categoryID = Server.UrlEncode (edit.CommandArgument);

            Response.Redirect ("~/Admin/EditCategory.aspx?categoryID=" + categoryID);
        }

        protected void logout_Click (object sender, EventArgs e)
        {
            Session ["user"] = null;
            Session.Abandon ();

            BulletedList directory = (BulletedList) Master.FindControl ("directory");

            directory.Items.Clear ();

            directory.Items.Add (new ListItem ("Home", "~/Site/Default.aspx"));
            directory.Items.Add (new ListItem ("Login", "~/Site/Login.aspx"));

            Response.Redirect ("~/Site/Default.aspx");
        }
    }
}