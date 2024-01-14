﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Domain.Entities.User
{
    public class RoleUser
    {
        public int UserId { get; set; }
        public User User { get; set; }



        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}