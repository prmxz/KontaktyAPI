using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    public class LoginDTO                   //Data Transfer Object(DTO) for login credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
