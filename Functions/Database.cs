using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Notes_App.Functions
{
    public class Database
    {
        public static SQLiteCommand sqlite_cmd;
        public static SQLiteConnection sqlite_conn;

        public SQLiteConnection create_Database_connection()
        {
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.sqlite;Version=3;");

            // open the connection:
            sqlite_conn.Open();

            sqlite_cmd = sqlite_conn.CreateCommand();

            // Test if Tables exist
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS [Notes] ([Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[Titel] Text NULL,[Erstellungsdatum] Text NULL,[Abschlussdatum] Text NULL,[Text] Text NULL)";
            sqlite_cmd.ExecuteNonQuery();

            return sqlite_conn;
        }

        public bool Database_insert(string query)
        {
            sqlite_cmd.CommandText = query;

            sqlite_cmd.ExecuteNonQuery();

            return true;
        }

        public bool Database_update(string query)
        {
            sqlite_cmd.CommandText = query;

            sqlite_cmd.ExecuteNonQuery();

            return true;
        }

        public bool Database_delete(string query)
        {
            sqlite_cmd.CommandText = query;

            int rows = sqlite_cmd.ExecuteNonQuery();

            return true;
        }
        public SQLiteDataReader Database_read(string query)
        {
            sqlite_cmd.CommandText = query;

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            return sqlite_datareader;
        }
    }
}
