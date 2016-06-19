using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly EntityModel _context;

        public CommentRepository(EntityModel uow)
        {
            _context = uow;
        }

        public void Create(DalComment e)
        {
            _context.Comments.Add(e.ToOrmComment());
        }

        public void Delete(DalComment e)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == e.Id);
            if (comment != null)
                _context.Comments.Remove(comment);
        }

        public void DeleteAllByArticle(int articleId)
        {
            var comments = _context.Comments.ToList().Where(x => x.ArticleId == articleId);
            foreach (var item in comments)
            {
                _context.Comments.Remove(item);
            }
        }

        public IEnumerable<DalComment> GetAll()
        {
            var comments = _context.Comments.ToList().Select(x => new DalComment()
            {
                Id = x.Id,
                DateTime = x.DateTime,
                Text = x.Text,
                UserId = x.UserId,
                User = _context.Users.FirstOrDefault(t => t.Id == x.UserId)?.ToDalUser(),
                ArticleId = x.ArticleId
            });
            return comments;
        }

        public DalComment GetById(int key)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == key)?.ToDalComment();
            if (comment != null)
                comment.User = _context.Users.FirstOrDefault(x => x.Id == comment.UserId)?.ToDalUser();
            return comment;
        }

        public DalComment GetByPredicate(Expression<Func<DalComment, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalComment entity)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == entity.Id);
            if (comment != null)
            {
                comment.Text = entity.Text;
            }
        }
    }
}
