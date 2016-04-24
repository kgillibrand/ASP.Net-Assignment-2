using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.Classes;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace Assignment_2.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Request.QueryString ["productID"] == null)
                Response.Redirect ("~/Admin/AdminDefault.aspx");

            if (Page.IsPostBack)
                return;

            UInt64 productID = 0UL;

            try
            {
                productID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["productID"]));
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

                using (MySqlDataAdapter adapter = new MySqlDataAdapter (new MySqlCommand ("Select * from categories", database)))
                {
                    using (DataTable table = new DataTable ())
                    {
                        adapter.Fill (table);

                        if (table.Rows.Count == 0)
                            Response.Redirect ("~/Admin/AdminDefault.aspx");

                        categories.DataSource = table;
                        categories.DataTextField = "categoryName";
                        categories.DataValueField = "categoryID";
                        categories.DataBind ();
                    }
                }

                using (MySqlCommand select = new MySqlCommand ("Select * from categories left join products on categories.categoryID = products.categoryID and productID = @productID", database))
                {
                    select.Parameters.AddWithValue ("@productID", productID);

                    using (MySqlDataReader reader = select.ExecuteReader ())
                    {
                        if (!reader.HasRows)
                            Response.Redirect ("~/Admin/AdminDefault.aspx");

                        reader.Read ();

                        string categoryName = reader.GetString ("categoryName");

                        for (Int32 categoryIndex = 0; categoryIndex < categories.Items.Count; ++categoryIndex)
                        {
                            if (categories.Items [categoryIndex].Text == categoryName)
                            {
                                categories.SelectedIndex = categoryIndex;
                                break;
                            }
                        }
                    }
                }

                using (MySqlCommand select = new MySqlCommand ("Select * from products where productID = @productID", database))
                {
                    select.Parameters.AddWithValue ("@productID", productID);

                    using (MySqlDataReader reader = select.ExecuteReader ())
                    {
                        if (!reader.HasRows)
                            Response.Redirect ("~/Admin/AdminDefault.aspx");

                        reader.Read ();

                        string productName = Server.HtmlEncode (reader.GetString ("productName"));
             
                        name.Text = productName;
                        shortDescription.Text = Server.HtmlEncode (reader.GetString ("productShortDescription"));
                        longDescription.Text = Server.HtmlEncode (reader.GetString ("productLongDescription"));
                        price.Text = Server.HtmlEncode (reader.GetDouble ("productPrice").ToString ());
                        salePrice.Text = Server.HtmlEncode (reader.GetDouble ("productSalePrice").ToString ());
                        onSale.Checked = reader.GetBoolean ("productOnSale");

                        currentImage.ImageUrl = "/FetchImage.ashx?productName=" + Server.UrlEncode (productName) + "&productID=" + Server.UrlEncode (productID.ToString ());
                    }
                }
            }
        }

        protected void submit_Click (object sender, EventArgs e)
        {
            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                string productName = null;
                UInt64 productID = Convert.ToUInt64 (Server.UrlDecode (Request.QueryString ["productID"]));

                using (MySqlCommand select = new MySqlCommand ("Select productName from products where productID = @productID", database))
                {
                    select.Parameters.AddWithValue ("@productID", productID);

                    using (MySqlDataReader reader = select.ExecuteReader ())
                    {
                        if (!reader.Read ())
                            Response.Redirect ("~/Admin/AdminDefault.aspx");

                        productName = reader.GetString ("productName");
                    }
                }

                using (MySqlCommand insert = new MySqlCommand ("Update products set categoryID = @categoryID, productName = @productName, productShortDescription = @productShortDescription, productLongDescription = @productLongDescription, productPrice = @productPrice, productSalePrice = @productSalePrice, productOnSale = @productOnSale where productID = @productID", database))
                {
                    insert.Parameters.AddWithValue ("@categoryID", Convert.ToUInt64 (categories.SelectedItem.Value));
                    insert.Parameters.AddWithValue ("@productName", name.Text.Trim ());
                    insert.Parameters.AddWithValue ("@productShortDescription", shortDescription.Text.Trim ());
                    insert.Parameters.AddWithValue ("@productLongDescription", longDescription.Text.Trim ());
                    insert.Parameters.AddWithValue ("@productPrice", Convert.ToDouble (price.Text.Trim ()));
                    insert.Parameters.AddWithValue ("@productSalePrice", Convert.ToDouble (salePrice.Text.Trim ()));
                    insert.Parameters.AddWithValue ("@productOnSale", onSale.Checked);

                    insert.Parameters.AddWithValue ("@productID", productID);

                    insert.ExecuteNonQuery ();

                    if (newImage.HasFile)
                    {
                        CloudStorageAccount storage = CloudStorageAccount.Parse (ConnectionStrings.AzureConnectionString);
                        CloudBlobClient blob = storage.CreateCloudBlobClient ();
                        CloudBlobContainer container = blob.GetContainerReference (ConnectionStrings.BlobContainer);
                        container.CreateIfNotExists ();

                        CloudBlockBlob blockBlob = container.GetBlockBlobReference (productName + productID);

                        using (Stream fileStream = newImage.FileContent)
                            blockBlob.UploadFromStream (fileStream);
                    }

                    Response.Redirect ("~/Admin/AdminDefault.aspx");
                }
            }
        }
    }
}