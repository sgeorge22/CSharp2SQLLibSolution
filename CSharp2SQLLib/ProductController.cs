using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class ProductController
    {
        private static Connection connection { get; set; }

        public List<Product> GetAll()
        {
            var sql = "SELECT * From Products; join Vendors on Products.VendorId = Vendors.Id; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
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
            var product = new Product()
            {
                Id = Convert.ToInt32(sqldatareader["Id"]),
                PartNbr = Convert.ToInt32(sqldatareader["PartNbr"]),
                Name = Convert.ToString(sqldatareader["Name"]),
                Price = Convert.ToDecimal(sqldatareader["Price"]),
                Unit = Convert.ToString(sqldatareader["Unit"]),
                PhotoPath = Convert.ToString(sqldatareader["PhotoPath"]),
                VendorId = Convert.ToInt32(sqldatareader["VendorId"])
            };
            sqldatareader.Close();
            return product;
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
