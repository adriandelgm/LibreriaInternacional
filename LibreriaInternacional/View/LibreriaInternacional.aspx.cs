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
                b.Book bookController = new b.Book();

                repBooks.DataSource = bookController.GetBooks();
                repBooks.DataBind();
            }
        }
    }
}