using LibreriaInternacional.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public DataTable GetBook(int idBook)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter( "idBook", idBook ),
            };

            return this.Fill("[dbo].[spGetBook]", param);
        }

        public DataTable GetSearchedBook(string search)
        {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@search", search),
            };

            return this.Fill("[dbo].[spGetSearchedBook]", param);
        }

        public void SaveCartBook(a.Books book)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@idBook", book.idBook),
                new SqlParameter("@email", book.email)
            };

            this.ExecuteQuery("[dbo].[spSaveCart]", param);
        }
        public DataTable GetCartBooks(string Email)
        {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Email", Email),
            };

            return this.Fill("[dbo].[spGetCart]", param);
        }

        public void DeleteCartBook(int bookId)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@bookId", bookId),
            };

            this.ExecuteQuery("[dbo].[spDeleteCartBook]", param);
        }

        public void SaveFavoriteBook(a.Books book)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@idBook", book.idBook),
                new SqlParameter("@email", book.email)
            };

            this.ExecuteQuery("[dbo].[spSaveFav]", param);
        }

        public DataTable GetFavoriteBooks(string email)
        {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@email", email)
            };

            return this.Fill("[dbo].[spGetFav]", param);
        }

        public void DeleteFavoriteBook(string Email, int bookId)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Email", Email),
                new SqlParameter("@bookId", bookId),
            };

            this.ExecuteQuery("[dbo].[spDeleteFavBook]", param);
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