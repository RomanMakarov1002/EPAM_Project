using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IArticleRepository :IRepository<DalArticle>
    {
        DalArticle GetByName(string name);
        IEnumerable<DalArticle> GetAllByTag(int id);
        IEnumerable<DalArticle> FindByText(string filter);
        IEnumerable<string> SearchText(string filter);
        IEnumerable<DalArticle> GetAllByBlog(int id);
    }
}
