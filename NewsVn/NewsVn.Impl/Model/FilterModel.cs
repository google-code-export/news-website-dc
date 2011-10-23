using System.Collections.Generic;

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
        public Vietstream.Data.Model.Base Token { get; set; }

        public FilterMethod Method { get; set; }

        public FilterChain Chain { get; set; }

        public IDictionary<string, object> Data { get; set; }
    }
}
