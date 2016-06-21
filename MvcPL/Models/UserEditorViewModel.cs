using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UserEditorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string NickName { get; set; }
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        [StringLength(50, MinimumLength = 6)]
        public string NewPassword { get; set; }
        [StringLength(50, MinimumLength = 6)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
        public string AvatarPath { get; set; }
    }
}