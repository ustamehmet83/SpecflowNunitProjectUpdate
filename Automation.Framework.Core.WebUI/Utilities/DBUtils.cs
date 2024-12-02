using Automation.DemoUI.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Utilities
{
    public class DBUtils
    {
        private static SqlConnection? connection;
        private static SqlCommand? command;
        private static SqlDataReader? reader;

        public static void CreateConnection()
        {
            string dbUrl = ConfigurationReader.GetJsonConfigurationValue("dbUrl");
            

            try
            {
                connection = new SqlConnection(dbUrl);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error creating connection: {e.Message}");
            }
        }

        public static void Destroy()
        {
            try
            {
                reader?.Close();
                command?.Dispose();
                if (connection?.State == ConnectionState.Open)
                {
                     connection?.Close();
                }
               
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error closing resources: {e.Message}");
            }
        }

        public static void ExecuteQuery(string query)
        {
            try
            {
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();//CommandBehavior.CloseConnection
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error executing query: {e.Message}");
            }
        }

        public static object GetCellValue(string query) => GetQueryResultList(query).FirstOrDefault();

        public static List<object> GetRowList(string query)
        {
            return GetQueryResultList(query).FirstOrDefault() ?? new List<object>();
        }

        public static Dictionary<string, object> GetRowMap(string query)
        {
            return GetQueryResultMap(query).FirstOrDefault() ?? new Dictionary<string, object>();
        }

        public static List<List<object>> GetQueryResultList(string query)
        {
            ExecuteQuery(query);
            var rowList = new List<List<object>>();

            while (reader.Read())
            {
                var row = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetValue(i));
                }
                rowList.Add(row);
            }

            reader.Close();
            return rowList;
        }

        public static List<object> GetColumnData(string query, string columnName)
        {
            ExecuteQuery(query);
            var columnData = new List<object>();

            while (reader.Read())
            {
                columnData.Add(reader[columnName]);
            }

            reader.Close();
            return columnData;
        }

        public static List<Dictionary<string, object>> GetQueryResultMap(string query)
        {
            ExecuteQuery(query);
            var rowList = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                var rowMap = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    rowMap.Add(reader.GetName(i), reader.GetValue(i));
                }
                rowList.Add(rowMap);
            }

            reader.Close();
            return rowList;
        }

        public static List<Dictionary<string, long>> GetQueryResultMapLong(string query)
        {
            ExecuteQuery(query);
            var rowList = new List<Dictionary<string, long>>();

            while (reader.Read())
            {
                var rowMap = new Dictionary<string, long>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    rowMap.Add(reader.GetName(i), reader.GetInt64(i));
                }
                rowList.Add(rowMap);
            }

            reader.Close();
            return rowList;
        }

        public static List<string> GetColumnNames(string query)
        {
            ExecuteQuery(query);
            var columns = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }

            reader.Close();
            return columns;
        }

        public static void ExecuteUpdate(string query)
        {
            try
            {
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error executing update: {e.Message}");
            }
        }

        public static int GetRowCount(string query)
        {
            ExecuteQuery(query);
            int rowCount = 0;

            while (reader.Read())
            {
                rowCount++;
            }

            reader.Close();
            return rowCount;
        }

        public static void SslContext()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}
