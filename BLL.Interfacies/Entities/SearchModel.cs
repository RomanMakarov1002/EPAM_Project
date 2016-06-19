using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class SearchModel
    {
        public IEnumerable<TagEntity> Tags { get; set; }
        public IEnumerable<ArticleEntity> Articles { get; set; } 
    }
}
