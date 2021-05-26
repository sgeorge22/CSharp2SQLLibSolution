using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CSharp2SQLLib
{
    public class SqlLib
    {
        public SqlConnection sqlconn { get; set; }

        public User GetByPK(int id)
        {
            var sql = $"SELECT * From Users Where Id = {id}; ";
            var cmd = new SqlCommand(sql, sqlconn);
            var sqldatareader = cmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                sqldatareader.Close();
                return null;
            }
            sqldatareader.Read();
            var user = new User() 
            { 
                Id = Convert.ToInt32(sqldatareader["Id"]), 
                Username = Convert.ToString(sqldatareader["Username"]),
                Password = Convert.ToString(sqldatareader["Password"]),
                Firstname = Convert.ToString(sqldatareader["Firstname"]),
                Phone = Convert.ToString(sqldatareader["Phone"]),
                Email = Convert.ToString(sqldatareader["Email"]),
                IsReviewer = Convert.ToBoolean(sqldatareader["IsReviewer"]),
                IsAdmin = Convert.ToBoolean(sqldatareader["IsAdmin"])
            };
            sqldatareader.Close();
            return user;
        }

        public List<User> GetAllUsers()
        {
            var sql = "SELECT * From Users;";
            var cmd = new SqlCommand(sql, sqlconn);
            var sqldatareader = cmd.ExecuteReader();

            var users = new List<User>();
            while (sqldatareader.Read())
            {
                var id = Convert.ToInt32(sqldatareader["Id"]);
                var username = Convert.ToString(sqldatareader["Username"]);
                //var username = (sqldatareader["Username"].ToString); this way is acceptable to for string
                var password = Convert.ToString(sqldatareader["Password"]);
                var firstname = Convert.ToString(sqldatareader["Firstname"]);
                var lastname = Convert.ToString(sqldatareader["Lastname"]);
                var phone = Convert.ToString(sqldatareader["Phone"]);
                var email = Convert.ToString(sqldatareader["Email"]);
                var isReviewer = Convert.ToBoolean(sqldatareader["IsReviewer"]);
                var isAdmin = Convert.ToBoolean(sqldatareader["IsAdmin"]);

                var user = new User()
                {   //initializing date for the constructor
                    Id = id, Username = username, Password = password, Firstname = firstname, Lastname = lastname, 
                    Phone = phone, Email = email, IsReviewer = isReviewer, IsAdmin = isAdmin
                };
                users.Add(user);
            }
            sqldatareader.Close();
            return users;
        }
        public List<Vendor> GetAllVendors() 
        {
            var sql = "SELECT * From Vendors;";
            var cmd = new SqlCommand(sql, sqlconn);
            var sqldatareader = cmd.ExecuteReader();

            var vendors = new List<Vendor>();
            while (sqldatareader.Read())
            {
                var id = Convert.ToInt32(sqldatareader["Id"]);
                var code = Convert.ToInt32(sqldatareader["Code"]);
                var name = Convert.ToString(sqldatareader["Name"]);
                var address = Convert.ToString(sqldatareader["Address"]);
                var city = Convert.ToString(sqldatareader["City"]);
                var state = Convert.ToString(sqldatareader["State"]);
                var zip = Convert.ToString(sqldatareader["Zip"]);
                var phone = Convert.ToString(sqldatareader["Phone"]);
                var email = Convert.ToString(sqldatareader["Email"]);

                var vendor = new Vendor()
                {
                    Id = id,
                    Code = code,
                    Name = name,
                    Address = address,
                    City = city,
                    State = state,
                    Zip = zip,
                    Phone = phone,
                    Email = email
                };
                vendors.Add(vendor);

            }
                sqldatareader.Close();
                return vendors;
        }
        public void Connect()
        {
            var connStr = "server=localhost\\sqlexpress01;" +
                            "database=PrsDb;" +
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
