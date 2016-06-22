using System;
using System.ComponentModel.DataAnnotations;


namespace MvcPL.Models
{
    public class SimpleTagViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}