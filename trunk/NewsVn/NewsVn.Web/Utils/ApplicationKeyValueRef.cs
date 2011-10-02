using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsVn.Impl.Context;
using System.Web.UI.WebControls;

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
                return "";
            }
        }

        public static void BindingDataToComboBox(DropDownList ddl, string keyRefType)
        {
            var refValueResult = _keyValueRef.Where(g => g.Type == keyRefType).ToList();
            ddl.DataSource = refValueResult;
            ddl.DataTextField = "Value";
            ddl.DataValueField = "Key";
            ddl.DataBind();    
        }
        /// <summary>
        /// get location by parentID | 02/10/2011
        /// </summary>
        /// <param name="ddl">ddl control</param>
        /// <param name="ParentID">int value</param>
        public static void LoadLocation(DropDownList ddl, int ParentID, bool isSelectAllCountry)
        {
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _Location = ctx.LocationRepo.Getter.getEnumerable()
                    .Select(l => new
                    {
                        l.LocationID,
                        l.LocationName,
                        l.CountryID
                    }).Take(0).ToList();
                if (isSelectAllCountry)
                {
                    _Location = _Location.Where(p => p.CountryID == ParentID).Select(l => new
                    {
                        l.LocationID,
                        l.LocationName,
                        l.CountryID
                    }).ToList();
                }
                else
                {
                    _Location = _Location.Where(p => p.CountryID != ParentID).Select(l => new
                    {
                        l.LocationID,
                        l.LocationName,
                        l.CountryID
                    }).ToList();
                }
                ddl.DataSource = _Location;
                ddl.DataTextField = "LocationName";
                ddl.DataValueField = "LocationID";
                ddl.DataBind();
            }
        }

        /// <summary>
        /// return (string) location Name by LocationID | 02/10/2011
        /// </summary>
        /// <param name="ParentID">int Location ID</param>
        public static string getLocationNameByID(int LocationID) {
            var  LocationName = "";
            using (var ctx = new NewsVnContext(Utils.ApplicationManager.ConnectionString))
            {
                var _Location = ctx.LocationRepo.Getter.getOne(l => l.LocationID == LocationID);
                LocationName = _Location.LocationName;
            }
            return LocationName;
        }
    }
}