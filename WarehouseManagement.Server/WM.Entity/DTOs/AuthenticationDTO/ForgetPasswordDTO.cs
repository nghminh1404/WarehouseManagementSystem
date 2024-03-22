using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.AuthenticationDTO
{
    public class ForgetPasswordDTO
    {
        public int? UserId { get; set; }
        public string Password { get; set; }
        public string? OldPassword { get; set; }
    }
}
