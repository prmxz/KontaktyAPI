using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    public class RegisterUserDTO
    {   
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
        public string PhoneNumber { get; set; }
    }
}
