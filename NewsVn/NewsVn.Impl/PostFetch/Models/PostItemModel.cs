using System;
using NewsVn.Impl.Entity;

namespace NewsVn.Impl.PostFetch.Models
{
    public class PostItemModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime PubDate { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// Converts this model into Post Entity
        /// </summary>
        /// <returns>Post entity</returns>
        public Post ToPostEntity()
        {
            return null;
        }
    }
}

