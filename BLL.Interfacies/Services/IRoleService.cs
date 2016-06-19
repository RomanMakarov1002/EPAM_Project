using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;

namespace BLL.Interfacies.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntity(int id);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
        FullRoleEntity GetFullRoleEntity(RoleEntity e);
        IEnumerable<RoleEntity> GetRolesForUser(int userId);
    }
}
