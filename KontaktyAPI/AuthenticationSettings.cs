using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI
{
    /// <summary>
    /// //Class holding configuration of Jwt Token
    /// </summary>
    public class AuthenticationSettings             
    {
        public string JwtKey { get; set; }
        public int JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
