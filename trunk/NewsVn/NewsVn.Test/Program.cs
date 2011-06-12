using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsVn.Impl.Context;
using NewsVn.Impl.Entity;

namespace NewsVn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string _connectionString = Connection.ConnectionString;

            using (var db = new NewsVnContext(_connectionString))
            {
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine(db.CategoryRespo.Getter.getFirst().ToString());
                Console.WriteLine(db.CategoryRespo.Getter.getLast().ToString());

                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine(db.CategoryRespo.Getter.getAtIndex(1).ToString());
            }
        }
    }
}
