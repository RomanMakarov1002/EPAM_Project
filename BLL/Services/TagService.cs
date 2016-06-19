using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;
using BLL.Interfacies.Services;
using BLL.Mappers;
using DAL.Interfacies.Repository;

namespace BLL.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork uow;

        public TagService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void CreateTag(TagEntity e)
        {
            uow.TagRepository.Create(e.ToDalTag());
            uow.Commit();
        }

        public void DeleteTag(TagEntity e)
        {
            uow.TagRepository.Delete(e.ToDalTag());
            uow.Commit();
        }

        public IEnumerable<TagEntity> FindTags(string filter)
        {
            return uow.TagRepository.FindTags(filter).Select(x => x.ToBllTag());
        }

        public IEnumerable<TagEntity> GetAllTagEntities()
        {
            return uow.TagRepository.GetAll().Select(x => x.ToBllTag());
        }

        public FullTagEntity GetFullTagEntity(TagEntity e)
        {
            var result = new FullTagEntity()
            {
                Id = e.Id,
                Name = e.Name,
                Articles = uow.ArticleTagRepository.GetAll().Where(tag => tag.TagId == e.Id).Select(x => uow.ArticleRepository.GetById(x.ArticleId)?.ToBllArticle())
            };
            return result;
        }

        public TagEntity GetTagEntity(int id)
        {
            return uow.TagRepository.GetById(id)?.ToBllTag();
        }

        public IEnumerable<string> SearchTags(string filter)
        {
            return uow.TagRepository.SearchTags(filter);
        }

        public void UpdateTag(TagEntity e)
        {
            uow.TagRepository.Update(e.ToDalTag());
            uow.Commit();
        }
    }
}
