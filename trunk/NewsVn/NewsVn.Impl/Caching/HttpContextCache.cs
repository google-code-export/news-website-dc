using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace NewsVn.Impl.Caching
{
    public class HttpContextCache
    {
        private static object _lockObject;
        private static readonly Cache _cache;

        static HttpContextCache()
        {
            _cache = HttpRuntime.Cache;
            _lockObject = new object();
        }

        public static void Add(string key, object data)
        {
            lock (_lockObject)
            {
                _cache.Insert(key, data, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(24), CacheItemPriority.AboveNormal, null);
            }
        }

        public static void Add(string key, object data, CacheDependency dep)
        {
            lock (_lockObject)
            {
                _cache.Insert(key, data, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null);
            }
        }

        public static void Add(string key, object data, TimeSpan slidingExpiration)
        {
            lock (_lockObject)
            {
                _cache.Insert(key, data, null, Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.AboveNormal, null);
            }
        }

        public static bool Exists(string key)
        {
            lock (_lockObject)
            {
                return _cache.Get(key) != null;
            }
        }

        public static T Get<T>(string key)
        {
            lock (_lockObject)
            {
                object item = _cache.Get(key);
                if (item == null)
                    return default(T);

                return (T)item;
            }
        }

        public static void Remove(string key)
        {
            lock (_lockObject)
            {
                _cache.Remove(key);
            }
        }

        public static void RemoveByPattern(string pattern)
        {
            lock (_lockObject)
            {
                IDictionaryEnumerator enumerator = _cache.GetEnumerator();
                Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var keysToRemove = new List<String>();
                while (enumerator.MoveNext())
                {
                    if (regex.IsMatch(enumerator.Key.ToString()))
                    {
                        keysToRemove.Add(enumerator.Key.ToString());
                    }
                }

                foreach (string key in keysToRemove)
                {
                    _cache.Remove(key);
                }
            }
        }

        public static void Clear()
        {
            lock (_lockObject)
            {
                IDictionaryEnumerator enumerator = _cache.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    _cache.Remove(enumerator.Key.ToString());
                }
            }
        }
    }
}
