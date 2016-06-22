using System.Collections.Generic;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Entities.FullModel;

namespace BLL.Interfacies.Services
{
    public interface ICommentService
    {
        FullCommentEntity GetCommentEntity(int id);
        IEnumerable<FullCommentEntity> GetAllCommentEntities();
        void CreateCommentEntity(CommentEntity comment);
        void DeleteCommentEntity(FullCommentEntity comment);
        void CreateCommentEntity(FullCommentEntity comment);
        void UpdateCommentEntity(FullCommentEntity comment);
    }
}
