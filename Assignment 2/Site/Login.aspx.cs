using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.ACLogin;

namespace Assignment_2.Site
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load (object sender, EventArgs e)
        {
            if (Session ["user"] != null)
                Response.Redirect ("~/Site/Default.aspx");

            if (Page.IsPostBack)
                return;

            if (Request.UrlReferrer != null)
                Session ["previousPage"] = Request.UrlReferrer.ToString ();
        }

        protected void login_Authenticate (object sender, AuthenticateEventArgs e)
        {
            AuthenticateServiceSoapClient client = new AuthenticateServiceSoapClient ();

            client.Open ();
            AlgonquinCollegeUser user = client.AuthenticateUser (Server.HtmlDecode (login.UserName.Trim ()), Server.HtmlDecode (login.Password.Trim ()));
            client.Close ();

            if (user == null)
            {
                e.Authenticated = false;

                return;
            }

            e.Authenticated = true;
            Session ["user"] = user;

            if (Session ["previousPage"] == null)
            {
                System.Diagnostics.Debug.WriteLine ("Not referred");

                Response.Redirect ("~/Site/Default.aspx");
            }
            else
            {
                string previousPage = Convert.ToString (Session ["previousPage"]);

                Session.Remove ("previousPage");

                System.Diagnostics.Debug.WriteLine ("Referred by: " + previousPage);

                Response.Redirect (previousPage);
            }
        }
    }
}