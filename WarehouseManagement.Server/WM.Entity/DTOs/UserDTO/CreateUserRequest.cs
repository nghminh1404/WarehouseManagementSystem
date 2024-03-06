﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.UserDTO
{
    public class CreateUserRequest
    {
      
        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public string? Phone { get; set; }

        public int RoleId { get; set; }

        public int StatusId { get; set; }

        public string? UserName { get; set; }

        public int StorageId { get; set; }

        public string? UserCode { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }

        public string? FullName { get; set; }
    }
}
