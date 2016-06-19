using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class SimpleArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        [Required]
        public string Text { get; set; }
        public string TitleImage { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
    }
}