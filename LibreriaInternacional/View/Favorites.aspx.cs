﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LibreriaInternacional.View
{
    public partial class Favorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginInfo"] == null)
            {
                string msg = string.Empty;
                msg = $"alert('Necesitas tener una cuenta para acceder a favoritos')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
                Response.Redirect("~/Views/Homepage.aspx");

            }
            else
            {
                LoadFavoritePage();

            }
        }

        public void LoadFavoritePage()
        {
            m.LoginResponsePayload session = (m.LoginResponsePayload)Session["loginInfo"];
            c.Books bookController = new c.Books();
            repFavorites.DataSource = bookController.GetFavoriteBooks(session);
            repFavorites.DataBind();
        }

        protected void btnDeleteFavorite_ServerClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            var button = (HtmlButton)sender;
            Session["bookId"] = Convert.ToInt16(button.Attributes["dataId"]);

            int bookId = Convert.ToInt16(Session["bookId"]);
            m.LoginResponsePayload session = (m.LoginResponsePayload)Session["loginInfo"];

            c.Books bookController = new c.Books();
            bookController.DeleteFavoriteBook(session.email, bookId);
            msg = $"alert('Libro eliminado de favoritos.')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", msg, true);
            LoadFavoritePage();
        }
    }
}