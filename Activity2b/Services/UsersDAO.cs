using Activity2b.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2b.Services
{
    public class UsersDAO
    {

        string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Activity2db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool findUserByNameAndPassword(UserModel userIn) 
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = userIn.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = userIn.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) 
                    {
                        success = true;
                    } 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
                return success;
        }

    }   
}
