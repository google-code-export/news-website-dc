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

        public DateTime? PubDate { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// Converts this model into Post Entity
        /// </summary>
        /// <returns>Post entity</returns>
        public Post ToPostEntity()
        {
            Post PostEntity = new Post();
            PostEntity.ID = ID;
            PostEntity.Title = Title.Trim();
            PostEntity.Avatar = Avatar;
            PostEntity.Description = Description.Trim();
            PostEntity.Content = Content;
            PostEntity.SeoUrl = Url.Trim();
            return PostEntity;
        }
    }
}

