using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IBlogRepository :IRepository<DalBlog>
    {
        DalBlog GetByName(string name);
        IEnumerable<DalBlog> GetAllByUser(int userId);
    }
}
