using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using a = LibreriaInternacional.Models;

namespace LibreriaInternacional.DatabaseHelper
{
    public class Database
    {
        const string database = "LibreriaInternacional";
        const string server = "localhost";
        SqlConnection connection = new SqlConnection($"Data Source = {server};Initial Catalog={database};Integrated Security=True");

        public DataTable GetBooks()
        {
            return this.Fill("[dbo].[spGetBooks]", null);
        }

        public DataTable GetBooks(int idBook)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter( "idBook", idBook ),
            };

            return this.Fill("[dbo].[spGetBook]", param);
        }

        public void BuyBook(a.Books books)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("idBook", books.idBook),
                new SqlParameter("ISBN", books.ISBN),
                new SqlParameter("Image", books.Image),
                new SqlParameter("Title", books.Title),
                new SqlParameter("Author", books.Author),
                new SqlParameter("PublishingDate", books.PublishingDate),
                new SqlParameter("Price", books.Price),
                new SqlParameter("Description", books.Description),
                new SqlParameter("status", books.Status)
            };

            this.ExecuteQuery("[dbo].[spSaveCart]", param);
        }

        public DataTable GetCart(string ISBN)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("ISBN", ISBN)
            };

            return this.Fill("[dbo].[spGetCart]", param);
        }

        public void DeleteBook(string email, int idBook)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@email", email),
                new SqlParameter("idBook", idBook)
            };

            this.ExecuteQuery("[dbo].[spDeleteBook]", param);
        }

        public DataTable Fill(string storedProcedure, List<SqlParameter> param)
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedure;

                    if (param!= null)
                    {
                        foreach (SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }

                    DataTable ds = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteQuery(string storedProcedure, List<SqlParameter> param)
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedure;

                    if (param!= null)
                    {
                        foreach(SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}