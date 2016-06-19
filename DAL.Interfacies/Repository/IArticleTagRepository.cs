using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IArticleTagRepository
    {
        IEnumerable<DalArticleTag> GetAll();
        DalArticleTag GetById(int key, int key2);
        void Create(DalArticleTag e);
        void Delete(DalArticleTag e);
        void Update(DalArticleTag e);
        void DeleteAllByArticle(int articleId);
    }
}
