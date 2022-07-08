using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    /// <summary>
    /// //Data Transfer Object(DTO) for projecting "Category" table's content
    /// </summary>
    public class CategoryDTO                                
    {
        public int Id { get; set; }
        public string Role { get; set; }

    }
}
