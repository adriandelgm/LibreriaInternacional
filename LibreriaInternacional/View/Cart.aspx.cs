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
            if (!IsPostBack)
            {
                if (Session["loginInfo"] == null)
                {
                    Response.Redirect("LibreriaInternacional.aspx?session=false");
                }

                LoadCart();
            }
        }

        public void LoadCart()
        {
            a.LoginResponsePayload session = (a.LoginResponsePayload)Session["loginInfo"];

            b.Buy CartController = new b.Buy();

            repCart.DataSource = CartController.GetCart(session);
            repCart.DataBind();

            if (repCart.Items.Count == 0)
            {
                divNoBooks.Attributes.Remove("hidden");
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            var button = (HtmlButton)sender;
            Session["bookId"] = Convert.ToInt16(button.Attributes["dataId"]);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction",
                "showModal('Delete booking','Do you really want to delete this booking?')", true);
        }

        protected void btnConfirmDelete_ServerClick(object sender, EventArgs e)
        {
            int bookId = Convert.ToInt16(Session["bookId"]);

            a.LoginResponsePayload session = (a.LoginResponsePayload)Session["loginInfo"];

            b.Buy bookController = new b.Buy();
            bookController.DeleteBook(session.email, bookId);

            LoadCart();
        }
    }
}