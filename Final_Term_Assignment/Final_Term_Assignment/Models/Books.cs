using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term_Assignment.Models
{
    public class Books
    {
        

        private SqlConnection conn;

        public Books(SqlConnection conn)
        {
            this.conn = conn;
        }
        public ArrayList GetAllBooks()  
        {
            ArrayList books = new ArrayList();
            conn.Open();
            string query = "SELECT * FROM books";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book();
                book.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                book.Name = reader.GetString(reader.GetOrdinal("Name"));
                book.Author = reader.GetString(reader.GetOrdinal("Author"));
                book.Edition = reader.GetString(reader.GetOrdinal("Edition"));

                books.Add(book);
            }
            conn.Close();
            return books;
        }
        public Book SearchBook(string name) 
        {
            conn.Open();
            string query = String.Format("SELECT * FROM books WHERE Name='{0}'", name);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Book book = null;
            while (reader.Read())
            {
                book = new Book();
                book.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                book.Name = reader.GetString(reader.GetOrdinal("Name"));
                book.Author = reader.GetString(reader.GetOrdinal("Author"));
                book.Edition = reader.GetString(reader.GetOrdinal("Edition"));
              

            }
            conn.Close();
            return book;
        }
       
        


       
    }
}
