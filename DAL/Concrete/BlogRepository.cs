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
    public class BlogRepository : IBlogRepository
    {
        private readonly EntityModel _context;

        public BlogRepository(EntityModel context)
        {
            this._context = context;
        }

        public void Create(DalBlog e)
        {
            _context.Blogs.Add(e.ToOrmBlog());
        }

        public void Delete(DalBlog e)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == e.Id);
            if (blog != null)
                _context.Blogs.Remove(blog);
        }

        public IEnumerable<DalBlog> GetAll()
        {
            return _context.Blogs.ToList().Select(x => x.ToDalBlog());
        }

        public IEnumerable<DalBlog> GetAllByUser(int userId)
        {
            return _context.Blogs.ToList().Where(x => x.UserId == userId).Select(x => x.ToDalBlog());
        }

        public DalBlog GetById(int key)
        {
            return _context.Blogs.FirstOrDefault(x => x.Id == key)?.ToDalBlog();
        }

        public DalBlog GetByName(string name)
        {
            return _context.Blogs.FirstOrDefault(x => x.Name == name)?.ToDalBlog();
        }

        public DalBlog GetByPredicate(Expression<Func<DalBlog, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalBlog entity)
        {
            var blog = _context.Blogs.FirstOrDefault(e => e.Id == entity.Id);
            if (blog != null)
            {
                blog.Name = entity.Name;
            }
        }
    }
}
