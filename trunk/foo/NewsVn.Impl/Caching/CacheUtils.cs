using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsVn.Impl.Caching
{
    public class CacheUtils
    {
        public static IQueryable<T> SetCacheData<T>(IQueryable<T> data, Func<T, bool> predicate)
        {
            return SetCacheData<T>(data, predicate, "List");
        }

        public static IQueryable<T> SetCacheData<T>(IQueryable<T> data, Func<T, bool> predicate, string cacheSuffix)
        {
            return SetCacheData<T>(data, predicate, cacheSuffix, false);
        }

        public static IQueryable<T> SetCacheData<T>(IQueryable<T> data, Func<T, bool> predicate, string cacheSuffix, bool forceUpdate)
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

        public static IQueryable<T> UpdateCacheData<T>(IQueryable<T> data)
        {
            return UpdateCacheData<T>(data, "List");
        }

        public static IQueryable<T> UpdateCacheData<T>(IQueryable<T> data, string cacheSuffix)
        {
            string key = typeof(T).Name + "." + cacheSuffix;

            if (HttpContextCache.Exists(key)) HttpContextCache.Remove(key);
            HttpContextCache.Add(key, data.ToList().AsQueryable());
            return HttpContextCache.Get<IQueryable<T>>(key);
        }
    }
}
