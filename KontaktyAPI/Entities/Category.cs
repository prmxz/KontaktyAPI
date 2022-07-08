using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KontaktyAPI.Entities
{
    /// <summary>
    /// // Used to create Category Table with Entity Framework
    /// </summary>
    public class Category                                   
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public int ContactId { get; set; }
    
    }
}
