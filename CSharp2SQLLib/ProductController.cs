using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class ProductController
    {
        private static Connection connection { get; set; }

        private Product FillProductFromSqlRow(SqlDataReader reader)
        {
            var product = new Product()
            {
                Id = Convert.ToInt32(reader["Id"]),
                PartNbr = Convert.ToInt32(reader["PartNbr"]),
                Name = Convert.ToString(reader["Name"]),
                Price = Convert.ToDecimal(reader["Price"]),
                Unit = Convert.ToString(reader["Unit"]),
                PhotoPath = Convert.ToString(reader["PhotoPath"]),
                VendorId = Convert.ToInt32(reader["VendorId"])
            };
            return product;
        }

        public List<Product> GetAll()
        {
            var sql = "SELECT * From Products; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                var product = FillProductFromSqlRow(reader);
                products.Add(product);
            }
            reader.Close();
            GetVendorForProducts(products);
            return products;

        }
        public Product GetByPK(int id)
        {
            var sql = $"SELECT * From Products Where Id = {id}; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var sqldatareader = cmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                sqldatareader.Close();
                return null;
            }
            sqldatareader.Read();
            var product = FillProductFromSqlRow(sqldatareader);
            sqldatareader.Close();
            return product;
        }
        //public bool Create(Product product)
        //{
        //    var vendCtrl = new VendorsController(connection);
        //    var vendor = vendCtrl.GetByCode(VendorCode);
        //    product.VendorId = vendor.Id;
        //        return Create(product);
        //}

        public bool Create(Product product)
        {
            var sql = "INSERT into Products " +
                        " (PartNbr, Name, Price, Uit, PhotoPath, VendorId) " +
                        " VALUES (@partnbr, @name, @price, @unit, @photopath, @vendorid); ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@partnbr", product.PartNbr);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@unit", product.Unit);
            cmd.Parameters.AddWithValue("@photopath", (object) product.PhotoPath ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@vendorid", product.VendorId);
            var rowsAffected = cmd.ExecuteNonQuery();

            return (rowsAffected == 1);
        }
        
        private void GetVendorForProducts(List<Product> products)
        {
            foreach(var product in products)
            {
                GetVendorForProducts(product);
            }
        }
        private void GetVendorForProducts(Product product)
        {
            var vendCtrl = new VendorsController(connection);
            product.Vendor = vendCtrl.GetByPK(product.VendorId);
        }

        public ProductController(Connection connection) //dependency injection
        {
            ProductController.connection = connection;
        }

    }
}
