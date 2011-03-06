using System;
using System.Linq;
using System.Web.Configuration;
using System.Data.Objects.DataClasses;
using NewsVn.Data;
using NewsVn.Core.Caching;

namespace NewsVn.Web.Utils
{
    public class ApplicationManager
    {
        private static bool _alreadyInit;

        public static string HostName { get; set; }
        
        //public static string ResourcesPath { get; set; }

        //public static string AlbumPath { get; set; }
        
        //public static string PostPath { get; set; }

        //public static string DocumentPath { get; set; }

        //public static string SlidePath { get; private set; }

        //public static string BannerPath { get; private set; }

        public static NewsVnEntities Entities { get; private set; }

        public static void Init()
        {
            if (!_alreadyInit)
            {
                HostName = WebConfigurationManager.AppSettings["HostName"];

                //ResourcesPath = HostName + "/Resources/";
                //AlbumPath = HostName + "/Resources/Albums/";
                //PostPath = HostName + "/Resources/Posts/";
                //SlidePath = HostName + "/Resources/Slides/";
                //BannerPath = HostName + "/Resources/Banners/";
                //DocumentPath = HostName + "/Resources/Documents/";

                Entities = new NewsVnEntities(WebConfigurationManager.ConnectionStrings["NewsVnEntities"].ConnectionString);

                _alreadyInit = true;
            }
        }

        public static IQueryable<T> SetCacheData<T>(IQueryable<T> data, Func<T, bool> predicate) where T : EntityObject
        {
            return SetCacheData<T>(data, predicate, "List");
        }

        public static IQueryable<T> SetCacheData<T>(IQueryable<T> data, Func<T, bool> predicate, string cacheSuffix) where T : EntityObject
        {
            return SetCacheData<T>(data, predicate, cacheSuffix, false);
        }

        public static IQueryable<T> SetCacheData<T>(IQueryable<T> data, Func<T, bool> predicate, string cacheSuffix, bool forceUpdate) where T : EntityObject
        {
            string key = typeof(T).Name + "." + cacheSuffix;

            if (!HttpContextCache.Exists(key))
            {
                if (predicate != null) data = data.Where(predicate).ToList().AsQueryable();
                else data = data.ToList().AsQueryable();
                HttpContextCache.Add(key, data);
            }
            else
            {
                if (forceUpdate)
                {
                    return UpdateCacheData<T>(data, cacheSuffix);
                }
            }
            return HttpContextCache.Get<IQueryable<T>>(key);
        }
        
        public static IQueryable<T> UpdateCacheData<T>(IQueryable<T> data) where T : EntityObject
        {
            return UpdateCacheData<T>(data, "List");
        }

        public static IQueryable<T> UpdateCacheData<T>(IQueryable<T> data, string cacheSuffix) where T : EntityObject
        {
            string key = typeof(T).Name + "." + cacheSuffix;

            if (HttpContextCache.Exists(key)) HttpContextCache.Remove(key);
            HttpContextCache.Add(key, data.ToList().AsQueryable());
            return HttpContextCache.Get<IQueryable<T>>(key);
        }
    }
}