using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CSharp2SQLLib
{
    public class SqlLib
    {
        public SqlConnection sqlconn { get; set; }

        public bool Remove(User user)
        {
            var sql = $"DELETE from Users " +
                         " Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, sqlconn);
            sqlcmd.Parameters.AddWithValue("@id", user.Id);
            sqlcmd.Parameters.AddWithValue("@username", user.Username);
            sqlcmd.Parameters.AddWithValue("@password", user.Password);
            sqlcmd.Parameters.AddWithValue("@firstname", user.Firstname);
            sqlcmd.Parameters.AddWithValue("@lastname", user.Lastname);
            sqlcmd.Parameters.AddWithValue("@phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@email", user.Email);
            sqlcmd.Parameters.AddWithValue("@isreviewer", user.IsReviewer);
            sqlcmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }

        public bool Change(User user)
        {
            var sql = $"UPDATE Users Set " +
                         " Username = @username, " +
                         " Password = @password, " +
                         " Firstname = @firstname, " +
                         " Lastname = @lastname, " +
                         " Phone = @phone, " +
                         " Email = @email, " +
                         " IsReviewer = @isreviewer, " +
                         " IsAdmin = @isadmin " +
                         " Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, sqlconn);
            sqlcmd.Parameters.AddWithValue("@id", user.Id);
            sqlcmd.Parameters.AddWithValue("@username", user.Username);
            sqlcmd.Parameters.AddWithValue("@password", user.Password);
            sqlcmd.Parameters.AddWithValue("@firstname", user.Firstname);
            sqlcmd.Parameters.AddWithValue("@lastname", user.Lastname);
            sqlcmd.Parameters.AddWithValue("@phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@email", user.Email);
            sqlcmd.Parameters.AddWithValue("@isreviewer", user.IsReviewer);
            sqlcmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }

        public bool CreateMultiple(List<User> users)
        {
            var success = true;
            foreach(var user in users)
            {
                success = success && Create(user);
            }
            return success;
        }

        public bool Create(User user)
        {

            var sql = $"INSERT into Users" +
                        " (Username, Password, Firstname, Lastname, Phone, Email, IsReviewer, IsAdmin) " +
                        " VALUES " +
                        $" (@username, @password, @firstname, @lastname, @phone, " +
                        $" @email, @isreviewer, @isadmin); "; //always include spaces by the "" and the values
            var sqlcmd = new SqlCommand(sql, sqlconn);
            sqlcmd.Parameters.AddWithValue("@username", user.Username);
            sqlcmd.Parameters.AddWithValue("@password", user.Password);
            sqlcmd.Parameters.AddWithValue("@firstname", user.Firstname);
            sqlcmd.Parameters.AddWithValue("@lastname", user.Lastname);
            sqlcmd.Parameters.AddWithValue("@phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@email", user.Email);
            sqlcmd.Parameters.AddWithValue("@isreviewer", user.IsReviewer);
            sqlcmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }

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
                Lastname = Convert.ToString(sqldatareader["Lastname"]),
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
