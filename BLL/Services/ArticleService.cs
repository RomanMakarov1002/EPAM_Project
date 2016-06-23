using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork uow;

        public ArticleService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateArticle(ArticleEntity e)
        {
            uow.ArticleRepository.Create(e.ToDalArticle());
            uow.Commit();
        }

        public void CreateFullArticleEntity(FullArticleEntity fullArticle)
        {
            if (fullArticle == null)
                return;
            var article = new ArticleEntity()
            {
                Id = fullArticle.Id,
                Title = fullArticle.Title,
                CreationTime = fullArticle.CreationTime,
                Text = fullArticle.Text,
                TitleImage = fullArticle.TitleImage,
                UserId = fullArticle.User.Id,
                BlogId = fullArticle.Blog.Id
            };
            uow.ArticleRepository.Create(article.ToDalArticle());

            var articleTag =
                fullArticle.Tags.Select(x => new ArticleTagEntity() { ArticleId = fullArticle.Id, TagId = x.Id }.ToDalArticleTag());

            foreach (var item in articleTag)
            {
                uow.ArticleTagRepository.Create(item);
            }
            uow.Commit();
        }

        //delete article with all comments
        public void DeleteArticle(FullArticleEntity fullArticle)
        {
            uow.ArticleRepository.Delete(fullArticle.ToDalArticle());
            uow.ArticleTagRepository.DeleteAllByArticle(fullArticle.Id);
            uow.CommentRepository.DeleteAllByArticle(fullArticle.Id);
            uow.Commit();
        }

        public IEnumerable<ArticleEntity> FindByText(string filter)
        {
            return uow.ArticleRepository.FindByText(filter).Select(x => x.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> GetAllArticleEntities()
        {
            return uow.ArticleRepository.GetAll().Select(x => x.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> GetAllByBlog(int blogId)
        {
            return uow.ArticleRepository.GetAllByBlog(blogId)?.Select(x => x.ToBllArticle());
        }

        public ArticleEntity GetArticleEntity(int id)
        {
            return uow.ArticleRepository.GetById(id)?.ToBllArticle();
        }

        public ArticleEntity GetArticleEntityByName(string name)
        {
            return uow.ArticleRepository.GetByName(name)?.ToBllArticle();
        }

        public IEnumerable<ArticleEntity> GetArticlesByTag(int id)
        {
            return uow.ArticleRepository.GetAllByTag(id).Select(x => x.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> GetArticlesForPage(int skipCount, int takeCount, ref int totalSize)
        {
            return uow.ArticleRepository.GetForPage(skipCount, takeCount, ref totalSize).Select(x => x.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> GetForPageByBlog(int blogId, int skipCount, int takeCount, ref int totalSize)
        {
            return
                uow.ArticleRepository.GetForPageByBlog(blogId, skipCount, takeCount, ref totalSize)
                    .Select(x => x.ToBllArticle());
        }

        public IEnumerable<ArticleEntity> GetForPageByTag(int tagId, int skipCount, int takeCount, ref int totalSize)
        {
            return
                uow.ArticleRepository.GetForPageByTag(tagId, skipCount, takeCount, ref totalSize)
                    .Select(x => x.ToBllArticle());
        }

        public FullArticleEntity GetFullArticleEntity(ArticleEntity e)
        {
            if (e == null)
                return null;
            var result = new FullArticleEntity()
            {
                Id = e.Id,
                Title = e.Title,
                CreationTime = e.CreationTime,
                Text = e.Text,
                User = uow.UserRepository.GetById(e.UserId)?.ToBllUser(),
                TitleImage = e.TitleImage,
                Blog = uow.BlogRepository.GetById(e.BlogId)?.ToBllBlog(),
                Tags = uow.ArticleTagRepository.GetAll().Where(tag => tag.ArticleId == e.Id).Select(x => uow.TagRepository.GetById(x.TagId)?.ToBllTag()),
                Comments = uow.CommentRepository.GetAll().Where(comment => comment.ArticleId == e.Id).Select(x => x.ToFullCommentEntity())
            };
            return result;
        }

        public IEnumerable<string> SearchText(string filter)
        {
            return uow.ArticleRepository.SearchText(filter).Where(x => !String.IsNullOrWhiteSpace(x)).Distinct();
        }

        public void UpdateSimpleArticle(ArticleEntity article)
        {
            uow.ArticleRepository.Update(article?.ToDalArticle());
            uow.Commit();
        }

        public void UpdateTags(int articleId, int[] tagsId)
        {
            if (tagsId != null && articleId != 0)
            {
                uow.ArticleTagRepository.DeleteAllByArticle(articleId);             
                for (int i = 0; i < tagsId.Length; i++)
                {
                    uow.ArticleTagRepository.Create(new DalArticleTag() {ArticleId = articleId, TagId = tagsId[i]});
                }
                uow.Commit();
            }
        }
    }
}
