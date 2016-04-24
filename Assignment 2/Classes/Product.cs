using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.Classes
{
    public class Product
    {
        private UInt64 productID = 0UL;
        private UInt64 categoryID = 0UL;
        private string name = null;
        private string categoryName = null;
        private string shortDescription = null;
        private string longDescription = null;
        private double price = 0.0d;
        private double salePrice = 0.0d;
        private bool onSale = false;
        private DateTime added = DateTime.MinValue;

        public UInt64 ProductID
        {
            get
            {
                return productID;
            }
            private set
            {
                productID = value;
            }
        }

        public UInt64 CategoryID
        {
            get
            {
                return categoryID;
            }
            private set
            {
                categoryID = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                name = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                categoryName = value;
            }
        }

        public string ShortDescription
        {
            get
            {
                return shortDescription;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                shortDescription = value;
            }
        }

        public string LongDescription
        {
            get
            {
                return longDescription;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                longDescription = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value < 0.0d)
                    throw new ArgumentException ();

                price = value;
            }
        }

        public double SalePrice
        {
            get
            {
                return salePrice;
            }
            private set
            {
                if (value < 0.0d)
                    throw new ArgumentException ();

                salePrice = value;
            }
        }

        public bool OnSale
        {
            get
            {
                return onSale;
            }
            private set
            {
                onSale = value;
            }
        }

        public DateTime Added
        {
            get
            {
                return added;
            }
            private set
            {
                added = value;
            }
        }

        public Product (UInt64 productID, UInt64 categoryID, string name, string categoryName, string shortDescription, string longDescription, double price, double salePrice, bool onSale, DateTime added)
        {
            if (name == null || shortDescription == null || longDescription == null)
                throw new ArgumentNullException ();

            if (price < 0.0d || salePrice < 0.0d)
                throw new ArgumentException ();

            this.productID = productID;
            this.categoryID = categoryID;
            this.name = name;
            this.categoryName = categoryName;
            this.shortDescription = shortDescription;
            this.longDescription = longDescription;
            this.price = price;
            this.salePrice = salePrice;
            this.onSale = onSale;
            this.added = added;
        }

        public override bool Equals (object obj)
        {
            Product equal = (Product) obj;

            if (ReferenceEquals (equal, null))
                return false;

            if (ReferenceEquals (this, equal))
                return true;

            return (productID == equal.productID && categoryID == equal.categoryID && name == equal.name && categoryName == equal.categoryName && shortDescription == equal.shortDescription && longDescription == equal.longDescription && price == equal.price && salePrice == equal.salePrice && onSale == equal.onSale && added == equal.added);
        }

        public override int GetHashCode ()
        {
            return productID.GetHashCode () + categoryID.GetHashCode () + name.GetHashCode () + categoryName.GetHashCode () + shortDescription.GetHashCode () + longDescription.GetHashCode () + price.GetHashCode () + salePrice.GetHashCode () + onSale.GetHashCode ()  + added.GetHashCode ();
        }

        public override string ToString ()
        {
            return "Product ID: " + productID + ", Category ID: " + categoryID + ", Name: " + name + ", Category Name: " + categoryName + ", Short Description: " + shortDescription + ", Long Description: " + longDescription + ", Price: " + price + ", Sale Price: " + salePrice + ", On Sale: " + onSale + ", Added: " + added.ToString ();
        }

        public static bool operator == (Product product1, Product product2)
        {
            if (ReferenceEquals (product1, null))
                return false;

            return product1.Equals (product2);
        }

        public static bool operator != (Product product1, Product product2)
        {
            if (ReferenceEquals (product1, null))
                return false;

            return !product1.Equals (product2);
        }
    }
}