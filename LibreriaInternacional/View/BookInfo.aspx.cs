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
            int idBook = Convert.ToInt16(Request.QueryString["id"]);

            b.Book BookController = new b.Book();
            List<a.Books> book = BookController.GetBook(idBook);
            Session["book"] = book;

            repInfo.DataSource = book;
            repInfo.DataBind();

        }

        protected void btnCart_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            a.Books books = (a.Books)Session["Books"];

                b.Book controllerBook = new b.Book();

                if (controllerBook.SaveCartBook(books))
                {
                    msg = "Libro añadido a cesta";
                }
                else
                {
                    msg = "Error al añadir libro a cesta";
                }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showModal('Book','" + msg + "')", true);
        }
    }
}