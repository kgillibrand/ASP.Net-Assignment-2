using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using Assignment_2.Classes;

namespace Assignment_2.Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Page.IsPostBack)
                return;
        }

        protected void submit_Click (object sender, EventArgs e)
        {
            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand insert = new MySqlCommand ("Insert into categories (categoryName) values (@categoryName)", database))
                {
                    insert.Parameters.AddWithValue ("@categoryName", name.Text.Trim ());

                    insert.ExecuteNonQuery ();

                    Response.Redirect ("~/Admin/AdminDefault.aspx");
                }
            }
        }
    }
}