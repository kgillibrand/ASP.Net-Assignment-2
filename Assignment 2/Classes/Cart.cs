using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.Classes;

namespace Assignment_2.Classes
{
    public class Cart
    {
        private List <Product> products = null;
        private double total = 0.0d;

        public List <Product> Products
        {
            get
            {
                return products;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException ();

                products = value;
            }
        }

        public double Total
        {
            get
            {
                total = 0.0d;

                foreach (Product product in products)
                {
                    if (product.OnSale)
                        total += product.SalePrice;
                    else
                        total += product.Price;
                }

                return total;
            }
            private set
            {
                if (value < 0.0d)
                    throw new ArgumentException ();

                total = value;
            }
        }

        public Cart ()
        {
            products = new List <Product> ();
        }

        public void AddProduct (Product product)
        {
            if (product == null)
                throw new ArgumentNullException ();

            System.Diagnostics.Debug.WriteLine ("In cart.AddProduct, product not null");

            products.Add (product);

            System.Diagnostics.Debug.WriteLine ("In cart.AddProduct, product added");
        }

        public void RemoveProduct (Product product)
        {
            if (product == null)
                throw new ArgumentNullException ();

            products.Remove (product);
        }

        public void RemoveProductByIndex (Int32 productIndex)
        {
            if (productIndex < 0)
                throw new ArgumentException ();

            products.RemoveAt (productIndex);
        }

        public override bool Equals (object obj)
        {
            Cart equal = (Cart) obj;

            if (ReferenceEquals (equal, null))
                return false;

            if (ReferenceEquals (this, equal))
                return true;

            return (products == equal.products && total == equal.total);
        }

        public override int GetHashCode ()
        {
            return products.GetHashCode () + total.GetHashCode ();
        }

        public override string ToString ()
        {
            return "Total: " + total + ", Products: " + products.ToString ();
        }

        public static bool operator == (Cart cart1, Cart cart2)
        {
            if (ReferenceEquals (cart1, null))
                return false;

            return cart1.Equals (cart2);
        }

        public static bool operator != (Cart cart1, Cart cart2)
        {
            if (ReferenceEquals (cart1, null))
                return false;

            return !cart1.Equals (cart2);
        }
    }
}