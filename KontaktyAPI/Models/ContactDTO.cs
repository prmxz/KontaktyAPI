using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    /// <summary>
    /// //Data Transfer Object(DTO) for projecting Contacts table content
    /// </summary>
    public class ContactDTO            
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public string Category { get; set; }
    }
}
