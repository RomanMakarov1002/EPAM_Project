using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ArticleTag
    {
        [Key, Column(Order = 0)]
        public int ArticleId { get; set; }
        [Key, Column (Order = 1)]
        public int TagId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
