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

        protected void userEmail()
        {
            string msg = string.Empty;
            if (Session["loginInfo"] == null)
            {
                msg = $"alert('Necesitas tener una cuenta para añadir libros a favoritos')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
            }
            else
            {
                a.LoginResponsePayload session = (a.LoginResponsePayload)Session["loginInfo"];
                string email = session.email.ToString();

                List<a.Books> books = (List<a.Books>)Session["book"];

                a.Books book = new a.Books()
                {
                    idBook = books[0].idBook,
                    email = email,
                };
                Session["book"] = book;
            }
        }
        protected void btnFav_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (Session["loginInfo"] == null)
            {
                msg = $"alert('Necesitas tener una cuenta para añadir libros a favoritos')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
            }
            else
            {
                userEmail();
                a.Books book = (a.Books)Session["Book"];

                b.Book bookController = new b.Book();

                if (bookController.SaveFavoriteBook(book))
                {
                    msg = $"alert('¡Libro añadido a tu lista de favoritos!')";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
                }
                else
                {
                    msg = $"alert('Ocurrió un error al añadir el libro a favoritos.')";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
                }

            }

        }

        protected void btnCart_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (Session["loginInfo"] == null)
            {
                msg = $"alert('Necesitas tener una cuenta para añadir libros a la cesta')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
            }
            else
            {
                userEmail();
                a.Books book = (a.Books)Session["Book"];

                b.Book bookController = new b.Book();

                if (bookController.SaveCartBook(book))
                {
                    msg = $"alert('¡Libro añadido a tu cesta!')";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
                }
                else
                {
                    msg = $"alert('Ocurrió un error al añadir el libro a la cesta.')";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
                }

            }

        }
    }
}