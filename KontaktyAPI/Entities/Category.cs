using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KontaktyAPI.Entities
{
    public class Category                                   // Used to create Category Table with Entity Framework
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public int ContactId { get; set; }
    
    }
}
