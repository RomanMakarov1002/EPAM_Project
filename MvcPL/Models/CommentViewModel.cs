using System;


namespace MvcPL.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}