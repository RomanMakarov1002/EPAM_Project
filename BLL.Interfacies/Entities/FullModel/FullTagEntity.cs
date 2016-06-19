using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities.FullModel
{
    public class FullTagEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ArticleEntity> Articles { get; set; } 
    }
}
