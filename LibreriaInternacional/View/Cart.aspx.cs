using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using a = LibreriaInternacional.Models;
using b = LibreriaInternacional.Controller;

namespace LibreriaInternacional.View
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCart();
        }

        public void LoadCart()
        {
            a.LoginResponsePayload session = (a.LoginResponsePayload)Session["loginInfo"];
            b.Book bookController = new b.Book();
            repCart.DataSource = bookController.GetCartBooks(session);
            repCart.DataBind();
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            var button = (HtmlButton)sender;
            Session["idBook"] = Convert.ToInt16(button.Attributes["dataId"]);

            int idBook = Convert.ToInt16(Session["idBook"]);
            a.LoginResponsePayload session = (a.LoginResponsePayload)Session["loginInfo"];

            b.Book bookController = new b.Book();
            bookController.DeleteCartBook(session.email, idBook);
            LoadCart();
        }
    }
}