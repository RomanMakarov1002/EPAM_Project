using System;
using System.Collections.Generic;

namespace BLL.Interfacies.Entities.FullModel
{
    public class FullArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public string TitleImage { get; set; }
        public UserEntity User { get; set; }
        public IEnumerable<TagEntity> Tags { get; set; }
        public BlogEntity Blog { get; set; } 
        public IEnumerable<FullCommentEntity> Comments { get; set; } 
    }
}
