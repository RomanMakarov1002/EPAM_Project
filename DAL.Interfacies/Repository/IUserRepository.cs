using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetUserByEmail(string email);
        DalUser GetUserByNickname(string nickname);
    }
}