using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    class CRMDatabase
    {
        //private string connectionString;
        //public static MySqlConnection connection;

        public static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        #region Initialize
        private static void Initialize()
        {
            server = "localhost";
            database = "CRAime";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //verifier le connectionString

            connection = new MySqlConnection(connectionString);
        }
        #endregion

        #region OpenConnection
        //open connection to database
        public static bool OpenConnection()
        {            
            if (connection is null)
            {
                Initialize();
            }
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Erreur connexion BDD");
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
        #endregion

        #region CloseConnection
        //Close connection
        public static bool CloseConnection()
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
        #endregion       
    }
    
}