using System;
using System.Linq;
using System.Web.Configuration;
using NewsVn.Impl.Caching;
using System.IO;
using System.Globalization;

namespace NewsVn.Web.Utils
{
    public class ApplicationManager
    {
        private static bool _alreadyInit;

        public static string HostName { get; set; }
        public static string[] skyStatus { get;set;}

        public static string ConnectionString { get; private set; }

        public static void Init()
        {
            if (!_alreadyInit)
            {
                string[] _subSkyStatus = { "tornado", "tropical storm", "hurricane", "severe thunderstorms", "thunderstorms", "mixed rain and snow", "mixed rain and sleet", "mixed snow and sleet", "freezing drizzle", "drizzle", "freezing rain", "showers", "showers", "snow flurries", "light snow showers", "blowing snow", "snow", "hail", "sleet", "dust", "Sương mù", "haze", "smoky", "blustery", "Gió nhẹ", "cold", "Có mây", "Đêm nhiều mây", "Ngày nhiều mây", "partly cloudy (night)", "partly cloudy (day)", "Trời quang", "Nắng", "fair (night)", "fair (day)", "mixed rain and hail", "Trời nóng", "isolated thunderstorms", "scattered thunderstorms", "scattered thunderstorms", "scattered showers", "Tuyết rơi nhiều", "scattered snow showers", "heavy snow", "partly cloudy", "thundershowers", "snow showers", "isolated thundershowers", "not available" };
                
                skyStatus = _subSkyStatus;
                
                HostName = WebConfigurationManager.AppSettings["HostName"];

                ConnectionString = WebConfigurationManager.ConnectionStrings["NewsVnMain"].ConnectionString;
                
                _alreadyInit = true;
            }
        }        
    }
}