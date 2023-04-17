using LibreriaInternacional.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using a = LibreriaInternacional.Models;

namespace LibreriaInternacional.Controller
{
    public class Buy
    {
        public bool BuyBook(a.Books books)
        {
            try
            {
                DatabaseHelper.Database db = new DatabaseHelper.Database();

                db.BuyBook(books);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBook(string email, int idBook)
        {
            try
            {
                DatabaseHelper.Database db = new DatabaseHelper.Database();

                db.DeleteBook(email, idBook);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<a.Books> GetCart(LoginResponsePayload session)
        {
            List<a.Books> BookList= new List<a.Books>();
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            DataTable ds = db.GetCart(session.email);

            foreach (DataRow row in ds.Rows)
            {
                BookList.Add(new a.Books
                {

                    idBook = Convert.ToInt16(row["idBook"]),
                    ISBN = row["ISBN"].ToString(),
                    Image = row["Image"].ToString(),
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString(),
                    Description = row["Description"].ToString(),
                    PublishingDate = row["PublishingDate"].ToString(),
                    Price = row["price"].ToString(),
                    Status = row["status"].ToString()

                });
            }

            return BookList;
        }
    }
}