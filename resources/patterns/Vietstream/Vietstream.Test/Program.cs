using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vietstream.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string _connectionString = Connection.ConnectionString;
            
            using (var ctx = new Context.NewsVnContext(_connectionString))
            {
                Console.WriteLine(ctx.CategoryRespo.Getter.getAtIndex(5));
                Console.WriteLine(ctx.PostRespo.Getter.getAtIndex(5));
                Console.WriteLine(ctx.CategoryRespo.Getter.getLast());

                var category = new Entity.Category
                {
                    Type = "test",
                    Name = "Test Cate",
                    Description = "Test Desc",
                    SeoName = "seo name",
                    SeoUrl = "seo url",
                    UpdatedOn = DateTime.Now,
                    Actived = true
                };

                ctx.CategoryRespo.Setter.addOne(category);
            }
        }
    }
}
