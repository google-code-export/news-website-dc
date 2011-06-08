using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq2SqlEx.Data.Entity;
using Linq2SqlEx.Data.Service;

namespace Linq2SqlEx.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NewsVn;Persist Security Info=True;User ID=sa;Password=123";

            using (var exec = new Executor(connectionString))
            {
                var categories = exec.getQueryable<Category>(c => true);

                foreach (var item in categories)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine(exec.getFirst<Category>().ToString());
            }
        }
    }
}
