using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class FullCommentViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string Text { get; set; }
        public SimpleUserViewModel User { get; set; }
        public int ArticleId { get; set; }
    }
}