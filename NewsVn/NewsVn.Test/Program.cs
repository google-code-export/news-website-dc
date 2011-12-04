using System;
using NewsVn.Impl.Context;

namespace NewsVn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string _connectionString = Connection.ConnectionString;

            using (var ctx = new NewsVnContext(_connectionString))
            {
                var post = ctx.PostRepo.Getter.getOne(p => p.ID == 1024);
                Console.WriteLine(post.ToString());
            }
        }
    }
}
