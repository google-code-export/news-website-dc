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
           
        }
    }
}
