using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Assignment_2.Classes
{
    public static class ConnectionStrings
    {
        private static string dbConnectionString = ConfigurationManager.AppSettings ["DBConnectionString"];
        private static string azureConnectionString = ConfigurationManager.AppSettings ["AzureConnectionString"];
        private static string blobContainer = ConfigurationManager.AppSettings ["BlobContainer"];

        public static string DBConnectionString
        {
            get
            {
                return dbConnectionString;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                dbConnectionString = value;
            }
        }

        public static string AzureConnectionString
        {
            get
            {
                return azureConnectionString;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                azureConnectionString = value;
            }
        }

        public static string BlobContainer
        {
            get
            {
                return blobContainer;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                blobContainer = value;
            }
        }
    }
}