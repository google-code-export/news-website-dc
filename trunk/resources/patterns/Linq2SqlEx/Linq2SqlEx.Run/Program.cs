using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq2SqlEx.Impl.Context;

namespace Linq2SqlEx.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            string _connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NewsVn;Persist Security Info=True;User ID=sa;Password=123";

            using (var db = new NewsVnContext(_connectionString))
            {
                Console.WriteLine("--------------------------------------------------");
                
                Console.WriteLine(db.CategoryRespo.Getter.getFirst().ToString());
                Console.WriteLine(db.CategoryRespo.Getter.getLast().ToString());

                Console.WriteLine("--------------------------------------------------");

                var categories = db.CategoryRespo.Getter.getQueryable();//.Where(c => c.Name.Contains("kinh"));

                foreach (var cate in categories)
                {
                    Console.WriteLine(cate.ToString());
                }

                /*foreach (var post in db.CategoryRespo.Getter.getFirst().Posts)
                {
                    Console.WriteLine(post.ToString());
                }*/
            }
        }
    }
}
