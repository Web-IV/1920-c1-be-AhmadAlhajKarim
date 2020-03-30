﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostApi.DTO
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Location { set; get; }
    }
}

