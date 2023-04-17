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
                new SqlParameter("@bookId", book.idBook),
                new SqlParameter("@Email", book.email),
            };

            this.ExecuteQuery("[dbo].[spSaveFavoriteBook]", param);
        }
        public DataTable GetCartBooks(string Email)
        {

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Email", Email),
            };

            return this.Fill("[dbo].[spGetFavoriteBooks]", param);
        }

        public void DeleteCartBook(string Email, int bookId)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Email", Email),
                new SqlParameter("@bookId", bookId),
            };

            this.ExecuteQuery("[dbo].[spDeleteFavoriteBook]", param);
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