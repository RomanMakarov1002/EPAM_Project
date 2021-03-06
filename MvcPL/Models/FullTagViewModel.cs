﻿using System;
using System.Collections.Generic;


namespace MvcPL.Models
{
    public class FullTagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SimpleArticleViewModel> Articles { get; set; } 
    }
}