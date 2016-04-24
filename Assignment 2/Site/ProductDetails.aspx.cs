using Assignment_2.ACLogin;
using Assignment_2.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.Site
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private void bindComments (MySqlConnection database)
        {
            UInt64 productID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["productID"]));

            using (MySqlCommand selectComments = new MySqlCommand ("Select * from comments where comments.productID = @productID", database))
            {
                selectComments.Parameters.AddWithValue ("@productID", productID);

                using (MySqlDataAdapter selectCommentsAdapter = new MySqlDataAdapter (selectComments))
                {
                    using (DataTable table = new DataTable ())
                    {
                        selectCommentsAdapter.Fill (table);
                        
                        commentsView.DataSource = table;
                        commentsView.DataBind ();
                    }
                }

                Int32 totalComments = 0;

                using (MySqlCommand selectRows = new MySqlCommand ("Select count(*) from comments", database))
                    totalComments = Convert.ToInt32 (selectRows.ExecuteScalar ());

                using (MySqlDataReader reader = selectComments.ExecuteReader ())
                {
                    Int32 totalRating = 0;
                    double averageRating = 0.0d;

                    while (reader.Read ())
                        totalRating += reader.GetInt16 ("commentRating");

                    if (totalComments > 0)
                        averageRating = ((double) totalRating / (double) totalComments);

                    Literal averageLiteral = (Literal) productView.Rows [0].FindControl ("averageLiteral");
                    averageLiteral.Text = string.Format ("{0:N2}/5", Math.Round (averageRating, 2, MidpointRounding.AwayFromZero));
                }
            }

            List <string> badWords = new List <string> ();

            using (MySqlCommand selectBadWords = new MySqlCommand ("select * from badWords", database))
            {
                using (MySqlDataReader reader = selectBadWords.ExecuteReader ())
                {
                    while (reader.Read ())
                        badWords.Add (reader.GetString ("wordText"));
                }
            }

            foreach (GridViewRow row in commentsView.Rows)
            {
                foreach (string badWord in badWords)
                    row.Cells [0].Text = row.Cells [0].Text.Replace (badWord, "****");
            }
        }

        protected void Page_Load (object sender, EventArgs e)
        {
            if (Request.QueryString ["productID"] == null)
                Response.Redirect ("~/Site/Default.aspx");

            if (Page.IsPostBack)
                return;

            UInt64 productID = 0UL;

            try
            {
                productID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["productID"]));
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

                using (MySqlCommand selectProducts = new MySqlCommand ("Select * from products left join categories on products.categoryID = categories.categoryID where products.productID = @productID", database))
                {
                    selectProducts.Parameters.AddWithValue ("@productID", productID);

                    using (MySqlDataAdapter selectProductsAdapter = new MySqlDataAdapter (selectProducts))
                    {
                        using (DataTable table = new DataTable ())
                        {
                            selectProductsAdapter.Fill (table);

                            productView.DataSource = table;
                            productView.DataBind ();
                        }
                    }

                    using (MySqlDataReader reader = selectProducts.ExecuteReader ())
                    {
                        reader.Read ();
                        longDescription.Text = reader.GetString ("productLongDescription");
                    }
                }

                bindComments (database);
            }
        }

        protected void submitComment_Click (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            AlgonquinCollegeUser user = (AlgonquinCollegeUser) Session ["user"];
            UInt64 productID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["productID"]));

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand insertComment = new MySqlCommand ("Insert into comments (productID, commentName, commentRating, commentText) values (@productID, @commentName, @commentRating, @commentText)", database))
                {
                    insertComment.Parameters.AddWithValue ("@productID", productID);
                    insertComment.Parameters.AddWithValue ("@commentName", user.FirstName + " " + user.LastName);
                    insertComment.Parameters.AddWithValue ("@commentRating", Convert.ToInt16 (rating.Text));
                    insertComment.Parameters.AddWithValue ("@commentText", comment.Text.Trim ());

                    insertComment.ExecuteNonQuery ();
                }

                bindComments (database);

                comment.Text = "";
                rating.Text = "0";
            }
        }

        protected void deleteComment_Click (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            Button delete = (Button) sender;

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand deleteComment = new MySqlCommand ("Delete from comments where commentID = @commentID", database))
                {
                    deleteComment.Parameters.AddWithValue ("@commentID", Convert.ToUInt64 (delete.CommandArgument));

                    deleteComment.ExecuteNonQuery ();
                }

                bindComments (database);
            }
        }

        protected void add_Click (object sender, EventArgs e)
        {
                System.Diagnostics.Debug.WriteLine ("In add_Click");

                UInt64 productID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["productID"]));

                using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
                {
                    database.Open ();

                    using (MySqlCommand selectProduct = new MySqlCommand ("Select * from products left join categories on products.categoryID = categories.categoryID where products.productID = @productID", database))
                    {
                        selectProduct.Parameters.AddWithValue ("@productID", productID);

                        using (MySqlDataReader reader = selectProduct.ExecuteReader ())
                        {
                            reader.Read ();

                            Classes.Cart cart = null;

                            if (Session ["cart"] == null)
                            {
                                cart = new Classes.Cart ();
                                Session ["cart"] = cart;

                                System.Diagnostics.Debug.WriteLine ("Created cart");
                            }
                            else
                            {
                                cart = (Classes.Cart) Session ["cart"];

                                System.Diagnostics.Debug.WriteLine ("Retreived cart");
                            }

                            cart.AddProduct (new Product (reader.GetUInt64 ("productID"), reader.GetUInt64 ("categoryID"), reader.GetString ("productName"), reader.GetString ("categoryName"), reader.GetString ("productShortDescription"), reader.GetString ("productLongDescription"), reader.GetDouble ("productPrice"), reader.GetDouble ("productSalePrice"), reader.GetBoolean ("productOnSale"), reader.GetDateTime ("productAdded")));

                            System.Diagnostics.Debug.WriteLine ("Added product to cart");

                            Response.Redirect ("~/Site/Cart.aspx");
                        }
                    }
                }
            }
        }
}
