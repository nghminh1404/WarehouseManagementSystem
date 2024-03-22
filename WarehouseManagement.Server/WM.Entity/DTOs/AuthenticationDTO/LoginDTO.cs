using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.AuthenticationDTO
{
    public class LoginDTO
    {
        public string? Usercode { get; set; }
     //   [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
