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
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Request.QueryString ["categoryID"] == null)
                Response.Redirect ("~/Admin/AdminDefault.aspx");

            if (Page.IsPostBack)
                return;

            UInt64 categoryID = 0UL;

            try
            {
                categoryID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["categoryID"]));
            }
            catch (FormatException)
            {
                Response.Redirect ("~/Admin/AdminDefault.aspx");
            }
            catch (OverflowException)
            {
                Response.Redirect ("~/Admin/AdminDefault.aspx");
            }

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand select = new MySqlCommand ("Select categoryName from categories where categoryID = @categoryID", database))
                {
                    select.Parameters.AddWithValue ("@categoryID", categoryID);

                    using (MySqlDataReader reader = select.ExecuteReader ())
                    {
                        if (!reader.HasRows)
                            Response.Redirect ("~/Admin/AdminHome.aspx");

                        reader.Read ();

                        name.Text = reader.GetString ("categoryName");
                    }
                }
            }
        }

        protected void submit_Click (object sender, EventArgs e)
        {
            UInt64 categoryID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["categoryID"]));

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand insert = new MySqlCommand ("Update categories set categoryName = @categoryName where categoryID = @categoryID", database))
                {
                    insert.Parameters.AddWithValue ("@categoryName", name.Text.Trim ());

                    insert.Parameters.AddWithValue ("@categoryID", categoryID);

                    insert.ExecuteNonQuery ();

                    Response.Redirect ("~/Admin/AdminDefault.aspx");
                }
            }
        }
    }
}