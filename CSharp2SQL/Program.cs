using CSharp2SQLLib;
using System;

namespace CSharp2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlconn = new Connection("localhost\\sqlexpress01", "PrsDb");

            var newProduct = new Product()
            {
                Id = 0, PartNbr = 0, Name = "ColourPop", Price = 10,
                Unit = "Each", PhotoPath = null, VendorId = 0
            };
            var vendorsController = new VendorsController(sqlconn);
            var vendors = vendorsController.GetAll();

            var productcontroller = new ProductController(sqlconn);
            //var products = productcontroller.GetAll();
            var products = productcontroller.GetByPK(11);
            //var success = productcontroller.Create(newProduct, 1340);

            sqlconn.Disconnect();

            //var sqllib = new SqlLib();
            //sqllib.Connect();
            
            //var user = sqllib.GetByPK(4);
            //user.Phone = "513-555-1212";
            //user.Email = "user@email.com";
            //var success = sqllib.Change(user);

            //var user = sqllib.GetByPK(5);
            //var success = sqllib.Remove(user);

            //var newUser = new User()
            //{
                //Id = 0, Username = "XYZ1", Password = "XYZ1", Firstname = "XYZ1", Lastname = "XYZ1", 
                //Phone = "XYZ1", Email = "XYZ1", IsReviewer = true, IsAdmin = true
            //};
            //var success = sqllib.Create(newUser);

            //var users = sqllib.GetAllUsers();

            //var vendors = sqllib.GetAllVendors();

            //sqllib.Disconnet();
        }
    }
}
