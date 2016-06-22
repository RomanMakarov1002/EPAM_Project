using System;
using System.Collections.Generic;

namespace BLL.Interfacies.Entities.FullModel
{
    public class FullBlogEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserEntity User { get; set; }
        public IEnumerable<FullArticleEntity> Articles { get; set; } 
    }
}
