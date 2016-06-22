using System;
using System.ComponentModel.DataAnnotations;


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