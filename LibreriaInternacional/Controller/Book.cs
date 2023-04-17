using LibreriaInternacional.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        public List<a.Books> GetBook(int idBook)
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            DataTable ds = db.GetBook(idBook);

            return ConvertDSToList(ds);
        }

        public List<a.Books> GetSearchedBook(string search)
        {
            List<a.Books> bookList = new List<a.Books>();

            DatabaseHelper.Database db = new DatabaseHelper.Database();

            DataTable ds = db.GetSearchedBook(search);

            return ConvertDSToList(ds);
        }

        public bool SaveCartBook(a.Books book)
        {
            try
            {
                DatabaseHelper.Database db = new DatabaseHelper.Database();

                db.SaveCartBook(book);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<a.Books> GetCartBooks(LoginResponsePayload session)
        {
            List<a.Books> bookList = new List<a.Books>();

            DatabaseHelper.Database db = new DatabaseHelper.Database();

            DataTable ds = db.GetCartBooks(session.email);

            return ConvertDSToList(ds);
        }

        public bool DeleteCartBook(string Email, int bookId)
        {
            try
            {
                DatabaseHelper.Database db = new DatabaseHelper.Database();

                db.DeleteCartBook(Email, bookId);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<a.Books> ConvertDSToList(DataTable ds)
        {
            List<a.Books> booksList = new List<a.Books>();

            foreach (DataRow row in ds.Rows)
            {
                booksList.Add(new a.Books
                {
                    idBook = Convert.ToInt16(row["idBook"]),
                    ISBN = row["ISBN"].ToString(),
                    Image = row["Image"].ToString(),
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = row["Price"].ToString(),
                    PublishingDate = row["PublishingDate"].ToString()
                });
            }

            return booksList;
        }
    }
}