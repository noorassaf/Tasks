﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionSystem.Core.Models
{
    public class RegisterModel
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Password { get; set; }
    }
}
