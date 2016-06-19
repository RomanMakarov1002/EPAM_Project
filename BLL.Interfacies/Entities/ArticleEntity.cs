using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfacies.Entities
{
    public class ArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public string TitleImage { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
    }
}
