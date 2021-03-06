using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KontaktyAPI.Entities
{
    /// <summary>
    /// // Used to create Contact Table with Entity Framework
    /// </summary>
    public class Contact                        
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
