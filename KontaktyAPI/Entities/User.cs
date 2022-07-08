using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Entities
{
    public class User                   // Used to create User Table with Entity Framework
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
