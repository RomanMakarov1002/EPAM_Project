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
    public class RoleRepository : IRoleRepository
    {
        private readonly EntityModel _context;

        public RoleRepository(EntityModel uow)
        {
            this._context = uow;
        }
        public void Create(DalRole e)
        {
            _context.Roles.Add(e.ToOrmRole());
        }

        public void Delete(DalRole e)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == e.Id);
            if (role != null)
                _context.Roles.Remove(role);
        }

        public IEnumerable<DalRole> GetAll()
        {
            return _context.Roles.ToList().Select(roles => roles.ToDalRole());
        }

        public DalRole GetById(int key)
        {
            return _context.Roles.FirstOrDefault(role => role.Id == key).ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetRolesForUser(int userId)
        {
            return
                _context.UserRoles.ToList()
                    .Where(x => x.UserId == userId)
                    .Select(x => _context.Roles.FirstOrDefault(role => role.Id == x.RoleId)?.ToDalRole());
        }

        public void Update(DalRole entity)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == entity.Id);
            if (role != null)
            {
                role.Name = entity.Name;
                role.Description = entity.Description;
            }
        }
    }
}
