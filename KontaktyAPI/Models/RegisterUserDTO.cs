using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    public class RegisterUserDTO                        //Data Transfer Object(DTO) for registering new user with default RoleId provided
    {   
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; } = 1;
        public string PhoneNumber { get; set; }
    }
}
