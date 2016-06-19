using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserEntity GetUserEntity(int id)
        {
            return uow.UserRepository.GetById(id)?.ToBllUser();
        }
        
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return uow.UserRepository.GetAll().Select(user => user.ToBllUser());
        }

        public FullUserEntity GetFullUserEntity (UserEntity e)
        {
            if (e == null)
                return null;
            var result = new FullUserEntity
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                NickName = e.NickName,
                Password = e.Password,
                Email = e.Email,
                JoinTime = e.JoinTime,
                AvatarPath = e.AvatarPath,
                Roles = uow.UserRoleRepository.GetAll().Where(role => role.UserId== e.Id).Select(x => uow.RoleRepository.GetById(x.RoleId)?.ToBllRole())
            };
            return result;
        }

        public void CreateFullUser(FullUserEntity fullUser)
        {
            if (fullUser == null)
                return;
            var user = new UserEntity
            {
                Id = fullUser.Id,
                Name = fullUser.Name,
                Surname = fullUser.Surname,
                NickName = fullUser.NickName,
                Password = fullUser.Password,
                Email = fullUser.Email,
                JoinTime = fullUser.JoinTime,
                AvatarPath = fullUser.AvatarPath
            };
            uow.UserRepository.Create(user.ToDalUser());
            var roles =
                fullUser.Roles.Select(x => new UserRoleEntity {UserId = fullUser.Id, RoleId = x.Id}.ToDalUserRole());
            foreach (var item in roles)
            {
                uow.UserRoleRepository.Create(item);
            }
            uow.Commit();
        }

        public void CreateUser(UserEntity user)
        {
            uow.UserRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(FullUserEntity user)
        {
            uow.UserRepository.Delete(user.ToDalUser());
            //
            uow.Commit();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return uow.UserRepository.GetUserByEmail(email)?.ToBllUser();
        }

        public UserEntity GetUserByNickname(string nickname)
        {
            return uow.UserRepository.GetUserByNickname(nickname)?.ToBllUser();
        }

        public void UpdateUserRoles(FullUserEntity user)
        {
            uow.UserRoleRepository.DeleteAllByUserId(user.Id);
            foreach (var item in user.Roles)
            {
                uow.UserRoleRepository.Create(new DalUserRole() {UserId = user.Id, RoleId = item.Id});
            }
            uow.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            uow.UserRepository.Update(user.ToDalUser());
            uow.Commit();
        }
    }
}
