using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Lunchtime
{
    class MySqlDB
    {
        private SqlConnection conn;
        private string connString;


        // Method: ExecuteScalaQuery
        //
        // Description: Method executes SQL querry where single return value is expected
        //Return value: value returned by SQL query
        public object ExecuteScalarQuery(string query) 
        {
            object ret = null; 

            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "SQL connection exeption at Open()");
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                ret = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "SQL query exeption (ExecuteScalar)");
            }

            return ret;

        }


        // Method: ExecuteReaderQuery
        //
        // Description: Method executes SQL querry where more return values (rows) is expected
        //Return value: value returned by SQL query
        public object ExecuteReaderQuery(string query)
        {
            object ret = null;

            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "SQL connection exeption at Open()");
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                ret = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "SQL query exeption (ExecuteReaderQuery)");
            }

            return ret;
        }


        // Method: ExecuteVoidQuery
        //
        // Description: Method executes SQL query where no return value is expected (INSERT, UPDATE, ...)
        //Return value: int (0 - failed, 1 - success)
        public int ExecuteVoidQuery(string query)
        {
            int ret = 0;

            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "SQL connection exeption at Open()");
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                ret = 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "SQL query exeption (ExecuteReaderQuery)");
            }

            return ret;
        }


        // Method: Automatic Class constructor
        //
        // Description: It only stores SQL connection string into a private variable
        //Return value: none
        public MySqlDB()
        {
            connString = @"server=SVEDAMARTIN; database=lunchtime; User Id=martin; Password=martin";
        }

        
        // Method: Class constructor
        //
        // Description: It only stores SQL connection string into a private variable
        //Return value: none
        public MySqlDB(string server, string db, string userid, string passwd)
        {
            connString = @"server=" + server + "; database=" + db + "; User Id=" + userid + "; Password=" + passwd;
        }



        // Method: ValidateUser
        //
        // Description: method connects to DB and searches for number of records with given credentials
        // Return value: return number of found records (0 - none found, 1 - user exists
        public int ValidateUser(string user, string passwd)
        {
            string sql_query = @"select count (*) from users where username='" + user + "'"; // and passwd='" + passwd + "'";
            return (int)ExecuteScalarQuery(sql_query);
        }


        public int SaveUserData(string user, string name, string surname, string passwd, string email, int access_rights)
        {
            int ret = 0;

            string sql_query = @"insert into users(username,email,access_rights,name, surname, passwd) values (" +
                                 "'" + name + "'," +
                                 "'" + email + "'," +
                                 "'" + access_rights + "'," +
                                 "'" + name + "'," +
                                 "'" + surname + "'," +
                                 "'" + passwd + "')"; 
            ret = ExecuteVoidQuery(sql_query);

            return ret;
        }

        /*
        public List<User> GetUsers()
        {
            MySqlDB MySqlDB = new MySqlDB("SVEDAMARTIN", "lunchtime", "martin", "martin");

            string sql_query = @"select * from users";
            SqlDataReader reader = null;

            List<User> users = new List<User>();

            reader = (SqlDataReader)MySqlDB.ExecuteReaderQuery(sql_query);

            while (reader.Read())
            {
                User user = new User((string)reader["username"], (int)reader["access_rights"], (string)reader["name"], (string)reader["surname"],
                                     (string)reader["passwd"]);

                users.Add(user);

            }
            return users;
        }
         */



    }
}
