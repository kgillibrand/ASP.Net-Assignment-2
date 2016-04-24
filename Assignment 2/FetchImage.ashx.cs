using Assignment_2.Classes;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Assignment_2
{
    public class FetchImage : IHttpHandler
    {
        public void ProcessRequest (HttpContext context)
        {
            if (context.Request ["productName"] == null || context.Request ["productID"] == null)
                context.Response.Redirect ("~/Site/Default.aspx");

            string productName = context.Server.UrlDecode (context.Request ["productName"]);
            UInt64 productID = 0UL;

            try
            {
                productID = Convert.ToUInt64 (context.Server.UrlDecode (context.Request ["productID"]));
            }
            catch (FormatException)
            {
                context.Response.Redirect ("~/Site/Default.aspx");
            }
            catch (OverflowException)
            {
                context.Response.Redirect ("~/Site/Default.aspx");
            }

            CloudStorageAccount storage = CloudStorageAccount.Parse (ConnectionStrings.AzureConnectionString);
            CloudBlobClient blob = storage.CreateCloudBlobClient ();
            CloudBlobContainer container = blob.GetContainerReference (ConnectionStrings.BlobContainer);
            container.CreateIfNotExists ();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference (productName + productID);

            using (Stream blobStream = new MemoryStream ())
            {
                blockBlob.DownloadToStream (blobStream);

                blobStream.Seek (0, SeekOrigin.Begin);

                byte [] blobBuffer = new byte [blobStream.Length];
                blobStream.Read (blobBuffer, 0, (Int32) blobStream.Length);

                context.Response.Clear ();
                context.Response.ContentType = blockBlob.Properties.ContentType;
                context.Response.BinaryWrite (blobBuffer);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}