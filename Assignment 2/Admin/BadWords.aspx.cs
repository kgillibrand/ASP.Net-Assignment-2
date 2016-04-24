using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.ACLogin;
using Assignment_2.Classes;

namespace Assignment_2.Admin
{
    public partial class BadWords : System.Web.UI.Page
    {
        private void bindBadWords ()
        {
            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (DataTable table = new DataTable ())
                {
                    using (MySqlDataAdapter select = new MySqlDataAdapter (new MySqlCommand ("Select * from badWords", database)))
                    {
                        select.Fill (table);

                        badWords.DataSource = table;
                        badWords.DataBind ();
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

            bindBadWords ();
        }

        //Submit new bad word
        protected void submitBadWord_Click (object sender, EventArgs e)
        {
            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand insertWord = new MySqlCommand ("Insert into badWords (wordText) values (@wordText)", database))
                {
                    insertWord.Parameters.AddWithValue ("@wordText", writeBadWord.Text.Trim ());
                    insertWord.ExecuteNonQuery ();
                }

                writeBadWord.Text = "";

                bindBadWords ();
            }
        }

        protected void deleteWord_Click (object sender, EventArgs e)
        {
            Button delete = (Button) sender;

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand deleteWord = new MySqlCommand ("Delete from badWords where wordID = @wordID", database))
                {
                    deleteWord.Parameters.AddWithValue ("@wordID", Convert.ToUInt64 (delete.CommandArgument));

                    deleteWord.ExecuteNonQuery ();
                }

                bindBadWords ();
            }
        }
    }
}