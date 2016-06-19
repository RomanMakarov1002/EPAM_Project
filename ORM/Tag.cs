using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Tag
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ArticleTag> ArticleTag { get; set; } 
    }
}
