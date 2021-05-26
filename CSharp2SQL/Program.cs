using CSharp2SQLLib;
using System;

namespace CSharp2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqllib = new SqlLib();
            sqllib.Connect();

            var newUser = new User()
            {
                Id = 0, Username = "XYZ", Password = "XYZ", Firstname = "XYZ", Lastname = "XYZ", 
                Phone = "XYZ", Email = "XYZ", IsReviewer = true, IsAdmin = true
            };
            var success = sqllib.Create(newUser);

            var users = sqllib.GetAllUsers();
            var user = sqllib.GetByPK(4);

            var vendors = sqllib.GetAllVendors();

            sqllib.Disconnet();
        }
    }
}
