using NewsVn.Impl.PostFetch.Services;

namespace NewsVn.Impl.PostFetch.Services
{
    public class DefaultPostFetchService : PostFetchServiceAbstract
    {
        public DefaultPostFetchService(ISettingReader settingReader)
            : base(settingReader)
        {

        }
    }
}

