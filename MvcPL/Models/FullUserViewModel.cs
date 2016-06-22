using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class FullUserViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Surname { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string NickName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime JoinTime { get; set; }
        public string Captcha { get; set; }
        public string AvatarPath { get; set; }
        public IEnumerable<SimpleRoleViewModel> Roles { get; set; }
    }
}