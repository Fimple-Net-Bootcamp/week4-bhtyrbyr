﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPaws.Application.DTOs.UserDTOs
{
    public class UserUpdateDTO
    {
        public string NewName { get; set; }
        public string NewSurname { get; set; }
        public string NewPassword { get; set; }
    }
}
