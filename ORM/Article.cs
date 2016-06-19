using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Article
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public string TitleImage { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<ArticleTag> ArticleTag { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } 
    }
}
