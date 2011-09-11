using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Impl.Context;

namespace NewsVn.Web.Utils
{
    public class ApplicationSettings
    {
        private static List<Impl.Entity.Setting> _settings;
        
        static ApplicationSettings()
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                _settings = ctx.SettingRepo.Getter.getEnumerable().ToList();
            }
        }

        public static List<Impl.Entity.Setting> GetAll()
        {
            return _settings;
        }

        public static string GetSettingValue(string type, string name)
        {
            try
            {
                return _settings.SingleOrDefault(s => s.Type.Equals(type, StringComparison.OrdinalIgnoreCase)
                    && s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).Value;
            }
            catch (Exception)
            {
                return "Không tìm được giá trị cấu hình.";
            }
        }
    }
}