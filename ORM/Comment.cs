using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Column(TypeName = "text")]
        public string Text { get; set; }

        public virtual User User { get; set; }

        public virtual Article Article { get; set; }
    }
}
