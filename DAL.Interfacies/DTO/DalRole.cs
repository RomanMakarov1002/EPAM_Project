using System.Collections;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
