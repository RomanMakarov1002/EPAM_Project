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
    public class TagRepository : ITagRepository
    {
        private readonly EntityModel _context;

        public TagRepository(EntityModel context)
        {
            this._context = context;
        }

        public void Create(DalTag e)
        {
            _context.Tags.Add(e.ToOrmTag());
        }

        public void Delete(DalTag e)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == e.Id);
            if (tag != null)
                _context.Tags.Remove(tag);
        }

        public IEnumerable<DalTag> FindTags(string filter)
        {
            return _context.Tags.ToList().Where(x => x.Name.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.ToDalTag());
        }

        public IEnumerable<DalTag> GetAll()
        {
            return _context.Tags.ToList().Select(x => x.ToDalTag());
        }

        public DalTag GetById(int key)
        {
            return _context.Tags.FirstOrDefault(x => x.Id == key)?.ToDalTag();
        }

        public DalTag GetByPredicate(Expression<Func<DalTag, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> SearchTags(string filter)
        {
            return
                _context.Tags.ToList()
                    .Where(x => x.Name.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase))
                    .Select(x => x.Name);
        }

        public void Update(DalTag entity)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == entity.Id);
            if (tag != null)
            {
                tag.Name = entity.Name;
            }
        }
    }
}
