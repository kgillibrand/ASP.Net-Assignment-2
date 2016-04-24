using Assignment_2.Classes;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] == null)
                Response.Redirect ("~/Site/Login.aspx");

            if (Page.IsPostBack)
                return;

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter (new MySqlCommand ("Select * from categories", database)))
                {
                    using (DataTable table = new DataTable ())
                    {
                        adapter.Fill (table);

                        if (table.Rows.Count == 0)
                            Response.Redirect ("~/Site/AdminDefault.aspx");

                        categories.DataSource = table;
                        categories.DataTextField = "categoryName";
                        categories.DataValueField = "categoryID";
                        categories.DataBind ();

                        categories.Items.Insert (0, new ListItem ("Please select a category"));
                    }
                }
            }
        }

        protected void submit_Click (object sender, EventArgs e)
        {
            if (categories.SelectedIndex == 0)
            {
                Page.SetFocus (categories);
                return;
            }

            using (MySqlConnection database = new MySqlConnection (ConnectionStrings.DBConnectionString))
            {
                database.Open ();

                using (MySqlCommand insert = new MySqlCommand ("Insert into products (categoryID, productName, productShortDescription, productLongDescription, productPrice, productSalePrice, productOnSale) values (@categoryID, @productName, @productShortDescription, @productLongDescription, @productPrice, @productSalePrice, @productOnSale)", database))
                {
                    insert.Parameters.AddWithValue ("@categoryID", Convert.ToUInt64 (categories.SelectedItem.Value));
                    insert.Parameters.AddWithValue ("@productName", name.Text.Trim ());
                    insert.Parameters.AddWithValue ("@productShortDescription", shortDescription.Text.Trim ());
                    insert.Parameters.AddWithValue ("@productLongDescription", longDescription.Text.Trim ());
                    insert.Parameters.AddWithValue ("@productPrice", Convert.ToDouble (price.Text.Trim ()));
                    insert.Parameters.AddWithValue ("@productSalePrice", Convert.ToDouble (salePrice.Text.Trim ()));
                    insert.Parameters.AddWithValue ("@productOnSale", onSale.Checked);

                    insert.ExecuteNonQuery ();
                }

                UInt64 productID = 0UL;

                using (MySqlCommand select = new MySqlCommand ("Select max(productID) from products", database))
                    productID = Convert.ToUInt64 (select.ExecuteScalar ());

                if (newImage.HasFile)
                {
                    CloudStorageAccount storage = CloudStorageAccount.Parse (ConnectionStrings.AzureConnectionString);
                    CloudBlobClient blob = storage.CreateCloudBlobClient ();
                    CloudBlobContainer container = blob.GetContainerReference (ConnectionStrings.BlobContainer);
                    container.CreateIfNotExists ();

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference (name.Text.Trim () + productID);

                    using (Stream fileStream = newImage.FileContent)
                        blockBlob.UploadFromStream (fileStream);
                }

                Response.Redirect ("~/Admin/AdminDefault.aspx"); 
            }
        }
    }
}