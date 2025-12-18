using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEquips.DATA_ACCES
{
    using MySql.Data.MySqlClient;

    public class MySQLConnection
    {
        private string connectionString;
        private MySqlConnection connection;

        public MySQLConnection(string servidor = "localhost", string baseDades = "baseIdao", string usuari = "marc", string contrasenya = "password1")
        {
            connectionString = $"Server={servidor};Database={baseDades};Uid={usuari};Pwd={contrasenya};";
            connection = new MySqlConnection(connectionString);
        }

        public bool Connect()
        {
            bool fet = false;

            connection.Open();
            fet = true;
           

            return fet;
        }

        public bool Disconnect()
        {
            bool fet = false;

           
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                fet = true;
            }
            
           

            return fet;
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }

} 
