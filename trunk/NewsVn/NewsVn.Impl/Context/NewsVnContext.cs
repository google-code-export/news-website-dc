using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vietstream.Data.Domain;

namespace NewsVn.Impl.Context
{
    public class NewsVnContext : DbContext, IDisposable
    {
        private Repository<Entity.AdBox> _adBoxRepo;
        private Repository<Entity.AdPost> _adPostRepo;
        private Repository<Entity.Category> _categoryRepo;
        private Repository<Entity.Post> _postRepo;
        private Repository<Entity.PostComment> _postCommentRepo;
        private Repository<Entity.Setting> _settingRepo;
        private Repository<Entity.UserMessage> _userMessageRepo;
        private Repository<Entity.UserProfile> _userProfileRepo;
        private Repository<Entity.UserProfileComment> _userProfileCommentRepo;
        private Repository<Entity.Video> _videoRepo;

        public Repository<Entity.AdBox> AdBoxRepo
        {
            get
            {
                if (_adBoxRepo == null)
                {
                    _adBoxRepo = new Repository<Entity.AdBox>(_ctx);
                }
                return _adBoxRepo;
            }
        }

        public Repository<Entity.AdPost> AdPostRepo
        {
            get
            {
                if (_adPostRepo == null)
                {
                    _adPostRepo = new Repository<Entity.AdPost>(_ctx);
                }
                return _adPostRepo;
            }
        }

        public Repository<Entity.Category> CategoryRepo
        {
            get
            {
                if (_categoryRepo == null)
                {
                    _categoryRepo = new Repository<Entity.Category>(_ctx);
                }
                return _categoryRepo;
            }
        }

        public Repository<Entity.Post> PostRepo
        {
            get
            {
                if (_postRepo == null)
                {
                    _postRepo = new Repository<Entity.Post>(_ctx);
                }
                return _postRepo;
            }
        }

        public Repository<Entity.PostComment> PostCommentRepo
        {
            get
            {
                if (_postCommentRepo == null)
                {
                    _postCommentRepo = new Repository<Entity.PostComment>(_ctx);
                }
                return _postCommentRepo;
            }
        }

        public Repository<Entity.Setting> SettingRepo
        {
            get
            {
                if (_settingRepo == null)
                {
                    _settingRepo = new Repository<Entity.Setting>(_ctx);
                }
                return _settingRepo;
            }
        }

        public Repository<Entity.UserMessage> UserMessageRepo
        {
            get
            {
                if (_userMessageRepo == null)
                {
                    _userMessageRepo = new Repository<Entity.UserMessage>(_ctx);
                }
                return _userMessageRepo;
            }
        }

        public Repository<Entity.UserProfile> UserProfileRepo
        {
            get
            {
                if (_userProfileRepo == null)
                {
                    _userProfileRepo = new Repository<Entity.UserProfile>(_ctx);
                }
                return _userProfileRepo;
            }
        }

        public Repository<Entity.UserProfileComment> UserProfileCommentRepo
        {
            get
            {
                if (_userProfileCommentRepo == null)
                {
                    _userProfileCommentRepo = new Repository<Entity.UserProfileComment>(_ctx);
                }
                return _userProfileCommentRepo;
            }
        }

        public Repository<Entity.Video> VideoRepo
        {
            get
            {
                if (_videoRepo == null)
                {
                    _videoRepo = new Repository<Entity.Video>(_ctx);
                }
                return _videoRepo;
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
            if (_adBoxRepo != null) this.AdBoxRepo.Dispose();
            if (_adPostRepo != null) this.AdPostRepo.Dispose();
            if (_categoryRepo != null) this.CategoryRepo.Dispose();
            if (_postRepo != null) this.PostRepo.Dispose();
            if (_postCommentRepo != null) this.PostCommentRepo.Dispose();
            if (_settingRepo != null) this.SettingRepo.Dispose();
            if (_userMessageRepo != null) this.UserMessageRepo.Dispose();
            if (_userProfileRepo != null) this.UserProfileRepo.Dispose();
            if (_userProfileCommentRepo != null) this.UserProfileCommentRepo.Dispose();
            if (_videoRepo != null) this.VideoRepo.Dispose();
        }
    }
}
