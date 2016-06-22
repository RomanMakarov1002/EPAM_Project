using System;


namespace BLL.Interfacies.Entities.FullModel
{
    public class FullCommentEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public UserEntity User { get; set; }
        public int ArticleId { get; set; }          // article id only;
    }
}
