using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface ITagRepository : IRepository<DalTag>
    {
        IEnumerable<DalTag> FindTags(string filter);
        IEnumerable<string> SearchTags(string filter);
    }
}
