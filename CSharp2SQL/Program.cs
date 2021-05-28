using CSharp2SQLLib;
using System;
using System.Linq;

namespace CSharp2SQL
{
    class Program
    {
        static int[] ints = {
            505,916,549,881,918,385,350,228,489,719,
            866,252,130,706,581,313,767,691,678,187,
            115,660,653,564,805,720,729,392,598,791,
            620,345,292,318,726,501,236,573,890,357,
            854,212,670,782,267,455,579,849,229,661,
            611,588,703,607,824,730,239,118,684,149,
            206,952,531,809,134,929,593,385,520,214,
            643,191,998,555,656,738,829,454,195,419,
            326,996,666,242,189,464,553,579,188,884,
            197,369,435,476,181,192,439,615,746,277
        };
        static void Main(string[] args)
        {
            var sum1 = ints.Where(x => x % 7 == 0 || x % 11 == 0).Sum();

            var avg = ints.Where(x => x % 3 == 0).Count();
            var sum = 0;
            var cnt = 0;
            foreach (var i in ints)
            {
                if (i % 3 == 0)
                {
                    sum += i;
                    cnt++;
                }
            }
            var avg1 = sum / cnt;

            Console.WriteLine($"Average is {avg} and {avg1}");



            //    var sqlconn = new Connection("localhost\\sqlexpress01", "PrsDb");

            //    var newProduct = new Product()
            //    {
            //        Id = 0, PartNbr = 0, Name = "ColourPop", Price = 10,
            //        Unit = "Each", PhotoPath = null, VendorId = 0
            //    };
            //    var vendorsController = new VendorsController(sqlconn);
            //    var vendors = vendorsController.GetAll();

            //    var productcontroller = new ProductController(sqlconn);
            //    var products = productcontroller.GetAll();
            //    var products = productcontroller.GetByPK(11);
            //    //var success = productcontroller.Create(newProduct, 1340);

            //    sqlconn.Disconnect();

            //    //var sqllib = new SqlLib();
            //    //sqllib.Connect();

            //    //var user = sqllib.GetByPK(4);
            //    //user.Phone = "513-555-1212";
            //    //user.Email = "user@email.com";
            //    //var success = sqllib.Change(user);

            //    //var user = sqllib.GetByPK(5);
            //    //var success = sqllib.Remove(user);

            //    //var newUser = new User()
            //    //{
            //        //Id = 0, Username = "XYZ1", Password = "XYZ1", Firstname = "XYZ1", Lastname = "XYZ1", 
            //        //Phone = "XYZ1", Email = "XYZ1", IsReviewer = true, IsAdmin = true
            //    //};
            //    //var success = sqllib.Create(newUser);


            //    //var users = sqllib.GetAllUsers();

            //    //var vendors = sqllib.GetAllVendors();

              //  sqllib.Disconnet();
        }
        }
}
