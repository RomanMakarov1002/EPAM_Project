using System;
using System.Data.Entity;
using System.Diagnostics;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityModel Context;

        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private UserRoleRepository _userRoleRepository;
        private ArticleRepository _articleRepository;
        private TagRepository _tagRepository;
        private ArticleTagRepository _articleTagRepository;
        private CommentRepository _commentRepository;
        private BlogRepository _blogRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(Context);
                return _userRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(Context);
                return _roleRepository;
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(Context);
                return _userRoleRepository;
            }
        }

        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                    _articleRepository = new ArticleRepository(Context);
                return _articleRepository;
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(Context);
                return _tagRepository;
            }
        }

        public IArticleTagRepository ArticleTagRepository
        {
            get
            {
                if (_articleTagRepository == null)
                    _articleTagRepository = new ArticleTagRepository(Context);
                return _articleTagRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(Context);
                return _commentRepository;
            }
        }

        public IBlogRepository BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                    _blogRepository = new BlogRepository(Context);
                return _blogRepository;
            }
        }

        public UnitOfWork(EntityModel context)
        {
            this.Context = context;
        }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}