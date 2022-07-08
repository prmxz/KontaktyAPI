using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    public class CategoryDTO                                //Data Transfer Object(DTO) for projecting "Category" table's content
    {
        public int Id { get; set; }
        public string Role { get; set; }

    }
}
