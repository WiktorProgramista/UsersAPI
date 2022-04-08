using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UserAPI.Application.Interfaces;

namespace UserAPI.Application.Implementations
{

    public class DbConnector : IDbConnector
    {
        private MySqlConnection connection;

        public DbConnector()
        {
            connection = new MySqlConnection("Server=localhost;Port=3306;Database=myapplicationdb;Uid=root;Pwd=");
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand newQuery = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = newQuery.ExecuteReader();
            return dataReader;
        }
    }
}
