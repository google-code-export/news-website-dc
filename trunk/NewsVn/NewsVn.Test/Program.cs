using System;
using NewsVn.Impl.Context;
using NewsVn.Impl.PostFetch;
using NewsVn.Impl.Caching;

namespace NewsVn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_PostFetch_XmlReader();
        }

        static void Test_PostFetch_XmlReader()
        {
            try
            {
                string xmlPath = "../../PostFetchSites.xml";

                ISettingReader sr = new XmlSettingReader(xmlPath);

                var sites = sr.GetSiteSettings();

                foreach (var site in sites)
                {
                    var cates = site.Categories;
                    var filters = site.Filters;
                    var rules = site.Rules;

                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Site: {0} | {1} | {2}", site.ID, site.Name, site.Url);
                    Console.WriteLine("\tCategories:");

                    foreach (var cate in cates)
                    {
                        Console.WriteLine("\t\t{0} | {1} | {2} | {3} | {4}",
                            cate.ID, cate.Name, cate.Type, cate.Url, cate.TargetID);
                    }

                    Console.WriteLine("\tFilters:");

                    foreach (var filter in filters)
                    {
                        Console.WriteLine("\t\t{0} | {1} | {2}", filter.Type, filter.Target, filter.Selector);
                    }

                    Console.WriteLine("\tRules:");

                    foreach (var rule in rules)
                    {
                        Console.WriteLine("\t\t{0} | {1} | {2}", rule.Type, rule.Target, rule.Condition);
                    }
                }

                Console.WriteLine("Cached: {0}", HttpContextCache.Exists(Constants.XmlCacheKey));
            }
            catch (Exception)
            {

            }
        }

        static void Test_Data()
        {
            try
            {
                string _connectionString = Connection.ConnectionString;

                using (var ctx = new NewsVnContext(_connectionString))
                {
                    var post = ctx.PostRepo.Getter.getOne(p => p.ID == 1024);
                    Console.WriteLine(post.ToString());
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
