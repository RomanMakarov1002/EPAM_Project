using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DALMappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class ArticleTagRepository : IArticleTagRepository
    {
        private readonly EntityModel _context;

        public ArticleTagRepository(EntityModel context)
        {
            this._context = context;
        }
        public void Create(DalArticleTag e)
        {
            _context.ArticleTags.Add(e.ToOrmArticleTag());
        }

        public void Delete(DalArticleTag e)
        {
            _context.ArticleTags.Remove(e.ToOrmArticleTag());
        }

        public void DeleteAllByArticle(int articleId)
        {
            _context.ArticleTags.Where(x => x.ArticleId == articleId).ToList().ForEach(x => _context.ArticleTags.Remove(x));
        }

        public IEnumerable<DalArticleTag> GetAll()
        {
            return _context.ArticleTags.ToList().Select(x => x.ToDalArticleTag());
        }

        public DalArticleTag GetById(int key, int key2)
        {
            return _context.ArticleTags.FirstOrDefault(x => x.ArticleId == key && x.TagId == key2).ToDalArticleTag();
        }

        public void Update(DalArticleTag e)
        {
            throw new NotImplementedException();
        }
    }
}
