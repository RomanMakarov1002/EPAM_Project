using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.DALMappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly EntityModel _context;

        public UserRoleRepository(EntityModel uow)
        {
            this._context = uow;
        }

        public void Create(DalUserRole e)
        {
            _context.UserRoles.Add(e.ToOrmUserRole());
        }

        public void Delete(DalUserRole e)
        {
            _context.UserRoles.Remove(e.ToOrmUserRole());
        }

        public void DeleteAllByUserId(int id)
        {
            _context.UserRoles.RemoveRange(_context.UserRoles.Where(x => x.UserId == id));
        }

        public IEnumerable<DalUserRole> GetAll()
        {
            return _context.UserRoles.ToList().Select(e => e.ToDalUserRole());
        }

        public DalUserRole GetById(int key, int key2)
        {
            return _context.UserRoles.FirstOrDefault(x => x.UserId==key && x.RoleId==key2).ToDalUserRole();
        }

        public DalUserRole GetByPredicate(Expression<Func<DalUserRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
