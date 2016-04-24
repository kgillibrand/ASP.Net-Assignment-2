using Assignment_2.ACLogin;
using Assignment_2.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

                if (Session ["breadcrumb"] == null)
                    Session ["breadcrumb"] = new List<string> ();

                List<string> breadcrumb = (List<string>) Session ["breadcrumb"];

                string pageName = Path.GetFileName (Page.AppRelativeVirtualPath);
                string pagePath = HttpContext.Current.Request.Url.AbsolutePath;

                string pageLink = "<a href = \"" + pagePath + "\">" + pageName + "</a>";

                if (!breadcrumb.Contains (pageLink))
                    breadcrumb.Add (pageLink);

                for (Int32 pageIndex = 0; pageIndex < breadcrumb.Count; ++pageIndex)
                    visited.Text += breadcrumb.ElementAt (pageIndex);

                if (Session ["user"] != null)
                {
                    AlgonquinCollegeUser user = (AlgonquinCollegeUser) Session ["user"];
                    login.Text = "Welcome " + user.FirstName + " " + user.LastName + "!";
                }
                else
                    login.Text = "Would you like to <a href = \"Login.aspx\">login?</a>";

                using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
                {
                    database.Open ();

                    using (MySqlDataAdapter select = new MySqlDataAdapter (new MySqlCommand ("Select * from categories", database)))
                    {
                        using (DataTable table = new DataTable ())
                        {
                            select.Fill (table);

                            categories.DataSource = table;
                            categories.DataBind ();
                        }
                    }
                }

            directory.Items.Clear ();

            directory.Items.Add (new ListItem ("Home", "~/Site/Default.aspx"));

            if (Session ["user"] == null)
                directory.Items.Insert (1, new ListItem ("Login", "~/Site/Login.aspx"));
            else
            {
                directory.Items.Add (new ListItem ("Cart", "~/Site/Cart.aspx"));
                directory.Items.Add (new ListItem ("Admin Home", "~/Admin/AdminDefault.aspx"));
            }

            if (Session ["user"] == null)
                logout.Visible = false;
            else
                logout.Visible = true;
        }

        protected void logout_Click (object sender, EventArgs e)
        {
            Session ["user"] = null;
            Session.Abandon ();

            logout.Visible = false;

            BulletedList directory = (BulletedList) Master.FindControl ("directory");

            directory.Items.Clear ();

            directory.Items.Add (new ListItem ("Home", "~/Site/Default.aspx"));
            directory.Items.Add (new ListItem ("Login", "~/Site/Login.aspx"));
        }
    }
}