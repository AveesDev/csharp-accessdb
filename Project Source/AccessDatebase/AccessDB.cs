using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace AccessDatebase
{
    public class DatabaseConnection
    {
        public static OleDbConnection dbConnect = new OleDbConnection();
        public static OleDbCommand dbCommand = new OleDbCommand();

        public static void Initialize(string dbPath)
        {
            dbConnect.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath + ";";
            dbCommand.Connection = dbConnect;
        }

        public static List<string> SqlRead(string query) //Used for SELECT commands. Records are returned with cell data seperated with a ':'. Use string.split to seperate them.
        {
            dbConnect.Open();

            dbCommand.CommandText = query;
            OleDbDataReader dbReader = dbCommand.ExecuteReader();
            List<string> records = new List<string>();
            string result = "";
            while (dbReader.Read())
            {
                int numValues = dbReader.FieldCount - 1;

                for (int i = 0; i <= numValues; i++)
                {
                    result += (dbReader.GetValue(i) + ":");
                }
                result = result.Remove(result.Length - 1);
                records.Add(result);
                result = "";
            }

            dbConnect.Close();

            return records;
        }

        public static void SqlUpdate(string query) //Used for INSERT INTO, DELETE, UPDATE etc
        {
            dbCommand.CommandText = query;
            dbConnect.Open();
            dbCommand.ExecuteNonQuery();
            dbConnect.Close();
        }
    }
}
