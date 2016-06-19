using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DALMappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly EntityModel _context;

        public ArticleRepository(EntityModel context)
        {
            this._context = context;
        }

        public void Create(DalArticle e)
        {
            _context.Articles.Add(e.ToOrmArticle());
        }

        public void Delete(DalArticle e)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Id == e.Id);
            if (article != null)
                _context.Articles.Remove(article);
        }

        public IEnumerable<DalArticle> FindByText(string filter)
        {
            filter = filter.ToUpperInvariant();
            var result = _context.Articles.ToList().Where(x => x.Text.ToUpperInvariant().Contains(filter))
                .Select(x => x.ToDalArticle()).ToList();
            return result;
            //return _context.Articles.ToList().Where(x => x.Text.Contains(filter)).Select(x => x.ToDalArticle());
        }

        public IEnumerable<DalArticle> GetAll()
        {
            return _context.Articles.ToList().Select(x => x.ToDalArticle()).OrderByDescending(x => x.CreationTime);
        }

        public IEnumerable<DalArticle> GetAllByBlog(int id)
        {
            return _context.Articles.ToList().Where(x => x.BlogId == id).Select(e => e.ToDalArticle()).OrderByDescending(x => x.CreationTime);
        }

        public IEnumerable<DalArticle> GetAllByTag(int id)
        {
            var tags = _context.ArticleTags.ToList().Where(x => x.TagId == id);
            return tags.Select(x => _context.Articles.Find(x.ArticleId).ToDalArticle()).OrderByDescending(x => x.CreationTime);
        }

        public DalArticle GetById(int key)
        {
            return _context.Articles.FirstOrDefault(x => x.Id == key)?.ToDalArticle();
        }

        public DalArticle GetByName(string name)
        {
            return _context.Articles.FirstOrDefault(x => x.Title == name)?.ToDalArticle();
        }

        public DalArticle GetByPredicate(Expression<Func<DalArticle, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> SearchText(string filter)
        {
            filter = filter.ToUpperInvariant();
            var res = filter.Split(' ', '.', '!', '?', ',');
            //var result = _context.Articles.ToList().Where(x => x.Text.ToUpperInvariant().Contains(filter))
            //    .Select(x => x.Text.Split(' ', '.', '!', '?'))
            //    .Select(x => x.FirstOrDefault(e => e.ToUpperInvariant().StartsWith(res[res.Length - 1])));
            var result = _context.Articles.ToList().Where(x => x.Text.ToUpperInvariant().Contains(filter))
                .Select(x => x.Text.Split(' ', '.', '!', '?', ',')).ToList();
            IEnumerable<string> query;
            if (res.Length > 1)
            {
                query = result.Select(x => x.SkipWhile(e => e.ToUpperInvariant() != res[res.Length-2]).Skip(1))
                .Select(x => x.FirstOrDefault(e => e.ToUpperInvariant().StartsWith(res[res.Length - 1])));
            }
            else
            {
                query = result.Select(x => x.FirstOrDefault(e => e.ToUpperInvariant().StartsWith(res[res.Length - 1])));
            }
            string[] resStr = new string[res.Length-1];
            Array.Copy(res, resStr, res.Length-1);
            if (res.Length >1)
                for (int i = 0; i < resStr.Length; i++)
                    resStr[i] += ' ';
            var str = String.Concat(resStr).ToLowerInvariant();
            return query.Select(x => str + x.ToLowerInvariant());

            //filter = filter.ToUpperInvariant();
            //return
            //    _context.Articles.ToList()
            //        .Select(x => x.Text.Split(new char[] {' ', '.', '!', '?'}))
            //        .Select(x => x.FirstOrDefault(e => e.ToUpperInvariant().Contains(filter)));
        }

        public void Update(DalArticle entity)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Id == entity.Id);
            if (article != null)
            {
                article.Title = entity.Title;
                article.Text = entity.Text;
                article.TitleImage = entity.TitleImage;
            }
        }
    }
}
