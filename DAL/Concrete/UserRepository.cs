using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DAL.DALMappers;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly EntityModel _context;

        public UserRepository(EntityModel uow)
        {
            this._context = uow;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Users.ToList().Select(user => user.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            return _context.Users.FirstOrDefault(user => user.Id == key)?.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            //Expression<Func<DalUser, bool>> -> Expression<Func<User, bool>> (!)
            throw new NotImplementedException();
        }

        public void Create(DalUser e)
        {
            _context.Users.Add(e.ToOrmUser());
        }

        public void Delete(DalUser e)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == e.Id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public void Update(DalUser entity)
        {
            var user = _context.Users.FirstOrDefault(e => e.Id == entity.Id);
            if (user != null)
            {
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.Password = entity.Password;
                user.Email = entity.Email;
                user.AvatarPath = entity.AvatarPath;
            }
        }

        public DalUser GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email)?.ToDalUser();
        }

        public DalUser GetUserByNickname(string nickname)
        {
            return _context.Users.FirstOrDefault(x => x.NickName == nickname)?.ToDalUser();
        }
    }
}