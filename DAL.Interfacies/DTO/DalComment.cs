using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalComment : IEntity
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public DalUser User { get; set; }

        public int ArticleId { get; set; }
    }
}
