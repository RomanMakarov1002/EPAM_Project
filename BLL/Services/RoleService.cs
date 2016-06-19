using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;

        public RoleService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreateRole(RoleEntity role)
        {
            uow.RoleRepository.Create(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            uow.RoleRepository.Delete(role.ToDalRole());
            uow.Commit();
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return uow.RoleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public FullRoleEntity GetFullRoleEntity(RoleEntity e)
        {
            return new FullRoleEntity
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Users = uow.UserRoleRepository.GetAll().Select(x => uow.UserRepository.GetById(x.UserId).ToBllUser())
            };
        }

        public RoleEntity GetRoleEntity(int id)
        {
            return uow.RoleRepository.GetById(id).ToBllRole();
        }

        public IEnumerable<RoleEntity> GetRolesForUser(int userId)
        {
            return uow.RoleRepository.GetRolesForUser(userId).Select(x => x.ToBllRole());
        }
    }
}
