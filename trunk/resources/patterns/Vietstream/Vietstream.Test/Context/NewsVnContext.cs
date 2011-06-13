using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Domain;

namespace Vietstream.Test.Context
{
    public class NewsVnContext : DbContext, IDisposable
    {
        private Repository<Entity.AdBox> _adBoxRespo;
        private Repository<Entity.AdPost> _adPostRespo;
        private Repository<Entity.Category> _categoryRespo;
        private Repository<Entity.Post> _postRespo;
        private Repository<Entity.PostComment> _postCommentRespo;
        private Repository<Entity.Setting> _settingRespo;
        private Repository<Entity.UserMessage> _userMessageRespo;
        private Repository<Entity.UserProfile> _userProfileRespo;
        private Repository<Entity.UserProfileComment> _userProfileCommentRespo;
        private Repository<Entity.Video> _videoRespo;

        public Repository<Entity.AdBox> AdBoxRespo
        {
            get
            {
                if (_adBoxRespo == null)
                {
                    _adBoxRespo = new Repository<Entity.AdBox>(_ctx);
                }
                return _adBoxRespo;
            }
        }

        public Repository<Entity.AdPost> AdPostRespo
        {
            get
            {
                if (_adPostRespo == null)
                {
                    _adPostRespo = new Repository<Entity.AdPost>(_ctx);
                }
                return _adPostRespo;
            }
        }

        public Repository<Entity.Category> CategoryRespo
        {
            get
            {
                if (_categoryRespo == null)
                {
                    _categoryRespo = new Repository<Entity.Category>(_ctx);
                }
                return _categoryRespo;
            }
        }

        public Repository<Entity.Post> PostRespo
        {
            get
            {
                if (_postRespo == null)
                {
                    _postRespo = new Repository<Entity.Post>(_ctx);
                }
                return _postRespo;
            }
        }

        public Repository<Entity.PostComment> PostCommentRespo
        {
            get
            {
                if (_postCommentRespo == null)
                {
                    _postCommentRespo = new Repository<Entity.PostComment>(_ctx);
                }
                return _postCommentRespo;
            }
        }

        public Repository<Entity.Setting> SettingRespo
        {
            get
            {
                if (_settingRespo == null)
                {
                    _settingRespo = new Repository<Entity.Setting>(_ctx);
                }
                return _settingRespo;
            }
        }

        public Repository<Entity.UserMessage> UserMessageRespo
        {
            get
            {
                if (_userMessageRespo == null)
                {
                    _userMessageRespo = new Repository<Entity.UserMessage>(_ctx);
                }
                return _userMessageRespo;
            }
        }

        public Repository<Entity.UserProfile> UserProfileRespo
        {
            get
            {
                if (_userProfileRespo == null)
                {
                    _userProfileRespo = new Repository<Entity.UserProfile>(_ctx);
                }
                return _userProfileRespo;
            }
        }

        public Repository<Entity.UserProfileComment> UserProfileCommentRespo
        {
            get
            {
                if (_userProfileCommentRespo == null)
                {
                    _userProfileCommentRespo = new Repository<Entity.UserProfileComment>(_ctx);
                }
                return _userProfileCommentRespo;
            }
        }

        public Repository<Entity.Video> VideoRespo
        {
            get
            {
                if (_videoRespo == null)
                {
                    _videoRespo = new Repository<Entity.Video>(_ctx);
                }
                return _videoRespo;
            }
        }


        public NewsVnContext(string connectionString)
        {
            this.ContextName = "NewsVn";
            this.ConnectionString = connectionString;

            this.CreateDataContext();
        }

        public void Dispose()
        {
            if (_adBoxRespo != null) this.AdBoxRespo.Dispose();
            if (_adPostRespo != null) this.AdPostRespo.Dispose();
            if (_categoryRespo != null) this.CategoryRespo.Dispose();
            if (_postRespo != null) this.PostRespo.Dispose();
            if (_postCommentRespo != null) this.PostCommentRespo.Dispose();
            if (_settingRespo != null) this.SettingRespo.Dispose();
            if (_userMessageRespo != null) this.UserMessageRespo.Dispose();
            if (_userProfileRespo != null) this.UserProfileRespo.Dispose();
            if (_userProfileCommentRespo != null) this.UserProfileCommentRespo.Dispose();
            if (_videoRespo != null) this.VideoRespo.Dispose();
        }
    }
}
