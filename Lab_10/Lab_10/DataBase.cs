using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Lab_10
{
    class DataBase
    {
        string connectionString;
        SqlConnection connection = null;

        public DataBase()
        {
            connectionString = "Data Source=LAPTOP-N0QMVJ9U;Initial Catalog=Library_OOP;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }

        public bool AddBook(Book p)
        {
            string sql = $"INSERT INTO PART(NAME, DESCRIPTION, QUANTITY, PRICE, ImagePath) VALUES " +
                $"(\'{p.Id}\', \'{p.Name}\', \'{p.AuthorId}\')";
            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
