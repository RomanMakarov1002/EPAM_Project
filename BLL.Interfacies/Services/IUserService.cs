using System.Collections.Generic;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;

namespace BLL.Interfacies.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(FullUserEntity user);
        FullUserEntity GetFullUserEntity(UserEntity e);
        void CreateFullUser(FullUserEntity fullUser);
        UserEntity GetUserByEmail(string email);
        UserEntity GetUserByNickname(string nickname);
        void UpdateUserRoles(FullUserEntity user);
        void UpdateUser(UserEntity user);
        //etc.
    }
}