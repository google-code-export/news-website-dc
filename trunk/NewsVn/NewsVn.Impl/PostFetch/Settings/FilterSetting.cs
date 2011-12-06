using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch.Settings
{
    public class FilterSetting
    {
        public string Type { get; set; }

        public string Target { get; set; }

        public string Selector { get; set; }

        public SiteSetting Site { get; set; }
    }
}

