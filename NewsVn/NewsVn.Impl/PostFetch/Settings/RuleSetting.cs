using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch.Settings
{
    public class RuleSetting
    {
        public string Type { get; set; }

        public string Target { get; set; }

        public string Condition { get; set; }

        public SiteSetting Site { get; set; }
    }
}