using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.IO;


namespace Lab_06
{
    public class DataBase : IDisposable
    {
        string connectionString;
        SqlConnection connection = null;

        public DataBase() 
        {
            try
            {
                connectionString = "server = LAPTOP-N0QMVJ9U; Trusted_Connection = Yes; DataBase = Products";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string str = "use  [Products]";
                SqlCommand command = new SqlCommand(str, connection);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // string connectionString = ConfigurationManager.ConnectionStrings["SqlCreate"].ConnectionString;
                //connection = new SqlConnection(connectionString);
                //connection.Open();
                try
                {
                    string str = "use master;create database [Products]";

                    SqlConnection sqlCon = new SqlConnection("Server=LAPTOP-N0QMVJ9U;Trusted_Connection = Yes;DataBase=master");
                    SqlCommand command = new SqlCommand(str, sqlCon);
                    sqlCon.Open();
                    command.ExecuteNonQuery();
                    sqlCon.Close();
                }catch(Exception exx)
                { }

            }

        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }

        public bool AddProd(Prod p)
        {
            string sql = $"INSERT INTO Products( Name, Description, ImagePath, Quantity, Price, FullDiscription, Pic) VALUES " +
                $"(\'{p.Name}\', \'{p.Description}\', \'{p.ImagePath}\', \'{p.Quantity}\', \'{p.Price}\', \'{p.FullDiscription}\',@image)";
            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@image", SqlDbType.Image, 1000000);
                command.Parameters["@image"].Value = p.Image;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public List<Prod> GetProds()
        {
            string sql = "SELECT * FROM Products";
            DataTable prodsTable = new DataTable();
            SqlDataAdapter adapter;

            List<Prod> prods = new List<Prod>();
            try
            {

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader info = command.ExecuteReader();
                object n = -1, t = -1, i_p = -1, o_l = -1, q = -1, desc = -1, f_d = -1, p = -1, i=-1, im = -1;
                while (info.Read())
                {
                    i = info["Id"];
                    n = info["Name"];
                    desc = info["Description"];
                    i_p = info["ImagePath"];
                    q = info["Quantity"];
                    p = info["Price"];
                    f_d = info["FullDiscription"];
                    im = info["Pic"];

                    Prod a = new Prod();
                    if (i_p != null)
                    {
                        a = new Prod(Convert.ToInt32(i), Convert.ToString(n), Convert.ToString(desc), Convert.ToInt32(q), Convert.ToInt32(p), Convert.ToString(i_p), Convert.ToString(f_d));
                    }
                    else
                    {
                        a = new Prod(Convert.ToInt32(i), Convert.ToString(n), Convert.ToString(desc), Convert.ToInt32(q), Convert.ToInt32(p), Convert.ToString(f_d), (byte[])(im));
                    }
                    prods.Add(a);
                }


                //adapter = new SqlDataAdapter(command);
                //adapter.Fill(prodsTable);
                //for (int i = 0; i < prodsTable.Rows.Count; i++)
                //{
                //    Prod prod = new Prod(prodsTable.Rows[i].Field<int>("Id"),
                //        prodsTable.Rows[i].Field<string>("Name"),
                //        prodsTable.Rows[i].Field<string>("Description"),
                //        prodsTable.Rows[i].Field<int>("ImagePath"),
                //        prodsTable.Rows[i].Field<int>("Quantity"),
                //        prodsTable.Rows[i].Field<string>("Price"),
                //        prodsTable.Rows[i].Field<string>("FullDiscription")
                //        );
                //    prods.Add(prod);
                //}
            }
            catch (Exception ex)
            {
                try
                {
                    string str =
         "use [Products] " +
         "CREATE TABLE[dbo].[Products](" +
         "[Id][int] IDENTITY(0, 1) NOT NULL," +
         "[Name] [nvarchar](50) NULL," +
         "[Description] [nvarchar](50) NULL," +
         "[ImagePath] [nvarchar](MAX) NULL," +
         "[Quantity] [int] NULL," +
         "[Price] [int] NULL," +
         "[FullDiscription] [nvarchar](50) NULL," +
         "[Pic] varbinary(MAX) NULL" +
         ") ON[PRIMARY] " +
         " ";

                    SqlConnection sqlCon = new SqlConnection("Server=LAPTOP-N0QMVJ9U;Trusted_Connection = Yes;DataBase=master");
                    SqlCommand command = new SqlCommand(str, sqlCon);
                    sqlCon.Open();
                    command.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show(ex.Message);
                }
                catch(Exception e)
                { }
            }
            return prods;
        }

        public bool Delete(Prod d)
        {
            string sql = $"DELETE FROM Products WHERE Id = {d.Id}";

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

        public bool Transaction()
        {
            SqlConnection sqlCon = new SqlConnection("server = LAPTOP-N0QMVJ9U; Trusted_Connection = Yes; DataBase = Products");
            sqlCon.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            try
            {
               
                string img = @"C:\Users\User\Pictures\411491371.jpg";
                command.CommandText = "INSERT INTO Products( Name, Description, ImagePath,  FullDiscription, Pic) VALUES " +
                $"(\'Transaction\', \'Transaction\', \'{img}\', \'Transaction\',@image)";
                command.Parameters.Add("@image", SqlDbType.Image, 1000000);
                command.Parameters["@image"].Value = File.ReadAllBytes(img) ;
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Products( Name, Description, ImagePath,  FullDiscription) VALUES " +
                $"(\'Transaction1\', \'Transaction1\', \'{img}\',  \'Transaction1\')";
                command.ExecuteNonQuery();

                
                transaction.Commit();
                MessageBox.Show("Данные добавлены в базу данных");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
                return false;
            }
        }
        public List<Prod> Sort()
        {
            string sql = "SELECT * FROM Products ORDER BY Name desc";
            DataTable prodsTable = new DataTable();
            SqlDataAdapter adapter;

            List<Prod> prods = new List<Prod>();
            try
            {

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader info = command.ExecuteReader();
                object n = -1, t = -1, i_p = -1, o_l = -1, q = -1, desc = -1, f_d = -1, p = -1, i = -1, im=-1;
                while (info.Read())
                {
                    i = info["Id"];
                    n = info["Name"];
                    desc = info["Description"];
                    i_p = info["ImagePath"];
                    q = info["Quantity"];
                    p = info["Price"];
                    f_d = info["FullDiscription"];
                    im = info["image"];

                    Prod a = new Prod();
                    if (i_p != null)
                    {
                        a = new Prod(Convert.ToInt32(i), Convert.ToString(n), Convert.ToString(desc), Convert.ToInt32(q), Convert.ToInt32(p), Convert.ToString(i_p), Convert.ToString(f_d));
                    }
                    else
                    {
                        a = new Prod(Convert.ToInt32(i), Convert.ToString(n), Convert.ToString(desc), Convert.ToInt32(q), Convert.ToInt32(p), Convert.ToString(f_d), (byte[])(im));
                    }
                    prods.Add(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return prods;
        }

        public bool Trunc()
        {
            string sql = $"truncate TABLE Products ";

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

        public bool Update(int id, Prod p)
        {
            string sql = $"UPDATE Products SET Name=\'{p.Name}\', Description = \'{p.Description}\', Quantity = \'{p.Quantity}\', Price = \'{p.Price}\', Pic = @image  WHERE Id = {id}";

            try
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@image", SqlDbType.Image, 1000000);
                command.Parameters["@image"].Value = p.Image ?? File.ReadAllBytes(p.ImagePath);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void MyProcedure()
        {
            try
            {

                string Procedure = "ADOSHOW";
                //connection.Open();
                SqlCommand command = new SqlCommand(Procedure, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                string result = "";
                result += reader.GetName(0) + "\t" + reader.GetName(1) + "\t" + reader.GetName(2) + "\n";
                while (reader.Read())
                {
                    result += reader.GetString(0) + '\t';
                    result += reader.GetString(1) + '\t';
                    result += reader.GetString(2) + '\n';

                }
                MessageBox.Show(result);
                //connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    string str =
                            "CREATE PROCEDURE ADOSHOW " +
                            "AS  " +
                            "BEGIN " +
                            "SELECT NAME, DESCRIPTION, ImagePath FROM Products " +
                            "END go" +
                            "";

                    SqlConnection sqlCon = new SqlConnection("Server=LAPTOP-N0QMVJ9U;Trusted_Connection = Yes;DataBase=Products");
                    SqlCommand command = new SqlCommand(str, sqlCon);
                    sqlCon.Open();
                    command.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show(ex.Message);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
