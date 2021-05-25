using Microsoft.Data.SqlClient;
using System;

namespace CSharp2SQLLib
{
    public class SqlLib
    {
        public SqlConnection sqlconn { get; set; }

        public void Connect()
        {
            var connStr = "server=localhost\\sqlexpress01;" +
                            "database=EdDb;" +
                            "trusted_connection=true;";
            sqlconn = new SqlConnection(connStr);
            sqlconn.Open();
            if (sqlconn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection string is not correct!");
            }
            Console.WriteLine("Open connection successful!");
        }
            public void Disconnet()
            {
                if(sqlconn == null)
                {
                    return;
                }
            sqlconn.Close();
            sqlconn = null;

            }

        

    }
}
