﻿using System;
using System.Collections;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime JoinTime { get; set; }
        public string AvatarPath { get; set; }
    }
}