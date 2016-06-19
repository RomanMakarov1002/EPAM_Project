using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalAuthorization : IEntity
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
