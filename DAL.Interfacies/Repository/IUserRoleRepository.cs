using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRoleRepository 
    {
        IEnumerable<DalUserRole> GetAll();
        DalUserRole GetById(int key, int key2);
        void Create(DalUserRole e);
        void Delete(DalUserRole e);
        void Update(DalUserRole entity);
        void DeleteAllByUserId(int id);
    }
}
