using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Model;

namespace NewsVn.Impl.Model
{
    public enum FilterMethod
    {
        Absolute, Relative
    }

    public enum FilterChain
    {
        LinkOne, LinkAll
    }
    
    public class FilterModel
    {
        public Base Token { get; set; }

        public FilterMethod Method { get; set; }

        public FilterChain Chain { get; set; }

        public static bool EqualToString(string strHost, string strCompare)
        {
            strHost = strHost.Trim();
            strCompare = strCompare.Trim();

            if (string.IsNullOrEmpty(strHost) || string.IsNullOrEmpty(strCompare))
            {
                return true;
            }

            return strHost.Equals(strCompare, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainString(string strHost, string strCompare)
        {
            strHost = strHost.Trim();
            strCompare = strCompare.Trim();

            if (string.IsNullOrEmpty(strHost) || string.IsNullOrEmpty(strCompare))
            {
                return true;
            }

            return strHost.ToLower().Contains(strCompare.ToLower());
        }
    }
}
