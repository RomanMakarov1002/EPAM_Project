using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Infrastructure;

namespace MvcPL.Models
{
    public class PagingViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public Paging Paging { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}