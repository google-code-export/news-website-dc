using NewsVn.Impl.PostFetch.Settings;
using System.Collections.Generic;

namespace NewsVn.Impl.PostFetch.Settings
{
    public class SiteSetting
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public IList<CategorySetting> Categories { get; set; }

        public IList<FilterSetting> Filters { get; set; }

        public IList<RuleSetting> Rules { get; set; }
    }
}

