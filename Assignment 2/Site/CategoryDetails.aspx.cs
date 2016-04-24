using Assignment_2.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.Menu
{
    public partial class CategoryDetails : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Request.QueryString ["categoryID"] == null)
                Response.Redirect ("~/Site/Default.aspx");

            if (Page.IsPostBack)
                return;

            UInt64 categoryID = 0UL;

            try
            {
                categoryID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["categoryID"]));
            }
            catch (FormatException)
            {
                Response.Redirect ("~/Site/Default.aspx");
            }
            catch (OverflowException)
            {
                Response.Redirect ("~/Site/Default.aspx");
            }

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand selectProducts = new MySqlCommand ("Select * from products left join categories on products.categoryID = categories.categoryID where categories.categoryID = @categoryID", database))
                {
                    selectProducts.Parameters.AddWithValue ("@categoryID", categoryID);

                    using (MySqlDataAdapter selectProductsAdapter = new MySqlDataAdapter (selectProducts))
                    {
                        using (DataTable table = new DataTable ())
                        {
                            selectProductsAdapter.Fill (table);

                            products.DataSource = table;
                            products.DataBind ();
                        }
                    }

                    using (MySqlDataReader reader = selectProducts.ExecuteReader ())
                    {
                        reader.Read ();
                        category.Text = "Products in Category: " + reader.GetString ("categoryName");
                    }
                }
            }
        }
    }
}