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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork uow;

        public CommentService(IUnitOfWork uow)
        {
            this.uow = uow;           
        }

        public void CreateCommentEntity(FullCommentEntity comment)
        {
            uow.CommentRepository.Create(comment.ToDalComment());
            uow.Commit();
        }

        public void CreateCommentEntity(CommentEntity comment)
        {
            uow.CommentRepository.Create(comment.ToDalComment());
            uow.Commit();
        }

        public void DeleteCommentEntity(FullCommentEntity comment)
        {
            uow.CommentRepository.Delete(comment.ToDalComment());
            uow.Commit();
        }
        

        public IEnumerable<FullCommentEntity> GetAllCommentEntities()
        {
            return uow.CommentRepository.GetAll()?.Select(x => x.ToFullCommentEntity());
        }

        public FullCommentEntity GetCommentEntity(int id)
        {
            return uow.CommentRepository.GetById(id)?.ToFullCommentEntity();
        }

        public void UpdateCommentEntity(FullCommentEntity comment)
        {
            uow.CommentRepository.Update(comment.ToDalComment());
            uow.Commit();
        }
    }
}
