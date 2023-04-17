using LibreriaInternacional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using a = LibreriaInternacional.Models;
using b = LibreriaInternacional.Controller;

namespace LibreriaInternacional
{
    public partial class LibreriaInternacional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsLogged();

                string session = Request.QueryString["session"];

                if (session == "false")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showModal('Login','You must login to access this page')", true);
                }

                b.Book bookController = new b.Book();

                repBooks.DataSource = bookController.GetBooks();
                repBooks.DataBind();
            }
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            b.LogIn loginController = new b.LogIn();

            LoginResponsePayload loginInfo = loginController.SignInWithPassword(new a.LoginResponsePayload
            {
                email = txtEmail.Value,
                password = txtPassword.Value
            });

            if (loginInfo != null && loginInfo.registered)
            {
                Session["loginInfo"] = loginInfo;
                msg = "Welcome " + txtEmail.Value;
                IsLogged();
            }
            else
            {
                msg = "Incorrect credentials";
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showModal('Login','" + msg + "')", true);
        }

        private void IsLogged()
        {
            if (Session["loginInfo"] != null)
            {
                a.LoginResponsePayload session = (a.LoginResponsePayload)Session["loginInfo"];

                lblName.InnerText = session.email;
                cardLogin.Attributes.Add("hidden", "hidden");
                cardUser.Attributes.Remove("hidden");
                tabBookings.Attributes.Remove("hidden");
            }
        }

        private void IsLogOut()
        {
            if (Session["loginInfo"] == null)
            {
                cardUser.Attributes.Add("hidden", "hidden");
                cardLogin.Attributes.Remove("hidden");
                tabBookings.Attributes.Add("hidden", "hidden");
            }
        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            IsLogOut();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showModal('Login','Thank you for visiting Booking.com')", true);
        }
    }
}