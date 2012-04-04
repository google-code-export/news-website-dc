using System.Collections.Generic;
using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch.Models
{
    public class PostSettingModel
    {
        public int SiteID { get; set; }

        // Added by CuongNguyen: 04/04/2012
        public string SiteName { get; set; }

        public int CategoryID { get; set; }

        public string Type { get; set; }
        
        public string Url { get; set; }

        public string SiteUrl { get; set; }

        public int TargetID { get; set; }

        public IList<FilterSetting> Filters { get; set; }

        public IList<RuleSetting> Rules { get; set; }
    }
}
