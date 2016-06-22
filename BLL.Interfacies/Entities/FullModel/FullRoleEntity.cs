using System.Collections.Generic;


namespace BLL.Interfacies.Entities.FullModel
{
    public class FullRoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<UserEntity> Users { get; set; } 
    }
}
