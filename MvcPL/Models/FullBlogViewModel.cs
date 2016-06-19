using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class FullBlogViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public SimpleUserViewModel User { get; set; }
        public IEnumerable<FullArticleViewModel> Articles { get; set; }
    }
}