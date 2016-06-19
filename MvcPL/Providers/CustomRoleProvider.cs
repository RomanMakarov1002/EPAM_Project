using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interfacies.Services;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IRoleService _roleService
            => (IRoleService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IRoleService));
        private IUserService _userService
            => (IUserService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string nickname)
        {
            var id = _userService.GetUserByNickname(nickname)?.Id;
            if (id > 0)
            {
                return _roleService.GetRolesForUser(id.Value).Select(x => x.Name).ToArray();
            }
            return null;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}