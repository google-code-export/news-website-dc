using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Domain;

namespace NewsVn.Impl.Context
{
    public class NewsVnContext : DbContext, IDisposable
    {
        public Repository<Entity.AdBox, int> AdBoxRespo { get; private set; }
        public Repository<Entity.AdPost, int> AdPostRespo { get; private set; }
        public Repository<Entity.Category, int> CategoryRespo { get; private set; }
        public Repository<Entity.Post, int> PostRespo { get; private set; }
        public Repository<Entity.PostComment, int> PostCommentRespo { get; private set; }
        public Repository<Entity.Setting, int> SettingRespo { get; private set; }
        public Repository<Entity.UserMessage, int> UserMessageRespo { get; private set; }
        public Repository<Entity.UserProfile, string> UserProfileRespo { get; private set; }
        public Repository<Entity.UserProfileComment, int> UserProfileCommentRespo { get; private set; }
        public Repository<Entity.Video, int> VideoRespo { get; private set; }


        public NewsVnContext(string connectionString)
        {
            this.ContextName = "NewsVn";
            this.ConnectionString = connectionString;
            
            this.CreateDataContext();

            this.AdBoxRespo = new Repository<Entity.AdBox, int>(_ctx);
            this.AdPostRespo = new Repository<Entity.AdPost, int>(_ctx);          
            this.CategoryRespo = new Repository<Entity.Category, int>(_ctx);
            this.PostRespo = new Repository<Entity.Post, int>(_ctx);
            this.PostCommentRespo = new Repository<Entity.PostComment, int>(_ctx);
            this.SettingRespo = new Repository<Entity.Setting, int>(_ctx);
            this.UserMessageRespo = new Repository<Entity.UserMessage, int>(_ctx);
            this.UserProfileRespo = new Repository<Entity.UserProfile, string>(_ctx);
            this.UserProfileCommentRespo = new Repository<Entity.UserProfileComment, int>(_ctx);
            this.VideoRespo = new Repository<Entity.Video, int>(_ctx);
        }

        public void Dispose()
        {
            this.AdBoxRespo.Dispose();
            this.AdPostRespo.Dispose();
            this.CategoryRespo.Dispose();
            this.PostRespo.Dispose();
            this.PostCommentRespo.Dispose();
            this.SettingRespo.Dispose();
            this.UserMessageRespo.Dispose();
            this.UserProfileRespo.Dispose();
            this.UserProfileCommentRespo.Dispose();
            this.VideoRespo.Dispose();
        }
    }
}
