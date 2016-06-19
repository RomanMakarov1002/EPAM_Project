using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
