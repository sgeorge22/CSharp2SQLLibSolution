using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class VendorsController
    {
        private static Connection connection { get; set; }

        private Vendor FillVendorFromSqlRow(SqlDataReader reader)
        {
            var vendor = new Vendor()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Code = Convert.ToString(reader["Code"]),
                Name = Convert.ToString(reader["Name"]),
                Address = Convert.ToString(reader["Address"]),
                City = Convert.ToString(reader["City"]),
                State = Convert.ToString(reader["State"]),
                Zip = Convert.ToString(reader["Zip"]),
                Phone = Convert.ToString(reader["Phone"]),
                Email = Convert.ToString(reader["Email"])
            };
            return vendor;
        }

        public Vendor GetByCode(string Code)
        {
            var sql = "SELECT * From Vendors Where Code = @code;";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@code", Code);
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();

            var vendor= FillVendorFromSqlRow(reader);

            reader.Close();
            return vendor;
        }
        

        public List<Vendor> GetAll()
        {
            var sql = "SELECT * From Vendors;";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var reader = cmd.ExecuteReader();
            var vendors = new List<Vendor>();
            while (reader.Read())
            {
                var vendor = FillVendorFromSqlRow(reader);
                vendors.Add(vendor);
            }
            reader.Close();
            return vendors;

        }
        public Vendor GetByPK(int id)
        {
            var sql = $"SELECT * From Vendors Where Id = {id}; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();
            var vendor = FillVendorFromSqlRow(reader);
            reader.Close();
            return vendor;
        }
        public bool Remove(Vendor vendor)
        {
            var sql = $"DELETE from Vendors " +
                         " Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", vendor.Id);
            sqlcmd.Parameters.AddWithValue("@code", vendor.Code);
            sqlcmd.Parameters.AddWithValue("@name", vendor.Name);
            sqlcmd.Parameters.AddWithValue("@address", vendor.Address);
            sqlcmd.Parameters.AddWithValue("@city", vendor.City);
            sqlcmd.Parameters.AddWithValue("@state", vendor.State);
            sqlcmd.Parameters.AddWithValue("@zip", vendor.Zip);
            sqlcmd.Parameters.AddWithValue("@phone", vendor.Phone);
            sqlcmd.Parameters.AddWithValue("@email", vendor.Email);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }

        public bool change(Vendor vendor)
        {
            var sql = $"UPDATE Vendors Set " +
                        " Code = @code, Name = @name, Address = @address, City = @city, " +
                        " State = @state, Zip = @zip, Phone = @phone, Email = @email, " +
                         " Where Id = @id;";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", vendor.Id);
            sqlcmd.Parameters.AddWithValue("@code", vendor.Code);
            sqlcmd.Parameters.AddWithValue("@name", vendor.Name);
            sqlcmd.Parameters.AddWithValue("@address", vendor.Address);
            sqlcmd.Parameters.AddWithValue("@city", vendor.City);
            sqlcmd.Parameters.AddWithValue("@state", vendor.State);
            sqlcmd.Parameters.AddWithValue("@zip", vendor.Zip);
            sqlcmd.Parameters.AddWithValue("@phone", vendor.Phone);
            sqlcmd.Parameters.AddWithValue("@email", vendor.Email);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }

        public bool Create(Vendor user)
        {

            var sql = $"INSERT into Vendors" +
                        " (Code, Name, Address, City, State, Zip, Phone, Email) " +
                        " VALUES " +
                        $" (@code, @name, @address, @city, @state, " +
                        $" @zip, @phone, @email); ";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@code", user.Code);
            sqlcmd.Parameters.AddWithValue("@name", user.Name);
            sqlcmd.Parameters.AddWithValue("@address", user.Address);
            sqlcmd.Parameters.AddWithValue("@city", user.City);
            sqlcmd.Parameters.AddWithValue("@state", user.State);
            sqlcmd.Parameters.AddWithValue("@zip", user.Zip);
            sqlcmd.Parameters.AddWithValue("@phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@email", user.Email);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }



        public VendorsController(Connection connection) //dependency injection
        {
            VendorsController.connection = connection;
        }



    }


}    
        
