using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;

namespace BLL.Interfacies.Services
{
    public interface ITagService
    {
        TagEntity GetTagEntity(int id);
        IEnumerable<TagEntity> GetAllTagEntities();
        void CreateTag(TagEntity e);
        void DeleteTag(TagEntity e);
        void UpdateTag(TagEntity e);
        FullTagEntity GetFullTagEntity(TagEntity e);
        IEnumerable<TagEntity> FindTags(string filter);
        IEnumerable<string> SearchTags(string filter);
    }
}
