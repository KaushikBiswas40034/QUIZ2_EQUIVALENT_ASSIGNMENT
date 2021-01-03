using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Term_Assignment.Models
{
    public class Database
    {
        public Books Books { get; set; }
        public Database()
        {
            string connString = "Server=DESKTOP-VKVJ2PU;Integrated Security=true;Database=Assignment";
            SqlConnection conn = new SqlConnection(connString);
            Books = new Books(conn);
        }
        public static SqlConnection ConnectDB()
        {
            string conString = "Server=DESKTOP-VKVJ2PU;Database=Assignment;Integrated Security=true";
            SqlConnection conn = new SqlConnection(conString);
            return conn;
        }

    }
}
