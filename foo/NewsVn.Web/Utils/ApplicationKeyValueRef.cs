using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Impl.Context;

namespace NewsVn.Web.Utils
{
    public class ApplicationKeyValueRef
    {
        private static List<Impl.Entity.KeyValueRef> _keyValueRef;

         static ApplicationKeyValueRef()
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                _keyValueRef = ctx.KeyValueRefRepo.Getter.getEnumerable().ToList();
            }
        }

        public static List<Impl.Entity.KeyValueRef> GetAll()
        {
            return _keyValueRef;
        }

        public static string GetKeyValue(string type, string key)
        {
            try
            {
                return _keyValueRef.SingleOrDefault(s => s.Type.Equals(type, StringComparison.OrdinalIgnoreCase)
                    && s.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).Value;
            }
            catch (Exception)
            {
                return "Không tìm được giá trị.";
            }
        }
    }
}