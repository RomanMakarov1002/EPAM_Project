using System;
using System.Collections.Generic;


namespace BLL.Interfacies.Entities.FullModel
{
    public class FullUserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime JoinTime { get; set; }
        public string AvatarPath { get; set; }

        public IEnumerable<RoleEntity> Roles { get; set; } 
    }
}
