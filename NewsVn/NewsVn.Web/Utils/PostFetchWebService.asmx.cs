using System.Collections.Generic;
using System.Web.Services;
using NewsVn.Impl.PostFetch.Models;
using NewsVn.Impl.PostFetch.Services;

namespace NewsVn.Web.Utils
{
    /// <summary>
    /// Summary description for PostFetchWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class PostFetchWebService : System.Web.Services.WebService
    {
        private readonly PostFetchServiceAbstract _fetchService;

        public PostFetchWebService()
        {
            _fetchService = new DefaultPostFetchService();
        }

        [WebMethod]
        public PostSettingModel RequestSetting(int siteID, int categoryID)
        {
            return _fetchService.RequestSetting(siteID, categoryID);
        }

        [WebMethod]
        public IList<PostItemModel> RequestPostItemList(string categoryUrl)
        {
            return _fetchService.RequestPostItemList(categoryUrl);
        }

        public string RequestRawPostItemList(string categoryUrl)
        {
            return _fetchService.RequestRawPostItemList(categoryUrl);
        }

        [WebMethod]
        public string RequestRawPostItem(string itemUrl)
        {
            return _fetchService.RequestRawPostItem(itemUrl);
        }

        [WebMethod]
        public bool AddPostItem(PostItemModel item)
        {
            return _fetchService.AddPostItem(item);
        }
    }
}
