using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _uow;

        public BlogService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public void CreateBlog(FullBlogEntity entity)
        {
            _uow.BlogRepository.Create(entity.ToDalBlog());
            _uow.Commit();
        }

        public void DeleteBlog(FullBlogEntity entity)
        {
            foreach (var article in entity.Articles)
            {
                _uow.CommentRepository.DeleteAllByArticle(article.Id);
                _uow.ArticleRepository.Delete(article.ToDalArticle());
                _uow.ArticleTagRepository.DeleteAllByArticle(article.Id);
            }
            _uow.BlogRepository.Delete(entity.ToDalBlog());
            _uow.Commit();
        }

        public IEnumerable<BlogEntity> GetAllByUser(int userId)
        {
            return _uow.BlogRepository.GetAllByUser(userId).Select(x => x.ToBllBlog());
        }

        public IEnumerable<BlogEntity> GetAllSimpleBlogs()
        {
            return _uow.BlogRepository.GetAll().Select(x => x.ToBllBlog());
        }

        public FullBlogEntity GetBlogById(int id)
        {
            var simpleblog = _uow.BlogRepository.GetById(id);
            if (simpleblog != null)
            {
                var fullBlog = new FullBlogEntity()
                {
                    Id = simpleblog.Id,
                    Name = simpleblog.Name,
                    User = _uow.UserRepository.GetById(simpleblog.UserId).ToBllUser(),
                };
                return fullBlog;
            }
            return null;
        }

        public FullBlogEntity GetBlogByName(string name)
        {
            var simpleblog = _uow.BlogRepository.GetByName(name);
            if (simpleblog != null)
            {
                var fullBlog = new FullBlogEntity()
                {
                    Id = simpleblog.Id,
                    Name = simpleblog.Name,
                    User = _uow.UserRepository.GetById(simpleblog.UserId).ToBllUser(),
                };
                return fullBlog;
            }
            return null;
        }

        public BlogEntity GetSimpleBlogById(int id)
        {
            return _uow.BlogRepository.GetById(id)?.ToBllBlog();
        }

        public void UpdateBlog(FullBlogEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
