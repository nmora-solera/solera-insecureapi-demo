using Google.Protobuf.WellKnownTypes;
using InsecureApi.Classes;
using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;

namespace InsecureApi.Database
{
    public class DatabaseOperations
    {
        private string server = "localhost";
        public string databaseName = "insecureapi";
        public string userName = "root";
        public string password = "admin";
        private MySqlConnection? connection;
        private string apiKey = "0imfnc8mVLWwsAawjYr4Rx-Af50DDqtlx";

        public void openConnection()
        {
            try
            {
                if (connection == null)
                {
                    connection = new MySqlConnection($"Server={server}; database={databaseName}; UID={userName}; password={password}");
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {

            }
        }

        public void closeConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {

            }
        }

        public List<User> GetAccount(string id)
        {
            openConnection();

            string query = "SELECT * FROM userslist where id = '" + id + "'";
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            List<User> user = new List<User>();

            while (reader.Read())
            {
                User userClass = new User();
                userClass.id = reader.GetString(0);
                userClass.name = reader.GetString(1);
                userClass.type = reader.GetString(2);

                user.Add(userClass);
            }

            closeConnection();
            return user;
        }

        public bool Login(string userId, string password)
        {
            openConnection();

            string query = "SELECT * FROM credentials where name = '" + userId + "' and password = '" + password + "'";
            var cmd = new MySqlCommand(query, connection);
            var userCanLogin = cmd.ExecuteScalar();
            closeConnection();

            return userCanLogin != null ? true : false;
        }
        public bool ChangePassword(string userId, string newPassword)
        {
            openConnection();

            string query = "UPDATE credentials SET password = '" + newPassword + "' where id = " + userId;
            var cmd = new MySqlCommand(query, connection);
            var userCanLogin = cmd.ExecuteNonQuery();
            closeConnection();

            return userCanLogin > 0 ? true : false;
        }

        public List<User> GetParameterizedAccount(string name)
        {
            openConnection();

            string query = "SELECT * FROM userslist where name = @param1";
            List<User> user = new List<User>();

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@param1", name);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User userClass = new User();
                userClass.id = reader.GetString(0);
                userClass.name = reader.GetString(1);
                userClass.type = reader.GetString(2);

                user.Add(userClass);
            }

            closeConnection();
            return user;
        }
    }
}
