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

            var users = sqllib.GetAllUsers();
            var user = sqllib.GetByPK(4);

            sqllib.Disconnet();
        }
    }
}
