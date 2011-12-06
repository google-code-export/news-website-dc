using NewsVn.Impl.PostFetch.Settings;

namespace NewsVn.Impl.PostFetch.Settings
{
    public class CategorySetting
    {
        public int ID { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public int TargetID { get; set; }

        public string Name { get; set; }

        public SiteSetting Site { get; set; }
    }
}

