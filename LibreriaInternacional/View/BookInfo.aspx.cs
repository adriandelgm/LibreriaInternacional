using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using a = LibreriaInternacional.Models;
using b = LibreriaInternacional.Controller;

namespace LibreriaInternacional.View
{
    public partial class BookInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loginInfo"] == null)
                {
                    Response.Redirect("Booking.aspx?session=false");
                }

                int idBook = Convert.ToInt16(Request.QueryString["id"]);

                b.Book BookController = new b.Book();
                List<a.Books> book = BookController.GetBook(idBook);
                Session["book"] = book;


                CalculateUnitsCost(false);

                repBooks.DataSource = book;
                repBooks.DataBind();
            }
        }

        private void CalculateUnitsCost(bool flag)
        {

        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            a.Cart buy = (a.Cart)Session["Buy"];

            if (buy.isReady)
            {
                b.Buy controllerBuy = new b.Buy();

                if (controllerBuy.BuyBook(buy))
                {
                    msg = "Libro añadido a cesta";
                }
                else
                {
                    msg = "Error al añadir libro a cesta";
                }
            }
            else
            {
                msg = "Por favor confirma las unidades antes de continuar";
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showModal('Book','" + msg + "')", true);
        }
    }
}