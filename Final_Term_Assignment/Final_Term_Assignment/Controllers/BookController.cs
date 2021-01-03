using Final_Term_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;



namespace Final_Term_Assignment.Controllers
{
    class BookController
    {
        static Database db = new Database();

        public static ArrayList GetAllBooks()
        {
            return db.Books.GetAllBooks();
        }
        public static Book SearchBook(string name)
        {
            return db.Books.SearchBook(name);
        }
    }
}