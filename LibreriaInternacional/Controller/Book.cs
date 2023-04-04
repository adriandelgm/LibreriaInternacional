using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using a = LibreriaInternacional.Models;

namespace LibreriaInternacional.Controller
{
    public class Book
    {
        public List<a.Books> GetBooks()
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            DataTable ds = db.GetBooks();

            return ConvertDSToList(ds);
        }

        public List<a.Books> GetBooks(int id)
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            DataTable ds = db.GetBooks(id);

            return ConvertDSToList(ds);
        }

        public List<a.Books> ConvertDSToList(DataTable ds)
        {
            List<a.Books> booksList = new List<a.Books>();

            foreach (DataRow row in ds.Rows)
            {
                booksList.Add(new a.Books
                {
                    ISBN = Convert.ToInt16(row["ISBN"]),
                    Image = row["Image"].ToString(),
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString(),
                    Description = row["Description"].ToString(),
                    PublishingDate = row["PublishingDate"].ToString(),
                    Price = Convert.ToDecimal(row["price"])
                });
            }

            return booksList;
        }
    }
}