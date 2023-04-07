using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using b = LibreriaInternacional.Controller;

namespace LibreriaInternacional.View
{
    public partial class BookInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            b.Book bookController = new b.Book();
            int ISBN = Convert.ToInt16(Request.QueryString["ISBN"]);

            repBook.DataSource = bookController.GetBook(ISBN);
            repBook.DataBind();
        }
    }
}