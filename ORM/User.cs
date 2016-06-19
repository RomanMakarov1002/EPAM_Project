using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{
    public partial class User
    {
        [Required]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime JoinTime { get; set; }
        public string AvatarPath { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
         
    }
}
