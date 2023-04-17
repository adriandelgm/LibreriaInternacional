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
            int idBook = Convert.ToInt16(Request.QueryString["idBook"]);

            b.Book BookController = new b.Book();
            List<a.Books> book = BookController.GetBook(idBook);
            Session["book"] = book;

            repBooks.DataSource = book;
            repBooks.DataBind();
        }
    }
}