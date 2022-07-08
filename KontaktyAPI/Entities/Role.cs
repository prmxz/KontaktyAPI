using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Entities
{
    public class Role               // Used to create Role Table with Entity Framework
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
