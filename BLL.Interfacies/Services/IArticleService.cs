using System.Collections.Generic;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;

namespace BLL.Interfacies.Services
{
    public interface IArticleService
    {
        ArticleEntity GetArticleEntity(int id);
        IEnumerable<ArticleEntity> GetAllArticleEntities();
        void CreateArticle(ArticleEntity e);
        void DeleteArticle (FullArticleEntity fullArticle);
        FullArticleEntity GetFullArticleEntity(ArticleEntity e);
        void CreateFullArticleEntity(FullArticleEntity fullArticle);
        ArticleEntity GetArticleEntityByName(string name);
        IEnumerable<ArticleEntity> GetArticlesByTag(int id);
        IEnumerable<ArticleEntity> FindByText(string filter);
        IEnumerable<string> SearchText(string filter);
        IEnumerable<ArticleEntity> GetAllByBlog (int blogId);
        void UpdateTags(int articleId, int[] tagsId);
        void UpdateSimpleArticle(ArticleEntity article);
    }
}
