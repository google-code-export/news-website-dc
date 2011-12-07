using System.Collections.Generic;
using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch.Models
{
    public class PostSettingModel
    {
        public string Url { get; set; }

        public int TargetID { get; set; }

        public IList<FilterSetting> Filters { get; set; }

        public IList<RuleSetting> Rules { get; set; }
    }
}
