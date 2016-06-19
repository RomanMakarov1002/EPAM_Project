using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Blog
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Article> Articles { get; set; } 
    }
}
