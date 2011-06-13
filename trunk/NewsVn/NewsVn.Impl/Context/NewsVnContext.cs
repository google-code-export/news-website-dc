using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Domain;

namespace NewsVn.Impl.Context
{
    public class NewsVnContext : DbContext, IDisposable
    {
        public Repository<Entity.AdBox> AdBoxRespo { get; private set; }
        public Repository<Entity.AdPost> AdPostRespo { get; private set; }
        public Repository<Entity.Category> CategoryRespo { get; private set; }
        public Repository<Entity.Post> PostRespo { get; private set; }
        public Repository<Entity.PostComment> PostCommentRespo { get; private set; }
        public Repository<Entity.Setting> SettingRespo { get; private set; }
        public Repository<Entity.UserMessage> UserMessageRespo { get; private set; }
        public Repository<Entity.UserProfile> UserProfileRespo { get; private set; }
        public Repository<Entity.UserProfileComment> UserProfileCommentRespo { get; private set; }
        public Repository<Entity.Video> VideoRespo { get; private set; }


        public NewsVnContext(string connectionString)
        {
            this.ContextName = "NewsVn";
            this.ConnectionString = connectionString;
            
            this.CreateDataContext();

            this.AdBoxRespo = new Repository<Entity.AdBox>(_ctx);
            this.AdPostRespo = new Repository<Entity.AdPost>(_ctx);          
            this.CategoryRespo = new Repository<Entity.Category>(_ctx);
            this.PostRespo = new Repository<Entity.Post>(_ctx);
            this.PostCommentRespo = new Repository<Entity.PostComment>(_ctx);
            this.SettingRespo = new Repository<Entity.Setting>(_ctx);
            this.UserMessageRespo = new Repository<Entity.UserMessage>(_ctx);
            this.UserProfileRespo = new Repository<Entity.UserProfile>(_ctx);
            this.UserProfileCommentRespo = new Repository<Entity.UserProfileComment>(_ctx);
            this.VideoRespo = new Repository<Entity.Video>(_ctx);
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
